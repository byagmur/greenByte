using System;
using System.Windows.Forms;
using GreenByte.Models;
using GreenByte.DataAccess;

namespace greenByte.Forms
{
    public partial class FormGreenhouse : Form
    {

    
        public GreenHouseModel Greenhouse { get; private set; }
        private bool isEditing = false;

        public FormGreenhouse()
        {
            InitializeComponent();
            Greenhouse = new GreenHouseModel();
            this.Text = "Yeni Sera Ekle";

        }

        public FormGreenhouse(GreenHouseModel greenhouse)
        {
            InitializeComponent();
            Greenhouse = greenhouse;
            isEditing = true;
            this.Text = "Sera Düzenle";

            LogDataAccess.Add(new LogModel
            {
                UserId = CurrentUser.Id,
                LogType = LogType.Info,
                Message = $"Sera düzenleme formu açıldı. Sera ID: {greenhouse.Id}",
                LogTime = DateTime.Now
            });

            // Form yüklendiğinde mevcut değerleri doldur
            LoadGreenhouseData();
        }

        private void LoadGreenhouseData()
        {
            if (Greenhouse != null)
            {
                txtSeraAdi.Text = Greenhouse.Name;
                txtKonum.Text = Greenhouse.Location;
                dateTimePickerKurulusTarihi.Value = Greenhouse.EstablishmentDate;

                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = $"Sera verileri forma yüklendi. Sera: {Greenhouse.Name}",
                    LogTime = DateTime.Now
                });
            }
        }


        private void FormGreenhouse_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde gerekli işlemler
            if (!isEditing)
            {
                dateTimePickerKurulusTarihi.Value = DateTime.Now;

                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = "Yeni sera için varsayılan kuruluş tarihi ayarlandı",
                    LogTime = DateTime.Now
                });
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            LogDataAccess.Add(new LogModel
            {
                UserId = CurrentUser.Id,
                LogType = LogType.Info,
                Message = "Form kapatma düğmesine tıklandı",
                LogTime = DateTime.Now
            });

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            LogDataAccess.Add(new LogModel
            {
                UserId = CurrentUser.Id,
                LogType = LogType.Info,
                Message = "Form kapatılıyor",
                LogTime = DateTime.Now
            });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSeraAdi.Text))
            {
                MessageBox.Show("Sera adı boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = "Sera kaydetme işlemi başarısız: Sera adı boş bırakıldı",
                    LogTime = DateTime.Now
                });

                return;
            }

            try
            {
                string action = isEditing ? "güncellendi" : "oluşturuldu";

                Greenhouse.Name = txtGHName.Text;
                Greenhouse.Location = txtGHName.Text;
                Greenhouse.EstablishmentDate = dateTimePickerKurulusTarihi.Value;
                Greenhouse.UserId = CurrentUser.Id;

                var greenhouseDal = new GreenHouseDataAccess();
                greenhouseDal.Update(Greenhouse);

                MessageBox.Show("Sera başarıyla kaydedildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = $"Sera kaydetme işlemi başarılı. Sera: {Greenhouse.Name}",
                    LogTime = DateTime.Now
                });

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = $"Sera kaydetme sırasında hata: {ex.Message}",
                    LogTime = DateTime.Now
                });
            }
        }
    }
}