using PODRFID.DB;
using PODRFID.Forms;
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

namespace PODRFID
{
    public partial class Form1 : Form
    {
        public static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Form1()
        {
            InitializeComponent();
           // this.Text = "Login " + MYGlobal.VERSION;
            this.Width = 502;
            this.panelMenu.Visible = false;
            this.panelLogin.Visible = true;
            this.Text = "POD-RFID-"+ MYGlobal.VERSION;
        }

        private bool checkUser()
        {
            if(txtPwd.Text=="admin" && txtUserId.Text == "admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            //check connection
            if (!DBUtils.getConnectionStatus())
            {
                MessageBox.Show("DB Connection failed, Please start/connect database!");
                return;
            }

            if (!checkUser())
            {
                this.Width = 502;

                MessageBox.Show("Login failed, Please try again");
                return;
            }

            try
            {
                bool bb = MYGlobal.checkConnection();
                log.Info("Connection " + bb);
                this.Width = 800;
                this.Visible = false;
                FormMenu frm = new FormMenu();
                frm.Show();

               /* this.panelLogin.Visible = false;
                this.panelMenu.Visible = true;

                this.panelMenu.Left = 10;
                this.panelMenu.Location = new Point(36, 3);*/

                this.Refresh();

                // this.Visible = false;
                
            }
            catch (Exception ee)
            {
                log.Error("Error " + ee.Message);
            }
        }

        FormAddStock frm = null;
        FormInventory frmInv = null;

        private void showStockMgmt()
        {
            if (frm == null)
            {
                frm = new FormAddStock();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Already logged in");
                frm.Show();
            }
            
        }

        private void showInvMgmt()
        {
            if (frmInv == null)
            {
                frmInv = new FormInventory();
                frmInv.Show();
            }
            else
            {
                MessageBox.Show("Already logged in");
                frmInv.Show();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bye");
            System.Environment.Exit(0);
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
             showStockMgmt();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            showInvMgmt();
        }
    }
}
