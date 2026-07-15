using DocumentFormat.OpenXml.Wordprocessing;
using ispda.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ispda.Classes.Entities
{
    internal class Documents
    {
        public static DataTable dtDocuments = new DataTable();
        public static string filterSql = "true";


        public static void GetList()
        {
            Connection.command.CommandText = $@"
SELECT 	documents.document_number, 
        document_types.document_type_name,
        project_stages.stage_name,
        documents.created_at,
        CONCAT(projects.project_number, ' | ', if(projects.project_short_name = null, projects.project_name, projects.project_short_name)) as project_name,
		documents.document_id, 
        documents.scan_path
FROM documents
LEFT JOIN document_types ON  document_types.document_type_id = documents.document_type_id
LEFT JOIN roadmap_items ON  roadmap_items.roadmap_item_id = documents.roadmap_item_id
LEFT JOIN project_stages ON  project_stages.stage_id = roadmap_items.stage_id
LEFT JOIN projects ON  roadmap_items.project_id = projects.project_id
WHERE {filterSql};";
            dtDocuments.Clear();
            Connection.adapter.Fill(dtDocuments);
        }

        public static bool Add(string roadmapItemId, string documentTypeId, string documentNumber, string scanPath, string createdAt)
        {
            try
            {
                Connection.command.CommandText = $@"
INSERT INTO documents 
(document_id, roadmap_item_id, document_type_id, document_number, scan_path, created_at) 
VALUES (null, '{roadmapItemId}', '{documentTypeId}', '{documentNumber}', '{scanPath}', '{createdAt}');";
                if(Connection.command.ExecuteNonQuery() > 0) 
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public static bool Del(string documentId)
        {
            try
            {
                Connection.command.CommandText = $@"
DELETE FROM documents WHERE document_id = '{documentId}';";
                if (Connection.command.ExecuteNonQuery() > 0)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }
    }
}
