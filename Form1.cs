using MaterialSkin;
using System;
using System.IO;
using System.Windows.Forms;

namespace Base64EncodeAndDecodeFile
{
    public partial class Base64EncodeAndDecodeFile : Form
    {
        public FileInfo FileToBase64 { get; set; }
        public FileInfo FileFromBase64 { get; set; }

        public Base64EncodeAndDecodeFile()
        {
            InitializeComponent();
          
        }

        #region CONVERTE PARA BASE 64
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
            FileInfo file = new(textBox1.Text);
            FileToBase64 = file;
            button1.Enabled = true;
        }
        private void ToBase64(FileInfo file)
        {
            try
            {
                string fileString = file.FullName;
                string newFileName = file.Name.Replace(file.Extension, "");
                string pathSave = fileString.Replace(file.Name, "");

                if (File.Exists(fileString))
                {
                    byte[] objByte = File.ReadAllBytes(fileString);
                    string fileEnd = Convert.ToBase64String(objByte);
                    string pathAndFile = $@"{pathSave}{newFileName}_Base64.txt";
                    File.WriteAllText(pathAndFile, fileEnd);
                    MessageBox.Show($"Arquivo salvo em: {pathSave}");
                }
                else
                {
                    MessageBox.Show("Parâmetros inválidos!");
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Parâmetros inválidos!");
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            ToBase64(FileToBase64);
        }

        #endregion

        #region CONVERTE PARA ARQUIVO
        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = folderBrowserDialog1.SelectedPath;
            }
            button2.Enabled = true;
        }

        private void FromBase64(string path)
        {
            try
            {
                var txtBase64 = textBox2.Text;
                if ((txtBase64.Length >= 1 || File.Exists(FileFromBase64.FullName)) & Directory.Exists(path) & textBox4.Text.Length >= 1)
                {
                    if (FileFromBase64 == null & txtBase64.Length >= 1)
                    {
                        byte[] objByte = Convert.FromBase64String(txtBase64);
                        File.WriteAllBytes(@$"{path}\arquivo_retorno_Base64.{textBox4.Text}", objByte);
                        MessageBox.Show($"Arquivo salvo em: {path}");
                    }
                    else if(FileFromBase64.Length > 1 & txtBase64.Length <= 1)
                    {
                        if (File.Exists(FileFromBase64.FullName))
                        {
                            string file = File.ReadAllText(FileFromBase64.FullName);
                            byte[] objByte = Convert.FromBase64String(file);
                            File.WriteAllBytes(@$"{path}\arquivo_retorno_Base64.{textBox4.Text}", objByte);
                            MessageBox.Show($"Arquivo salvo em: {path}");
                        }
                    }
                    else
                    {
                        if (File.Exists(FileFromBase64.FullName))
                        {
                            string file = File.ReadAllText(FileFromBase64.FullName);
                            byte[] objByte = Convert.FromBase64String(file);
                            File.WriteAllBytes(@$"{path}\arquivo_retorno_Base64.{textBox4.Text}", objByte);
                            MessageBox.Show($"Arquivo salvo em: {path}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"Parâmetros inválidos!");
                }
            }
            catch (Exception)
            {

                MessageBox.Show($"Parâmetros inválidos!");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FromBase64(textBox3.Text);
        }
        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox5.Text = openFileDialog2.FileName;
            }
            FileInfo file = new(textBox5.Text);
            FileFromBase64 = file;
        }
        
        #endregion

    }
}
