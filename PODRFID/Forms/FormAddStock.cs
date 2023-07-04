using MySql.Data.MySqlClient;
using MySql.Data.Types;
using PODRFID.DB;
using PODRFID.Global;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PODRFID.Forms
{
    public partial class FormAddStock : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string ACTION = "Add";
        //private Form1 frmLogin;

        public FormAddStock()
        {
            InitializeComponent();

            this.Text = "Stock Management " + MYGlobal.VERSION;

            //this.frmLogin = frmLogin;

            loadDG();

            doUpdateLabel();
        }


        private void doUpdateLabel()
        {
            String ss = ">> To add new items, 1. Click Add button , 2. Enter data, 3.Click Save button. \n  >> To Update items, 1.Search, 2.Bottom table select, 3.Update data, 4. Save button";
            lblHelp.Text = ss;
        }

        //Convert.ToDateTime(Calibration_date).ToString("yyyy-MM-dd")
        private void loadDG()
        {
            String sql = "select Id, Belong,Type,Description, Cameron_asset_no, Drive_size, Weight, Serial_no, Where_to_use," +
                " Calibration_date, Calibration_due_date,  Status," +
                " Location,Remarks, RFID_tag from t_pod_tools ";


            String belong = cboBelong.Text;
            String type = cboType.Text;
            String location = cboLocation.Text.Trim();
            String cameron_asset_no = txtCameronAssetNo.Text.Trim();
            string where2use = cboWhere2Use.Text.Trim();
            string desc = txtDescription.Text.Trim();
            string status = cboStatus.Text.Trim();
            string weight = txtWeight.Text.Trim();
            string slno = txtSlNo.Text.Trim();
            string drivesize = txtDriveSize.Text.Trim();
            string remarks = txtRemarks.Text.Trim();
            string rfid_tag = txtRFIDTag.Text.Trim();
            string common_text = txtCommonSearch.Text.Trim();

            if (common_text.Length > 0)
            {
                if (sql.Contains("where "))
                {
                    sql = sql + " and Belong='" + belong + "'";
                }
                else
                {
                    sql = sql + " where  (DESCRIPTION LIKE '%"+ common_text + "%' OR DESCRIPTION = NULL) " +
                                        " or(Belong LIKE '%" + common_text + "%' OR Belong = NULL)" +
                                        " or(Type LIKE '%" + common_text + "%' OR Type = NULL)" +
                                        " or(Cameron_asset_no LIKE '%" + common_text + "%' OR Cameron_asset_no = NULL)" +
                                        " or(Serial_no LIKE '%" + common_text + "%' OR Serial_no = NULL)" +
                                        " or(drive_size LIKE '%" + common_text + "%' OR drive_size = NULL)" +
                                        " or(Weight LIKE '%" + common_text + "%' OR Weight = NULL)" +
                                        " or(location LIKE '%" + common_text + "%' OR location = NULL)" +                                       
                                        " or(Where_to_use LIKE '%" + common_text + "%' OR Where_to_use = NULL)" +
                                        " or(RFID_tag LIKE '%" + common_text + "%' OR RFID_tag = NULL)" +
                                         " or(Status LIKE '%" + common_text + "%' OR Status = NULL)" +
                                        " or(Remarks LIKE '%" + common_text + "%' OR Remarks = NULL)"  

                        ;
                }
            }

            if (belong.Length > 0)
            {
                belong = belong.Trim();
                if (sql.Contains("where "))
                {
                    sql = sql + " and Belong='" + belong + "'";
                }
                else
                {
                    sql = sql + " where  Belong='" + belong + "'";
                }
            }

            if (drivesize.Length > 0)
            {
                drivesize = drivesize.Trim();
                if (sql.Contains("where "))
                {
                    sql = sql + " and Drive_size like '%" + drivesize + "%'";
                }
                else
                {
                    sql = sql + " where  Drive_size like '%" + drivesize + "%'";
                }
            }            

            if (cameron_asset_no.Length > 0)
            {
                 
                if (sql.Contains("where "))
                {
                    sql = sql + " and Cameron_asset_no like '%" + cameron_asset_no + "%'";
                }
                else
                {
                    sql = sql + " where  Cameron_asset_no like '%" + cameron_asset_no + "%'";
                }
            }

            if (type.Length > 0)
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

            if (slno.Length > 0)
            {
                slno = slno.Trim();
                if (sql.Contains("where "))
                {
                    sql = sql + " and Serial_no like '%" + slno + "%'";
                }
                else
                {
                    sql = sql + " where  Serial_no like '%" + slno + "%'";
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

            if (weight.Length > 0)
            {
               
                if (sql.Contains("where "))
                {
                    sql = sql + " and weight like '%" + weight + "%'";
                }
                else
                {
                    sql = sql + " where  weight like '%" + weight + "%'";
                }
            }

            if (remarks.Length > 0)
            {
                
                if (sql.Contains("where "))
                {
                    sql = sql + " and Remarks like '%" + remarks + "%'";
                }
                else
                {
                    sql = sql + " where  Remarks like '%" + remarks + "%'";
                }
            }


            if (rfid_tag.Length > 0)
            {

                if (sql.Contains("where "))
                {
                    sql = sql + " and RFID_tag like '%" + rfid_tag + "%'";
                }
                else
                {
                    sql = sql + " where  RFID_tag like '%" + rfid_tag + "%'";
                }
            }

            try
            {
                sql = sql + " order by id desc  ";
                log.Info("Sql = " + sql);
                int rowscount = 0;
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

                              rowscount = dataGridView1.Rows.Count;
                           
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
            catch(Exception ee)
            {
                MessageBox.Show("Error fetching " + ee.Message);
            }


        }


        private void doSave()
        {

           // String from_date = dateTimePickerCaliDate.Value.ToString("yyyy-MM-dd");
           // String to_date = dateTimePickerCaliDueDate.Value.ToString("yyyy-MM-dd");

            if (string.IsNullOrEmpty(cboBelong.Text)){
                MessageBox.Show("Belong can't be null");
                return;
            }

            if (string.IsNullOrEmpty(cboLocation.Text)){
                MessageBox.Show("Location can't be null");
                return;
            }

            if (string.IsNullOrEmpty(cboType.Text))
            {
                MessageBox.Show("Type can't be null");
                return;
            }

            if (string.IsNullOrEmpty(cboWhere2Use.Text))
            {
                MessageBox.Show("Where2Use can't be null");
                return;
            }

            InvDao dao = new InvDao();
            dao.Belong = cboBelong.Text;
            dao.CalibDate = DateTime.Now;// dateTimePickerCaliDate.Value;
            dao.CalibDueDate = DateTime.Now;//dateTimePickerCaliDueDate.Value;
            dao.Description = txtDescription.Text;
            dao.DriveSize = txtDriveSize.Text;            
            dao.Location = cboLocation.Text;
            dao.Remarks = txtRemarks.Text;
            dao.RFIDTag = txtRFIDTag.Text;
            dao.SerialNo = txtSlNo.Text;
            dao.Status = cboStatus.Text;
            dao.Type = cboType.Text;
            dao.Weight = txtWeight.Text;
            dao.Where2Use = cboWhere2Use.Text;
            dao.CameronAssetNo = txtCameronAssetNo.Text;


            if (ACTION == "Add")
            {
                
              bool bb =   DBUtils.doInsertInv(dao);
                if (bb)
                {
                    MessageBox.Show("save new item success ");
                }
                else
                {
                    MessageBox.Show("save new item failed ");
                }

            }
            else if (ACTION == "Update")
            {
              
                dao.Id = Int32.Parse(lblId.Text);

              bool bb =   DBUtils.doUpdateInv(dao);
                if (bb)
                {
                    MessageBox.Show("Update success ");
                }
                else
                {
                    MessageBox.Show("Update failed ");
                }
            }
        }

        private void loadRow()
        {
            DataGridViewRow dgvRow = dataGridView1.CurrentRow;
            String id = string.Empty;
            doClear();

            if (dgvRow != null)
            {
                if ((dgvRow.Cells["dgv_id"].Value != null))
                {
                    int xy = (int) dgvRow.Cells["dgv_id"].Value;
                    lblId.Text =  xy.ToString();
                }

                if ((dgvRow.Cells["dgv_Belong"].Value != DBNull.Value))
                {
                    string xy = (string)dgvRow.Cells["dgv_Belong"].Value;
                    cboBelong.Text = xy.ToString();
                }

                if ((dgvRow.Cells["dgv_type"].Value != DBNull.Value))
                {
                    string xy = (string)dgvRow.Cells["dgv_type"].Value;
                    cboType.Text = xy.ToString();
                }

                if ((dgvRow.Cells["dgv_Description"].Value != DBNull.Value))
                {
                    string xy = (string)dgvRow.Cells["dgv_Description"].Value;
                    txtDescription.Text = xy.ToString();
                }

                if ((dgvRow.Cells["dgv_Cameron_asset_no"].Value != DBNull.Value) )
                {
                    string xy = (string)dgvRow.Cells["dgv_Cameron_asset_no"].Value;
                    txtCameronAssetNo.Text = xy.ToString();
                }

                if ((dgvRow.Cells["dgv_Serial_no"].Value != DBNull.Value))
                {
                    string xy = (string)dgvRow.Cells["dgv_Serial_no"].Value;
                    txtSlNo.Text = xy.ToString();
                }

                if ((dgvRow.Cells["dgv_Drive_size"].Value != DBNull.Value))
                {
                    string xy = (string)dgvRow.Cells["dgv_Drive_size"].Value;
                    txtDriveSize.Text = xy.ToString();
                }

                if ((dgvRow.Cells["dgv_Weight"].Value != DBNull.Value))
                {
                    string xy = (string)dgvRow.Cells["dgv_Weight"].Value;
                    txtWeight.Text = xy.ToString();
                }

                if ((dgvRow.Cells["dgv_Where_to_use"].Value != DBNull.Value))
                {
                    string xy = (string)dgvRow.Cells["dgv_Where_to_use"].Value;
                    cboWhere2Use.Text = xy.ToString();
                }

                if ((dgvRow.Cells["dgv_Status"].Value != DBNull.Value))
                {
                    string xy = (string)dgvRow.Cells["dgv_Status"].Value;
                    cboStatus.Text = xy.ToString();
                }

                if ((dgvRow.Cells["dgv_Location"].Value != DBNull.Value))
                {
                    string xy = (string)dgvRow.Cells["dgv_Location"].Value;
                    cboLocation.Text = xy.ToString();
                }

                if ((dgvRow.Cells["dgv_Remarks"].Value != DBNull.Value))
                {
                    string xy = (string)dgvRow.Cells["dgv_Remarks"].Value;
                    txtRemarks.Text = xy.ToString();
                }

                if (dgvRow.Cells["dgv_RFID_tag"].Value != DBNull.Value)
                {
                    string xy = (string)dgvRow.Cells["dgv_RFID_tag"].Value;
                    txtRFIDTag.Text = xy.ToString();
                }

                try
                {

                    // DateTime dt =   dgvRow.Cells["dgv_Calibration_date"].Value == DBNull.Value ? SqlDateTime.Null : dgvRow.Cells["dgv_Calibration_date"].Value;
                    //MySql.Data.Types.MySqlDateTime
                    if (dgvRow.Cells["dgv_Calibration_date"].Value != DBNull.Value)
                    {
                        MySqlDateTime xy = (MySqlDateTime)dgvRow.Cells["dgv_Calibration_date"].Value;
                        string ss=   xy.ToString();
                        log.Info("ss " + ss);
                        DateTime dt = DateTime.Parse(ss);
                       // dateTimePickerCaliDate.Value = dt;
                    }
                }catch(Exception ee)
                {
                    log.Info("Error dgv_Calibration_date = " + ee.Message);
                   // dateTimePickerCaliDate.Value = ;
                }


                try
                {

                    if (dgvRow.Cells["dgv_Calibration_due_date"].Value != DBNull.Value)
                    {
                        MySqlDateTime xy = (MySqlDateTime)dgvRow.Cells["dgv_Calibration_due_date"].Value;
                        //dateTimePickerCaliDueDate.Value = xy;
                    }
                }
                catch (Exception ee)
                {
                    log.Info("Error dgv_Calibration_due_date = " + ee.Message);
                }
                //dateTimePickerCaliDate.Value = null;

            }

        }

        private void dbRowCellClick(DataGridViewCellEventArgs e)
        {
            /*  if (e.ColumnIndex == dataGridView1.Columns["dgtPINFO"].Index && e.RowIndex >= 0)
              {
                  //doUpdatePInfo(e);
              }
              else if (e.ColumnIndex == dataGridView1.Columns["btnReject"].Index && e.RowIndex >= 0)
              {
                  //MessageBox.Show("Rject");
                  //doReject(e);
              }*/

            loadRow();

        }

        private void pbSearchBelong_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void pbSearchDesc_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void pbSearchSlno_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void pbSearchWeight_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void pbSearchCalibDate_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void pbSearchStatus_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void pbSearchRemarks_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void pbSearchRFIDTag_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void pbSearchLocation_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void pbSearchCalibDueDate_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void pbSearchBWhere2Use_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void pbSearchDriverSize_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void pbSearchAssetNo_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void pbSearchType_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            doSave();
            loadDG();
        }

        private void doClear()
        {
            txtRFIDTag.Text = "";
            txtSlNo.Text = "";
            txtWeight.Text = "";
            txtRemarks.Text = "";
            txtDriveSize.Text = "";
            txtDescription.Text = "";
            txtCameronAssetNo.Text = "";
            cboBelong.Text = "";
            cboLocation.Text = "";
            cboStatus.Text = "";
            cboType.Text = "";
            cboWhere2Use.Text = "";
            txtCommonSearch.Text = "";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dbRowCellClick(e);
            ACTION = "Update";
        }

        private void btnLoadAll_Click(object sender, EventArgs e)
        {
            doClear();
            loadDG();
            MessageBox.Show("All items loaded");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            doClear();
            ACTION = "Add";
            MessageBox.Show("You can add new items now in the boxes above, Dont forget to click save after adding");
            //user will add in this page itself
        }

        private void FormAddStock_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            this.Parent = null;
            e.Cancel = true;

           // frmLogin.Visible = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            doClear();
            MessageBox.Show("All text boxes and search criteria all cleared");
        }

        private void btnExcelExport_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure to download Excel", "Download", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (res == DialogResult.Yes)
            {
                MYGlobal.export2Excel(dataGridView1, "AllStock");
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to delete?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                MessageBox.Show("Sorry you dont have permission to delete, Please contact admin");
                return;
            }
        }

        private void doKey(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadDG();
                MessageBox.Show("Found " + lblTotalRows.Text + " Items ");
            }
        }

        private void txtDriveSize_KeyDown(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void cboBelong_KeyDown(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void txtSlNo_KeyDown(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void txtWeight_KeyDown(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void cboStatus_KeyUp(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void txtRemarks_KeyUp(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void cboType_KeyDown(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void txtCameronAssetNo_KeyUp(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void cboWhere2Use_KeyUp(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void txtRFIDTag_KeyUp(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void pbCommonSearch_Click(object sender, EventArgs e)
        {
            loadDG();
        }

        private void txtCommonSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtCommonSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //loadDG();
               // MessageBox.Show("Found " + lblTotalRows.Text + " Items ");
            }
        }

        private void doKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                loadDG();
                MessageBox.Show("Found " + lblTotalRows.Text + " Items ");
            }
        }

        private void txtCommonSearch_KeyDown(object sender, KeyEventArgs e)
        {
            doKeyDown(e);
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            doKeyDown(e);
        }

        private void txtCameronAssetNo_KeyDown(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void txtRFIDTag_KeyDown(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void cboLocation_KeyDown(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void cboWhere2Use_KeyDown(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            doKey(e);
        }

        private void cboStatus_KeyDown(object sender, KeyEventArgs e)
        {
            doKey(e);
        }
    }
}
