using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace FileIODemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

     

        private void btnCreateDirectory_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string path = @"C:\TestFolder";


        //        if (Directory.Exists(path))
        //        {
        //            MessageBox.Show("Directory alredy exists");
        //        }
        //        else
        //        {
        //            Directory.CreateDirectory(path);
        //            MessageBox.Show("Directory Created");
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        {
            try
            {
                string path = @"C:\TestFolder";
                DirectoryInfo info = new DirectoryInfo(path);


                if (info.Exists)
                {
                    MessageBox.Show("Directory already exists...");
                }
                else
                {
                    info.Create();
                    MessageBox.Show("Directory Created...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            //try 
            //{
            //    string path = @"C:\TestFolder\Employee.dat"; //.dat-->Data file(binary)

            //    if(File.Exists(path))
            //    {
            //        MessageBox.Show("File alredy exists...");
            //    }
            //    else
            //    {
            //        File.Create(path);
            //        MessageBox.Show("File Created");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            try
            {
                string path = @"C:\TestFolder\Employee.dat"; //.dat-->Data file(binary)
                FileInfo file = new FileInfo(path);

                if (file.Exists)
                {
                    MessageBox.Show("File already exists...");
                }
                else
                {
                    file.Create();
                    MessageBox.Show("File Created...");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\TestFolder\Employee.dat", FileMode.Create, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(Convert.ToInt32(txtid.Text));
                bw.Write(txtName.Text);
                bw.Write(Convert.ToDouble(txtSalary.Text));
                bw.Close();
                fs.Close();
                MessageBox.Show("Done");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnRaed_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\TestFolder\Employee.dat", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                txtid.Text = br.ReadInt32().ToString();
                txtName.Text = br.ReadString();
                txtSalary.Text = br.ReadDouble().ToString();
                br.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnStreamWrite_Click(object sender, EventArgs e)
        {
            try 
            {
                FileStream fs = new FileStream(@"C:\TestFolder\data.txt", FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(richTextBox1.Text);
                sw.Close();
                fs.Close();
                MessageBox.Show("Done");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStreamRead_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"C:\TestFolder\data.txt", FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                fs.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
