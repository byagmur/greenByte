using GreenByte.DataAccess;
using GreenByte.Models;
using System.Linq;
using System.Windows.Forms;

namespace greenByte.Pages
{
    public partial class DataControlPage : UserControl
    {

private SensorDataDataAccess sensordal = new SensorDataDataAccess();
        public DataControlPage()
        {
            InitializeComponent();
            Utils.StyleDataGrid(dataGridViewDatas);
            LoadDatas();
        }

        private void LoadDatas()
        {
            var seraId = CurrentGreenhouse.Selected?.Id ?? 0;

            // Daha performanslı bir sorgu için GetByGreenhouseId kullanıldı
            var filteredDatas = sensordal.GetByGreenhouseId(seraId);
            dataGridViewDatas.DataSource = filteredDatas;

            // Kolon başlıklarını düzenle
            dataGridViewDatas.Columns["Id"].HeaderText = "ID";
            dataGridViewDatas.Columns["Id"].Visible = false;
            dataGridViewDatas.Columns["SensorId"].HeaderText = "Sensor ID";
            dataGridViewDatas.Columns["SensorId"].Visible = false; // Görünür yapıldı
            dataGridViewDatas.Columns["GreenhouseId"].HeaderText = "Sera ID";
            dataGridViewDatas.Columns["GreenhouseId"].Visible = false; // Görünür yapıldı
            dataGridViewDatas.Columns["Value"].HeaderText = "Değer";
            dataGridViewDatas.Columns["RecordTime"].HeaderText = "Kayıt Zamanı";
            dataGridViewDatas.Columns["RecordTime"].Visible = true; // Görünür yapıldı
            dataGridViewDatas.Columns["RecordTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss"; // Tarih formatı
            dataGridViewDatas.Columns["RecordTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; // Orta hizalama
        }
    }
}
