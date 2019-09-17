using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {

        int Counttemp = 0;


        private String docfile3()
        {
            String kq = "";
            string[] lines = File.ReadAllLines("config.inf");
            foreach (string s in lines)
            {
                kq = kq + s;
            }

            return kq;
        }
        public Form1()
        {
            InitializeComponent();
        }
        DateTime start = DateTime.Now;
        int count = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            string a;
            if (label9.Text.Trim() == "20")
            {
                xoa();
                start = DateTime.Now;
                a = (DateTime.Now - start).ToString();
                System.Diagnostics.Process.Start("chambai.jar");
                ghitemp();
            }
            else
            {
               
                a = (DateTime.Now - start).ToString();
            }
            DateTime passTime = DateTime.Parse(a);
            string b = passTime.ToLongTimeString().ToString();

            b = b.Substring(6, b.Length - 6);
            b = b.Substring(0, b.Length - 2);
            label9.Text = b;
      
          

   

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            xoa();


            button2.Hide();
            Counttemp = Convert.ToInt16(docfile3());
            txtTime.Text = "10:00";

          

        }


        void xoa()
        {
            try
            {
                String path = "C:\\Sysn\\Code_killer\\myKQ.txt";
                File.SetAttributes(path, 0);//Thiet lap lai cac thuoc tinh ve khong xac lap
                File.Delete(path);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            start = DateTime.Now;
            timer1.Enabled = true;
            button2.Show();
           
        }


        void ghiFile()
        {
            String dulieunhap = Counttemp.ToString();
            String filepath = "config.inf";// đường dẫn của file muốn tạo
            FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt            
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);//fs là 1 FileStream 
            sWriter.WriteLine(dulieunhap);
            sWriter.Flush();
            fs.Close();
        }


        void ghitemp()
        {
            String dulieunhap = "";
            String filepath = "C:\\Sysn\\Code_killer\\cookie"+Counttemp.ToString()+".txt";// đường dẫn của file muốn tạo
            FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt            
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);//fs là 1 FileStream 
            sWriter.WriteLine(dulieunhap);
            sWriter.Flush();
            fs.Close();
            Counttemp++;
        }



        void ghiDE(string a)
        {
            String dulieunhap = a;
            String filepath = "C:\\Sysn\\Code_killer\\myTest.txt";// đường dẫn của file muốn tạo
            FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt            
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);//fs là 1 FileStream 
            sWriter.WriteLine(dulieunhap);
            sWriter.Flush();
            fs.Close();
            Counttemp++;
        }

        void ghiConfig2(string a)
        {
            String dulieunhap = a;
            String filepath = "C:\\Sysn\\Code_killer\\config.inf";// đường dẫn của file muốn tạo
            FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt            
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);//fs là 1 FileStream 
            sWriter.WriteLine(dulieunhap);
            sWriter.Flush();
            fs.Close();
            Counttemp++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Hide();
            start = DateTime.Now;
            timer1.Enabled = false;
            label9.Text = "00";
            ghiFile();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ghiFile();
        }


        private String docfile()
        {
            String kq = "";
            string[] lines = File.ReadAllLines("C:\\Sysn\\Code_killer\\myKQ.txt");
            foreach (string s in lines)
            {
                kq = kq + s;
            }

            return kq;
        }
        int countx = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
      
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            ghiDE(richTextBox1.Text);
            ghitemp();
            ghiConfig2(txtTime.Text);
            ghitemp();
            btnSubmit.Enabled = false;
            ghitemp();
            ghitemp();
            ghitemp();
        }
    }
}
