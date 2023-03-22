using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Diagnostics;

namespace VideoMergeProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string FilePath;
        public string FilePath2;
        public string FilePath3;

        public void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();

            // Dosya yolunu alır.
            FilePath = openFileDialog1.FileName;

            label1.Text = FilePath;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog2 = new OpenFileDialog();
            openFileDialog2.ShowDialog();

            // Dosya2 yolunu alır.
            FilePath2 = openFileDialog2.FileName;

            label2.Text = FilePath2;
        }

        public void Merge()
        {
            // VLC için dosya konumu değiştirilmeli.
            Process.Start("cmd.exe", "/c" + $"cd \"{FilePath3}\" & \"C:\\Program Files\\VideoLAN\\VLC\\vlc.exe\" \"{FilePath}\" \"{FilePath2}\" --sout \"" + "#gather:std{access=file,dst=videomerged.mp4}\" --sout-keep & taskkill /F /IM vlc.exe");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Merge();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();

            // Dosya3 yolunu alır.
            FilePath3 = folderBrowserDialog.SelectedPath;

            label3.Text = FilePath3;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
