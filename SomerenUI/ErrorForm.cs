using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class ErrorForm : Form
    {
        public ErrorForm()
        {
            InitializeComponent();

            UpdateListBox();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void UpdateListBox()
        {
            string[] errorlines = File.ReadAllLines(@"..\..\..\errorlog.txt");

            listBoxError.Items.Clear();

            for (int i = errorlines.Length - 1; i >= 0; i--)
            {
                listBoxError.Items.Add(errorlines[i]);
            }
        }
    }
}
