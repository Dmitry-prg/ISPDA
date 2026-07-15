using ispda.Entities;
using ispda.Forms.Reference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ispda.Classes.Entities
{
    internal class Organizations
    {

        public static DataTable dtList = new DataTable();
        public static DataTable dtListForComboBox = new DataTable();


        public static void GetList()
        {
            try
            {
                Connection.command.CommandText = $@"SELECT organization_id, stakeholder_type_id, full_name, short_name, ogrn, inn, kpp, legal_address, phone, email, if(is_active, 'Да', 'Нет') as is_active FROM organizations WHERE ({ViewReferenceForm.search}) ORDER BY full_name";
                dtList.Clear();
                Connection.adapter.Fill(dtList);
            }
            catch { }
        }

        public static void GetListForComboBox()
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT organization_id,  
	if(short_name is not null, short_name, full_name) as name
FROM organizations WHERE is_active = '1' ORDER BY name";
                dtListForComboBox.Clear();
                Connection.adapter.Fill(dtListForComboBox);
            }
            catch { }
        }


        public static bool Add(string name, string shortName, string stakeholderId, string ogrn, string inn, string kpp, string legalAddress, string phone, string email, bool isActive)
        {
            try
            {
                Connection.command.CommandText = $@"
INSERT INTO organizations VALUES(null, '{stakeholderId}', '{name}', '{shortName}', '{ogrn}', '{inn}', '{kpp}', '{legalAddress}', '{phone}', '{email}', '{Convert.ToInt16(isActive)}');";
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

        public static bool Update(string id, string name, string shortName, string stakeholderId, string ogrn, string inn, string kpp, string legalAddress, string phone, string email, bool isActive)
        {
            try
            {
                Connection.command.CommandText = $@"
UPDATE organizations 
SET full_name = '{name}',
    stakeholder_type_id = '{stakeholderId}',
    short_name = '{shortName}',
    ogrn = '{ogrn}',
    inn = '{inn}',
    kpp = '{kpp}',
    legal_address = '{legalAddress}',
    phone = '{phone}',
    email = '{email}',    
    is_active = '{Convert.ToInt16(isActive)}'
WHERE organization_id = '{id}';";
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
DELETE FROM organizations WHERE organization_id = '{id}';";
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


        public static bool CheckDuplicate(string name, string inn, string email)
        {
            try
            {
                Connection.command.CommandText = $@"
SELECT full_name FROM organizations WHERE full_name = '{name}' or inn = '{inn}' or email = '{email}';";
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












    }
}
