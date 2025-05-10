using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using greenByte.Forms;
using GreenByte.DataAccess;
using GreenByte.Models;

namespace greenByte.Pages
{
    public partial class UsersControlPage : UserControl
    {
        private UserDataAccess userDal = new UserDataAccess();

        public UsersControlPage()
        {
            
            InitializeComponent();
            LoadUsers();
            StyleDataGrid();
        }

        private void LoadUsers()
        {
            var seraId = CurrentGreenhouse.Selected?.Id ?? 0;

            var users = userDal.GetAll();

            // Filtreleme ve DataGridView doldurma
            var filteredUsers = users.Where(u => u.GreenhouseId == seraId).ToList();

            dataGridViewKullanicilar.DataSource = filteredUsers;

            // Kolon başlıklarını düzenle
            dataGridViewKullanicilar.Columns["Id"].HeaderText = "ID";
            dataGridViewKullanicilar.Columns["Id"].Visible = false;
            dataGridViewKullanicilar.Columns["Username"].HeaderText = "Kullanıcı Adı";
            dataGridViewKullanicilar.Columns["Email"].HeaderText = "E-posta";
            dataGridViewKullanicilar.Columns["RegistrationDate"].HeaderText = "Kayıt Tarihi";
            dataGridViewKullanicilar.Columns["GreenhouseId"].HeaderText = "Sera ID";
            dataGridViewKullanicilar.Columns["GreenhouseId"].Visible = false;
            dataGridViewKullanicilar.Columns["Password"].Visible = false; // Şifreyi gizle
        }

        private void StyleDataGrid()
        {
            var dgv = dataGridViewKullanicilar;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 125, 50);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 230, 201);
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.LightGray;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowTemplate.Height = 32;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(232, 245, 233);
        }

        private void btnKullaniciEkle_Click(object sender, EventArgs e)
        {
            var form = new FormUser();
            try{
             if (form.ShowDialog() == DialogResult.OK)
            {
                userDal.Add(form.User);
                // Log ekle
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = $"{form.User.Username} adlı kullanıcı eklendi.",
                    LogTime = DateTime.Now
                });
                LoadUsers();
            } 
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = "Kullanıcı Ekleme Hatası: " + ex.Message,
                    LogTime = DateTime.Now
                });
            }
            
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridViewKullanicilar.CurrentRow == null) return;
            var selectedUser = dataGridViewKullanicilar.CurrentRow.DataBoundItem as UserModel;
            if (selectedUser == null) return;

            var userCopy = new UserModel
            {
                Id = selectedUser.Id,
                Username = selectedUser.Username,
                Email = selectedUser.Email,
                Password = selectedUser.Password,
                RegistrationDate = selectedUser.RegistrationDate,
                GreenhouseId = selectedUser.GreenhouseId
            };

            var form = new FormUser(userCopy);
            try{
            if (form.ShowDialog() == DialogResult.OK)
            {
                userDal.Update(form.User);
                // Log ekle
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = $"{form.User.Username} adlı kullanıcı güncellendi.",
                    LogTime = DateTime.Now
                });
                LoadUsers();
                MessageBox.Show("Kullanıcı başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = "Kullanıcı Güncelleme Hatası: " + ex.Message,
                    LogTime = DateTime.Now
                });
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewKullanicilar.CurrentRow == null) return;
            var selectedUser = dataGridViewKullanicilar.CurrentRow.DataBoundItem as UserModel;
            if (selectedUser == null) return;

            var result = MessageBox.Show("Kullanıcıyı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try{
                userDal.Delete(selectedUser.Id);
                // Log ekle
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = $"{selectedUser.Username} adlı kullanıcı silindi.",
                    LogTime = DateTime.Now
                });
                LoadUsers();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogDataAccess.Add(new LogModel
                    {
                        UserId = CurrentUser.Id,
                        LogType = LogType.Error,
                        Message = "Kullanıcı Silme Hatası: " + ex.Message,
                        LogTime = DateTime.Now
                    });
                }
            }
        }

        private void buttonRefreshData_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }
    }
}
