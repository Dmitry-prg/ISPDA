using ispda.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ispda.Classes.Entities
{
    public class Projects
    {
        public static DataTable dtProjects = new DataTable();
        public static DataTable dtProjectsForComboBox = new DataTable();
        public static DataTable dtProjectsbyUser = new DataTable();
        public static string searchSql = "true";
		public static string filterSql1 = "true";
        public static string filterSql2 = "true";
		public static string dateStart;
		public static string dateEnd;

        public static void GetList()
        {
			try
			{
				Connection.command.CommandText = $@"
SELECT 	 
		projects.project_number, 
		projects.project_name, 
		projects.project_short_name, 
        projects.developer_id,
        projects.initiative_request_id,
        customer.organization_id as customer_id,
        customer.short_name as customer_full_name,
        developer.short_name as developer_full_name,
		projects.product_name, 
		projects.product_name_genitive, 
		projects.product_name_prepositional, 
		projects.product_short_name, 
		projects.start_date, 
		projects.end_date, 
		projects.actual_start_date, 
		projects.actual_end_date, 
		projects.url, 
		projects.ip, 
		projects.admin_panel_url, 
		if(projects.is_gis, 'Да', 'Нет') as is_gis,
		if(projects.is_pnd, 'Да', 'Нет') as is_pnd,
		if(projects.is_internal, 'Да', 'Нет') as is_internal,
		projects.notes,
        statuses.status_name,
        projects.status_id,
		projects.project_id
FROM projects
LEFT JOIN statuses ON statuses.status_id = projects.status_id
LEFT JOIN organizations developer ON developer.organization_id = projects.developer_id
LEFT JOIN initiative_requests ON initiative_requests.initiative_request_id = projects.initiative_request_id
LEFT JOIN organizations customer ON customer.organization_id = initiative_requests.customer_id
WHERE ({filterSql1}) AND ({filterSql2}) AND ({searchSql}) AND (projects.start_date BETWEEN '{dateStart}' AND '{dateEnd}')
ORDER BY projects.project_id";
				dtProjects.Clear();
				Connection.adapter.Fill(dtProjects);
			}
			catch { }
		}

        public static void GetListForComboBox()
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT 	projects.project_id,
		CONCAT(projects.project_number, ' | ', if(projects.project_short_name = null, projects.project_name, projects.project_short_name)) as name
FROM projects ORDER BY projects.project_id";
                dtProjectsForComboBox.Clear();
                Connection.adapter.Fill(dtProjectsForComboBox);
            }
            catch { }
        }

        public static void GetListByUser(string userId)
        {
			try
			{
				Connection.command.CommandText = $@"
SELECT 	projects.project_number,
		projects.project_short_name
FROM project_teams 
LEFT JOIN projects ON projects.project_id = project_teams.proejct_id 
WHERE (project_teams.user_id = '{userId}' AND projects.status_id = 9)";
                dtProjectsbyUser.Clear();
                Connection.adapter.Fill(dtProjectsbyUser);
			}
			catch { }
		}

        public static bool CheckDel(string id)
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT project_id FROM roadmap_items WHERE project_id = '{id}';";
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

        public static bool CheckDuplicateNumber(string number)
		{
			try
			{
				Connection.command.CommandText = $@"
SELECT project_number FROM projects WHERE project_number = '{number}';";
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

		public static bool Add(string status, string number, string projectName, string projectShortName, string initiativeRequestId, string developer, string productName, string productNameGenitive, string productNamePrepositional, string productShortName, string startDate, string endDate, string url, string ip, string adminPanelUrl, bool isGis, bool isPnd, bool isInternal, string notes)
		{
			try
			{
				Connection.command.CommandText = $@"
INSERT INTO projects VALUES(null, '{status}', '{number}', '{projectName}', '{projectShortName}', '{initiativeRequestId}', '{developer}', '{productName}', '{productNameGenitive}', '{productNamePrepositional}', '{productShortName}', '{startDate}', '{endDate}', null, null, '{url}', '{ip}', '{adminPanelUrl}', '{Convert.ToInt16(isGis)}', '{Convert.ToInt16(isPnd)}', '{Convert.ToInt16(isInternal)}', '{notes}', '1');";
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

        public static bool Update(string id, string status, string number, string projectName, string projectShortName, string initiativeRequestId, string developer, string productName, string productNameGenitive, string productNamePrepositional, string productShortName, string startDate, string endDate, string url, string ip, string adminPanelUrl, bool isGis, bool isPnd, bool isInternal, string notes)
        {
			try
			{
				Connection.command.CommandText = $@"
Update projects 
SET status_id = '{status}', 
	project_number = '{number}', 
	project_name = '{projectName}', 
	project_short_name = '{projectShortName}', 
	initiative_request_id = '{initiativeRequestId}', 
	developer_id = '{developer}', 
	product_name = '{productName}', 
	product_name_genitive = '{productNameGenitive}', 
	product_name_prepositional = '{productNamePrepositional}', 
	product_short_name = '{productShortName}', 
	start_date = '{startDate}', 
	end_date = '{endDate}', 
	url = '{url}', 
	ip = '{ip}', 
	admin_panel_url = '{adminPanelUrl}', 
	is_gis = '{Convert.ToInt16(isGis)}', 
	is_pnd = '{Convert.ToInt16(isPnd)}', 
	is_internal = '{Convert.ToInt16(isInternal)}', 
	notes = '{notes}'
WHERE project_id = '{id}';";
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
        public static bool UpdateStatus(string id, string status)
        {
            try
            {
                Connection.command.CommandText = $@"
Update projects 
SET status_id = {status}
WHERE project_id = '{id}';";
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
        public static bool UpdateActualStart(string id, string startDate)
        {
            try
            {
                Connection.command.CommandText = $@"
Update projects 
SET actual_start_date = '{startDate}' 
WHERE project_id = '{id}';";
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
        public static bool UpdateActualEnd(string id, string endDate)
        {
            try
            {
                Connection.command.CommandText = $@"
Update projects 
SET actual_end_date = '{endDate}' 
WHERE project_id = '{id}';";
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
DELETE FROM projects WHERE project_id = '{id}';";
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
