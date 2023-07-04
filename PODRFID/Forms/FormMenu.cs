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
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
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
                MessageBox.Show("Stock Mgmt already loaded ");
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
                MessageBox.Show("Inventory Mgmt already loaded ");
                frmInv.Show();
            }

        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            showStockMgmt();
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
             showInvMgmt();
        }

        private void FormMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
        }
    }
}
