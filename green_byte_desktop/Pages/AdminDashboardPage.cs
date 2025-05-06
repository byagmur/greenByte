using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace greenByte.Controls
{
    public partial class AdminDashboardPage : UserControl
    {
        private Chart temperatureHumidityChart;

        public AdminDashboardPage()
        {
            InitializeComponent();

            // Set control properties
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(245, 245, 245);

            // Initialize the dashboard content
            CreateDashboardContent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Clear controls and recreate when resized
            this.Controls.Clear();
            CreateDashboardContent();
        }

        private void CreateDashboardContent()
        {
            // Calculate the available space for main content
            int contentStartY = 20; // Top margin
            int contentWidth = this.Width - 40; // 20px margin on each side

            // Calculate optimal dimensions for sensor panels
            int sensorPanelWidth = (contentWidth - 60) / 4; // 60 = 3 gaps of 20px between panels
            int sensorPanelHeight = 160;
            int sensorPanelGap = 20;

            // Create sensor panels with corrected positioning
            CreateSensorPanel("SICAKLIK", "24.5°C", "↑ 0.5°C (10d)", Color.FromArgb(255, 80, 80), "🌡️",
                new Point(20, contentStartY), Color.FromArgb(255, 235, 235), sensorPanelWidth, sensorPanelHeight);

            CreateSensorPanel("NEM", "65%", "↑ 2% (15d)", Color.FromArgb(0, 150, 255), "💧",
                new Point(20 + sensorPanelWidth + sensorPanelGap, contentStartY),
                Color.FromArgb(230, 245, 255), sensorPanelWidth, sensorPanelHeight);

            CreateSensorPanel("IŞIK SEVİYESİ", "850 lux", "↑ 50 lux (5d)", Color.FromArgb(255, 193, 7), "💡",
                new Point(20 + (sensorPanelWidth + sensorPanelGap) * 2, contentStartY),
                Color.FromArgb(255, 248, 225), sensorPanelWidth, sensorPanelHeight);

            CreateSensorPanel("TOPRAK NEMİ", "72%", "↑ 5% (8s)", Color.FromArgb(76, 175, 80), "🌱",
                new Point(20 + (sensorPanelWidth + sensorPanelGap) * 3, contentStartY),
                Color.FromArgb(232, 245, 233), sensorPanelWidth, sensorPanelHeight);

            // Calculate chart and status panel positions
            int chartPanelY = contentStartY + sensorPanelHeight + 20;
            int chartPanelWidth = (int)(contentWidth * 0.7); // 70% of available width
            int statusPanelWidth = (int)(contentWidth * 0.27); // 27% of available width
            int chartPanelHeight = this.Height - chartPanelY - 40; // Dynamic height

            // Create chart with corrected positioning
            CreateTemperatureHumidityChart(new Point(20, chartPanelY), chartPanelWidth, chartPanelHeight);

            // Create system status panel with corrected positioning
            CreateSystemStatusPanel(
                new Point(20 + chartPanelWidth + sensorPanelGap, chartPanelY),
                statusPanelWidth,
                chartPanelHeight);
        }

        private void CreateSensorPanel(string title, string value, string change, Color color, string icon,
                               Point location, Color bgColor, int width, int height)
        {
            Panel sensorPanel = new Panel
            {
                Width = width,
                Height = height,
                Location = location,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // Apply rounded corners
            sensorPanel.Region = GetRoundedRegion(sensorPanel.Width, sensorPanel.Height, 15);

            // Add shadow effect
            ApplyShadowEffect(sensorPanel);

            Panel colorBar = new Panel
            {
                Width = width,
                Height = 6,
                Location = new Point(0, 0),
                BackColor = color
            };

            // Apply rounded corners to top of color bar
            colorBar.Region = new Region(new RectangleF(0, 0, width, 6));

            Panel iconContainer = new Panel
            {
                Width = 50,
                Height = 50,
                Location = new Point(20, 25),
                BackColor = bgColor
            };

            // Apply rounded corners to icon container
            iconContainer.Region = GetRoundedRegion(iconContainer.Width, iconContainer.Height, 25);

            Label iconLabel = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 24),
                Size = new Size(50, 50),
                Padding = new Padding(5),
                Location = new Point(0, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };

            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.Gray,
                Location = new Point(90, 30),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 24, FontStyle.Bold),
                Location = new Point(90, 60),
                AutoSize = true,
                BackColor = Color.Transparent
            };

            Label changeLabel = new Label
            {
                Text = change,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Location = new Point(90, 100),
                AutoSize = true
            };

            iconContainer.Controls.Add(iconLabel);
            sensorPanel.Controls.Add(colorBar);
            sensorPanel.Controls.Add(iconContainer);
            sensorPanel.Controls.Add(titleLabel);
            sensorPanel.Controls.Add(valueLabel);
            sensorPanel.Controls.Add(changeLabel);

            this.Controls.Add(sensorPanel);
        }

        private void CreateTemperatureHumidityChart(Point location, int width, int height)
        {
            Panel chartPanel = new Panel
            {
                Width = width,
                Height = height,
                Location = location,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // Apply rounded corners
            chartPanel.Region = GetRoundedRegion(chartPanel.Width, chartPanel.Height, 15);

            // Add shadow effect
            ApplyShadowEffect(chartPanel);

            Label chartTitleLabel = new Label
            {
                Text = "24 Saatlik Sıcaklık ve Nem Grafiği",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            temperatureHumidityChart = new Chart
            {
                Width = width - 40, // 20px padding on each side

                Height = Math.Max(height, 100), // Ensure a minimum height  

                Location = new Point(20, 60),
                BackColor = Color.White,
                Palette = ChartColorPalette.None
            };

            ChartArea chartArea = new ChartArea();
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
            chartArea.AxisX.Minimum = 0;
            chartArea.AxisX.Maximum = 24;
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 100;
            chartArea.BackColor = Color.White;

            temperatureHumidityChart.ChartAreas.Add(chartArea);

            // Temperature series
            Series tempSeries = new Series
            {
                Name = "Sıcaklık (°C)",
                ChartType = SeriesChartType.Line,
                Color = Color.FromArgb(255, 80, 80),
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                MarkerColor = Color.Transparent,
                
                
            };

            // Humidity series
            Series humSeries = new Series
            {
                Name = "Nem (%)",
                ChartType = SeriesChartType.Line,
                Color = Color.FromArgb(0, 150, 255),
                BorderWidth = 3,
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 8,
                MarkerColor = Color.Transparent
            };

            // Sample data with realistic temperature and humidity patterns
            double[] tempData = { 19, 18, 17, 16, 16, 15, 18, 22, 25, 28, 30, 32, 33, 33, 34, 33, 31, 29, 26, 24, 22, 21, 20, 19 };
            double[] humData = { 75, 78, 80, 82, 83, 85, 80, 75, 65, 60, 55, 50, 45, 43, 42, 44, 50, 55, 60, 65, 68, 70, 72, 75 };

            // Hour labels for X axis
            string[] hourLabels = {
                "00:00", "01:00", "02:00", "03:00", "04:00", "05:00", "06:00", "07:00", "08:00", "09:00", "10:00", "11:00",
                "12:00", "13:00", "14:00", "15:00", "16:00", "17:00", "18:00", "19:00", "20:00", "21:00", "22:00", "23:00"
            };

            // Add custom X axis labels (hours)
            chartArea.AxisX.CustomLabels.Clear();
            for (int i = 0; i < 24; i += 4) // Show every 4 hours
            {
                chartArea.AxisX.CustomLabels.Add(
                    i - 0.5,
                    i + 0.5,
                    hourLabels[i],
                    0,
                    LabelMarkStyle.None
                );
            }

            for (int i = 0; i < 24; i++)
            {
                tempSeries.Points.AddXY(i, tempData[i]);
                humSeries.Points.AddXY(i, humData[i]);
            }

            temperatureHumidityChart.Series.Add(tempSeries);
            temperatureHumidityChart.Series.Add(humSeries);

            // Add Legend
            Legend chartLegend = new Legend
            {
                Name = "ChartLegend",
                Docking = Docking.Bottom,
                Alignment = StringAlignment.Center,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.White
            };

            temperatureHumidityChart.Legends.Add(chartLegend);

            chartPanel.Controls.Add(chartTitleLabel);
            chartPanel.Controls.Add(temperatureHumidityChart);

            this.Controls.Add(chartPanel);
        }

        private void CreateSystemStatusPanel(Point location, int width, int height)
        {
            Panel statusPanel = new Panel
            {
                Width = width,
                Height = height,
                Location = location,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // Apply rounded corners
            statusPanel.Region = GetRoundedRegion(statusPanel.Width, statusPanel.Height, 15);

            // Add shadow effect
            ApplyShadowEffect(statusPanel);

            Label statusTitleLabel = new Label
            {
                Text = "Sistem Durumu",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            Panel statusIndicatorPanel = new Panel
            {
                Width = width - 40, // 20px padding on each side
                Height = 50,
                Location = new Point(20, 60),
                BackColor = Color.FromArgb(232, 245, 233),
                BorderStyle = BorderStyle.None
            };

            // Apply rounded corners to status indicator
            statusIndicatorPanel.Region = GetRoundedRegion(statusIndicatorPanel.Width, statusIndicatorPanel.Height, 10);

            Label statusIndicatorLabel = new Label
            {
                Text = "OTOMATİK MODDA",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(76, 175, 80),
                AutoSize = true
            };

            // Center the status indicator label
            statusIndicatorLabel.Location = new Point(
                (statusIndicatorPanel.Width - statusIndicatorLabel.PreferredWidth) / 2,
                (statusIndicatorPanel.Height - statusIndicatorLabel.PreferredHeight) / 2
            );

            // Create system control toggles
            string[] systemLabels = {
                "Sıcaklık Kontrol", "Nem Kontrol", "Işık Kontrol", "Sulama Sistemi", "Havalandırma"
            };

            for (int i = 0; i < systemLabels.Length; i++)
            {
                CreateSystemToggle(systemLabels[i], new Point(20, 130 + (i * 60)), statusPanel, width - 40);
            }

            // Add additional status summary panel at the bottom
            int summaryPanelY = 130 + (systemLabels.Length * 60) + 20;

            // Only add summary panel if there's enough space
            if (summaryPanelY + 100 < height)
            {
                Panel summaryPanel = new Panel
                {
                    Width = width - 40,
                    Height = 100,
                    Location = new Point(20, summaryPanelY),
                    BackColor = Color.FromArgb(240, 248, 255),
                    BorderStyle = BorderStyle.None
                };

                // Apply rounded corners
                summaryPanel.Region = GetRoundedRegion(summaryPanel.Width, summaryPanel.Height, 10);

                Label summaryTitle = new Label
                {
                    Text = "Sistem Özeti",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    Location = new Point(15, 10),
                    AutoSize = true
                };

                Label summaryStatus = new Label
                {
                    Text = "Tüm sistemler normal çalışıyor",
                    Font = new Font("Segoe UI", 10),
                    ForeColor = Color.FromArgb(46, 125, 50),
                    Location = new Point(15, 40),
                    AutoSize = true
                };

                Label summaryTime = new Label
                {
                    Text = "Son güncelleme: " + DateTime.Now.ToString("HH:mm:ss"),
                    Font = new Font("Segoe UI", 9),
                    ForeColor = Color.Gray,
                    Location = new Point(15, 70),
                    AutoSize = true
                };

                summaryPanel.Controls.Add(summaryTitle);
                summaryPanel.Controls.Add(summaryStatus);
                summaryPanel.Controls.Add(summaryTime);
                statusPanel.Controls.Add(summaryPanel);
            }

            statusPanel.Controls.Add(statusTitleLabel);
            statusPanel.Controls.Add(statusIndicatorPanel);
            statusIndicatorPanel.Controls.Add(statusIndicatorLabel);

            this.Controls.Add(statusPanel);
        }

        private void CreateSystemToggle(string label, Point location, Panel parent, int availableWidth)
        {
            Panel toggleContainer = new Panel
            {
                Width = availableWidth,
                Height = 50,
                Location = location,
                BackColor = Color.FromArgb(250, 250, 250),
                BorderStyle = BorderStyle.None
            };

            // Apply rounded corners
            toggleContainer.Region = GetRoundedRegion(toggleContainer.Width, toggleContainer.Height, 10);

            Label systemLabel = new Label
            {
                Text = label,
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.FromArgb(70, 70, 70),
                Location = new Point(15, 15),
                AutoSize = true
            };

            // Create toggle switch
            Panel toggleBackground = new Panel
            {
                Width = 60,
                Height = 30,
                Location = new Point(availableWidth - 80, 10),
                BackColor = Color.FromArgb(76, 175, 80),
                Cursor = Cursors.Hand
            };

            // Apply rounded corners to toggle
            toggleBackground.Region = GetRoundedRegion(toggleBackground.Width, toggleBackground.Height, 15);

            Panel toggleButton = new Panel
            {
                Width = 26,
                Height = 26,
                Location = new Point(32, 2),
                BackColor = Color.White,
                Cursor = Cursors.Hand
            };

            // Apply rounded corners to toggle button
            toggleButton.Region = GetRoundedRegion(toggleButton.Width, toggleButton.Height, 13);

            // Add hover effect for toggle
            toggleBackground.MouseEnter += (sender, e) => {
                toggleBackground.BackColor = Color.FromArgb(56, 155, 60);
            };

            toggleBackground.MouseLeave += (sender, e) => {
                toggleBackground.BackColor = Color.FromArgb(76, 175, 80);
            };

            toggleBackground.Controls.Add(toggleButton);
            toggleContainer.Controls.Add(systemLabel);
            toggleContainer.Controls.Add(toggleBackground);
            parent.Controls.Add(toggleContainer);
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

        private void ApplyShadowEffect(Panel panel)
        {
            // This is a placeholder for where you'd add shadow effects
            // In a real application you might use a third-party library or custom drawing
            // For now, we'll just add a border to simulate a shadow
            panel.BorderStyle = BorderStyle.None;

            // You could implement actual shadows with a custom paint event
            panel.Paint += (sender, e) => {
                Control control = (Control)sender;
                int shadowSize = 3;
                Color shadowColor = Color.FromArgb(30, 0, 0, 0);

                using (SolidBrush brush = new SolidBrush(shadowColor))
                {
                    e.Graphics.FillRectangle(brush,
                        new Rectangle(shadowSize, shadowSize,
                        control.Width, control.Height));
                }
            };
        }

        // Designer-generated code
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AdminDashboardPage
            // 
            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AdminDashboardPage";
            this.Size = new System.Drawing.Size(800, 600);
            this.ResumeLayout(false);
        }
    }
}