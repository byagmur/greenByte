using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using greenByte.Controls; // Add reference to our controls namespace

namespace greenByte.Forms
{
    public partial class FormMain : Form
    {
        private Panel sidebarPanel;
        private Panel mainPanel;
        private Panel headerPanel;
        private Button closeButton;
        private Button minimizeButton;
        private AdminDashboardPage dashboardPage; // Reference to our dashboard control

        public FormMain()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Text = "GreenByte Sera Yönetim Sistemi";
            this.Icon = new Icon(SystemIcons.Application, 40, 40);

            // Set form to start maximized
            this.WindowState = FormWindowState.Maximized;

            // Set form background color
            this.BackColor = Color.FromArgb(240, 240, 240);

            // Create the sidebar
            CreateSidebar();

            // Create main panel
            CreateMainPanel();

            // Create header
            CreateHeader();

            // Create window control buttons
            CreateWindowControls();

            // Set Resize event handler to adjust layout when window size changes
            this.Resize += FormMain_Resize;

            // Load the dashboard page
            LoadDashboardPage();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            // Recalculate and redraw the layout when the form is resized
            if (headerPanel != null)
            {
                // Reposition window control buttons
                RepositionWindowControls();
            }
        }

        private void CreateSidebar()
        {
            // Create sidebar panel
            sidebarPanel = new Panel
            {
                BackColor = Color.FromArgb(21, 103, 30), // Dark green color
                Dock = DockStyle.Left,
                Width = 250
            };
            this.Controls.Add(sidebarPanel);

            // Add logo/title to sidebar
            Panel logoPanel = new Panel
            {
                Width = sidebarPanel.Width,
                Height = 70,
                Location = new Point(0, 30),
                BackColor = Color.Transparent
            };

            PictureBox logoPictureBox = new PictureBox
            {
                Size = new Size(50, 50),
                Location = new Point(20, 10),
                BackColor = Color.Transparent
            };

            // We would normally load an image here, but for now let's use a placeholder
            logoPictureBox.Image = Image.FromFile("C:\\Projects\\C#\\greenByte\\assets\\icon.png"); // Replace with actual path to logo image

            Label logoLabel = new Label
            {
                Text = "GreenByte",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Height = 50,
                AutoSize = true,
                Location = new Point(85, 18)
            };

            logoPanel.Controls.Add(logoPictureBox);
            logoPanel.Controls.Add(logoLabel);
            sidebarPanel.Controls.Add(logoPanel);

            // Add menu items
            string[] menuItems = {
                "Dashboard", "Sıcaklık Kontrol", "Nem Kontrol", "Aydınlatma",
                "Su Deposu", "Bitki Durumu", "Kamera Görüntüleri", "Geçmiş Veriler", "Ayarlar"
            };

            string[] menuIcons = {
                "🏠", "🌡️", "💧", "💡", "🚰", "🌱", "📷", "📊", "⚙️"
            };

            // Daha sıkı ve kontrollü menü aralıkları
            int menuStartY = 120;
            int menuHeight = 45; // Yüksekliği azalttık
            int menuSpacing = 10; // Sabit aralık

            for (int i = 0; i < menuItems.Length; i++)
            {
                Panel menuItemPanel = new Panel
                {
                    Width = sidebarPanel.Width - 30,
                    Height = menuHeight,
                    Location = new Point(15, menuStartY + (i * (menuHeight + menuSpacing))),
                    BackColor = Color.FromArgb(40, 133, 50),
                    Cursor = Cursors.Hand
                };

                // Apply rounded corners
                menuItemPanel.Region = GetRoundedRegion(menuItemPanel.Width, menuItemPanel.Height, 10);

                Label iconLabel = new Label
                {
                    Text = menuIcons[i],
                    Font = new Font("Segoe UI", 14), // İcon boyutunu küçülttük
                    Location = new Point(15, 10), // İcon konumunu ayarladık
                    Size = new Size(25, 25), // İcon için sabit boyut
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.White
                };

                Label textLabel = new Label
                {
                    Text = menuItems[i],
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 11),
                    Location = new Point(50, 13), // Metin konumunu ayarladık
                    AutoSize = true
                };

                menuItemPanel.Controls.Add(iconLabel);
                menuItemPanel.Controls.Add(textLabel);
                sidebarPanel.Controls.Add(menuItemPanel);

                // Highlight the Dashboard item (first item)
                if (i == 0)
                {
                    menuItemPanel.BackColor = Color.FromArgb(60, 153, 70);
                }

                // Add hover effect
                int index = i;
                menuItemPanel.MouseEnter += (sender, e) =>
                {
                    if (index != 0) // Skip for selected item
                        ((Panel)sender).BackColor = Color.FromArgb(50, 143, 60);
                };

                menuItemPanel.MouseLeave += (sender, e) =>
                {
                    if (index != 0) // Skip for selected item
                        ((Panel)sender).BackColor = Color.FromArgb(40, 133, 50);
                };

                // Add click event for menu items
                menuItemPanel.Click += (sender, e) =>
                {
                    // Switch to selected page
                    SwitchToPage(index);
                };
            }
        }

        private void SwitchToPage(int pageIndex)
        {
            // Clear current content (except header)
            foreach (Control control in mainPanel.Controls)
            {
                if (control != headerPanel)
                {
                    mainPanel.Controls.Remove(control);
                    control.Dispose();
                }
            }

            // Load appropriate page based on index
            switch (pageIndex)
            {
                case 0:
                    LoadDashboardPage();
                    break;
                // Add cases for other pages as needed
                default:
                    // Create content panel with padding for header
                    Panel contentPanel = new Panel
                    {
                        Dock = DockStyle.Fill,
                        BackColor = Color.FromArgb(245, 245, 245),
                        Padding = new Padding(0, headerPanel.Height, 0, 0) // Add padding at the top for header
                    };

                    // Create a placeholder for unimplemented pages
                    Label placeholderLabel = new Label
                    {
                        Text = "Bu sayfa henüz uygulanmadı.",
                        Font = new Font("Segoe UI", 16),
                        ForeColor = Color.Gray,
                        AutoSize = true
                    };

                    // Center the label in the content panel
                    placeholderLabel.Location = new Point(
                        (contentPanel.Width - placeholderLabel.PreferredWidth) / 2,
                        (contentPanel.Height - placeholderLabel.PreferredHeight) / 2
                    );

                    contentPanel.Controls.Add(placeholderLabel);
                    mainPanel.Controls.Add(contentPanel);

                    // Make sure the header stays on top
                    headerPanel.BringToFront();
                    break;
            }
        }

        private void CreateMainPanel()
        {
            mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 245, 245)
            };
            this.Controls.Add(mainPanel);
            mainPanel.BringToFront();
        }

        private void CreateHeader()
        {
            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(21, 103, 30)
            };

            Label titleLabel = new Label
            {
                Text = "",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                Location = new Point(25, 15),
                AutoSize = true
            };

            // Calculate position for control mode panel to be centered horizontally
            int panelWidth = 350;

            Panel controlModePanel = new Panel
            {
                Width = panelWidth,
                Height = 40,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            // Apply rounded corners
            controlModePanel.Region = GetRoundedRegion(controlModePanel.Width, controlModePanel.Height, 20);

            Label controlModeLabel = new Label
            {
                Text = "Sera Kontrol Modu",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(15, 8),
                AutoSize = true
            };

            Panel togglePanel = new Panel
            {
                Width = 160,
                Height = 28,
                Location = new Point(170, 6),
                BackColor = Color.LightGray
            };

            // Apply rounded corners to toggle panel
            togglePanel.Region = GetRoundedRegion(togglePanel.Width, togglePanel.Height, 14);

            Panel activeToggle = new Panel
            {
                Width = 80,
                Height = 28,
                Location = new Point(0, 0),
                BackColor = Color.FromArgb(76, 175, 80)
            };

            // Apply rounded corners to active toggle
            activeToggle.Region = GetRoundedRegion(activeToggle.Width, activeToggle.Height, 14);

            Label autoLabel = new Label
            {
                Text = "OTOMATİK",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(15, 5),
                AutoSize = true
            };

            Label manualLabel = new Label
            {
                Text = "MANUEL",
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(95, 5),
                AutoSize = true
            };

            activeToggle.Controls.Add(autoLabel);
            togglePanel.Controls.Add(activeToggle);
            togglePanel.Controls.Add(manualLabel);
            controlModePanel.Controls.Add(controlModeLabel);
            controlModePanel.Controls.Add(togglePanel);

            // Position the control mode panel dynamically
            controlModePanel.Location = new Point(
                this.Width / 2 - panelWidth / 2,
                (headerPanel.Height - controlModePanel.Height) / 2
            );

            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(controlModePanel);

            mainPanel.Controls.Add(headerPanel);
        }

        private void CreateWindowControls()
        {
            // Create window control buttons (close and minimize only)
            closeButton = CreateWindowButton("X", Color.FromArgb(240, 71, 71), 0);
            minimizeButton = CreateWindowButton("-", Color.FromArgb(255, 209, 102), 1);

            // Add event handlers
            closeButton.Click += (sender, e) => Application.Exit();
            minimizeButton.Click += (sender, e) => this.WindowState = FormWindowState.Minimized;

            // Position buttons
            RepositionWindowControls();
        }

        private Button CreateWindowButton(string text, Color backColor, int order)
        {
            Button button = new Button
            {
                Size = new Size(30, 30),
                Text = text,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = backColor,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Cursor = Cursors.Hand
            };

            // Remove border
            button.FlatAppearance.BorderSize = 0;

            // Add to form
            this.Controls.Add(button);
            button.BringToFront();

            return button;
        }

        private void RepositionWindowControls()
        {
            // Position based on current form size
            int buttonSpacing = 10;
            int topMargin = 15;
            int rightMargin = 15;

            closeButton.Location = new Point(this.Width - closeButton.Width - rightMargin, topMargin);
            minimizeButton.Location = new Point(closeButton.Left - minimizeButton.Width - buttonSpacing, topMargin);
        }

        private void LoadDashboardPage()
        {
            // Create content panel that will contain our dashboard (below the header)
            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(245, 245, 245),
                Padding = new Padding(0, headerPanel.Height, 0, 0) // Add padding at the top for header
            };

            // Create a new instance of the AdminDashboardPage user control
            dashboardPage = new AdminDashboardPage
            {
                Dock = DockStyle.Fill
            };

            // Add the dashboard page to the content panel
            contentPanel.Controls.Add(dashboardPage);

            // Add the content panel to the main panel
            mainPanel.Controls.Add(contentPanel);

            // Make sure the header stays on top
            headerPanel.BringToFront();
        }

        private Region GetRoundedRegion(int width, int height, int radius)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius * 2, radius * 2, 180, 90);
                path.AddArc(width - radius * 2, 0, radius * 2, radius * 2, 270, 90);
                path.AddArc(width - radius * 2, height - radius * 2, radius * 2, radius * 2, 0, 90);
                path.AddArc(0, height - radius * 2, radius * 2, radius * 2, 90, 90);
                path.CloseAllFigures();

                return new Region(path);
            }
        }
    }
}