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

namespace Picthrive
{
    public partial class Form1 : Form
    {
        string currentDir = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                // Dosya kaydetme iletişim kutusunu göster
                var fb = new FolderBrowserDialog();
                {
                    if (fb.ShowDialog() == DialogResult.OK)
                    {
                        currentDir = fb.SelectedPath;
                        txtSelectedFolder.Text = currentDir;
                        var dirInfo = new DirectoryInfo(currentDir);
                        var files = dirInfo.GetFiles().Where(c => (c.Extension.Equals(".jpg") || c.Extension.Equals(".jpeg") || c.Extension.Equals(".png") || c.Extension.Equals(".bmp")));
                        foreach (var image in files)
                        {
                            listBox1.Items.Add(image.Name);
                        }
                    }
                }
            
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Bir hata oluştu: " + ex.Message + " " + ex.Source);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedImage = listBox1.SelectedItems[0].ToString();
                if (!string.IsNullOrEmpty(selectedImage) && !string.IsNullOrEmpty(currentDir));
                    {
                    var fullPath = Path.Combine(currentDir, selectedImage);
                    pictureBox1.Image = Image.FromFile(fullPath);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
    
}
