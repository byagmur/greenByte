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
    public partial class GreenHouseManagementPage : UserControl
    {
        private GreenHouseDataAccess greenhouseDal = new GreenHouseDataAccess();

        public GreenHouseManagementPage()
        {
            InitializeComponent();
            Utils.StyleDataGrid(dataGridViewGreenHouses); // Ensure this is inside a method or constructor  
            LoadGreenhouses();
        }

        private void LoadGreenhouses()
        {
            var greenhouses = greenhouseDal.GetAll();
            dataGridViewGreenHouses.DataSource = greenhouses;

            // Kolon başlıklarını düzenle  
            dataGridViewGreenHouses.Columns["Id"].HeaderText = "ID";
            dataGridViewGreenHouses.Columns["Id"].Visible = false;
            dataGridViewGreenHouses.Columns["Name"].HeaderText = "Sera Adı";
            dataGridViewGreenHouses.Columns["Location"].HeaderText = "Konum";
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var form = new FormGreenhouse();
            try
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    greenhouseDal.Add(form.Greenhouse);
                    // Log ekle  
                    LogDataAccess.Add(new LogModel
                    {
                        UserId = CurrentUser.Id,
                        LogType = LogType.Info,
                        Message = $"{form.Greenhouse.Name} adlı sera eklendi.",
                        LogTime = DateTime.Now
                    });
                    LoadGreenhouses();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = "Sera Ekleme Hatası: " + ex.Message,
                    LogTime = DateTime.Now
                });
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            if (dataGridViewGreenHouses.CurrentRow == null) return;
            var selectedGreenhouse = dataGridViewGreenHouses.CurrentRow.DataBoundItem as GreenHouseModel;
            if (selectedGreenhouse == null) return;

            var greenhouseCopy = new GreenHouseModel
            {
                Id = selectedGreenhouse.Id,
                Name = selectedGreenhouse.Name,
                Location = selectedGreenhouse.Location,
                EstablishmentDate = selectedGreenhouse.EstablishmentDate
            };

            var form = new FormGreenhouse(greenhouseCopy);
            try
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    greenhouseDal.Update(form.Greenhouse);
                    // Log ekle  
                    LogDataAccess.Add(new LogModel
                    {
                        UserId = CurrentUser.Id,
                        LogType = LogType.Info,
                        Message = $"{form.Greenhouse.Name} adlı sera güncellendi.",
                        LogTime = DateTime.Now
                    });
                    LoadGreenhouses();
                    MessageBox.Show("Sera başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = "Sera Güncelleme Hatası: " + ex.Message,
                    LogTime = DateTime.Now
                });
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridViewGreenHouses.CurrentRow == null) return;
            var selectedGreenhouse = dataGridViewGreenHouses.CurrentRow.DataBoundItem as GreenHouseModel;
            if (selectedGreenhouse == null) return;

            var result = MessageBox.Show("Serayı silmek istediğinize emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    greenhouseDal.Delete(selectedGreenhouse.Id);
                    // Log ekle  
                    LogDataAccess.Add(new LogModel
                    {
                        UserId = CurrentUser.Id,
                        LogType = LogType.Info,
                        Message = $"{selectedGreenhouse.Name} adlı sera silindi.",
                        LogTime = DateTime.Now
                    });
                    LoadGreenhouses();
                    MessageBox.Show("Sera başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogDataAccess.Add(new LogModel
                    {
                        UserId = CurrentUser.Id,
                        LogType = LogType.Error,
                        Message = "Sera Silme Hatası: " + ex.Message,
                        LogTime = DateTime.Now
                    });
                }
            }
        }

        private void buttonRefreshData_Click(object sender, EventArgs e)
        {
            LoadGreenhouses();
        }
    }
}