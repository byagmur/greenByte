using greenByte.Forms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace GreenByte
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Kenarlıksız form
            this.StartPosition = FormStartPosition.CenterScreen; // Ekranın ortasında başlat
            
            // Gradient panel için Paint olayı
            gradientPanel.Paint += (s, e) =>
            {
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    gradientPanel.ClientRectangle,
                    Color.FromArgb(180, 27, 94, 32),
                    Color.FromArgb(100, 27, 94, 32),
                    LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, gradientPanel.ClientRectangle);
                }
            };

            // Focus olayları
            userTextBox.Enter += (s, e) => userUnderlinePanel.BackColor = Color.FromArgb(46, 125, 50);
            userTextBox.Leave += (s, e) => userUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224);

            passwordTextBox.Enter += (s, e) => passwordUnderlinePanel.BackColor = Color.FromArgb(46, 125, 50);
            passwordTextBox.Leave += (s, e) => passwordUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224);

            // Giriş butonu için Click olayı
            loginButton.Click += LoginButton_Click;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Panel rightPanel = this.Controls[0].Controls[2] as Panel;
            TextBox userTextBox = rightPanel.Controls[3] as TextBox;
            TextBox passwordTextBox = rightPanel.Controls[6] as TextBox;

            string username = userTextBox.Text;
            string password = passwordTextBox.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Kullanıcı adı ve şifre boş bırakılamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
   
                using (var connection = DBContext.GetConnection())
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM kullanicilar WHERE kullanici_adi = @username AND sifre = @password";
                    
                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            MessageBox.Show("Giriş başarılı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormMain mainForm = new FormMain();
                            mainForm.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bağlantı hatası: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegisterLink_Click(object sender, EventArgs e)
        {
            // Kayıt formunu açma kodları buraya gelecek
            // RegisterForm registerForm = new RegisterForm();
            // registerForm.Show();
            // this.Hide();
        }

        // Form kenarlıklarının yuvarlak olması için
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Formun kenarları için yuvarlak köşe çiz
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 5;

            path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
            path.AddArc(this.Width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
            path.AddArc(this.Width - radius * 2, this.Height - radius * 2, radius * 2, radius * 2, 0, 90);
            path.AddArc(0, this.Height - radius * 2, radius * 2, radius * 2, 90, 90);

            path.CloseAllFigures();

            this.Region = new Region(path);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}