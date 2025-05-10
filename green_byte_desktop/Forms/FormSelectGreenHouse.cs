using GreenByte;
using GreenByte.DataAccess;
using GreenByte.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace greenByte.Forms
{
    public partial class FormSelectGreenHouse : Form
    {
        public Greenhouse SelectedGreenhouse { get; private set; }

        public FormSelectGreenHouse()
        {
            InitializeComponent();
            fillGreenHouseCombo();
        }

        private void fillGreenHouseCombo()
        {
            var user = CurrentUser.User;
            if (user == null)
                return;

            // Kullanıcıya ait seraları çek
            var greenhouseDal = new GreenHouseDataAccess();
            var greenhouses = greenhouseDal.GetAll()
                                           .Where(g => g.UserId == user.Id)
                                           .ToList();

            comboBoxGreenHouse.DataSource = greenhouses;
            comboBoxGreenHouse.DisplayMember = "Name";
            comboBoxGreenHouse.ValueMember = "Id";
            if (greenhouses.Count > 0)
                comboBoxGreenHouse.SelectedIndex = 0;
        }

        private void buttonDevam_Click(object sender, EventArgs e)
        {
            SelectedGreenhouse = comboBoxGreenHouse.SelectedItem as Greenhouse;
            if (SelectedGreenhouse == null)
            {
                MessageBox.Show("Lütfen bir sera seçiniz!");
                return;
            }

            // Seçili serayı global olarak ata
            CurrentGreenhouse.Selected = SelectedGreenhouse;

            // Ana forma yönlendir
            var mainForm = new FormMain();
            mainForm.Show();
            this.Hide();
        }

        private void buttonBackToLogin_Click(object sender, EventArgs e)
        {
            // Login sayfasına geri git
            var loginForm = new FormLogin();
            loginForm.Show();
            this.Hide();
        }
    }
}
