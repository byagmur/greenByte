using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace GreenByte
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Kenarlıksız form
            this.StartPosition = FormStartPosition.CenterScreen; // Ekranın ortasında başlat
        }

        private void InitializeComponent()
        {
            // Form boyutlarını ayarla
            this.ClientSize = new Size(900, 620);
            this.Text = "GreenByte Sera Yönetim Sistemi - Kayıt";

            // Ana panel
            Panel mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.BackColor = Color.FromArgb(245, 245, 245);

            // Üst çubuk
            Panel topBar = new Panel();
            topBar.Size = new Size(900, 35);
            topBar.Location = new Point(0, 0);
            topBar.BackColor = Color.FromArgb(46, 125, 50); // #2E7D32

            // Başlık etiketi
            Label titleLabel = new Label();
            titleLabel.Text = "GreenByte Sera Yönetim Sistemi - Kayıt";
            titleLabel.ForeColor = Color.White;
            titleLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            titleLabel.Location = new Point(15, 8);
            titleLabel.AutoSize = true;

            // Çıkış düğmesi
            Button closeButton = new Button();
            closeButton.Size = new Size(30, 25);
            closeButton.Location = new Point(860, 5);
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.BackColor = Color.FromArgb(231, 76, 60); // #E74C3C
            closeButton.Text = "X";
            closeButton.ForeColor = Color.White;
            closeButton.Click += (s, e) => Application.Exit();

            // Sol panel (dekoratif alan)
            Panel leftPanel = new Panel();
            leftPanel.Size = new Size(445, 565);
            leftPanel.Location = new Point(0, 35);
            mainPanel.BackColor = Color.FromArgb(245, 245, 245);

            // Sol panel için arkaplan resmi
            PictureBox backgroundImage = new PictureBox();
            backgroundImage.Padding = new Padding(8, 0, 0, 0);
            backgroundImage.Size = new Size(440, 565);
            backgroundImage.Location = new Point(0, 0);
            backgroundImage.BackgroundImageLayout = ImageLayout.Stretch; // Resmi panele sığdır
            backgroundImage.BackgroundImage = Image.FromFile("C:\\Projects\\C#\\greenByte\\assets\\background.jpg");
            backgroundImage.BackColor = Color.FromArgb(245, 245, 245);

            // Yarı saydam gradient overlay panel
            Panel gradientPanel = new Panel();
            gradientPanel.Size = new Size(400, 565);
            gradientPanel.Location = new Point(0, 0);
            gradientPanel.BackColor = Color.Transparent;
            gradientPanel.Paint += (s, e) => {
                // Gradient efekti oluştur (soldan sağa doğru)
                using (LinearGradientBrush brush = new LinearGradientBrush(
                    gradientPanel.ClientRectangle,
                    Color.FromArgb(180, 27, 94, 32), // Başlangıç rengi (yarı saydam koyu yeşil)
                    Color.FromArgb(100, 27, 94, 32), // Bitiş rengi (daha saydam yeşil)
                    LinearGradientMode.Horizontal))
                {
                    e.Graphics.FillRectangle(brush, gradientPanel.ClientRectangle);
                }
            };

            // Slogan etiketi
            Label sloganLabel = new Label();
            sloganLabel.Text = "Akıllı Teknoloji, Verimli Tarım";
            sloganLabel.ForeColor = Color.White;
            sloganLabel.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            sloganLabel.Location = new Point(65, 500);
            sloganLabel.Size = new Size(270, 25);
            sloganLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Sağ panel (kayıt formu)
            Panel rightPanel = new Panel();
            rightPanel.Size = new Size(420, 565); 
            rightPanel.Location = new Point(420, 35); 
            mainPanel.BackColor = Color.FromArgb(245, 245, 245);

            // Kayıt başlığı
            Label welcomeLabel = new Label();
            welcomeLabel.Text = "Hesap Oluştur";
            welcomeLabel.ForeColor = Color.FromArgb(46, 125, 50); // #2E7D32
            welcomeLabel.Font = new Font("Segoe UI", 21, FontStyle.Bold);
            welcomeLabel.Location = new Point(125, 30);
            welcomeLabel.Size = new Size(250, 40);
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Alt başlık
            Label subTitleLabel = new Label();
            subTitleLabel.Text = "Sera yönetim sistemine kayıt olun";
            subTitleLabel.ForeColor = Color.FromArgb(117, 117, 117); // #757575
            subTitleLabel.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            subTitleLabel.Location = new Point(75, 70);
            subTitleLabel.Size = new Size(350, 30);
            subTitleLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Ad Soyad etiketi
            Label nameLabel = new Label();
            nameLabel.Text = "Ad Soyad";
            nameLabel.ForeColor = Color.FromArgb(117, 117, 117); // #757575
            nameLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            nameLabel.Location = new Point(55, 110);
            nameLabel.AutoSize = true;

            // Ad Soyad metin kutusu
            TextBox nameTextBox = new TextBox();
            nameTextBox.Size = new Size(390, 30);
            nameTextBox.Location = new Point(55, 135);
            nameTextBox.Font = new Font("Segoe UI", 12);
            nameTextBox.BorderStyle = BorderStyle.None;
            nameTextBox.BackColor = Color.White;

            // Ad Soyad alt çizgi paneli
            Panel nameUnderlinePanel = new Panel();
            nameUnderlinePanel.Size = new Size(390, 1);
            nameUnderlinePanel.Location = new Point(55, 165);
            nameUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224); // #E0E0E0

            // E-posta etiketi
            Label emailLabel = new Label();
            emailLabel.Text = "E-posta Adresi";
            emailLabel.ForeColor = Color.FromArgb(117, 117, 117); // #757575
            emailLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            emailLabel.Location = new Point(55, 175);
            emailLabel.AutoSize = true;

            // E-posta metin kutusu
            TextBox emailTextBox = new TextBox();
            emailTextBox.Size = new Size(390, 30);
            emailTextBox.Location = new Point(55, 200);
            emailTextBox.Font = new Font("Segoe UI", 12);
            emailTextBox.BorderStyle = BorderStyle.None;
            emailTextBox.BackColor = Color.White;

            // E-posta alt çizgi paneli
            Panel emailUnderlinePanel = new Panel();
            emailUnderlinePanel.Size = new Size(390, 1);
            emailUnderlinePanel.Location = new Point(55, 230);
            emailUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224); // #E0E0E0

            // Kullanıcı adı etiketi
            Label userLabel = new Label();
            userLabel.Text = "Kullanıcı Adı";
            userLabel.ForeColor = Color.FromArgb(117, 117, 117); // #757575
            userLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            userLabel.Location = new Point(55, 240);
            userLabel.AutoSize = true;

            // Kullanıcı adı metin kutusu
            TextBox userTextBox = new TextBox();
            userTextBox.Size = new Size(390, 30);
            userTextBox.Location = new Point(55, 265);
            userTextBox.Font = new Font("Segoe UI", 12);
            userTextBox.BorderStyle = BorderStyle.None;
            userTextBox.BackColor = Color.White;

            // Kullanıcı adı alt çizgi paneli
            Panel userUnderlinePanel = new Panel();
            userUnderlinePanel.Size = new Size(390, 1);
            userUnderlinePanel.Location = new Point(55, 295);
            userUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224); // #E0E0E0

            // Şifre etiketi
            Label passwordLabel = new Label();
            passwordLabel.Text = "Şifre";
            passwordLabel.ForeColor = Color.FromArgb(117, 117, 117); // #757575
            passwordLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            passwordLabel.Location = new Point(55, 305);
            passwordLabel.AutoSize = true;

            // Şifre metin kutusu
            TextBox passwordTextBox = new TextBox();
            passwordTextBox.Size = new Size(390, 30);
            passwordTextBox.Location = new Point(55, 330);
            passwordTextBox.Font = new Font("Segoe UI", 12);
            passwordTextBox.BorderStyle = BorderStyle.None;
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.BackColor = Color.White;

            // Şifre alt çizgi paneli
            Panel passwordUnderlinePanel = new Panel();
            passwordUnderlinePanel.Size = new Size(390, 1);
            passwordUnderlinePanel.Location = new Point(55, 360);
            passwordUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224); // #E0E0E0

            // Şifre Tekrar etiketi
            Label passwordConfirmLabel = new Label();
            passwordConfirmLabel.Text = "Şifre Tekrar";
            passwordConfirmLabel.ForeColor = Color.FromArgb(117, 117, 117); // #757575
            passwordConfirmLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            passwordConfirmLabel.Location = new Point(55, 370);
            passwordConfirmLabel.AutoSize = true;

            // Şifre Tekrar metin kutusu
            TextBox passwordConfirmTextBox = new TextBox();
            passwordConfirmTextBox.Size = new Size(390, 30);
            passwordConfirmTextBox.Location = new Point(55, 395);
            passwordConfirmTextBox.Font = new Font("Segoe UI", 12);
            passwordConfirmTextBox.BorderStyle = BorderStyle.None;
            passwordConfirmTextBox.UseSystemPasswordChar = true;
            passwordConfirmTextBox.BackColor = Color.White;

            // Şifre Tekrar alt çizgi paneli
            Panel passwordConfirmUnderlinePanel = new Panel();
            passwordConfirmUnderlinePanel.Size = new Size(390, 1);
            passwordConfirmUnderlinePanel.Location = new Point(55, 425);
            passwordConfirmUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224); // #E0E0E0

            // Kullanım koşulları onay kutusu
            CheckBox termsCheckBox = new CheckBox();
            termsCheckBox.Text = "Kullanım koşullarını kabul ediyorum";
            termsCheckBox.ForeColor = Color.FromArgb(117, 117, 117); // #757575
            termsCheckBox.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            termsCheckBox.Location = new Point(55, 435);
            termsCheckBox.AutoSize = true;

            // Kayıt butonu
            Button registerButton = new Button();
            registerButton.Text = "KAYIT OL";
            registerButton.ForeColor = Color.White;
            registerButton.BackColor = Color.FromArgb(46, 125, 50); // #2E7D32
            registerButton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            registerButton.Size = new Size(390, 45);
            registerButton.TextAlign = ContentAlignment.MiddleCenter;
            registerButton.Location = new Point(55, 470);
            registerButton.FlatStyle = FlatStyle.Flat;
            registerButton.FlatAppearance.BorderSize = 0;
            registerButton.Cursor = Cursors.Hand;

            // Giriş yap metni
            Label loginTextLabel = new Label();
            loginTextLabel.Text = "Zaten hesabınız var mı?";
            loginTextLabel.ForeColor = Color.FromArgb(117, 117, 117); // #757575
            loginTextLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            loginTextLabel.Location = new Point(55, 530);
            loginTextLabel.AutoSize = true;

            // Giriş yap bağlantısı
            LinkLabel loginLink = new LinkLabel();
            loginLink.Text = " Giriş Yapın";
            loginLink.LinkColor = Color.FromArgb(46, 125, 50); // #2E7D32
            loginLink.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            loginLink.Location = new Point(206, 530);
            loginLink.AutoSize = true;

            // Telif hakkı metni
            Label copyrightLabel = new Label();
            copyrightLabel.Text = "© 2025 GreenByte Ltd. Şti. Tüm hakları saklıdır.";
            copyrightLabel.ForeColor = Color.FromArgb(158, 158, 158); // #9E9E9E
            copyrightLabel.Font = new Font("Segoe UI", 8);
            copyrightLabel.Location = new Point(100, 555);
            copyrightLabel.Size = new Size(300, 15);
            copyrightLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Focus olayları ekle
            nameTextBox.Enter += (s, e) => nameUnderlinePanel.BackColor = Color.FromArgb(46, 125, 50);
            nameTextBox.Leave += (s, e) => nameUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224);

            emailTextBox.Enter += (s, e) => emailUnderlinePanel.BackColor = Color.FromArgb(46, 125, 50);
            emailTextBox.Leave += (s, e) => emailUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224);

            userTextBox.Enter += (s, e) => userUnderlinePanel.BackColor = Color.FromArgb(46, 125, 50);
            userTextBox.Leave += (s, e) => userUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224);

            passwordTextBox.Enter += (s, e) => passwordUnderlinePanel.BackColor = Color.FromArgb(46, 125, 50);
            passwordTextBox.Leave += (s, e) => passwordUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224);

            passwordConfirmTextBox.Enter += (s, e) => passwordConfirmUnderlinePanel.BackColor = Color.FromArgb(46, 125, 50);
            passwordConfirmTextBox.Leave += (s, e) => passwordConfirmUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224);

            // Kontrolleri panellere ekle
            topBar.Controls.Add(titleLabel);
            topBar.Controls.Add(closeButton);

            // Sol panel kontrollerini ekleme sırası önemli
            leftPanel.Controls.Add(backgroundImage); // Arka plan resmini en alta ekle
            leftPanel.Controls.Add(gradientPanel); // Gradient efektini onun üzerine ekle
            leftPanel.Controls.Add(sloganLabel);

            rightPanel.Controls.Add(welcomeLabel);
            rightPanel.Controls.Add(subTitleLabel);
            rightPanel.Controls.Add(nameLabel);
            rightPanel.Controls.Add(nameTextBox);
            rightPanel.Controls.Add(nameUnderlinePanel);
            rightPanel.Controls.Add(emailLabel);
            rightPanel.Controls.Add(emailTextBox);
            rightPanel.Controls.Add(emailUnderlinePanel);
            rightPanel.Controls.Add(userLabel);
            rightPanel.Controls.Add(userTextBox);
            rightPanel.Controls.Add(userUnderlinePanel);
            rightPanel.Controls.Add(passwordLabel);
            rightPanel.Controls.Add(passwordTextBox);
            rightPanel.Controls.Add(passwordUnderlinePanel);
            rightPanel.Controls.Add(passwordConfirmLabel);
            rightPanel.Controls.Add(passwordConfirmTextBox);
            rightPanel.Controls.Add(passwordConfirmUnderlinePanel);
            rightPanel.Controls.Add(termsCheckBox);
            rightPanel.Controls.Add(registerButton);
            rightPanel.Controls.Add(loginTextLabel);
            rightPanel.Controls.Add(loginLink);
            rightPanel.Controls.Add(copyrightLabel);

            mainPanel.Controls.Add(topBar);
            mainPanel.Controls.Add(leftPanel);
            mainPanel.Controls.Add(rightPanel);

            this.Controls.Add(mainPanel);

            // Kayıt butonuna işlevsellik ekle
            registerButton.Click += new EventHandler(RegisterButton_Click);

            // Giriş yap bağlantısına işlevsellik ekle
            loginLink.Click += new EventHandler(LoginLink_Click);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            // Kayıt doğrulama kodları buraya gelecek
            Panel rightPanel = this.Controls[0].Controls[2] as Panel;
            TextBox nameTextBox = rightPanel.Controls[3] as TextBox;
            TextBox emailTextBox = rightPanel.Controls[6] as TextBox;
            TextBox userTextBox = rightPanel.Controls[9] as TextBox;
            TextBox passwordTextBox = rightPanel.Controls[12] as TextBox;
            TextBox passwordConfirmTextBox = rightPanel.Controls[15] as TextBox;
            CheckBox termsCheckBox = rightPanel.Controls[17] as CheckBox;

            string name = nameTextBox.Text;
            string email = emailTextBox.Text;
            string username = userTextBox.Text;
            string password = passwordTextBox.Text;
            string passwordConfirm = passwordConfirmTextBox.Text;

            // Basit doğrulama kontrolleri
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(passwordConfirm))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (password != passwordConfirm)
            {
                MessageBox.Show("Şifreler eşleşmiyor!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!termsCheckBox.Checked)
            {
                MessageBox.Show("Lütfen kullanım koşullarını kabul edin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // E-posta formatı doğrulama
            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Geçerli bir e-posta adresi giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kayıt işlemi başarılı
            MessageBox.Show("Kayıt işlemi başarılı! Giriş sayfasına yönlendiriliyorsunuz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Giriş formuna geçiş kodları buraya gelecek
            // LoginForm loginForm = new LoginForm();
            // loginForm.Show();
            // this.Hide();
        }

        private void LoginLink_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
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
    }
}