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
    public partial class AccountInfo : Form
    {
        public AccountInfo()
        {
            InitializeComponent();
        }
        public AccountInfo(account _acc)
        {
            InitializeComponent();
            this.acc = _acc;
        }

        private account acc = new account();

        private void btn_conform_Click(object sender, EventArgs e)
        {
            if (txt_password.Text != txt_rePassword.Text)
            {
                MessageBox.Show("kiêm tra lại mật khẩu");
                return;
            }
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = db.accounts.Where(r => r.id == acc.id).FirstOrDefault();
                obj.displayName = txt_displayName.Text;
                obj.password = txt_password.Text;
                db.SubmitChanges();
                MessageBox.Show("thay đổi thông tin thành công \n vui lòng đang nhập lại để cập nhật tài khoản");
            }
        }

        private void AccountInfo_Load(object sender, EventArgs e)
        {
            txt_displayName.Text = acc.displayName;
        }
    }
}
