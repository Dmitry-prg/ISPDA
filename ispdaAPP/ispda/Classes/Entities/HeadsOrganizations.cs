using ispda.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ispda.Classes.Entities
{
    internal class HeadsOrganizations
    {
        public static DataTable dtList = new DataTable();
        public static DataTable dtListByCustomer = new DataTable();
        public static string filter = "heads_organizations.period_validity_start <= CURRENT_DATE() AND heads_organizations.period_validity_end >= CURRENT_DATE()";
        public static string filterOrg = "true";

        public static void GetList()
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT 	heads_organizations.head_organization_id, 
		heads_organizations.fio_head, 
        heads_organizations.fio_head_genitive, 
        heads_organizations.fio_head_dative, 
        heads_organizations.short_fio_head, 
        heads_organizations.short_fio_head_reverse, 
        heads_organizations.organization_id, 
        organizations.full_name,
        heads_organizations.position_id, 
        positions.position_name,
        heads_organizations.position_genitive, 
        heads_organizations.acts_on_the_basis_of, 
        heads_organizations.period_validity_start, 
        heads_organizations.period_validity_end
FROM heads_organizations
LEFT JOIN organizations ON organizations.organization_id = heads_organizations.organization_id
LEFT JOIN positions ON positions.position_id = heads_organizations.position_id
WHERE ({filter}) AND ({filterOrg}) ";
                dtList.Clear();
                Connection.adapter.Fill(dtList);
            }
            catch {}
        }

        public static bool Add(string fioHead, string fioHeadGenitive, string fioHeadDative, string shortFioHead, string organizationId, string positionId, string positionGenitive, string actsOnTheBasisOf, string periodValidityStart, string periodValidityEnd)
        {
            try
            {
                string shortFioHeadReverse = shortFioHead.Split(' ')[1] + " " + shortFioHead.Split(' ')[0];
                Connection.command.CommandText = $@"
INSERT INTO heads_organizations VALUES(null, '{fioHead}', '{fioHeadGenitive}', '{fioHeadDative}', '{shortFioHead}', '{shortFioHeadReverse}', {organizationId}, {positionId}, '{positionGenitive}', '{actsOnTheBasisOf}', '{periodValidityStart}', '{periodValidityEnd}');";
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

        public static bool Update(string id, string fioHead, string fioHeadGenitive, string fioHeadDative, string shortFioHead, string organizationId, string positionId, string positionGenitive, string actsOnTheBasisOf, string periodValidityStart, string periodValidityEnd)
        {
            try
            {
                string shortFioHeadReverse = shortFioHead.Split(' ')[1] + " " + shortFioHead.Split(' ')[0];
                Connection.command.CommandText = $@"
UPDATE heads_organizations 
SET fio_head = '{fioHead}', 
    fio_head_genitive = '{fioHeadGenitive}', 
    fio_head_dative = '{fioHeadDative}', 
    short_fio_head = '{shortFioHead}', 
    short_fio_head_reverse = '{shortFioHeadReverse}', 
    organization_id = {organizationId}, 
    position_id = {positionId}, 
    position_genitive = '{positionGenitive}', 
    acts_on_the_basis_of = '{actsOnTheBasisOf}', 
    period_validity_start = '{periodValidityStart}', 
    period_validity_end = '{periodValidityEnd}'
WHERE head_organization_id = '{id}';";
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
DELETE FROM heads_organizations WHERE head_organization_id = '{id}';";
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
