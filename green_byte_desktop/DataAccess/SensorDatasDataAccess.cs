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
                // sera_id sütunu kaldırıldı
                string sql = "SELECT id AS Id, sensor_id AS SensorId, deger AS Value, kayit_zamani AS RecordTime FROM sensor_verileri";
                return connection.Query<SensorData>(sql).ToList();
            }
        }

        public SensorData GetById(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                // sera_id sütunu kaldırıldı
                string sql = "SELECT id AS Id, sensor_id AS SensorId, deger AS Value, kayit_zamani AS RecordTime FROM sensor_verileri WHERE id = @Id";
                return connection.QueryFirstOrDefault<SensorData>(sql, new { Id = id });
            }
        }

        public void Add(SensorData data)
        {
            using (var connection = DBContext.GetConnection())
            {
                // sera_id sütunu kaldırıldı
                string sql = "INSERT INTO sensor_verileri (sensor_id, deger) VALUES (@SensorId, @Value)";
                connection.Execute(sql, data);
            }
        }

        public void Update(SensorData data)
        {
            using (var connection = DBContext.GetConnection())
            {
                // sera_id sütunu kaldırıldı
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

        public List<SensorData> GetBySensorId(int sensorId)
        {
            using (var connection = DBContext.GetConnection())
            {
                // sera_id sütunu kaldırıldı
                string sql = "SELECT id AS Id, sensor_id AS SensorId, deger AS Value, kayit_zamani AS RecordTime FROM sensor_verileri WHERE sensor_id = @SensorId ORDER BY kayit_zamani DESC";
                return connection.Query<SensorData>(sql, new { SensorId = sensorId }).ToList();
            }
        }

        public List<SensorData> GetByGreenhouseId(int greenhouseId)
        {
            using (var connection = DBContext.GetConnection())
            {
                // Artık sensor_verileri tablosunda sera_id sütunu olmadığı için,
                // Sensörler tablosundan sera_id (veya greenhouse_id) sütunu üzerinden ilişki kuruyoruz
                string sql = @"SELECT sv.id AS Id, sv.sensor_id AS SensorId, sv.deger AS Value, 
                              sv.kayit_zamani AS RecordTime 
                              FROM sensor_verileri sv
                              INNER JOIN sensorler s ON sv.sensor_id = s.id
                              WHERE s.sera_id = @GreenhouseId  -- Burada sensorler tablosundaki sera_id/greenhouse_id sütunu kullanılıyor
                              ORDER BY sv.kayit_zamani DESC";

                return connection.Query<SensorData>(sql, new { GreenhouseId = greenhouseId }).ToList();
            }
        }
    }
}