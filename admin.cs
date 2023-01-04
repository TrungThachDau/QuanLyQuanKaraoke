using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
namespace quanLyQuanKara
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();

        }
        private void XuatExcel(DataGridView dgv)
        {

            Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
            XcelApp.Application.Workbooks.Add(Type.Missing);

            for (int i = 1; i < dgv.Columns.Count + 1; i++)
            {
                XcelApp.Cells[1, i] = dgv.Columns[i - 1].HeaderText;
            }

            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.Columns.Count; j++)
                {
                    XcelApp.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value.ToString();
                }
            }
            XcelApp.Columns.AutoFit();
            XcelApp.Visible = true;
        }
        #region 
        CultureInfo cul = new CultureInfo("vi-Vn");
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        #region method
        private void loadDayTimepiker()
        {
            DateTime today = DateTime.Now;
            dtp_start.Value = new DateTime(today.Year, today.Month, 1);
            dtp_end.Value = dtp_start.Value.AddMonths(1).AddDays(-1);
        }
        private void loadDatagridviewToTal()
        {
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                dgv_Total.DataSource = null;
                var obj = from b in db.bills
                          from r in db.Rooms
                          where r.id == b.idRoom && b.dateCheckIn > dtp_start.Value && b.dateCheckOut < dtp_end.Value
                          select new
                          {
                              TenPhong = r.Name,
                              TongTien = b.totalPrice,
                              dateIn = b.dateCheckIn,
                              dateOut = b.dateCheckOut,
                              discount = b.discount
                          };

                dgv_Total.DataSource = obj;
            }
        }
        private void updateDgvFood()
        {
            dtgv_food.DataSource = null;
            using(QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = from f in db.foods
                          from c in db.foodCategories
                          where f.idCategory == c.id && f.Name.Contains(txt_SearchFood.Text)
                          select new
                          {
                              FoodID = f.id,
                              FoodName = f.Name,
                              FoodPrice = f.price,
                              CategoryName = c.Name,
                              IsDelete = f.isDelete == 0 ? "còn" : "Đã xóa"
                          };
                dtgv_food.DataSource = obj;
            }
        }
        private void updateDgvCategory()
        {
            dtgvCategory.DataSource = null;
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = from c in db.foodCategories
                          where c.Name.Contains(txtSearchCategory.Text)
                          select new
                          {
                              CategoryID= c.id,
                              CategoryName = c.Name,
                              IsDelete = c.isDelete == 0 ? "còn" : "Đã xóa"
                          };
                dtgvCategory.DataSource = obj;
            }
        }
        private void updateDgvRoom()
        {
            dtgvRoom.DataSource = null;
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = from r in db.Rooms
                          where r.Name.Contains(txtSearchRoom.Text)
                          select new
                          {
                              RoomID= r.id,
                              RoomName = r.Name,
                              RoomStatus = r.status,
                              IsDelete = r.isDelete == 0 ? "còn" : "Đã xóa"
                          };
                dtgvRoom.DataSource = obj;
            }
        }
        private void updateDgvAccount()
        {
            dtgvAcc.DataSource = null;
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = from a in db.accounts
                          where a.userName.Contains(txtSearchAcc.Text) || a.displayName.Contains(txtSearchAcc.Text)
                          select new
                          {
                              accountID = a.id,
                              displayName = a.displayName,
                              userName = a.userName,
                              password = a.password,
                              type = a.type
                          };
                dtgvAcc.DataSource = obj;
            }
        }
        private void loadCboFood()
        {
            cbo_CategoryFood.DataSource = null;
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = db.foodCategories.ToList();
                cbo_CategoryFood.DataSource = obj;
                cbo_CategoryFood.DisplayMember = "Name";
                cbo_CategoryFood.ValueMember = "ID";
            }
        }
        private void selectCboFoodByFoodId(int id)
        {
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = db.foodCategories.Where(c => c.id == id).FirstOrDefault();
                if (obj == null) { return; }
                cbo_CategoryFood.SelectedIndex = cbo_CategoryFood.FindStringExact(obj.Name);

            }
        }
        private void messageExist()
        {
            MessageBox.Show("không tồn tại thực thể này");
        }
        private void messageNotSelect()
        {
            MessageBox.Show("chưa chọn trường nào");
        }
        private void updateTongTien()
        {
            double totalPrice = 0;
            foreach (DataGridViewRow item in dgv_Total.Rows)
            {
                totalPrice += Convert.ToDouble(item.Cells[1].Value.ToString());
                
            }
            txt_total.Text = totalPrice.ToString("c", cul);
        }

        private bool messageEcceept()
        {
            DialogResult r = MessageBox.Show("bạn có muốn lưu/ thay đổi giá trị này", "xác nhận thay đổi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                return true;
            return false;
        }
        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////////////
        #region event
        private void admin_Load(object sender, EventArgs e)
        {
            loadDayTimepiker();
            loadDatagridviewToTal();
            updateDgvFood();
            updateDgvCategory();
            updateDgvRoom();
            updateDgvAccount();
            loadCboFood();
            updateTongTien();
        }
        //////////////////////////////////////FOOD///////////////////////////////////////////////
        #region foodTab
        private void btnSearchFood_Click(object sender, EventArgs e)
        {
            updateDgvFood();
        }
        private void txt_SearchFood_TextChanged(object sender, EventArgs e)
        {
            updateDgvFood();
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if(cbo_CategoryFood.SelectedValue == null) { return; }
            food newfood = new food();
            newfood.Name = txt_NameFood.Text;
            newfood.idCategory = (int)cbo_CategoryFood.SelectedValue;
            newfood.price = Convert.ToDouble(NumPriceFood.Value);
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                db.foods.InsertOnSubmit(newfood);
                if (!messageEcceept())
                    return;
                db.SubmitChanges();
                updateDgvFood();
            }
        }
        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            if(txtIdFood.Text == "")
            {
                messageNotSelect();
                return;
            }
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var foodDelete = db.foods.Where(f => f.id == Convert.ToInt32(txtIdFood.Text)).FirstOrDefault();
                if(foodDelete == null) { messageExist(); return; }
                bool hasItem = db.billInfos.Where(c => c.idFood == foodDelete.id).Count() > 0;
                if (hasItem)
                {
                    foodDelete.isDelete = 1;
                }
                else
                {
                    db.foods.DeleteOnSubmit(foodDelete);
                }
                foodDelete.isDelete = 1;
                if (!messageEcceept())
                    return;
                db.SubmitChanges();
            }
            updateDgvFood();
        }
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            if (txtIdFood.Text == "")
            {
                messageNotSelect();
                return;
            }
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var foodEditing = db.foods.Where(f => f.id == Convert.ToInt32(txtIdFood.Text)).FirstOrDefault();
                if(foodEditing == null) { messageExist(); return; }
                foodEditing.Name = txt_NameFood.Text;
                foodEditing.idCategory = (int)cbo_CategoryFood.SelectedValue;
                foodEditing.price = Convert.ToDouble(NumPriceFood.Value);
                if (!messageEcceept())
                    return;
                db.SubmitChanges();
                updateDgvFood();
                
            }
        }
        private void dtgv_food_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)dtgv_food.SelectedCells[0].OwningRow.Cells[0].Value;
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                food newFood = db.foods.Where(f => f.id == i).FirstOrDefault();
                if (newFood == null) { }
                else
                {
                    txtIdFood.Text = newFood.id.ToString();
                    txt_NameFood.Text = newFood.Name.ToString();
                    loadCboFood();
                    selectCboFoodByFoodId(newFood.idCategory);
                    NumPriceFood.Value = Convert.ToDecimal(newFood.price);
                }

            }
        }
        #endregion
        ///////////////////CATEGORY//////////////////////
        #region categoryTab
        private void btnSearchCategory_Click(object sender, EventArgs e)
        {
            updateDgvCategory();
        }
        private void txtSearchCategory_TextChanged(object sender, EventArgs e)
        {
            updateDgvCategory();
        }
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            foodCategory newFoodCategory = new foodCategory();
            newFoodCategory.Name = txt_categoryName.Text;
            using(QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                db.foodCategories.InsertOnSubmit(newFoodCategory);
                db.SubmitChanges();
                if (!messageEcceept())
                    return;
                updateDgvCategory();
            }
        }
        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if(txtIdCategory.Text == "")
            {
                messageNotSelect();
                return;
            }
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = db.foodCategories.Where(c => c.id == Convert.ToInt32(txtIdCategory.Text)).FirstOrDefault();
                if (obj == null) { messageExist(); return; }
                bool hasItem = db.foods.Where(c => c.idCategory == obj.id).Count() > 0;
                if(hasItem)
                {
                    obj.isDelete = 1;
                }
                else
                {
                    db.foodCategories.DeleteOnSubmit(obj);
                }
                if (!messageEcceept())
                    return;
                db.SubmitChanges();
                updateDgvCategory();

            }
        }
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            if (txtIdCategory.Text == "")
            {
                messageNotSelect();
                return;
            }
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var categoryEditing = db.foodCategories.Where(f => f.id == Convert.ToInt32(txtIdCategory.Text)).FirstOrDefault();
                if(categoryEditing == null) { messageExist(); return; }
                categoryEditing.Name = txt_categoryName.Text;
                if (!messageEcceept())
                    return;
                db.SubmitChanges();
                updateDgvFood();
            }
        }
        private void dtgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)dtgvCategory.SelectedCells[0].OwningRow.Cells[0].Value;
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                foodCategory newCategoryFood = db.foodCategories.Where(c => c.id == i).FirstOrDefault();
                if (newCategoryFood == null) { }
                else
                {
                    txt_categoryName.Text = newCategoryFood.Name;
                    txtIdCategory.Text = newCategoryFood.id.ToString();
                }
            }
        }


        #endregion
        ////////////////////ROOM/////////////////////////
        #region roomtab
        private void txtSearchRoom_TextChanged(object sender, EventArgs e)
        {
            updateDgvRoom();
        }
        private void btnSearchRoom_Click(object sender, EventArgs e)
        {
            updateDgvRoom();
        }
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            Room newRoom = new Room();
            newRoom.Name = txtNameRoom.Text;
            newRoom.status = "trống";
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                db.Rooms.InsertOnSubmit(newRoom);
                if (!messageEcceept())
                    return;
                db.SubmitChanges();
                updateDgvRoom();
            }

        }
        private void btnRemoveRoom_Click(object sender, EventArgs e)
        {
            if (txt_IdRoom.Text == "")
            {
                messageNotSelect();
                return;
            }
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = db.Rooms.Where(r => r.id == Convert.ToInt32(txt_IdRoom.Text)).FirstOrDefault();
                if (obj == null) { messageExist(); return; }
                bool hasItem = db.bills.Where(c => c.idRoom == obj.id).Count() > 0;
                if (hasItem)
                {
                    obj.isDelete = 1;
                }
                else
                {
                    db.Rooms.DeleteOnSubmit(obj);
                }
                if (!messageEcceept())
                    return;
                db.SubmitChanges();
                updateDgvRoom();
            }
        }
        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            if (txt_IdRoom.Text == "")
            {
                messageNotSelect();
                return;
            }
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = db.Rooms.Where(r => r.id == Convert.ToInt32(txt_IdRoom.Text)).FirstOrDefault();
                if(obj == null) { messageExist(); return; }
                obj.Name= txtNameRoom.Text;
                db.SubmitChanges();
                if (!messageEcceept())
                    return;
                updateDgvRoom();
            }
        }
        private void dtgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)dtgvRoom.SelectedCells[0].OwningRow.Cells[0].Value;
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                Room newRoom = db.Rooms.Where(c => c.id == i).FirstOrDefault();
                if (newRoom == null) { }
                else
                {
                    txtNameRoom.Text = newRoom.Name;
                    txt_IdRoom.Text = newRoom.id.ToString();
                }
            }
        }
        #endregion
        ////////////////////ACCOUNT//////////////////////
        #region accountTab
        private void txtSearchAcc_TextChanged(object sender, EventArgs e)
        {
            updateDgvAccount();
        }
        private void btnSearcgAcc_Click(object sender, EventArgs e)
        {
            updateDgvAccount();
        }
        private void btnAddAcc_Click(object sender, EventArgs e)
        {
            if(txtDisplayNameAcc.Text == "" || txtUserNameAcc.Text == "" || txtPasswordAcc.Text == "")
            {
                messageNotSelect();
                return;
            }
            account newAccout = new account();
            newAccout.displayName = txtDisplayNameAcc.Text;
            newAccout.userName = txtUserNameAcc.Text;
            newAccout.password = txtPasswordAcc.Text;
            newAccout.type = (int)nud_typeAccount.Value;
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                db.accounts.InsertOnSubmit(newAccout);
                db.SubmitChanges();
                if (!messageEcceept())
                    return;
                updateDgvAccount();
            }
        }
        private void btnDeleteAcc_Click(object sender, EventArgs e)
        {
            if (txtIdAcc.Text == "")
            {
                messageNotSelect();
                return;
            }
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = db.accounts.Where(r => r.id == Convert.ToInt32(txtIdAcc.Text)).FirstOrDefault();
                if(obj == null) { messageExist(); return; }
                db.accounts.DeleteOnSubmit(obj);
                db.SubmitChanges();
                if (!messageEcceept())
                    return;
                updateDgvAccount();
            }
        }
        private void btnEditAcc_Click(object sender, EventArgs e)
        {
            if (txtIdAcc.Text == "")
            {
                messageNotSelect();
                return;
            }
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = db.accounts.Where(r => r.id == Convert.ToInt32(txtIdAcc.Text)).FirstOrDefault();
                if(obj == null) { messageExist(); return; }
                obj.userName = txtUserNameAcc.Text;
                obj.password = txtPasswordAcc.Text;
                obj.displayName= txtDisplayNameAcc.Text;
                obj.password = txtPasswordAcc.Text;
                if (!messageEcceept())
                    return;
                db.SubmitChanges();
                updateDgvAccount();
            }
        }
        private void dtgvAcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = (int)dtgvAcc.SelectedCells[0].OwningRow.Cells[0].Value;
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                account newAccount = db.accounts.Where(c => c.id == i).FirstOrDefault();
                if (newAccount == null) { }
                else
                {
                    txtDisplayNameAcc.Text = newAccount.displayName;
                    txtUserNameAcc.Text = newAccount.userName;
                    txtPasswordAcc.Text = newAccount.password;
                    txtIdAcc.Text = newAccount.id.ToString();
                    nud_typeAccount.Text = newAccount.type.ToString();
                }
            }
        }
        #endregion
        ////////////////////TOTAL////////////////////////
        #region total
        private void btn_fill_Click(object sender, EventArgs e)
        {
            loadDatagridviewToTal();
            updateTongTien();
        }

        private void btn_reOpenFood_Click(object sender, EventArgs e)
        {
            if (txtIdFood.Text == "")
            {
                messageNotSelect();
                return;
            }
            using(QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = db.foods.Where(f => f.id == Convert.ToInt32(txtIdFood.Text)).FirstOrDefault();
                if (obj == null) { messageExist(); return; }
                obj.isDelete = 0;
                db.SubmitChanges();
                updateDgvFood();
            }

        }

        private void btn_reOpenCategory_Click(object sender, EventArgs e)
        {
            if (txtIdCategory.Text == "")
            {
                messageNotSelect();
                return;
            }
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = db.foodCategories.Where(f => f.id == Convert.ToInt32(txtIdCategory.Text)).FirstOrDefault();
                if (obj == null) { messageExist(); return; }
                obj.isDelete = 0;
                db.SubmitChanges();
                updateDgvCategory();
            }
        }

        private void btn_reOpenRoom_Click(object sender, EventArgs e)
        {
            if (txt_IdRoom.Text == "")
            {
                messageNotSelect();
                return;
            }
            using (QL_karaokeDataContext db = new QL_karaokeDataContext())
            {
                var obj = db.Rooms.Where(f => f.id == Convert.ToInt32(txt_IdRoom.Text)).FirstOrDefault();
                if (obj == null) { messageExist(); return; }
                obj.isDelete = 0;
                db.SubmitChanges();
                updateDgvRoom();
            }
        }

        private void tbFoods_Click(object sender, EventArgs e)
        {

        }

        private void btnXuatxls_Click(object sender, EventArgs e)
        {
            if (dtgv_food.Rows.Count > 0)
            {
                MessageBox.Show("Xuất thành công");
                XuatExcel(dgv_Total);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất");
            }
        }
        
        private void btnXuatThucAn_Click(object sender, EventArgs e)
        {
            if(dtgv_food.Rows.Count>0)
            {
                MessageBox.Show("Xuất thành công");
                XuatExcel(dtgv_food);
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để xuất");
            }
        }

        private void dtgv_food_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtIdFood_TextChanged(object sender, EventArgs e)
        {

        }


        #endregion

        #endregion
        //////////////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////////////
    }
}
