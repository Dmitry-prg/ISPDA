using ispda.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ispda.Classes.Entities
{
    internal class InitiativeRequests
    {

        public static DataTable dtList = new DataTable();
        public static DataTable dtListByCustomer = new DataTable();
        public static string filter = "true";

        public static void GetList()
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT 
initiative_requests.initiative_request_id, 
initiative_requests.decision_id, 
decisions.decision_name,
initiative_requests.customer_id, 
organizations.short_name,
initiative_requests.initiative_request_details, 
initiative_requests.created_at,
initiative_requests.approved_at
FROM initiative_requests
LEFT JOIN organizations ON organizations.organization_id = initiative_requests.customer_id
LEFT JOIN decisions ON decisions.decision_id = initiative_requests.decision_id
WHERE ({filter})
ORDER BY initiative_requests.created_at DESC";
                dtList.Clear();
                Connection.adapter.Fill(dtList);
            }
            catch (Exception ex) { Mes.Error(ex.Message); }
        }

        public static void GetListByCustomer(string customerId)
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT 	initiative_requests.initiative_request_id, 
        CONCAT('№', initiative_requests.initiative_request_id, ' от ', DATE_FORMAT(initiative_requests.created_at, '%d.%m.%Y'), ' | ', initiative_requests.initiative_request_details) as date_and_details
FROM initiative_requests
LEFT JOIN organizations ON organizations.organization_id = initiative_requests.customer_id
LEFT JOIN decisions ON decisions.decision_id = initiative_requests.decision_id
WHERE initiative_requests.customer_id = '{customerId}' AND initiative_requests.decision_id = '2'
ORDER BY initiative_requests.initiative_request_id;";
                dtListByCustomer.Clear();
                Connection.adapter.Fill(dtListByCustomer);
            }
            catch (Exception ex) { Mes.Error(ex.Message); }
        }

        public static bool Add(string customerId, string decisionId, string details, string date)
        {
            try
            {
                Connection.command.CommandText = $@"
INSERT INTO initiative_requests VALUES(null, '{decisionId}', '{customerId}', '{details}', '{date}', null);";
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

        public static bool Update(string id, string customerId, string decisionId, string details, string date, string dateApproved)
        {
            try
            {
                
                Connection.command.CommandText = $@"
UPDATE initiative_requests 
SET decision_id = '{decisionId}', 
    customer_id = '{customerId}', 
    initiative_request_details = '{details}',
    created_at = '{date}',
    approved_at = '{dateApproved}'
WHERE initiative_request_id = '{id}';";
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
DELETE FROM initiative_requests WHERE initiative_request_id = '{id}';";
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
