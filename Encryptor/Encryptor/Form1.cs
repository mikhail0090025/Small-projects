using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encryptor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_get_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog.ShowDialog();
            string path = OpenFileDialog.FileName;
            lbl_path.Text = $"Path: {path}";
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            Key key = new Key();
            MessageBox.Show(key.ShowKey());
        }
    }
}
