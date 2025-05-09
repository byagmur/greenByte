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

            ChartHazirla();
        }

       private void ChartHazirla()
{
    // Önce eski serileri temizle
    chartSicaklikVeNem.Series.Clear();

    // Sıcaklık serisi
    var sicaklikSerisi = new System.Windows.Forms.DataVisualization.Charting.Series("Sıcaklık (°C)");
    sicaklikSerisi.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
    sicaklikSerisi.Color = System.Drawing.Color.Red;
    sicaklikSerisi.BorderWidth = 2;

    // Nem serisi
    var nemSerisi = new System.Windows.Forms.DataVisualization.Charting.Series("Nem (%)");
    nemSerisi.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
    nemSerisi.Color = System.Drawing.Color.Blue;
    nemSerisi.BorderWidth = 2;

    // Örnek saatler ve veriler (görseldeki gibi)
    string[] saatler = { "00:00", "03:00", "06:00", "09:00", "12:00", "15:00", "18:00", "21:00", "24:00" };
    double[] sicakliklar = { 24, 23.5, 23, 24, 25, 25.5, 25, 24.5, 24 };
    double[] nemler =      { 65, 63, 62, 64, 66, 67, 66, 65, 65 };

    for (int i = 0; i < saatler.Length; i++)
    {
        sicaklikSerisi.Points.AddXY(saatler[i], sicakliklar[i]);
        nemSerisi.Points.AddXY(saatler[i], nemler[i]);
    }

    chartSicaklikVeNem.Series.Add(sicaklikSerisi);
    chartSicaklikVeNem.Series.Add(nemSerisi);

    // Eksen ve grid ayarları
    var ca = chartSicaklikVeNem.ChartAreas[0];
    ca.AxisX.Title = "Saat";
    ca.AxisY.Title = "Değer";
    ca.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
    ca.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
    ca.AxisX.Interval = 1;
    ca.AxisX.LabelStyle.Angle = -45;

    // Legend ayarı
    chartSicaklikVeNem.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
}

// Bunu constructor'da çağırabilirsin
        
    }
}