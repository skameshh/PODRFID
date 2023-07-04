using MySql.Data.MySqlClient;
using PODRFID.DB;
using PODRFID.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PODRFID.Forms
{
    public partial class FormInventory : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

         
        public FormInventory()
        {
            InitializeComponent();
            this.Text = "Inventory Management " + MYGlobal.VERSION;            

            loadDG();
        }

        private void loadDG()
        {
            String sql = "select rfid_tag,str_date, Type, Serial_no, Cameron_asset_no, Location from view_inventory";

            String from_date = dateTimePicker1.Value.ToString("yyyyMMdd");

           


            if (from_date.Length > 0)
            {
                
                if (sql.Contains("where "))
                {
                    sql = sql + " and str_date='" + from_date + "'";
                }
                else
                {
                    sql = sql + " where  str_date='" + from_date + "'";
                }
            }

          /*  if (type.Length > 0)
            {
                type = type.Trim();
                if (sql.Contains("where "))
                {
                    sql = sql + " and type like '%" + type + "%'";
                }
                else
                {
                    sql = sql + " where  type like '%" + type + "%'";
                }
            }

            if (location.Length > 0)
            {
                location = location.Trim();
                if (sql.Contains("where "))
                {
                    sql = sql + " and Location like '%" + location + "%'";
                }
                else
                {
                    sql = sql + " where  Location like '%" + location + "%'";
                }
            }

            if (where2use.Length > 0)
            {
                where2use = where2use.Trim();
                if (sql.Contains("where "))
                {
                    sql = sql + " and Where_to_use like '%" + where2use + "%'";
                }
                else
                {
                    sql = sql + " where  Where_to_use like '%" + where2use + "%'";
                }
            }

            if (desc.Length > 0)
            {
                desc = desc.Trim();
                if (sql.Contains("where "))
                {
                    sql = sql + " and Description like '%" + desc + "%'";
                }
                else
                {
                    sql = sql + " where  Description like '%" + desc + "%'";
                }
            }

            if (status.Length > 0)
            {
                status = status.Trim();
                if (sql.Contains("where "))
                {
                    sql = sql + " and status like '%" + status + "%'";
                }
                else
                {
                    sql = sql + " where  status like '%" + status + "%'";
                }
            }
*/
            try
            {
                sql = sql + " order by id desc  ";
                log.Info("Sql = " + sql);
                using (MySqlConnection conn = new MySqlConnection(MYGlobal.getMySqlCString()))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataAdapter sqlDa = new MySqlDataAdapter(cmd))
                        {

                            DataTable dt = new DataTable();
                            sqlDa.Fill(dt);
                            dataGridView1.DataSource = dt;
                            dataGridView1.Cursor = Cursors.Default;

                            int rowscount = dataGridView1.Rows.Count;
                            lblTotalRows.Text = "" + (rowscount - 1);
                            for (int i = 0; i < rowscount; i++)
                            {
                                //cells_count
                                int cells_count = dataGridView1.Rows[i].Cells.Count;


                            }//for


                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error fetching " + ee.Message);
            }


        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            MYGlobal.export2Excel(dataGridView1, "AllInventory");
        }

        private void FormInventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;
        }

        private static string todaye()
        {
            return DateTime.Now.ToString("yyyyMMdd");//20230325
        }

        private void doClear()
        {
           bool bb= DBUtils.doClearTodayInventory(todaye());
            if (bb)
            {
                log.Info("Clear success");
                MessageBox.Show("clear success");
            }
            else
            {
                MessageBox.Show("clear failed");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dr =MessageBox.Show("Are you sure to clear", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                btnClear.Enabled = false;
                doClear();
                loadDG();
                btnClear.Enabled = true;
            }
        }
    }
}
