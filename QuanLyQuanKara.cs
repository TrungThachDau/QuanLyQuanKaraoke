using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanLyQuanKara
{
    public partial class QuanLyQuanKara : Form
    {
        
        public QuanLyQuanKara()
        {
            InitializeComponent();
        }

        public QuanLyQuanKara(account acc)
        {
            InitializeComponent();
            this.account = acc;
        }
        #region variables
        private account account = new account();
        public static int width = 90;
        public static int height = width;
        private int? currentRoomId;
        CultureInfo culture = CultureInfo.GetCultureInfo("vi-Vn");
        private double pricePerSecone = 1000;
        #endregion

        #region method
        private void loadRoomField()
        {
            flp_room.Controls.Clear();
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var Rooms = db.Rooms.Where(r => r.isDelete == 0).ToList();
                foreach (var room in Rooms)
                {
                    Button btn = new Button();
                    btn.Width= width;
                    btn.Height= height;
                    btn.Text = room.Name;
                    btn.Text += Environment.NewLine + room.status;
                    btn.Tag = room.id;
                    btn.Click += btn_click;
                    if(room.status == "trống")
                    {
                        btn.BackColor = Color.Lime;
                    }
                    else
                    {
                        btn.BackColor = Color.Pink;
                    }
                    flp_room.Controls.Add(btn);
                }
            }
        }
        private void btn_click(object sender, EventArgs e)
        {
            lw_displayBill.Items.Clear();
            using(QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                //lấy ra id của phòng vừa chọn 
                int id = (int)(sender as Button).Tag;
                currentRoomId = id;
                // hiển thị tên phòng dc chọn 
                lb_currentRoom.Text = id.ToString();
                //lấy bill của phòng dc chọn nếu không có bill kết thúc
                var obj = db.bills.Where(b => b.idRoom == id && b.status == 0).FirstOrDefault();
                if (obj == null)
                {
                    updateTotalprice();
                    return;
                }
                //lấy bill info của bill dc chon đưa lên listview 
                loadListView(obj.id);
            }
        }
        private void loadListView(int id)
        {
            lw_displayBill.Items.Clear();
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var billInfos = db.billInfos.Where(bif => bif.idBill == id).ToList();
                foreach (var item in billInfos)
                {
                    ListViewItem lv = new ListViewItem();
                    var food = db.foods.Where(f => f.id == item.idFood).FirstOrDefault();
                    lv.Text = food.Name;
                    lv.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = food.price.ToString() });
                    lv.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.count.ToString() });
                    lv.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = (food.price * item.count).ToString() });
                    lw_displayBill.Items.Add(lv);
                }
            }
            updateTotalprice();
        }
        private void updateTotalprice()
        {
            double totalprice = 0;
            int roomTime = 0;
            if (currentRoomId != null)
            {
                using (QL_karaokeDataContext db = new QL_karaokeDataContext())
                {
                    var bill = db.bills.Where(b => b.idRoom == currentRoomId && b.status == 0).FirstOrDefault();
                    if (bill != null)
                    {

                        var billInfos = db.billInfos.Where(bif => bif.idBill == bill.id).ToList();
                        foreach (var item in billInfos)
                        {
                            var food = db.foods.Where(f => f.id == item.idFood).FirstOrDefault();
                            totalprice += food.price * item.count;
                        }
                        roomTime = Convert.ToInt32((DateTime.Now - bill.dateCheckIn).TotalMinutes);
                        double roomPrice = pricePerSecone * roomTime;
                        txt_roomPrice.Text = roomPrice.ToString("c", culture);
                        txt_time.Text = roomTime.ToString();
                        totalprice += roomPrice;
                    }
                    else
                    {
                        txt_time.Text = "";
                        txt_roomPrice.Text = "";
                    }


                }
            }
            double discount = totalprice * 0.01 * (int)nud_discount.Value;
            totalprice -= discount;
            txt_totalPrice.Text = totalprice.ToString("c", culture);

        }
        private void loadCboCategory()
        {
            cbo_category.DataSource = null;
            using(QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = db.foodCategories.Where(c => c.isDelete == 0).ToList();
                cbo_category.DataSource= obj;
                cbo_category.DisplayMember= "Name";
                cbo_category.ValueMember = "id";
            }
        }
        private void loadCboFood(int id)
        {
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                cbo_food.DataSource = null;
                var obj = db.foods.Where( f => f.idCategory == id && f.isDelete == 0 ).ToList();
                cbo_food.DataSource = obj;
                cbo_food.DisplayMember = "Name";
                cbo_food.ValueMember = "id";
            }
        }

        #endregion


        #region event
        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void quảnLýToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void QuanLyQuanKara_Load(object sender, EventArgs e)
        {
            loadRoomField();
            loadCboCategory();
            loadCboFood(1);
            if(account.type == 0)
            {
                tt_admin.Enabled= false;
            }
            lb_Displayname.Text = account.displayName;
        }
        private void cbo_category_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadCboFood((int)cbo_category.SelectedValue);
        }
        private void nud_discount_ValueChanged(object sender, EventArgs e)
        {
            updateTotalprice();
        }
        private void btn_addFood_Click(object sender, EventArgs e)
        {
            // kiểm tra input
            {
                if (currentRoomId == null)
                {
                    MessageBox.Show("chưa chọn phòng");
                    return;
                }
                if (cbo_food.SelectedValue == null)
                {
                    MessageBox.Show("chưa chọn móm");
                    return;
                }
                if (nud_quantity.Value <= 0)
                {
                    MessageBox.Show("chưa chọn số lượng món");
                    return;
                }
            }

            using(QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                // kiểm tra xem phòng dc chọn có đang hoạt động hay ko

                var currentbill = db.bills.Where(b => b.idRoom == currentRoomId && b.status == 0).FirstOrDefault();
                // nếu không hoạt động thông báo có muốn đạt phòng này hay ko
                // nếu không kết thúc 
                if(currentbill == null)
                {
                    DialogResult result =  MessageBox.Show("phòng này chưa dc đặt ban có muốn đặt phòng ngay", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    // nếu không kết thúc 
                    if (result == DialogResult.No) return;
                    //nếu có đổi trạng thái của phòng và thêm bill cho phòng này
                    //lấy phòng ra để chỉnh sửa
                    var room = db.Rooms.Where(r => r.id == currentRoomId).FirstOrDefault();
                    room.status = "có người";
                    // tạo bill mới cho phòng này
                    {
                        bill Newbill = new bill();
                        Newbill.idRoom = room.id;
                        Newbill.dateCheckIn = DateTime.Now;
                        db.bills.InsertOnSubmit(Newbill);
                    }
                    db.SubmitChanges();
                    // lấy lại bill 
                    currentbill = db.bills.Where(b => b.idRoom == currentRoomId && b.status == 0).FirstOrDefault();
                }

                //xem mon an da ton tai hay chua 
                {
                    var thisFood = db.billInfos.Where(b => b.idBill == currentbill.id && b.idFood == (int)cbo_food.SelectedValue).FirstOrDefault();
                    // nếu món ăn này tồn tại thì + số lượng tương ứng
                    if(thisFood != null)
                    {
                        thisFood.count += (int)nud_quantity.Value;
                    }
                    else
                    {
                        // nếu chưa có thêm bill info cho thức ăn vừa nhập
                        billInfo newbillInfo = new billInfo();
                        newbillInfo.idBill = currentbill.id;
                        newbillInfo.idFood = (int)cbo_food.SelectedValue;
                        newbillInfo.count = (int)nud_quantity.Value;
                        db.billInfos.InsertOnSubmit(newbillInfo);

                    }
                    db.SubmitChanges();
                }
                
                loadRoomField();
                loadListView(currentbill.id);
                
            }
        }
        private void btn_pay_Click(object sender, EventArgs e)
        {
            // kiêm tra input |phòng trống| chọn phòng |
            if(currentRoomId == null)
            {
                MessageBox.Show("chưa chọn phòng");
                return;
            }
            using(QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var bill = db.bills.Where(b => b.idRoom == currentRoomId && b.status == 0).FirstOrDefault();
                if(bill == null)
                {
                    MessageBox.Show("phòng này chưa được đặt");
                    return;
                }

                // nếu phòng này đang được đặt set check out và trạng thái sang đã thanh toán
                bill.dateCheckOut = DateTime.Now;
                bill.status = 1;
                string stringNumber = "";
                foreach (var item in txt_totalPrice.Text)
                {
                    if (char.IsDigit(item))
                    {
                        stringNumber += item;
                    }
                }
                bill.totalPrice = Convert.ToDouble(stringNumber) / 100;
                bill.discount = (int) nud_discount.Value;

                db.Rooms.Where(r => r.id == currentRoomId).FirstOrDefault().status = "trống";
                updateTotalprice();
                DialogResult qk = MessageBox.Show(
                    "xác nhận thanh toán" + "\ntổng tiền: " + txt_totalPrice.Text,
                    "thanh toán",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                    );
                if (qk == DialogResult.No)
                    return;
               
                db.SubmitChanges();
                loadRoomField();
                lw_displayBill.Items.Clear();
                updateTotalprice();
            }
        }
        private void txt_timeCheck_Click(object sender, EventArgs e)
        {
            updateTotalprice();
        }
        #endregion

        private void thôngTinCáToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountInfo f = new AccountInfo(account);
            f.ShowDialog();
            
        }

        private void flp_room_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void thôngTinTàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void giớiThiệuVềPhầnMềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about a = new about();
            a.ShowDialog();
        }

        private void quảnLýToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            admin a = new admin();
            this.Hide();
            a.ShowDialog();
            this.Show();
        }

        private void thoátToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lw_displayBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbo_category_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
