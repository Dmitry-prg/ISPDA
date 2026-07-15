using ispda.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using GanttChart;
using ispda.Forms.Projects;
using System.Data;

namespace ispda.Classes.Entities
{
    internal class RoadMapItems
    {
        public static DataTable dtItems = new DataTable();

        public static GanttChart.Chart GetList(string id, DateTime startProject, DateTime endProject)
        {
            Connection.command.CommandText = $@"
SELECT 	roadmap_items.roadmap_item_id,
		roadmap_items.project_id, 
        roadmap_items.stage_id, 
        project_stages.stage_name,
        roadmap_items.planned_start, 
        roadmap_items.planned_end, 
        roadmap_items.turn,
        roadmap_items.actual_start, 
        roadmap_items.actual_end, 
        roadmap_items.notes
FROM roadmap_items 
LEFT JOIN project_stages ON project_stages.stage_id = roadmap_items.stage_id
LEFT JOIN projects ON projects.project_id = roadmap_items.project_id
WHERE roadmap_items.project_id = '{id}'
ORDER BY roadmap_items.turn;";

            GanttChart.Chart ganttChart = new GanttChart.Chart();
            ganttChart.ScaleMode = Enums.TimescaleMode.MonthsDays;
            ganttChart.StartDate = startProject;
            endProject = endProject.AddDays(2);
            ganttChart.EndDate = endProject;
            ganttChart.DefaultDayLabelFormat = "dd.MM"; 
            ganttChart.MinTimeIntervalWidth = 20;
            ganttChart.RecaculateFormatDictionaries(overwrite: false);
            ganttChart.Dock = DockStyle.Fill;

            var reader = Connection.command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader["stage_name"].ToString();
                string plannedStartDate = reader["planned_start"].ToString();
                string plannedEndDate = reader["planned_end"].ToString();

                string actualStartDate = reader["actual_start"].ToString();
                string actualEndDate = reader["actual_end"].ToString();

                string itemId = reader["roadmap_item_id"].ToString();
                string stageId = reader["stage_id"].ToString();
                string notes = reader["notes"].ToString();
                string turn = reader["turn"].ToString();

                Row rowPlanned = new Row(name + "(план.)") { Color = Color.LightBlue, notes = notes, id = itemId, type = stageId, turn = turn};
                TimeBlock planedStage = new TimeBlock();
                Row rowActual = new Row(name + "(факт.)") { Color = Color.LightGreen, notes = notes, id = itemId, type = stageId, turn = turn};
                TimeBlock actualStage = new TimeBlock();
                if (plannedStartDate != string.Empty && plannedEndDate != string.Empty)
                {
                    planedStage = new TimeBlock(name, Convert.ToDateTime(plannedStartDate), Convert.ToDateTime(plannedEndDate)) { Color = Color.LightBlue, id = itemId, type = stageId, turn = turn };
                    rowPlanned.TimeBlocks.Add(planedStage);
                }
                if (actualStartDate != string.Empty && actualEndDate != string.Empty)
                {
                    actualStage = new TimeBlock(name, Convert.ToDateTime(actualStartDate), Convert.ToDateTime(actualEndDate)) { Color = Color.LightGreen, id = itemId, type = stageId, turn = turn};
                    rowActual.TimeBlocks.Add(actualStage);
                }
                ganttChart.Rows.Add(rowPlanned);
                ganttChart.Rows.Add(rowActual);
            }
            ganttChart.HorizontalGridLinesVisible = true;
            ganttChart.VerticalGridLinesVisible = false;
            ganttChart.BackgroundColor = ColorTranslator.FromHtml("#E5F8FE");

            ganttChart.UpdateView();
            reader.Close();
            return ganttChart;
        }

        public static void GetListForComboBox(string projectId)
        {
            Connection.command.CommandText = $@"
SELECT 	roadmap_items.roadmap_item_id,
        project_stages.stage_name
FROM roadmap_items 
LEFT JOIN project_stages ON project_stages.stage_id = roadmap_items.stage_id
WHERE roadmap_items.project_id = '{projectId}'
ORDER BY roadmap_items.turn;";
            dtItems.Clear();
            Connection.adapter.Fill(dtItems);

        }

        public static bool CheckDuplicate(string stageId)
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT stage_id FROM roadmap_items WHERE project_id = '{RoadMapForProject.id}' AND stage_id = '{stageId}';";
                if (Connection.command.ExecuteScalar() == null)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static (string, string) GetDateTurnLimit(string turn, string projectId, bool actual)
        {
            try
            {
                string  minDate = "", maxDate = "";
                if (actual)
                {
                    Connection.command.CommandText = $@"
SELECT
(SELECT actual_end FROM roadmap_items 
WHERE turn < '{turn}' and project_id = '{projectId}'
ORDER BY turn DESC LIMIT 1) as lastStageEnd, 
IF((SELECT actual_start  FROM roadmap_items 
WHERE turn > '{turn}' and project_id = '{projectId}'
ORDER BY turn LIMIT 1) = null, 'null', (SELECT actual_start  FROM roadmap_items 
WHERE turn > '{turn}' and project_id = '{projectId}'
ORDER BY turn LIMIT 1)) as nextStageStart";
                }
                else
                {
                    Connection.command.CommandText = $@"
SELECT
(SELECT planned_end FROM roadmap_items 
WHERE turn < '{turn}' and project_id = '{projectId}'
ORDER BY turn DESC LIMIT 1) as lastStageEnd, 
IF((SELECT planned_start  FROM roadmap_items 
WHERE turn > '{turn}' and project_id = '{projectId}'
ORDER BY turn LIMIT 1) = null, 'null', (SELECT planned_start  FROM roadmap_items 
WHERE turn > '{turn}' and project_id = '{projectId}'
ORDER BY turn LIMIT 1)) as nextStageStart";
                }
                    
                var reader = Connection.command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        minDate = reader["lastStageEnd"].ToString();
                        maxDate = reader["nextStageStart"].ToString();
                    }
                }
                reader.Close();
                return (minDate, maxDate);
            }
            catch
            {
                return ("", "");
            }
        }

        public static string GetTurnForProject()
        {
            try
            {
                Connection.command.CommandText = $@"SELECT coalesce(MAX(turn), 0)+1 FROM roadmap_items WHERE project_id = '{RoadMapForProject.id}';";
                if(Connection.command.ExecuteScalar() != null)
                    return Connection.command.ExecuteScalar().ToString();
                else
                    return "";
            }
            catch
            {
                return "";
            }
        }

        public static bool Add(string stageId, string plannedStart, string plannedEnd, string notes)
        {
            try
            {
                string turn = GetTurnForProject();
                if (turn == "") 
                { 
                    turn = "1";
                    Projects.UpdateStatus(RoadMapForProject.id, "9");
                }
                Connection.command.CommandText = $@"
INSERT INTO roadmap_items VALUES(null, '{RoadMapForProject.id}', '{stageId}', '{turn}', '{plannedStart}', '{plannedEnd}', null, null, '{notes}');";
                if (Connection.command.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool Update(string id, string stageId, string plannedStart, string plannedEnd, string actualStart, string actualEnd, string notes)
        {
            try
            {
                Connection.command.CommandText = $@"
UPDATE roadmap_items 
SET stage_id = '{stageId}',
    planned_start = '{plannedStart}', 
    planned_end = '{plannedEnd}',
    actual_start = '{actualStart}',
    actual_end = '{actualEnd}',
    notes = '{notes}'
WHERE roadmap_item_id = '{id}';";
                if (Connection.command.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool SetDatePlanned(string id, string start, string end)
        {
            try
            {

                if (start == null || end == null)
                {
                    Connection.command.CommandText = $@"
UPDATE roadmap_items 
SET planned_start = null,
    planned_end = null
WHERE roadmap_item_id = '{id}';";
                }
                else
                {
                    Connection.command.CommandText = $@"
UPDATE roadmap_items 
SET planned_start = '{start}',
    planned_end = '{end}'
WHERE roadmap_item_id = '{id}';";
                }
                if (Connection.command.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool SetDateActual(string id, string start, string end)
        {
            try
            {
                if (start == null || end == null)
                {
                    Connection.command.CommandText = $@"
UPDATE roadmap_items 
SET actual_start = null,
    actual_end = null
WHERE roadmap_item_id = '{id}';";
                }
                else
                {
                    Connection.command.CommandText = $@"
UPDATE roadmap_items 
SET actual_start = '{start}',
    actual_end = '{end}'
WHERE roadmap_item_id = '{id}';";
                }
                if (Connection.command.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool Del(string id)
        {
            try
            {
                Connection.command.CommandText = $@"
DELETE FROM roadmap_items 
WHERE roadmap_item_id = '{id}';";
                if (Connection.command.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
