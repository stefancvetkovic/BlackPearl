using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
//using Application = Microsoft.Office.Interop.Word.System.Windows.Forms.Application;

namespace BlackPearl
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txtPath.Text = fbd.SelectedPath;
                string[] files = Directory.GetFiles(fbd.SelectedPath);

                MessageBox.Show("Pronađeno fajlova: " + files.Length.ToString(), "Message");

            }
            
        }

        private void btnReplace_Click(object sender, EventArgs e)
        {
           try
           {
               if (txtPath.Text == "" || txtFind.Text == "" || txtReplace.Text == "")
               {
                   DialogResult result = MessageBox.Show("Morate popuniti sva polja", "UPOZORENJE",
                       MessageBoxButtons.RetryCancel);
                   if (result == DialogResult.Cancel) this.Close();
               }
               else
               {
                   Logic l = new Logic();
                   var ext = new List<string> { ".doc", ".docx" };
                   var myFiles = Directory.GetFiles(txtPath.Text).Where(s => ext.Any(opa => s.EndsWith(opa)));

                   Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application { Visible = false };
                   foreach (var file in myFiles)
                   {

                       object fileName = file;
                       Document aDoc = wordApp.Documents.Open(fileName, ReadOnly: false, Visible: false);
                       aDoc.Activate();
                       l.FindAndReplace(wordApp, txtFind.Text, txtReplace.Text);
                       aDoc.Save();
                       aDoc.Close();


                   }
                   wordApp.Quit();
                   MessageBox.Show("Uspešna izmena!");
               }
           }
            catch (COMException ex)
            {

                throw ex;
            }
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnExtract_Click(object sender, EventArgs e)
        {
            string kosaCrta = @"\";
            var ext = new List<string> { ".doc", ".docx" };
            var myFiles = Directory.GetFiles(txtSourceJob.Text).Where(s => ext.Any(opa => s.EndsWith(opa)));

            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application { Visible = false };
            foreach (var file in myFiles)
            {
                string fileName1 = Path.GetFileNameWithoutExtension(file);
                object fileName = file;
                if (!file.Contains("~"))
                {
                    Document aDoc = wordApp.Documents.Open(fileName, ReadOnly: false, Visible: false);
                    //aDoc.Activate();
                    if (file.Contains("eng"))
                    {
                        foreach (Table tb in aDoc.Tables)
                        {
                            var cell1 = tb.Cell(8, 2);
                            var cell2 = tb.Cell(9, 1);
                            var cell3 = tb.Cell(9, 2);
                            string text1 = cell1.Range.Text.Replace("\r\a", string.Empty);
                            string text2 = cell2.Range.Text.Replace("\r\a", string.Empty);
                            string text3 = cell3.Range.Text.Replace("\r\a", string.Empty);
                            string[] tokens1 = text1.Split(Environment.NewLine.ToCharArray());
                            string[] tokens2 = text2.Split(Environment.NewLine.ToCharArray());
                            string[] tokens3 = text3.Split(Environment.NewLine.ToCharArray());
                            for (int i = 0; i < tokens1.Length - 1; i++)
                            {
                                //string a3a=tokens1[i].Insert(0,"* ");
                                richTextBox1.AppendText(tokens1[i].Insert(0, "* "));
                                richTextBox1.AppendText(Environment.NewLine);
                                //MessageBox.Show(v);
                                //test1.Add(v);
                            }
                            richTextBox1.AppendText(tokens2[0].Insert(0, "* "));
                            richTextBox1.AppendText(Environment.NewLine);
                            for (int i3 = 0; i3 < tokens3.Length - 1; i3++)
                            {
                                richTextBox1.AppendText(tokens3[i3].Insert(0, "* "));
                                richTextBox1.AppendText(Environment.NewLine);
                            }
                        }
                    }
                    else
                    {
                        foreach (Table tb in aDoc.Tables)
                        {
                            var cell1 = tb.Cell(6, 2);
                            var cell2 = tb.Cell(7, 1);
                            var cell3 = tb.Cell(7, 2);
                            string text1 = cell1.Range.Text.Replace("\r\a", string.Empty);
                            string text2 = cell2.Range.Text.Replace("\r\a", string.Empty);
                            string text3 = cell3.Range.Text.Replace("\r\a", string.Empty);
                            string[] tokens1 = text1.Split(Environment.NewLine.ToCharArray());
                            string[] tokens2 = text2.Split(Environment.NewLine.ToCharArray());
                            string[] tokens3 = text3.Split(Environment.NewLine.ToCharArray());
                            for (int i = 0; i < tokens1.Length - 1; i++)
                            {
                                //string a3a=tokens1[i].Insert(0,"* ");
                                richTextBox1.AppendText(tokens1[i].Insert(0, "* "));
                                richTextBox1.AppendText(Environment.NewLine);
                                //MessageBox.Show(v);
                                //test1.Add(v);
                            }
                            richTextBox1.AppendText(tokens2[0].Insert(0, "* "));
                            richTextBox1.AppendText(Environment.NewLine);
                            for (int i3 = 0; i3 < tokens3.Length - 1; i3++)
                            {
                                richTextBox1.AppendText(tokens3[i3].Insert(0, "* "));
                                richTextBox1.AppendText(Environment.NewLine);
                            }
                        }
                    }

                    System.IO.File.WriteAllText(@"" + txtDestinationJob.Text + kosaCrta + "" + fileName1 + ".txt", richTextBox1.Text, Encoding.ASCII);
                    //System.Diagnostics.Process.Start(@"D:\text.txt");
                    aDoc.Close();
                }
               
               
            }
           
            wordApp.Quit();
            MessageBox.Show("Uspešno ste kreirali opis(e)!");
        }
        public string Generate(string name)
        {


            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txtSourceJob.Text = fbd.SelectedPath;
                txtDestinationJob.Text = fbd.SelectedPath;
                string[] files = Directory.GetFiles(fbd.SelectedPath);

                MessageBox.Show("Pronađeno fajlova: " + files.Length.ToString(), "Message");

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            DialogResult result = fbd.ShowDialog();

            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                txtDestinationJob.Text = fbd.SelectedPath;
                //string[] files = Directory.GetFiles(fbd.SelectedPath);
            }
        }
    }
}
