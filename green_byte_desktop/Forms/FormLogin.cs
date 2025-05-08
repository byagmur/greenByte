using greenByte.Forms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GreenByte
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Kenarlıksız form
            this.StartPosition = FormStartPosition.CenterScreen; // Ekranın ortasında başlat
        }

        private void InitializeComponent()
        {
            // Form boyutlarını ayarla
            this.ClientSize = new Size(900, 600);
            this.Text = "GreenByte Sera Yönetim Sistemi - Giriş";

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
            titleLabel.Text = "GreenByte Sera Yönetim Sistemi - Giriş";
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


            // Sağ panel (giriş formu)
            Panel rightPanel = new Panel();
            rightPanel.Size = new Size(420, 565); // Genişlik aynı kalıyor
            rightPanel.Location = new Point(420, 35); // Konum 400'den 450'ye kaydırıldı
            mainPanel.BackColor = Color.FromArgb(245, 245, 245);

            // Hoşgeldiniz başlığı
            Label welcomeLabel = new Label();
            welcomeLabel.Text = "Hoş Geldiniz";
            welcomeLabel.ForeColor = Color.FromArgb(46, 125, 50); // #2E7D32
            welcomeLabel.Font = new Font("Segoe UI", 22, FontStyle.Bold);
            welcomeLabel.Location = new Point(125, 50);
            welcomeLabel.Size = new Size(250, 40);
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Alt başlık
            Label subTitleLabel = new Label();
            subTitleLabel.Text = "Sera yönetim sisteminize giriş yapın";
            subTitleLabel.ForeColor = Color.FromArgb(117, 117, 117); // #757575
            subTitleLabel.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            subTitleLabel.Location = new Point(75, 90);
            subTitleLabel.Size = new Size(350, 30);
            subTitleLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Kullanıcı adı etiketi
            Label userLabel = new Label();
            userLabel.Text = "Kullanıcı Adı";
            userLabel.ForeColor = Color.FromArgb(117, 117, 117); // #757575
            userLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            userLabel.Location = new Point(55, 150);
            userLabel.AutoSize = true;

            // Kullanıcı adı metin kutusu
            TextBox userTextBox = new TextBox();
            userTextBox.Size = new Size(390, 30);
            userTextBox.Location = new Point(55, 180);
            userTextBox.Font = new Font("Segoe UI", 12);
            userTextBox.BorderStyle = BorderStyle.None;
            userTextBox.BackColor = Color.White;

            // Kullanıcı adı alt çizgi paneli
            Panel userUnderlinePanel = new Panel();
            userUnderlinePanel.Size = new Size(390, 1);
            userUnderlinePanel.Location = new Point(55, 210);
            userUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224); // #E0E0E0

            // Şifre etiketi
            Label passwordLabel = new Label();
            passwordLabel.Text = "Şifre";
            passwordLabel.ForeColor = Color.FromArgb(117, 117, 117); // #757575
            passwordLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            passwordLabel.Location = new Point(55, 240);
            passwordLabel.AutoSize = true;

            // Şifre metin kutusu
            TextBox passwordTextBox = new TextBox();
            passwordTextBox.Size = new Size(390, 30);
            passwordTextBox.Location = new Point(55, 265);
            passwordTextBox.Font = new Font("Segoe UI", 12);
            passwordTextBox.BorderStyle = BorderStyle.None;
            passwordTextBox.UseSystemPasswordChar = true;
            passwordTextBox.BackColor = Color.White;

            // Şifre alt çizgi paneli
            Panel passwordUnderlinePanel = new Panel();
            passwordUnderlinePanel.Size = new Size(390, 1);
            passwordUnderlinePanel.Location = new Point(55, 295);
            passwordUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224); // #E0E0E0

            // Beni hatırla onay kutusu
            CheckBox rememberCheckBox = new CheckBox();
            rememberCheckBox.Text = "Beni Hatırla";
            rememberCheckBox.ForeColor = Color.FromArgb(117, 117, 117); // #757575
            rememberCheckBox.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            rememberCheckBox.Location = new Point(55, 310);
            rememberCheckBox.AutoSize = true;

            // Şifremi unuttum bağlantısı
            LinkLabel forgotPasswordLink = new LinkLabel();
            forgotPasswordLink.Text = "Şifremi Unuttum";
            forgotPasswordLink.LinkColor = Color.FromArgb(33, 150, 243); // #2196F3
            forgotPasswordLink.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            forgotPasswordLink.Location = new Point(325, 310);
            forgotPasswordLink.AutoSize = true;

            // Giriş butonu
            Button loginButton = new Button();
            loginButton.Text = "GİRİŞ YAP";
            loginButton.ForeColor = Color.White;
            loginButton.BackColor = Color.FromArgb(46, 125, 50); // #2E7D32
            loginButton.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            loginButton.Size = new Size(390, 45);
            loginButton.Location = new Point(55, 350);
            loginButton.FlatStyle = FlatStyle.Flat;
            loginButton.FlatAppearance.BorderSize = 0;
            loginButton.Cursor = Cursors.Hand;

            // Kayıt ol metni
            Label registerTextLabel = new Label();
            registerTextLabel.Text = "Hesabınız yok mu?";
            registerTextLabel.ForeColor = Color.FromArgb(117, 117, 117); // #757575
            registerTextLabel.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            registerTextLabel.Location = new Point(55, 410);
            registerTextLabel.AutoSize = true;

            // Kayıt ol bağlantısı
            LinkLabel registerLink = new LinkLabel();
            registerLink.Text = "  Kayıt Olun";
            registerLink.LinkColor = Color.FromArgb(46, 125, 50); // #2E7D32
            registerLink.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            registerLink.Location = new Point(165, 410);

            registerLink.Click += (sender, e) =>
            {
                RegisterForm registerForm = new RegisterForm();
                registerForm.Show();
                this.Hide();
            };
            registerLink.AutoSize = true;

            // Ayırıcı çizgiler ve "veya" metni
            Panel leftLine = new Panel();
            leftLine.Size = new Size(160, 1);
            leftLine.Location = new Point(55, 455);
            leftLine.BackColor = Color.FromArgb(224, 224, 224); // #E0E0E0


            Panel rightLine = new Panel();
            rightLine.Size = new Size(160, 1);
            rightLine.Location = new Point(285, 455);
            rightLine.BackColor = Color.FromArgb(224, 224, 224); // #E0E0E0


            // Telif hakkı metni
            Label copyrightLabel = new Label();
            copyrightLabel.Text = "© 2025 GreenByte Ltd. Şti. Tüm hakları saklıdır.";
            copyrightLabel.ForeColor = Color.FromArgb(158, 158, 158); // #9E9E9E
            copyrightLabel.Font = new Font("Segoe UI", 8);
            copyrightLabel.Location = new Point(100, 535);
            copyrightLabel.Size = new Size(300, 15);
            copyrightLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Focus olayları ekle
            userTextBox.Enter += (s, e) => userUnderlinePanel.BackColor = Color.FromArgb(46, 125, 50);
            userTextBox.Leave += (s, e) => userUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224);

            passwordTextBox.Enter += (s, e) => passwordUnderlinePanel.BackColor = Color.FromArgb(46, 125, 50);
            passwordTextBox.Leave += (s, e) => passwordUnderlinePanel.BackColor = Color.FromArgb(224, 224, 224);

            // Kontrolleri panellere ekle
            topBar.Controls.Add(titleLabel);
            topBar.Controls.Add(closeButton);

            // Sol panel kontrollerini ekleme sırası önemli
            leftPanel.Controls.Add(backgroundImage); // Arka plan resmini en alta ekle
            leftPanel.Controls.Add(gradientPanel); // Gradient efektini onun üzerine ekle
            leftPanel.Controls.Add(sloganLabel);

            rightPanel.Controls.Add(welcomeLabel);
            rightPanel.Controls.Add(subTitleLabel);
            rightPanel.Controls.Add(userLabel);
            rightPanel.Controls.Add(userTextBox);
            rightPanel.Controls.Add(userUnderlinePanel);
            rightPanel.Controls.Add(passwordLabel);
            rightPanel.Controls.Add(passwordTextBox);
            rightPanel.Controls.Add(passwordUnderlinePanel);
            rightPanel.Controls.Add(forgotPasswordLink);
            rightPanel.Controls.Add(rememberCheckBox);
            rightPanel.Controls.Add(loginButton);
            rightPanel.Controls.Add(registerTextLabel);
            rightPanel.Controls.Add(registerLink);
            rightPanel.Controls.Add(leftLine);

            rightPanel.Controls.Add(rightLine);

            rightPanel.Controls.Add(copyrightLabel);

            mainPanel.Controls.Add(topBar);
            mainPanel.Controls.Add(leftPanel);
            mainPanel.Controls.Add(rightPanel);

            this.Controls.Add(mainPanel);

            // Giriş butonuna işlevsellik ekle
            loginButton.Click += new EventHandler(LoginButton_Click);

            // Kayıt ol bağlantısına işlevsellik ekle
            registerLink.Click += new EventHandler(RegisterLink_Click);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // Giriş doğrulama kodları buraya gelecek
            Panel rightPanel = this.Controls[0].Controls[2] as Panel;
            TextBox userTextBox = rightPanel.Controls[3] as TextBox;
            TextBox passwordTextBox = rightPanel.Controls[6] as TextBox;

            string username = userTextBox.Text;
            string password = passwordTextBox.Text;

            username = "admin";
            password = "1234";
            if (username == "admin" && password == "1234")
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
    }
}