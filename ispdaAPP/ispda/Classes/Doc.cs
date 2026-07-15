using ClosedXML.Excel;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using ispda.Entities;
using ispda.Forms.Projects;
using OfficeIMO.Word;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;




namespace ispda.Classes
{
    internal class Doc
    {
        public static DataTable GetDataTableFromDataGridView(DataGridView dgv)
        {
            DataTable resultTable = new DataTable();
            Dictionary<int, string> columnIndexToNameMap = new Dictionary<int, string>();

            // 1. Получаем видимые столбцы, исключая кнопочные, и сортируем по DisplayIndex
            var visibleColumns = dgv.Columns.Cast<DataGridViewColumn>()
                .Where(col => col.Visible && !(col is DataGridViewButtonColumn))
                .OrderBy(col => col.DisplayIndex)  // <-- Вот ключевая строка!
                .ToList();

            // 2. Создаём колонки в DataTable в правильном порядке
            foreach (var column in visibleColumns)
            {
                string columnName = column.HeaderText;

                // Проверка уникальности имени
                if (resultTable.Columns.Contains(columnName))
                {
                    int counter = 1;
                    string newName;
                    do
                    {
                        newName = $"{columnName}_{counter++}";
                    } while (resultTable.Columns.Contains(newName));
                    columnName = newName;
                }

                resultTable.Columns.Add(columnName, typeof(string));
                columnIndexToNameMap[column.Index] = columnName;
            }

            // 3. Заполняем строки данными
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;
                DataRow dataRow = resultTable.NewRow();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (columnIndexToNameMap.TryGetValue(cell.ColumnIndex, out string columnName))
                    {
                        object displayValue = cell.FormattedValue;
                        string stringValue = displayValue?.ToString() ?? string.Empty;
                        dataRow[columnName] = stringValue;
                    }
                }
                resultTable.Rows.Add(dataRow);
            }

            return resultTable;
        }

        /// <summary>
        /// Формирование документа "Выгрузка данных в Excel"
        /// </summary>
        /// <param name="data"></param>
        /// <param name="filePath"></param>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public static bool CreateExcelFromDataTable(DataTable data, string filePath, string sheetName, string docName, Dictionary<string, string> filters)
        {
            try
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
                {
                    if (data.Rows.Count < 1000000)
                    {
                        if (package.Workbook.Worksheets.Contains(package.Workbook.Worksheets[$"{sheetName}"]))
                        {
                            package.Workbook.Worksheets.Delete(package.Workbook.Worksheets[$"{sheetName}"]);
                        }
                        ExcelWorksheet ws = package.Workbook.Worksheets.Add(sheetName);
                        ws.Cells["A1"].Value = docName;
                        byte c = 2;
                        if (filters.Count > 0)
                        {
                            foreach (KeyValuePair<string, string> filter in filters)
                            {
                                ws.Cells[$"A{c}"].Value = filter.Key;
                                ws.Cells[$"B{c}"].Value = filter.Value;
                                ws.Rows[c].Style.Font.Size = 12;
                                ws.Rows[c].Style.Font.Bold = true;
                                c++;
                            }
                        }
                        c++;
                        ws.Cells[$"A{c}"].LoadFromDataTable(data, true);
                        ws.Cells[ws.Dimension.Address].AutoFitColumns();

                        ExcelRange range = ws.Cells[c, 1, ws.Dimension.End.Row, ws.Dimension.End.Column];
                        foreach (var rangeCell in range)
                        {
                            rangeCell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        }
                        ws.Rows[1].Style.Font.Bold = true;
                        ws.Rows[1].Style.Font.Size = 12;
                        ws.Rows[2].Style.Font.Bold = true;
                        ws.Rows[2].Style.Font.Size = 12;
                        ws.Rows[c].Style.Font.Size = 12;
                        ws.Rows[c].Style.Font.Bold = true;
                        ws.Cells[$"A{ws.Dimension.End.Row + 2}"].Value = DateTime.Now.ToString("dd.MM.yyyy");
                        ws.Cells[ws.Dimension.End.Row, ws.Dimension.End.Column - 1].Value = "/" + Users.name;
                        ws.Cells[ws.Dimension.End.Row , ws.Dimension.End.Column - 2 ].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                        package.Save();
                    }
                    else
                    {
                        int listCount = 0;

                        for (int i = 0; i < data.Rows.Count; i += 1000000)
                        {
                            DataTable buf = data.Clone();

                            listCount++;
                            for (int j = i; j < i + 1000000 && j < data.Rows.Count; j++)
                            {
                                buf.ImportRow(data.Rows[i]);
                            }
                            if (package.Workbook.Worksheets.Contains(package.Workbook.Worksheets[$"{sheetName}"]))
                            {
                                package.Workbook.Worksheets.Delete(package.Workbook.Worksheets[$"{sheetName}"]);
                            }
                            ExcelWorksheet ws = package.Workbook.Worksheets.Add(sheetName);
                            ws.Cells["A1"].Value = docName;
                            byte c = 2;
                            if (filters.Count > 0)
                            {
                                foreach (KeyValuePair<string, string> filter in filters)
                                {
                                    ws.Cells[$"A{c}"].Value = filter.Key;
                                    ws.Cells[$"B{c}"].Value = filter.Value;
                                    ws.Rows[c].Style.Font.Size = 12;
                                    ws.Rows[c].Style.Font.Bold = true;
                                    c++;
                                }
                            }
                            c++;
                            ws.Cells[$"A{c}"].LoadFromDataTable(data, true);
                            ws.Cells[ws.Dimension.Address].AutoFitColumns();
                            

                            ExcelRange range = ws.Cells[c, 1, ws.Dimension.End.Row, ws.Dimension.End.Column];
                            foreach (var rangeCell in range)
                            {
                                rangeCell.Style.Border.BorderAround(ExcelBorderStyle.Thin);
                            }
                            ws.Rows[1].Style.Font.Bold = true;
                            ws.Rows[1].Style.Font.Size = 12;
                            ws.Rows[2].Style.Font.Bold = true;
                            ws.Rows[2].Style.Font.Size = 12;
                            ws.Rows[c].Style.Font.Size = 12;
                            ws.Rows[c].Style.Font.Bold = true;
                            ws.Cells[$"A{ws.Dimension.End.Row + 2}"].Value = DateTime.Now.ToString("dd.MM.yyyy");
                            ws.Cells[ws.Dimension.End.Row, ws.Dimension.End.Column - 1].Value = "/" + Users.name;
                            ws.Cells[ws.Dimension.End.Row, ws.Dimension.End.Column - 2].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;

                            package.Save();
                        }
                    }
                }
                //Process.Start(filePath);
                return true;

            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Читает строку из Excel через EPPlus и возвращает словарь "имя поля → значение"
        /// Первая строка считается заголовками.
        /// </summary>
        private static Dictionary<string, string> ReadExcelRow(string filePath, int rowIndex)
        {
            var result = new Dictionary<string, string>();

            FileInfo fileInfo = new FileInfo(filePath);
            if (!fileInfo.Exists)
                throw new FileNotFoundException("Excel-файл не найден", filePath);

            using (var package = new ExcelPackage(fileInfo))
            {
                var sheet = package.Workbook.Worksheets[0]; // первый лист
                if (sheet == null)
                    throw new Exception("Excel-файл не содержит листов");

                int colCount = sheet.Dimension?.Columns ?? 0;
                if (colCount == 0)
                    throw new Exception("Лист Excel пуст");

                // Читаем заголовки (строка 1)
                var headers = new string[colCount];
                for (int col = 1; col <= colCount; col++)
                    headers[col - 1] = sheet.Cells[1, col].Text.Trim();

                // Читаем данные из нужной строки
                for (int col = 1; col <= colCount; col++)
                {
                    string fieldName = headers[col - 1];
                    string value = sheet.Cells[rowIndex, col].Text;
                    result[fieldName] = value;
                }
            }
            return result;
        }

        /// <summary>
        /// Открывает шаблон Word, заполняет поля слияния данными из словаря,
        /// удаляет связь с источником и сохраняет новый документ.
        /// </summary>
        private static void GenerateSingleLetter(string templatePath, string outputPath, Dictionary<string, string> data)
        {
            Word.Application wordApp = null;
            Word.Document doc = null;
            object oMissing = System.Reflection.Missing.Value;

            try
            {
                wordApp = new Word.Application();
                wordApp.Visible = false;         
                // Создаём временную копию шаблона
                string tempTemplate = Path.Combine(Path.GetTempPath(), Guid.NewGuid() + ".docx");
                File.Copy(templatePath, tempTemplate, overwrite: true);

                wordApp = new Word.Application();
                wordApp.Visible = false;
                // Открываем шаблон
                doc = wordApp.Documents.Open(tempTemplate, ReadOnly: false, Visible: false);
                doc.Fields.Update();

                foreach (Word.Field field in doc.Fields)
                {
                    if (field.Type == Word.WdFieldType.wdFieldMergeField)
                    {
                        string fieldName = GetMergeFieldName(field.Code.Text);

                        if (data.TryGetValue(fieldName, out string newValue))
                        {  
                            field.Select();
                            field.Result.Text = newValue;
                            wordApp.Selection.TypeText(newValue);

                        }
                    }
                }

                //убираем связь с источником данных
                doc.Fields.Unlink();

                // Сохраняем как новый документ
                doc.SaveAs2(outputPath);

                object saveChanges = false;
                doc.Close(ref saveChanges);
                wordApp.Quit();
            }
            finally
            {
                // Освобождаем COM-объекты в обратном порядке
                if (doc != null)
                {
                    Marshal.ReleaseComObject(doc);
                    doc = null;
                }
                if (wordApp != null)
                {
                    Marshal.ReleaseComObject(wordApp);
                    wordApp = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();

                //KillWinWordProcess();

            }
        }
        private static void KillWinWordProcess()
        {
            foreach (var proc in Process.GetProcessesByName("WINWORD"))
            {
                try { proc.Kill(); proc.WaitForExit(5000); } catch { }
            }
        }

        /// <summary>
        /// Извлекает имя поля из строки кода поля
        /// </summary>
        private static string GetMergeFieldName(string fieldCode)
        {
            if (string.IsNullOrWhiteSpace(fieldCode))
                return string.Empty;

            string code = fieldCode.Trim();
            string prefix = "MERGEFIELD";
            int idx = code.IndexOf(prefix, StringComparison.OrdinalIgnoreCase);
            if (idx < 0) return string.Empty;

            string after = code.Substring(idx + prefix.Length).Trim();

            // Удаляем возможные переключатели, начинающиеся с "\"
            int slashPos = after.IndexOf('\\');
            if (slashPos >= 0)
                after = after.Substring(0, slashPos).Trim();

            return after;
        }

        //Инициация

        /// <summary>
        /// Формирует документ "Приказ о начале проектных работ"
        /// </summary>
        /// <param name="dateCreate"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CreateOrderBeginningProjectWork(DateTime dateCreate, string filePath)
        {
            try
            {
                //Получение данных для основы документа
                Connection.command.CommandText = $@"
SELECT 	        customer.full_name as customerName,       		  
        		position_developer.position_name as positionNameHeadDeveloper,
        		DATE_FORMAT(initiative_requests.created_at, '%d.%m.%Y') as createdAt,
                head_developer.short_fio_head_reverse as fioHeadDeveloper,
				DATE_FORMAT(projects.start_date, '%d.%m.%Y') as start,
				DATE_FORMAT(projects.end_date, '%d.%m.%Y') as end,
                projects.project_name as projectName,
                (SELECT documents.document_number 
                FROM documents 
                LEFT JOIN roadmap_items ON roadmap_items.roadmap_item_id = documents.roadmap_item_id
                WHERE documents.document_type_id = '1' AND roadmap_items.project_id = '{RoadMapForProject.id}') as docNumber,
                (SELECT DATE_FORMAT(documents.created_at, '%d.%m.%Y')
                FROM documents 
                LEFT JOIN roadmap_items ON roadmap_items.roadmap_item_id = documents.roadmap_item_id
                WHERE documents.document_type_id = '1' AND roadmap_items.project_id = '{RoadMapForProject.id}') as docDate
        FROM projects
        LEFT JOIN initiative_requests ON initiative_requests.initiative_request_id = projects.initiative_request_id
        LEFT JOIN organizations customer ON customer.organization_id = initiative_requests.customer_id
        LEFT JOIN heads_organizations head_customer ON head_customer.organization_id = customer.organization_id
        LEFT JOIN positions position_customer ON position_customer.position_id = head_customer.position_id
        LEFT JOIN organizations developer ON developer.organization_id = projects.developer_id
        LEFT JOIN heads_organizations head_developer ON head_developer.organization_id = developer.organization_id
        LEFT JOIN positions position_developer ON position_developer.position_id = head_developer.position_id
        WHERE projects.project_id = '{RoadMapForProject.id}'";
                var reader = Connection.command.ExecuteReader();

                string customerName, positionNameHeadDeveloper, fioHeadDeveloper, projectName, start, end, docNumber, docDate,  createdAt;

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        {
                            customerName = reader["customerName"].ToString();
                            positionNameHeadDeveloper = reader["positionNameHeadDeveloper"].ToString();
                            fioHeadDeveloper = reader["fioHeadDeveloper"].ToString();
                            projectName = reader["projectName"].ToString();
                            createdAt = reader["createdAt"].ToString();
                            start = reader["start"].ToString();
                            end = reader["end"].ToString();
                            docNumber = reader["docNumber"].ToString();
                            docDate = reader["docDate"].ToString();
                        }


                        string templatePathWord = Path.GetFullPath(@"./SRC/TemplatesDoc/Приказ о начале проектных работ.docx");
                        string templatePathExcel = Path.GetFullPath(@"./SRC/TemplatesDoc/Приказ о начале проектных работ.xlsx");

                        using (ExcelPackage package = new ExcelPackage(new FileInfo(templatePathExcel)))
                        {
                            ExcelWorksheet ws = package.Workbook.Worksheets[0];
                            ws.Cells["A2"].Value = dateCreate.ToString("dd MMMM yyyyг."); ;
                            ws.Cells["B2"].Value = customerName;
                            ws.Cells["C2"].Value = positionNameHeadDeveloper;
                            ws.Cells["D2"].Value = fioHeadDeveloper;
                            ws.Cells["E2"].Value = projectName;
                            ws.Cells["F2"].Value = createdAt;
                            ws.Cells["G2"].Value = start;
                            ws.Cells["H2"].Value = end;
                            ws.Cells["I2"].Value = docDate;
                            ws.Cells["J2"].Value = docNumber;
                            package.Save();
                        }

                        var fieldValues = ReadExcelRow(templatePathExcel, rowIndex: 2);
                        GenerateSingleLetter(templatePathWord, filePath, fieldValues);
                        reader.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        return false;
                    }
                }
                reader.Close();
                return false;
            }
            catch
            {
                return false;
            }
        }

        //Планирование
        /// <summary>
        /// Формирует документ "Устав проекта"
        /// </summary>
        /// <param name="dateCreate"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CreateProjectCharter(DateTime dateCreate, string filePath)
        {
            try
            {
                //Получение данных для основы документа
                Connection.command.CommandText = $@"
SELECT 	position_customer.position_name as positionNameHeadCustomer,
		customer.short_name as customerName,
        head_customer.short_fio_head_reverse as fioHeadCustomer,
        position_developer.position_name as positionNameHeadDeveloper,
        developer.short_name as developerName,
        head_developer.short_fio_head_reverse as fioHeadDeveloper,
        concat(SUBSTRING(users.first_name, 1, 1),'.',SUBSTRING(users.patronymic, 1, 1),'. ',users.last_name) as fioHeadProject,
		position_head_project.position_name as positionNameHeadProject,
        projects.project_short_name as projectShortName,
        projects.project_name as projectName,
        projects.product_name as productName,
        DATE_FORMAT(initiative_requests.created_at, '%d.%m.%Y') as createdAt
FROM projects
LEFT JOIN initiative_requests ON initiative_requests.initiative_request_id = projects.initiative_request_id
LEFT JOIN organizations customer ON customer.organization_id = initiative_requests.customer_id
LEFT JOIN heads_organizations head_customer ON head_customer.organization_id = customer.organization_id
LEFT JOIN positions position_customer ON position_customer.position_id = head_customer.position_id
LEFT JOIN organizations developer ON developer.organization_id = projects.developer_id
LEFT JOIN heads_organizations head_developer ON head_developer.organization_id = developer.organization_id
LEFT JOIN positions position_developer ON position_developer.position_id = head_developer.position_id
LEFT JOIN project_teams ON project_teams.proejct_id = projects.project_id
LEFT JOIN users ON users.user_id = project_teams.user_id
LEFT JOIN positions position_head_project ON position_head_project.position_id = users.position_id
WHERE projects.project_id = '{RoadMapForProject.id}' and (project_teams.role_in_project LIKE '%Руководитель%' or project_teams.role_in_project LIKE '%руководитель%');";
                var reader = Connection.command.ExecuteReader();

                string positionNameHeadCustomer, customerName, fioHeadCustomer, positionNameHeadDeveloper, developerName, fioHeadDeveloper, fioHeadProject, positionNameHeadProject, projectShortName, projectName, productName, createdAt;

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        {
                            positionNameHeadCustomer = reader["positionNameHeadCustomer"].ToString();
                            customerName = reader["customerName"].ToString();
                            fioHeadCustomer = reader["fioHeadCustomer"].ToString();
                            positionNameHeadDeveloper = reader["positionNameHeadDeveloper"].ToString();
                            developerName = reader["developerName"].ToString();
                            fioHeadDeveloper = reader["fioHeadDeveloper"].ToString();
                            positionNameHeadProject = reader["positionNameHeadProject"].ToString();
                            fioHeadProject = reader["fioHeadProject"].ToString();
                            projectShortName = reader["projectShortName"].ToString();
                            projectName = reader["projectName"].ToString();
                            productName = reader["productName"].ToString();
                            createdAt = reader["createdAt"].ToString();
                        }


                        string templatePathWord = Path.GetFullPath(@"./SRC/TemplatesDoc/Устав проекта.docx");
                        string templatePathExcel = Path.GetFullPath(@"./SRC/TemplatesDoc/Устав проекта.xlsx");

                        using (ExcelPackage package = new ExcelPackage(new FileInfo(templatePathExcel)))
                        {
                            ExcelWorksheet ws = package.Workbook.Worksheets[0];
                            ws.Cells["A2"].Value = positionNameHeadCustomer;
                            ws.Cells["B2"].Value = customerName;
                            ws.Cells["C2"].Value = fioHeadCustomer;
                            ws.Cells["D2"].Value = positionNameHeadDeveloper;
                            ws.Cells["E2"].Value = developerName;
                            ws.Cells["F2"].Value = fioHeadDeveloper;
                            ws.Cells["G2"].Value = positionNameHeadProject;
                            ws.Cells["H2"].Value = fioHeadProject;
                            ws.Cells["I2"].Value = projectName;
                            ws.Cells["J2"].Value = projectShortName;
                            ws.Cells["K2"].Value = productName;
                            ws.Cells["L2"].Value = createdAt;
                            package.Save();
                        }

                        var fieldValues = ReadExcelRow(templatePathExcel, rowIndex: 2);
                        GenerateSingleLetter(templatePathWord, filePath, fieldValues);
                        reader.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        return false;
                    }
                }
                reader.Close();
                return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Формирует документ "Календарный план проекта"
        /// </summary>
        /// <param name="dateCreate"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CreateCalendarPlanProject(DateTime dateCreate, string filePath)
        {
            try
            {
                DataTable dtStages = new DataTable();
                Connection.command.CommandText = $@"
SELECT 	project_stages.stage_name,
		DATE_FORMAT(roadmap_items.planned_start, '%d.%m.%Y') as planned_start,
		DATE_FORMAT(roadmap_items.planned_end, '%d.%m.%Y') as planned_end,
        roadmap_items.notes
FROM roadmap_items 
LEFT JOIN project_stages ON project_stages.stage_id = roadmap_items.stage_id
WHERE roadmap_items.project_id = '{RoadMapForProject.id}';";
                dtStages.Clear();
                Connection.adapter.Fill(dtStages);

                //Получение данных для основы документа
                Connection.command.CommandText = $@"
SELECT 	position_customer.position_name as positionNameHeadCustomer,
		customer.short_name as customerName,
        head_customer.short_fio_head_reverse as fioHeadCustomer,
        position_developer.position_name as positionNameHeadDeveloper,
        developer.short_name as developerName,
        head_developer.short_fio_head_reverse as fioHeadDeveloper,
        concat(SUBSTRING(users.first_name, 1, 1),'.',SUBSTRING(users.patronymic, 1, 1),'. ',users.last_name) as fioHeadProject,
		position_head_project.position_name as positionNameHeadProject,
        projects.project_short_name as projectShortName,
        projects.project_name as projectName,
        projects.product_name as productName,
        DATE_FORMAT(initiative_requests.created_at, '%d.%m.%Y') as createdAt
FROM projects
LEFT JOIN initiative_requests ON initiative_requests.initiative_request_id = projects.initiative_request_id
LEFT JOIN organizations customer ON customer.organization_id = initiative_requests.customer_id
LEFT JOIN heads_organizations head_customer ON head_customer.organization_id = customer.organization_id
LEFT JOIN positions position_customer ON position_customer.position_id = head_customer.position_id
LEFT JOIN organizations developer ON developer.organization_id = projects.developer_id
LEFT JOIN heads_organizations head_developer ON head_developer.organization_id = developer.organization_id
LEFT JOIN positions position_developer ON position_developer.position_id = head_developer.position_id
LEFT JOIN project_teams ON project_teams.proejct_id = projects.project_id
LEFT JOIN users ON users.user_id = project_teams.user_id
LEFT JOIN positions position_head_project ON position_head_project.position_id = users.position_id
WHERE projects.project_id = '{RoadMapForProject.id}' and (project_teams.role_in_project LIKE '%Руководитель%' or project_teams.role_in_project LIKE '%руководитель%') AND head_customer.period_validity_start <= CURRENT_DATE() AND head_customer.period_validity_end >= CURRENT_DATE() AND head_developer.period_validity_start <= CURRENT_DATE() AND head_developer.period_validity_end >= CURRENT_DATE();";
                var reader = Connection.command.ExecuteReader();

                string positionNameHeadCustomer, customerName, fioHeadCustomer, positionNameHeadDeveloper, developerName, fioHeadDeveloper, fioHeadProject, positionNameHeadProject, projectShortName, projectName, productName, createdAt;

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        {
                            positionNameHeadCustomer = reader["positionNameHeadCustomer"].ToString();
                            customerName = reader["customerName"].ToString();
                            fioHeadCustomer = reader["fioHeadCustomer"].ToString();
                            positionNameHeadDeveloper = reader["positionNameHeadDeveloper"].ToString();
                            developerName = reader["developerName"].ToString();
                            fioHeadDeveloper = reader["fioHeadDeveloper"].ToString();
                            positionNameHeadProject = reader["positionNameHeadProject"].ToString();
                            fioHeadProject = reader["fioHeadProject"].ToString();
                            projectShortName = reader["projectShortName"].ToString();
                            projectName = reader["projectName"].ToString();
                            productName = reader["productName"].ToString();
                            createdAt = reader["createdAt"].ToString();
                        }


                        string templatePathWord = Path.GetFullPath(@"./SRC/TemplatesDoc/Календарный план.docx");
                        string templatePathExcel = Path.GetFullPath(@"./SRC/TemplatesDoc/Календарный план.xlsx");

                        using (ExcelPackage package = new ExcelPackage(new FileInfo(templatePathExcel)))
                        {
                            ExcelWorksheet ws = package.Workbook.Worksheets[0];
                            ws.Cells["A2"].Value = positionNameHeadCustomer;
                            ws.Cells["B2"].Value = customerName;
                            ws.Cells["C2"].Value = fioHeadCustomer;
                            ws.Cells["D2"].Value = positionNameHeadDeveloper;
                            ws.Cells["E2"].Value = developerName;
                            ws.Cells["F2"].Value = fioHeadDeveloper;
                            ws.Cells["G2"].Value = positionNameHeadProject;
                            ws.Cells["H2"].Value = fioHeadProject;
                            ws.Cells["I2"].Value = projectName;
                            ws.Cells["J2"].Value = projectShortName;
                            ws.Cells["K2"].Value = productName;
                            ws.Cells["L2"].Value = createdAt;
                            package.Save();
                        }

                        var fieldValues = ReadExcelRow(templatePathExcel, rowIndex: 2);
                        GenerateSingleLetter(templatePathWord, filePath, fieldValues);



                        using (var document = WordDocument.Load(filePath))
                        {

                            var table = document.Tables[2];
                            int counter = 0;
                            int cellsCount = 4;
                            foreach (DataRow row in dtStages.Rows)
                            {
                                counter++;
                                table.AddRow(cellsCount);
                                var r = table.Rows[counter];
                                r.Cells[0].Paragraphs[0].SetText($@"{counter}");
                                r.Cells[1].Paragraphs[0].SetText($@"{row["stage_name"].ToString()}");
                                r.Cells[2].Paragraphs[0].SetText($@"С {row["planned_start"].ToString()} по {row["planned_end"].ToString()}");
                                r.Cells[3].Paragraphs[0].SetText($@"{row["notes"].ToString()}");
                            }
                            document.Save(filePath);





                        }
                        reader.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        return false;
                    }
                }
                reader.Close();
                return false;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Формирует документ "ТЗ"
        /// </summary>
        /// <param name="dateCreate"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CreateTechnicalSpecification(DateTime dateCreate, string filePath)
        {
            try
            {

                Connection.command.CommandText = $@"
        SELECT 	projects.project_short_name as projectShortName,
                projects.project_name as projectName,
                projects.product_name as productName,
                projects.product_short_name as shortProductName,
                customer.full_name as customerName,
                DATE_FORMAT(initiative_requests.created_at, '%d.%m.%Y') as createdAt
        FROM projects
        LEFT JOIN initiative_requests ON initiative_requests.initiative_request_id = projects.initiative_request_id
        LEFT JOIN organizations customer ON customer.organization_id = initiative_requests.customer_id
        WHERE projects.project_id = '{RoadMapForProject.id}' ";
                var reader = Connection.command.ExecuteReader();

                string projectName, projectShortName, productName, shortProductName, customerName, createdAt;

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        {
                            projectName = reader["projectName"].ToString();
                            projectShortName = reader["projectShortName"].ToString();
                            productName = reader["productName"].ToString();
                            shortProductName = reader["shortProductName"].ToString();
                            customerName = reader["customerName"].ToString();
                            createdAt = reader["createdAt"].ToString();

                        }
                        string templatePathWord = Path.GetFullPath(@"./SRC/TemplatesDoc/ТЗ.docx");
                        string templatePathExcel = Path.GetFullPath(@"./SRC/TemplatesDoc/ТЗ.xlsx");

                        using (ExcelPackage package = new ExcelPackage(new FileInfo(templatePathExcel)))
                        {
                            ExcelWorksheet ws = package.Workbook.Worksheets[0];
                            ws.Cells["A2"].Value = customerName;
                            ws.Cells["B2"].Value = projectName;
                            ws.Cells["C2"].Value = projectShortName;
                            ws.Cells["D2"].Value = productName;
                            ws.Cells["E2"].Value = shortProductName;
                            ws.Cells["F2"].Value = createdAt;
                            
                            package.Save();
                        }

                        var fieldValues = ReadExcelRow(templatePathExcel, rowIndex: 2);
                        GenerateSingleLetter(templatePathWord, filePath, fieldValues);

                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
                return false;
            }
            catch
            {
                return false;
            }
        }


        //Испытания и ввод в эксплуатацию
        /// <summary>
        /// Формирует документ "Акт приёма-передачи в опытную экплуатацию"
        /// </summary>
        /// <param name="dateCreate"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CreateActAcceptanceTransferIntoTrialOperation(DateTime dateCreate, string filePath)
        {
            try
            {


                Connection.command.CommandText = $@"
        SELECT 	projects.product_name_genitive as productName,
        		customer.short_name as customerShortName,
                customer.full_name as customerName,
        		developer.short_name as developerShortName,
        		developer.full_name as developerName,
                head_developer.position_genitive as positionNameHeadDeveloperGenitive,
                head_developer.fio_head_genitive as fioHeadDeveloperGenitive,
                head_developer.acts_on_the_basis_of as actDeveloper,
        		head_customer.position_genitive as positionNameHeadCustomerGenitive,
                head_customer.fio_head_genitive as fioHeadCustomerGenitive,
                head_customer.acts_on_the_basis_of as actCustomer,
        		DATE_FORMAT(initiative_requests.created_at, '%d.%m.%Y') as createdAt,
        		position_developer.position_name as positionNameHeadDeveloper,
                head_developer.short_fio_head_reverse as fioHeadDeveloper,
        		position_customer.position_name as positionNameHeadCustomer,
                head_customer.short_fio_head_reverse as fioHeadCustomer
        FROM projects
        LEFT JOIN initiative_requests ON initiative_requests.initiative_request_id = projects.initiative_request_id
        LEFT JOIN organizations customer ON customer.organization_id = initiative_requests.customer_id
        LEFT JOIN heads_organizations head_customer ON head_customer.organization_id = customer.organization_id
        LEFT JOIN positions position_customer ON position_customer.position_id = head_customer.position_id
        LEFT JOIN organizations developer ON developer.organization_id = projects.developer_id
        LEFT JOIN heads_organizations head_developer ON head_developer.organization_id = developer.organization_id
        LEFT JOIN positions position_developer ON position_developer.position_id = head_developer.position_id
        WHERE projects.project_id = '{RoadMapForProject.id}' AND head_customer.period_validity_start <= CURRENT_DATE() AND head_customer.period_validity_end >= CURRENT_DATE() AND head_developer.period_validity_start <= CURRENT_DATE() AND head_developer.period_validity_end >= CURRENT_DATE()";
                var reader = Connection.command.ExecuteReader();

                string productName, customerName, customerShortName, developerName, developerShortName, positionNameHeadDeveloperGenitive, fioHeadDeveloperGenitive, actDeveloper, positionNameHeadCustomerGenitive, fioHeadCustomerGenitive, actCustomer, createdAt, positionNameHeadDeveloper, fioHeadDeveloper, positionNameHeadCustomer, fioHeadCustomer;

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        {
                            productName = reader["productName"].ToString();
                            customerName = reader["customerName"].ToString();
                            customerShortName = reader["customerShortName"].ToString();
                            developerName = reader["developerName"].ToString();
                            developerShortName = reader["developerShortName"].ToString();
                            positionNameHeadDeveloperGenitive = reader["positionNameHeadDeveloperGenitive"].ToString();
                            fioHeadDeveloperGenitive = reader["fioHeadDeveloperGenitive"].ToString();
                            actDeveloper = reader["actDeveloper"].ToString();
                            positionNameHeadCustomerGenitive = reader["positionNameHeadCustomerGenitive"].ToString();
                            fioHeadCustomerGenitive = reader["fioHeadCustomerGenitive"].ToString();
                            actCustomer = reader["actCustomer"].ToString();
                            createdAt = reader["createdAt"].ToString();
                            positionNameHeadDeveloper = reader["positionNameHeadDeveloper"].ToString();
                            fioHeadDeveloper = reader["fioHeadDeveloper"].ToString();
                            positionNameHeadCustomer = reader["positionNameHeadCustomer"].ToString();
                            fioHeadCustomer = reader["fioHeadCustomer"].ToString();
                        }
                        string templatePathWord = Path.GetFullPath(@"./SRC/TemplatesDoc/Акт приема-передачи в опытную эксплуатацию.docx");
                        string templatePathExcel = Path.GetFullPath(@"./SRC/TemplatesDoc/Акт приема-передачи в опытную эксплуатацию.xlsx");


                        using (ExcelPackage package = new ExcelPackage(new FileInfo(templatePathExcel)))
                        {
                            ExcelWorksheet ws = package.Workbook.Worksheets[0];
                            ws.Cells["A2"].Value = "";
                            ws.Cells["B2"].Value = productName;
                            ws.Cells["C2"].Value = customerName;
                            ws.Cells["D2"].Value = dateCreate.ToString("dd MMMM yyyyг.");
                            ws.Cells["E2"].Value = developerName;
                            ws.Cells["F2"].Value = positionNameHeadDeveloperGenitive;
                            ws.Cells["G2"].Value = fioHeadDeveloperGenitive;
                            ws.Cells["H2"].Value = actDeveloper;
                            ws.Cells["I2"].Value = positionNameHeadCustomerGenitive;
                            ws.Cells["J2"].Value = fioHeadCustomerGenitive;
                            ws.Cells["K2"].Value = actCustomer;
                            ws.Cells["L2"].Value = createdAt;
                            ws.Cells["M2"].Value = positionNameHeadDeveloper;
                            ws.Cells["N2"].Value = developerShortName;
                            ws.Cells["O2"].Value = fioHeadDeveloper;
                            ws.Cells["P2"].Value = positionNameHeadCustomer;
                            ws.Cells["Q2"].Value = customerShortName;
                            ws.Cells["R2"].Value = fioHeadCustomer;
                            package.Save();
                        }

                        var fieldValues = ReadExcelRow(templatePathExcel, rowIndex: 2);
                        GenerateSingleLetter(templatePathWord, filePath, fieldValues);
                        reader.Close();
                        return true;


                    }
                }
                reader.Close();
                return false;
        }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Формирует документ "Журнал опытной эксплуатации"
        /// </summary>
        /// <param name="dateCreate"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CreateTrialOperationLog(DateTime dateCreate, string filePath)
        {
            try
            {

                Connection.command.CommandText = $@"
        SELECT 	projects.product_name as productName,
                projects.product_short_name as shortProductName,
                customer.full_name as customerName	
        FROM projects
        LEFT JOIN initiative_requests ON initiative_requests.initiative_request_id = projects.initiative_request_id
        LEFT JOIN organizations customer ON customer.organization_id = initiative_requests.customer_id
        WHERE projects.project_id = '{RoadMapForProject.id}' ";
                var reader = Connection.command.ExecuteReader();

                string productName, customerName, shortProductName;

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        {
                            productName = reader["productName"].ToString();
                            customerName = reader["customerName"].ToString();
                            shortProductName = reader["shortProductName"].ToString();      
                        }
                        string templatePathWord = Path.GetFullPath(@"./SRC/TemplatesDoc/Журнал опытной эксплуатации.docx");
                        string templatePathExcel = Path.GetFullPath(@"./SRC/TemplatesDoc/Журнал опытной эксплуатации.xlsx");

                        using (ExcelPackage package = new ExcelPackage(new FileInfo(templatePathExcel)))
                        {
                            ExcelWorksheet ws = package.Workbook.Worksheets[0];
                            ws.Cells["A2"].Value = customerName;
                            ws.Cells["B2"].Value = productName;
                            ws.Cells["C2"].Value = shortProductName;
                            package.Save();
                        }

                        var fieldValues = ReadExcelRow(templatePathExcel, rowIndex: 2);
                        GenerateSingleLetter(templatePathWord, filePath, fieldValues);

                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
                return false;
            }
            catch
            {
                return false;
            }
        }



        //Завершение проекта
        /// <summary>
        /// Формирует документ "Акт завершения работ"
        /// </summary>
        /// <param name="dateCreate"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CreateActCompleteWork(DateTime dateCreate, string filePath)
        {
            try
            {

                Connection.command.CommandText = $@"
        SELECT 	projects.product_name_genitive as productName,
        		customer.short_name as customerShortName,
                customer.full_name as customerName,
        		developer.short_name as developerShortName,
        		developer.full_name as developerName,
                head_developer.position_genitive as positionNameHeadDeveloperGenitive,
                head_developer.fio_head_genitive as fioHeadDeveloperGenitive,
                head_developer.acts_on_the_basis_of as actDeveloper,
        		head_customer.position_genitive as positionNameHeadCustomerGenitive,
                head_customer.fio_head_genitive as fioHeadCustomerGenitive,
                head_customer.acts_on_the_basis_of as actCustomer,
        		DATE_FORMAT(initiative_requests.created_at, '%d.%m.%Y') as createdAt,
        		position_developer.position_name as positionNameHeadDeveloper,
                head_developer.short_fio_head_reverse as fioHeadDeveloper,
        		position_customer.position_name as positionNameHeadCustomer,
                head_customer.short_fio_head_reverse as fioHeadCustomer,
				coalesce(DATE_FORMAT(projects.actual_start_date, '%d.%m.%Y'), DATE_FORMAT(projects.start_date, '%d.%m.%Y')) as start,
				coalesce(DATE_FORMAT(projects.actual_end_date, '%d.%m.%Y'), DATE_FORMAT(projects.end_date, '%d.%m.%Y')) as end,
                projects.project_name as projectName,
                (SELECT documents.document_number 
                FROM documents 
                LEFT JOIN roadmap_items ON roadmap_items.roadmap_item_id = documents.roadmap_item_id
                WHERE documents.document_type_id = '2' AND roadmap_items.project_id = '{RoadMapForProject.id}') as docNumber,
                (SELECT DATE_FORMAT(documents.created_at, '%d.%m.%Y')
                FROM documents 
                LEFT JOIN roadmap_items ON roadmap_items.roadmap_item_id = documents.roadmap_item_id
                WHERE documents.document_type_id = '2' AND roadmap_items.project_id = '{RoadMapForProject.id}') as docDate
        FROM projects
        LEFT JOIN initiative_requests ON initiative_requests.initiative_request_id = projects.initiative_request_id
        LEFT JOIN organizations customer ON customer.organization_id = initiative_requests.customer_id
        LEFT JOIN heads_organizations head_customer ON head_customer.organization_id = customer.organization_id
        LEFT JOIN positions position_customer ON position_customer.position_id = head_customer.position_id
        LEFT JOIN organizations developer ON developer.organization_id = projects.developer_id
        LEFT JOIN heads_organizations head_developer ON head_developer.organization_id = developer.organization_id
        LEFT JOIN positions position_developer ON position_developer.position_id = head_developer.position_id
        WHERE projects.project_id = '{RoadMapForProject.id}' AND head_customer.period_validity_start <= CURRENT_DATE() AND head_customer.period_validity_end >= CURRENT_DATE() AND head_developer.period_validity_start <= CURRENT_DATE() AND head_developer.period_validity_end >= CURRENT_DATE() ";
                var reader = Connection.command.ExecuteReader();

                string productName, customerName, customerShortName, developerName, developerShortName, positionNameHeadDeveloperGenitive, fioHeadDeveloperGenitive, actDeveloper, positionNameHeadCustomerGenitive, fioHeadCustomerGenitive, actCustomer, createdAt, positionNameHeadDeveloper, fioHeadDeveloper, positionNameHeadCustomer, fioHeadCustomer, start, end, docNumber, docDate, projectName;

                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        {
                            productName = reader["productName"].ToString();
                            customerName = reader["customerName"].ToString();
                            customerShortName = reader["customerShortName"].ToString();
                            developerName = reader["developerName"].ToString();
                            developerShortName = reader["developerShortName"].ToString();
                            positionNameHeadDeveloperGenitive = reader["positionNameHeadDeveloperGenitive"].ToString();
                            fioHeadDeveloperGenitive = reader["fioHeadDeveloperGenitive"].ToString();
                            actDeveloper = reader["actDeveloper"].ToString();
                            positionNameHeadCustomerGenitive = reader["positionNameHeadCustomerGenitive"].ToString();
                            fioHeadCustomerGenitive = reader["fioHeadCustomerGenitive"].ToString();
                            actCustomer = reader["actCustomer"].ToString();
                            createdAt = reader["createdAt"].ToString();
                            positionNameHeadDeveloper = reader["positionNameHeadDeveloper"].ToString();
                            fioHeadDeveloper = reader["fioHeadDeveloper"].ToString();
                            positionNameHeadCustomer = reader["positionNameHeadCustomer"].ToString();
                            fioHeadCustomer = reader["fioHeadCustomer"].ToString();
                            start = reader["start"].ToString();
                            end = reader["end"].ToString();
                            docNumber = reader["docNumber"].ToString();
                            docDate = reader["docDate"].ToString();
                            projectName = reader["projectName"].ToString();
                        }
                        string templatePathWord = Path.GetFullPath(@"./SRC/TemplatesDoc/Акт завершения работ.docx");
                        string templatePathExcel = Path.GetFullPath(@"./SRC/TemplatesDoc/Акт завершения работ.xlsx");

                        using (ExcelPackage package = new ExcelPackage(new FileInfo(templatePathExcel)))
                        {
                            ExcelWorksheet ws = package.Workbook.Worksheets[0];
                            ws.Cells["A2"].Value = "";
                            ws.Cells["B2"].Value = productName;
                            ws.Cells["C2"].Value = customerName;
                            ws.Cells["D2"].Value = dateCreate.ToString("dd MMMM yyyyг.");
                            ws.Cells["E2"].Value = developerName;
                            ws.Cells["F2"].Value = positionNameHeadDeveloperGenitive;
                            ws.Cells["G2"].Value = fioHeadDeveloperGenitive;
                            ws.Cells["H2"].Value = actDeveloper;
                            ws.Cells["I2"].Value = positionNameHeadCustomerGenitive;
                            ws.Cells["J2"].Value = fioHeadCustomerGenitive;
                            ws.Cells["K2"].Value = actCustomer;
                            ws.Cells["L2"].Value = createdAt;
                            ws.Cells["M2"].Value = positionNameHeadDeveloper;
                            ws.Cells["N2"].Value = developerShortName;
                            ws.Cells["O2"].Value = fioHeadDeveloper;
                            ws.Cells["P2"].Value = positionNameHeadCustomer;
                            ws.Cells["Q2"].Value = customerShortName;
                            ws.Cells["R2"].Value = fioHeadCustomer;
                            ws.Cells["S2"].Value = start;
                            ws.Cells["T2"].Value = end;
                            ws.Cells["U2"].Value = docDate;
                            ws.Cells["V2"].Value = docNumber;
                            ws.Cells["W2"].Value = projectName;

                            package.Save();
                        }

                        var fieldValues = ReadExcelRow(templatePathExcel, rowIndex: 2);
                        GenerateSingleLetter(templatePathWord, filePath, fieldValues);

                        reader.Close();
                        return true;
                    }
                }
                reader.Close();
                return false;
            }
            catch
            {
                return false;
            }
        }


    }
}
