using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyQuanKara
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkUserName();
            checkPassword();
        }


        private void checkUserName()
        {
            if(txt_UserName.Text == "")
            {
                errorProvider1.SetError(txt_UserName, "vui lòng không để trống trường này!");
            }
            else
                errorProvider1.SetError(txt_UserName, "");
        }

        private void checkPassword()
        {
            if (txt_PassWord.Text == "")
            {
                errorProvider1.SetError(txt_PassWord, "vui lòng không để trống trường này!");
            }
            else
                errorProvider1.SetError(txt_PassWord, "");
        }

        private void txt_UserName_TextChanged(object sender, EventArgs e)
        {
            checkUserName();
        }

        private void txt_PassWord_TextChanged(object sender, EventArgs e)
        {
            checkPassword();
        }

        private void txt_exit_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }

        private account login()
        {
            using(QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var user = db.accounts.Where(u => u.userName == txt_UserName.Text && u.password == txt_PassWord.Text).FirstOrDefault();
                if(user != null)
                {
                    return user;
                }
            }
            return null;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            account acc = login();
            if(acc == null)
            {
                MessageBox.Show("tài khoản mật khẩu không đúng");
                return;
            }
            QuanLyQuanKara f = new QuanLyQuanKara(acc);
            
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("bạn có muốn thoát!", "xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
