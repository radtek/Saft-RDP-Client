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
    public partial class Askdialog : Form
    {
        public Askdialog()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        public string ShowDialogString()
        {
            ShowDialog();
            return textBox1.Text;   
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label1.Text = textBox1.Text.GetHashCode().ToString();
            label2.Text = textBox1.TextLength.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

       

        
    }
}
