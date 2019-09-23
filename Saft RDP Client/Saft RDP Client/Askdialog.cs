using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaftRDPClient
{
    public partial class PasswordDialog_frm : Form
    {
        public PasswordDialog_frm()
        {
            InitializeComponent();
            
        }

        private void Accept_btn_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        public string ShowDialogString()
        {
            ShowDialog();
            return Passw_TxtBx.Text;   
        }

        private void Passw_TxtBx_TextChanged(object sender, EventArgs e)
        {
            Hash_lbl.Text = Passw_TxtBx.Text.GetHashCode().ToString();
            SymbCount_lbl.Text = Passw_TxtBx.TextLength.ToString();
        }

        private void Passw_TxtBx_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

       

        
    }
}
