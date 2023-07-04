using MySql.Data.MySqlClient;
using PODRFID.DB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PODRFID.Global
{
   public class MYGlobal
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static string VERSION = "v-0.1.5";

        public static UserDao loggedInUserDao = null;
        public static int loggedInUser_Id = 0;
        public static string MYSQL_SERVER = string.Empty;


        public static string getMySqlCString()
        {

            string server = GetSettingValue("MYSQL_SERVER_HOST"); ;//"localhost"; 
            string port = GetSettingValue("MYSQL_SERVER_PORT");
            string db = GetSettingValue("MYSQL_SERVER_DB");
            string user = GetSettingValue("MYSQL_SERVER_USER");
            string pwd = GetSettingValue("MYSQL_SERVER_PWD");
            //  return "server=" + server + ";user=root;pwd=;database=ocstoolinventorymgmt;persistsecurityinfo=True;SslMode=none;Convert Zero Datetime=True;Allow Zero Datetime=True";

            MYSQL_SERVER = server;

            //Allow Zero Datetime=True | Convert Zero Datetime=True;
            string sql_string = "server=" + server + ";user=" + user + ";pwd=" + pwd + ";database=" + db + ";persistsecurityinfo=True;SslMode=none;Allow Zero Datetime=True;allowPublicKeyRetrieval=true;";
            
            log.Info("Myql string = "+ sql_string);


            return sql_string;

        }

        public static string GetSettingValue(string paramName)
        {
            return String.Format(ConfigurationManager.AppSettings[paramName]);
        }

        public static bool checkConnection()
        {
            string sql = "select * from t_user limit 10";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(getMySqlCString()))
                {
                    conn.Open();

                    log.Info("sql = "+sql);
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["id"];
                                string userid = (string)reader["user_id"];
                                string name = (string)reader["name"];

                                log.Info("Connection success got user " + userid + ", name=" + name);
                            }

                            return true;
                        }

                    }
                }
            }
            catch (Exception ee)
            {
                log.Info("Connection failed");
                log.Info("Error " + ee.Message);
                return false;
            }


        }

        public static String getCurretnDate()
        {
            DateTime dateTime = DateTime.Today;
            return dateTime.ToString("yyyy-MM-dd");
        }

        public static String getCurretnDateTime()
        {
            DateTime dateTime = DateTime.Today;
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static String getCurretnTime()
        {
            DateTime dateTime = DateTime.Now;
            return dateTime.ToString("HH:mm:ss");
        }


        public static void export2Excel(DataGridView dataGridView, String name)
        {
            try
            {
                // creating Excel Application  
                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                // creating new WorkBook within Excel application  
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                // creating new Excelsheet in workbook  
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                // see the excel sheet behind the program  
                app.Visible = true;
                // get the reference of first sheet. By default its name is Sheet1.  
                // store its reference to worksheet  
                worksheet = workbook.Sheets["Sheet1"];
                worksheet = workbook.ActiveSheet;
                // changing the name of active sheet  
                worksheet.Name = "" + name;
                // storing header part in Excel  
                for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;
                }
                // storing Each row and column value to excel sheet  
                for (int i = 0; i < dataGridView.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        try
                        {
                            worksheet.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                        }
                        catch (Exception ee)
                        {
                            log.Error(" " + ee.Message);
                        }
                    }
                }

                //"c:\\temp\\tpc\\output.xlsx"
                // save the application  
                workbook.SaveAs("c:\\temp\\meie\\" + name + "-" + getCurretnDate() + ".xlsx", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                // Exit from the application  

                //MessageBox.Show("");

                app.Quit();
            }
            catch (Exception ee)
            {
                log.Error("Export Excel Error " + ee.Message);
            }
        }












    }
}
