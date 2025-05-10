using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using GreenByte.DataAccess;
using GreenByte.Models;

namespace greenByte.Controls
{
    public partial class AdminDashboardPage : UserControl
    {
        private Chart temperatureHumidityChart;

        public AdminDashboardPage()
        {
            InitializeComponent();
            updateLabelsByData();
            ChartHazirla();
           

            this.tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
                

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
          
            var panel = sender as TableLayoutPanel;
            if (panel != null)
            {
                using (var pen = new System.Drawing.Pen(Color.LightGray, 2))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, panel.Width - 1, panel.Height - 1);
                }
            }
        
        }

        private void updateLabelsByData()
        {
            var sensorDataAccess = new SensorDataAccess();

            // Sıcaklık sensörünün son verisi (id: 6)
            var sicaklikData = sensorDataAccess.GetBySensorId(6).OrderByDescending(d => d.RecordTime).FirstOrDefault();
            if (sicaklikData != null)
                labelSicaklik.Text = $"{sicaklikData.Value} °C";

            // Nem sensörünün son verisi (id: 7)
            var nemData = sensorDataAccess.GetBySensorId(6).OrderByDescending(d => d.RecordTime).FirstOrDefault();
            if (nemData != null)
                labelNem.Text = $"{nemData.Value} %";

            // Toprak nemi sensörünün son verisi (id: 7)
            var toprakNemData = sensorDataAccess.GetBySensorId(7).OrderByDescending(d => d.RecordTime).FirstOrDefault();
            if (toprakNemData != null)
                labelToprakNem.Text = $"{toprakNemData.Value} %";

            // Işık seviyesi sensörünün son verisi (id: 9)
            var isikData = sensorDataAccess.GetBySensorId(9).OrderByDescending(d => d.RecordTime).FirstOrDefault();
            if (isikData != null)
                labelIsik.Text = $"{isikData.Value} lux";

            var suSeviyeData = sensorDataAccess.GetBySensorId(8).OrderByDescending(d => d.RecordTime).FirstOrDefault();
            if (suSeviyeData != null)
                labelSuSeviyesi.Text = $"{suSeviyeData.Value} %";
        }


        private void ChartHazirla()
        {
            chartSicaklikVeNem.Series.Clear();

            var sicaklikSerisi = new System.Windows.Forms.DataVisualization.Charting.Series("Sıcaklık (°C)")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
                Color = System.Drawing.Color.Red,
                BorderWidth = 2
            };

            var nemSerisi = new System.Windows.Forms.DataVisualization.Charting.Series("Nem (%)")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
                Color = System.Drawing.Color.Blue,
                BorderWidth = 2
            };

            // SensorDataAccess ile sıcaklık ve nem verilerini çek
            var sensorDataAccess = new SensorDataAccess();

            // Sıcaklık ve nem sensörlerinin id'si 6 ise:
            var sicaklikVerileri = sensorDataAccess.GetBySensorId(6);
            var nemVerileri = sensorDataAccess.GetBySensorId(7); // Eğer nem sensörünün id'si 7 ise

            // X ekseni için saat/zaman bilgisini kullan
            foreach (var data in sicaklikVerileri.Cast<SensorData>())
            {
                sicaklikSerisi.Points.AddXY(data.RecordTime.ToString("HH:mm"), data.Value);
            }
            foreach (var data in nemVerileri.Cast<SensorData>())
            {
                nemSerisi.Points.AddXY(data.RecordTime.ToString("HH:mm"), data.Value);
            }

            chartSicaklikVeNem.Series.Add(sicaklikSerisi);
            chartSicaklikVeNem.Series.Add(nemSerisi);

            var ca = chartSicaklikVeNem.ChartAreas[0];
            ca.AxisX.Title = "Saat";
            ca.AxisY.Title = "Değer";
            ca.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            ca.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            ca.AxisX.LabelStyle.Angle = -45;

            chartSicaklikVeNem.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
        }

       

    }
}