using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Encryptor
{
    public partial class Form1 : Form
    {
        string path;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_get_file_Click(object sender, EventArgs e)
        {
            OpenFileDialog.ShowDialog();
            path = OpenFileDialog.FileName;
            lbl_path.Text = $"Path: {path}";
        }

        private void btn_encrypt_Click(object sender, EventArgs e)
        {
            Key key = new Key();
            MessageBox.Show(key.ShowKey());
            if(path == null || path == "")
            {
                MessageBox.Show("File is not selected! Select a file");
                return;
            }
            try
            {
                FileStream file = new FileStream(path, FileMode.Open);
                byte[] bytes = new byte[file.Length];
                file.Read(bytes, 0, bytes.Length);
                MessageBox.Show(string.Join(", ", bytes));
                var encrypted_bytes = key.Encrypt(bytes);
                using (FileStream EncryptedFile = new FileStream(path + ".encr", FileMode.CreateNew))
                {

                }
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show($"File {path} is not found!");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Unexpected error has occured: {ex.Message}");
            }
        }
    }
}
