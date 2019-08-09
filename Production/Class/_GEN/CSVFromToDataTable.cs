using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Production.Class
{
    class CSVFromToDataTable
    {
        public DataTable OpenCsvFileAsDataTable(string fileName, bool firstLineIsHeader)
        {
            DataTable result = new DataTable();
            System.IO.FileInfo fileInfo = new System.IO.FileInfo(fileName);

            // The table name is the actual name of the file.
            string tableName = fileInfo.Name;
            //MessageBox.Show("tableName :" + tableName);
            // Get the folder name in which the file is. This will be part of the 
            // connection string.
            string folderName = fileInfo.DirectoryName;
            //MessageBox.Show("folderName :" + folderName);
            string connectionString = "Provider=Microsoft.Jet.OleDb.4.0;" +
                                      "Data Source=" + folderName + ";" +
                                      "Extended Properties=\"Text;" +
                                      "HDR=" + (firstLineIsHeader ? "Yes" : "No") + ";" +
                                      "FMT=DecimalSymbol\"";
            using (System.Data.OleDb.OleDbConnection connection =
                new System.Data.OleDb.OleDbConnection(connectionString))
            {
                // Open the connection 
                connection.Open();

                // Set up the adapter and query the table.
                string sqlStatement = "SELECT * FROM " + tableName;
                using (System.Data.OleDb.OleDbDataAdapter adapter =
                    new System.Data.OleDb.OleDbDataAdapter(sqlStatement, connection))
                {
                    result = new DataTable(tableName);
                    adapter.Fill(result);
                }
            }
            return result;            
        }
        public DataTable ConvertCsvStringToDataTable(bool isFilePath, string CSVContent)
        {
            //CSVFilePathName = @"C:\test.csv";
            string[] Lines;
            if (isFilePath && File.Exists(CSVContent))
            {
                Lines = File.ReadAllLines(CSVContent);                
            }
            else
            {
                Lines = CSVContent.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            string[] Fields;
            Fields = Lines[0].Split(new char[] { ';' });
            int Cols = Fields.GetLength(0);
            DataTable dt = new DataTable();
            //1st row must be column names; force lower case to ensure matching later on.
            for (int i = 0; i < Cols; i++)
                //if( i == 0)
                    //dt.Columns.Add(Fields[i].ToLower(), typeof(string));
                    dt.Columns.Add(i.ToString(), typeof(string));
                //else
                    //dt.Columns.Add(Fields[i].ToLower(), typeof(string));
            DataRow Row;
            for (int i = 0; i < Lines.GetLength(0); i++)
            {
                Fields = Lines[i].Split(new char[] { ';' });
                Row = dt.NewRow();
                for (int f = 0; f < Cols; f++)
                    Row[f] = Fields[f];
                dt.Rows.Add(Row);
            }
            return dt;
        }
        public static DataTable XLSToDataTable(string filePath)
        {
            ////
            //DataTable dtexcel = new DataTable();
            ////
            //bool hasHeaders = true;
            ////
            //string HDR = hasHeaders ? "Yes" : "No";
            ////
            //string strConn;
            ////Microsoft.ACE.OLEDB.12.0
            //if (Path.GetExtension(filePath).ToLower().Trim() == ".xls" && Environment.Is64BitOperatingSystem == false)
                
            //    strConn =   "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + 
            //                ";Extended Properties=\"Excel 8.0;HDR=" + HDR + 
            //                ";IMEX=0\"";
            
            //else
            //    strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath +
            //                ";Extended Properties=\"Excel 12.0;HDR=" + HDR +
            //                ";IMEX=0\"";
            //OleDbConnection conn = new OleDbConnection(strConn);
            //conn.Open();
            //DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            //DataRow schemaRow = schemaTable.Rows[0];
            //string sheet = schemaRow["TABLE_NAME"].ToString();
            //XtraMessageBox.Show("sheet : " + sheet);
            //if (!sheet.EndsWith("_"))
            //{
            //    string query = "SELECT  * FROM [Sheet1$]";
            //    OleDbDataAdapter daexcel = new OleDbDataAdapter(query, conn);
            //    dtexcel.Locale = CultureInfo.CurrentCulture;
            //    daexcel.Fill(dtexcel);
            //}
            //conn.Close();
            //return dtexcel;

            DataTable dtexcel = new DataTable();
            //
            bool hasHeaders = true;
            //
            string isHDR = hasHeaders ? "Yes" : "No";
            //
            string conStr;
            //Microsoft.ACE.OLEDB.12.0
            if (Path.GetExtension(filePath).ToLower().Trim() == ".xls" && Environment.Is64BitOperatingSystem == false)
                conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath +
                            ";Extended Properties=\"Excel 8.0;HDR=" + isHDR +
                            ";IMEX=0\"";
            else
                conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath +
                            ";Extended Properties=\"Excel 12.0;HDR=" + isHDR +
                            ";IMEX=0\"";
            conStr = String.Format(conStr, filePath, isHDR);
            OleDbConnection connExcel = new OleDbConnection(conStr);
            OleDbCommand cmdExcel = new OleDbCommand();
            OleDbDataAdapter oda = new OleDbDataAdapter();
            DataTable dt = new DataTable();           
            //Get the name of First Sheet
            //if (connExcel.State == ConnectionState.Open)
            //    connExcel.Close();
            connExcel.Open();
            DataTable dtExcelSchema;
            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
            connExcel.Close();
            if (connExcel.State == ConnectionState.Open)
                connExcel.Close();
            //Read Data from First Sheet
            connExcel.Open();
            cmdExcel.Connection = connExcel;
            cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
            oda.SelectCommand = cmdExcel;
            oda.Fill(dt);
            connExcel.Close();
            if (connExcel.State == ConnectionState.Open)
                connExcel.Close();
            return dt;
        }

        public void XLSX2Grid(GridControl gc)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "Excel file (*.xlsx)|*.xlsx";
            choofdlog.ShowDialog();
            //string filePath = System.IO.Path.GetDirectoryName(choofdlog.FileName);
            string filePath = choofdlog.FileName;
            //XtraMessageBox.Show(filePath);
            System.Data.OleDb.OleDbConnection MyConnection;
            System.Data.DataSet DtSet;
            System.Data.OleDb.OleDbDataAdapter MyCommand;
            string conStr;
            if (Path.GetExtension(filePath).ToLower().Trim() == ".xls" && Environment.Is64BitOperatingSystem == false)
                conStr = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath +
                            ";Extended Properties=\"Excel 8.0;HDR= Yes" +
                            ";IMEX=0\"";
            else
                conStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath +
                            ";Extended Properties=\"Excel 12.0;HDR= Yes" +
                            ";IMEX=0\"";
            MyConnection = new System.Data.OleDb.OleDbConnection(conStr);
            //XtraMessageBox.Show(MyConnection.State.ToString());
            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                MyConnection.Open();
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet$]", MyConnection);
                //MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1]", MyConnection);
                MyCommand.TableMappings.Add("Table", "Net-informations.com");
                DtSet = new System.Data.DataSet();
                MyCommand.Fill(DtSet);
                gc.DataSource = DtSet.Tables[0];
                MyConnection.Close();
            }
            else
                choofdlog.Dispose();
        } 
        
        private static Microsoft.Office.Interop.Excel.Workbook mWorkBook;
        private static Microsoft.Office.Interop.Excel.Sheets mWorkSheets;
        private static Microsoft.Office.Interop.Excel.Worksheet mWSheet1;
        private static Microsoft.Office.Interop.Excel.Application oXL;
        public void WRITE2XSLX(GridView gv)
        {
            //string path = @"C:\ProjectTesting\TwsDde.xlsm";
            string path = @"D:\Template21Jun2018.xlsx";            
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = true;
            oXL.DisplayAlerts = false;
            mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //Get all the sheets in the workbook
            mWorkSheets = mWorkBook.Worksheets;
            //Get the allready exists sheet
            //mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item(0);
            mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)oXL.Worksheets["Sheet1"];
            Microsoft.Office.Interop.Excel.Range range = mWSheet1.UsedRange;
            //int colCount = range.Columns.Count;
            //int rowCount = range.Rows.Count;
            //for (int index = 1; index < 15; index++)
            //{
            //    mWSheet1.Cells[rowCount + index, 1] = rowCount + index;
            //    mWSheet1.Cells[rowCount + index, 2] = "New Item" + index;
            //}
            //XtraMessageBox.Show("gv.DataRowCount : " + gv.DataRowCount.ToString());
            for (int i = 0 ; i <= gv.DataRowCount - 1; i++ )
            {
                //XtraMessageBox.Show("i : " + i.ToString());
                //XtraMessageBox.Show("OA BATCH : " + gv.GetRowCellValue(i, "OA BATCH").ToString());
                mWSheet1.Cells[i + 2, 1] = gv.GetRowCellValue(i, "OA BATCH").ToString();                
            }
            mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault,
            Missing.Value, Missing.Value, Missing.Value, Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
            Missing.Value, Missing.Value, Missing.Value,
            Missing.Value, Missing.Value);
            mWorkBook.Close(Missing.Value, Missing.Value, Missing.Value);
            mWSheet1 = null;
            mWorkBook = null;
            oXL.Quit();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            //GC.WaitForPendingFinalizers();
            //GC.Collect();
        }
        
    }

}
