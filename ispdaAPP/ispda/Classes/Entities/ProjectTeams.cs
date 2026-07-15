using ispda.Entities;
using ispda.Forms.Projects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ispda.Classes.Entities
{
    internal class ProjectTeams
    {
        public static DataTable dtList = new DataTable();

        public static void GetList(string projectId)
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT 	project_teams.project_team_id, 
		project_teams.proejct_id, 
        project_teams.user_id, 
		CONCAT(users.last_name, ' ', users.first_name, ' ', users.patronymic) as fio, 
        project_teams.role_in_project
FROM project_teams
LEFT JOIN users ON users.user_id = project_teams.user_id
WHERE project_teams.proejct_id = '{projectId}'";
                dtList.Clear();
                Connection.adapter.Fill(dtList);
            }
            catch (Exception ex) { Mes.Error(ex.Message); }
        }

        public static bool CheckDuplicate(string userId)
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT  project_teams.user_id
FROM project_teams
WHERE project_teams.proejct_id = '{RoadMapForProject.id}' AND project_teams.user_id = '{userId}';";
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


        public static bool Add(string userId, string roleInProject)
        {
            try
            {
                Connection.command.CommandText = $@"
INSERT INTO project_teams VALUES(null, '{RoadMapForProject.id}', '{userId}', '{roleInProject}');";
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

        public static bool Update(string projectTeamId, string userId, string roleInProject)
        {
            try
            {
                Connection.command.CommandText = $@"
UPDATE project_teams
SET	proejct_id = '{RoadMapForProject.id}', 
    user_id = '{userId}', 
    role_in_project = '{roleInProject}'
WHERE project_team_id = '{projectTeamId}';";

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
        public static bool Del(string projectTeamId)
        {
            try
            {
                Connection.command.CommandText = $@"
DELETE FROM project_teams
WHERE project_team_id = '{projectTeamId}';";

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
