using Dapper;
using GreenByte.Models;
using System.Collections.Generic;
using System.Linq;

namespace GreenByte.DataAccess
{
    public class SensorDataDataAccess
    {
        public List<SensorData> GetAll()
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, sensor_id AS SensorId, deger AS Value, kayit_zamani AS RecordTime FROM sensor_verileri";
                return connection.Query<SensorData>(sql).ToList();
            }
        }

        public SensorData GetById(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, sensor_id AS SensorId, deger AS Value, kayit_zamani AS RecordTime FROM sensor_verileri WHERE id = @Id";
                return connection.QueryFirstOrDefault<SensorData>(sql, new { Id = id });
            }
        }

        public void Add(SensorData data)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "INSERT INTO sensor_verileri (sensor_id, deger) VALUES (@SensorId, @Value)";
                connection.Execute(sql, data);
            }
        }

        public void Update(SensorData data)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "UPDATE sensor_verileri SET sensor_id = @SensorId, deger = @Value WHERE id = @Id";
                connection.Execute(sql, data);
            }
        }

        public void Delete(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "DELETE FROM sensor_verileri WHERE id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }

        public List<SensorData> GetBySensorId(int sensorId) // SensorId'ye göre veri çekme
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, sensor_id AS SensorId, deger AS Value, kayit_zamani AS RecordTime FROM sensor_verileri WHERE sensor_id = @SensorId ORDER BY kayit_zamani";
                return connection.Query<SensorData>(sql, new { SensorId = sensorId }).ToList();
            }
        }
    }
}