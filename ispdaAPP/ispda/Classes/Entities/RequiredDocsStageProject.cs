using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ispda.Entities;
using ispda.Forms.Projects;

namespace ispda.Classes.Entities
{
    internal class RequiredDocsStageProject
    {
        public static DataTable dtReqiredDoc = new DataTable();
        public static string filter = "true";

        public static void GetList(string projectId)
        {
            Connection.command.CommandText = $@"
SELECT
    r.required_docs_stage_project_id,
    r.roadmap_item_id,
    ps.stage_name,
    r.document_type_id,
    dt.document_type_name,
    MAX(CASE WHEN d.document_type_id IS NOT NULL THEN 1 ELSE 0 END) AS complete
FROM required_docs_stage_project r
LEFT JOIN roadmap_items ri
    ON ri.roadmap_item_id = r.roadmap_item_id
LEFT JOIN documents d
    ON d.roadmap_item_id = ri.roadmap_item_id
    AND d.document_type_id = r.document_type_id          
LEFT JOIN project_stages ps
    ON ps.stage_id = ri.stage_id
LEFT JOIN document_types dt
    ON dt.document_type_id = r.document_type_id
WHERE ri.project_id = '{projectId}' AND ({filter})
GROUP BY
    r.required_docs_stage_project_id,
    r.roadmap_item_id,
    ps.stage_name,
    r.document_type_id,
    dt.document_type_name;";
            dtReqiredDoc.Clear();
            Connection.adapter.Fill(dtReqiredDoc);

        }



        public static bool Add(string itemId, string documentTypeId)
        {
            try
            {
                Connection.command.CommandText = $@"
INSERT INTO required_docs_stage_project VALUES(null, '{itemId}', '{documentTypeId}');";
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

        public static bool Update(string id, string itemId, string documentTypeId)
        {
            try
            {
                Connection.command.CommandText = $@"
UPDATE required_docs_stage_project 
SET roadmap_item_id = '{itemId}', 
    document_type_id = '{documentTypeId}'
WHERE required_docs_stage_project_id = '{id}';";
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
DELETE FROM required_docs_stage_project WHERE required_docs_stage_project_id = '{id}';";
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
