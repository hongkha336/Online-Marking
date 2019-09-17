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

namespace Code_killer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        String time ="";
        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Enabled = false;
            button2.Hide();
            richTextBox3.Text = "CHÀO MỌI NGƯỜI, CHÚC MỌI NGƯỜI LÀM BÀI THẬT TỐT";
            panel2.Hide();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ghitemp();
            if (!txtName.Text.Trim().Equals(""))
            {
             
                richTextBox1.Enabled = true;
                richTextBox1.Focus();
                txtName.Enabled = false;
                start2 = DateTime.Now;
                timer2.Enabled = true;
                button2.Show();
                btnStart.Enabled = false;
                time = docfile3();
                label3.Text = time;
               
            }
            else
            {
                MessageBox.Show("Vui lòng điền tên file");
            }
        }

        void ghiFile()
        {
            String dulieunhap = richTextBox1.Text;
            String filepath = "C:\\Code_killer\\Code_killer\\"+txtName.Text+".cpp";// đường dẫn của file muốn tạo
            FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt            
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);//fs là 1 FileStream 
            sWriter.WriteLine(dulieunhap);
            sWriter.Flush();
            fs.Close();
        }

        void nop()
        {
            ghitemp();
            ghiFile();
            richTextBox1.Enabled = false;
            timer1.Enabled = true;
            timer2.Enabled = false;
            button1.Enabled = false;
            panel2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult tl = MessageBox.Show("Bạn chắc chắn nộp bài", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (tl == DialogResult.Yes)
                nop();
            
        }

        private String docfile()
        {
            String kq = "";
            try
            {
                string[] lines = File.ReadAllLines("C:\\Code_killer\\Code_killer\\myKQ.txt");
                foreach (string s in lines)
                {
                    kq = kq + s;
                }

            }
            catch
            { }
            return kq;
        }

        private String docfile2()
        {
            String kq = "";
            try
            {
                string[] lines = File.ReadAllLines("C:\\Code_killer\\Code_killer\\myTest.txt");
                foreach (string s in lines)
                {
                    kq = kq + s;
                }
            }
            catch
            { }

            return kq;
        }


        private String docfile3()
        {
            String kq = "";
            try
            {
                string[] lines = File.ReadAllLines("C:\\Code_killer\\Code_killer\\config.inf");
                foreach (string s in lines)
                {
                    kq = kq + s;
                }
            }
            catch {
                kq = "10:00";
            }

            return kq;
        }

        void xoa()
        {
            try
            {
                String path = "C:\\Code_killer\\Code_killer\\myKQ.txt";
                File.SetAttributes(path, 0);//Thiet lap lai cac thuoc tinh ve khong xac lap
                File.Delete(path);
            }
            catch { }
        }


        DateTime start = DateTime.Now;

        DateTime start2 = DateTime.Now;
        private void timer1_Tick(object sender, EventArgs e)
        {
            string a="";
            if (label9.Text.Trim() == "10" || label9.Text.Trim() == "30" || label9.Text.Trim() == "20" || label9.Text.Trim() == "40" || label9.Text.Trim() == "50" || label9.Text.Trim() == "59")
            {
                a = (DateTime.Now - start).ToString();
                String kq = docfile();
                string xx = takemark(kq);
                richTextBox2.Text = xx;
                if (label9.Text.Trim() == "30")
                { ghitemp();
                    xoa();
                }
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

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
          richTextBox3.Text = docfile2();
            button2.Hide();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            string a = "";
            if (label10.Text.Trim() == time)
            {
                a = (DateTime.Now - start2).ToString();
                nop();
                ghitemp();
                timer2.Enabled = false;
            }
            else
            {
                a = (DateTime.Now - start2).ToString();
            }

            DateTime passTime = DateTime.Parse(a);
            string b = passTime.ToLongTimeString().ToString();

           b = b.Substring(3, b.Length - 3);
           b = b.Substring(0, b.Length - 2);
            label10.Text = b;
        }



        void ghitemp()
        {
            Random rnd = new Random();
            int month = rnd.Next(5000, 100000);
            String dulieunhap = month.ToString();
            String filepath = "C:\\Code_killer\\Code_killer\\cookie"+month.ToString()+".txt";// đường dẫn của file muốn tạo
            FileStream fs = new FileStream(filepath, FileMode.Create);//Tạo file mới tên là test.txt            
            StreamWriter sWriter = new StreamWriter(fs, Encoding.UTF8);//fs là 1 FileStream 
            sWriter.WriteLine(dulieunhap);
            sWriter.Flush();
            fs.Close();
           
        }



        string takemark(String kq)
        {
            string xx = "";
            if (!kq.Trim().Equals(""))
            {
                string yourname = txtName.Text;
                for (int i = 0; i<kq.Length-yourname.Length;i++)
                {
                    if(kq.Substring(i,yourname.Length).Equals(yourname.Length))
                    {
                        xx = kq.Substring(i, yourname.Length + 6);
                        return xx;
                      
                    }
                }
             }
            return xx;
        }
    }
}
