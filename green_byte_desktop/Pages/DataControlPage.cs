using GreenByte.DataAccess;
using GreenByte.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            LoadSensorTypes();
            LoadDatas();
        }
        private void LoadSensorTypes()
        {
            try
            {
                var sensors = sensordal.GetAll();
                comboBoxSensorType.DataSource = sensors;
                comboBoxSensorType.DisplayMember = "Name"; // Sensör adı gösterilecek
                comboBoxSensorType.ValueMember = "Id";    // Sensör ID değer olarak alındı
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Info,
                    Message = "Sensör listesi başarıyla yüklendi.",
                    LogTime = DateTime.Now
                });
            }
            catch
            {
                LogDataAccess.Add(new LogModel
                {
                    UserId = CurrentUser.Id,
                    LogType = LogType.Error,
                    Message = "Sensör listesi yüklenirken hata oluştu.",
                    LogTime = DateTime.Now
                });
            }
        }
        private void LoadDatas()
        {
            var seraId = CurrentGreenhouse.Selected?.Id ?? 0;
            var selectedSensorId = comboBoxSensorType.SelectedValue != null ?
                                   Convert.ToInt32(comboBoxSensorType.SelectedValue) : 0;
            List<SensorData> filteredDatas;
            if (selectedSensorId > 0)
            {
                // Sensör ID'ye göre filtrele
                filteredDatas = sensordal.GetBySensorId(selectedSensorId);
            }
            else
            {
                // Sadece sera ID'ye göre filtrele
                filteredDatas = sensordal.GetByGreenhouseId(seraId);
            }
            dataGridViewDatas.DataSource = filteredDatas;
            // Sütun ayarlarını düzenle
            dataGridViewDatas.Columns["Id"].HeaderText = "ID";
            dataGridViewDatas.Columns["Id"].Visible = false;
            dataGridViewDatas.Columns["SensorId"].HeaderText = "Sensor ID";
            dataGridViewDatas.Columns["SensorId"].Visible = false;
            // GreenhouseId artık SensorData nesnesinde yok, bu satırı kaldırıyoruz
            // dataGridViewDatas.Columns["GreenhouseId"].HeaderText = "Sera ID";
            // dataGridViewDatas.Columns["GreenhouseId"].Visible = false;
            dataGridViewDatas.Columns["Value"].HeaderText = "Değer";
            dataGridViewDatas.Columns["RecordTime"].HeaderText = "Kayıt Zamanı";
            dataGridViewDatas.Columns["RecordTime"].Visible = true;
            dataGridViewDatas.Columns["RecordTime"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dataGridViewDatas.Columns["RecordTime"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            // İsteğe bağlı: Sensör adı göstermek istiyorsanız JOIN sorgusuyla SensorName ekleyip burada gösterebilirsiniz
            // Eğer SensorData modelinize SensorName eklerseniz:
            // dataGridViewDatas.Columns["SensorName"].HeaderText = "Sensör";
            // dataGridViewDatas.Columns["SensorName"].Visible = true;
        }
        private void comboBoxSensorType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDatas();
        }
    }
}