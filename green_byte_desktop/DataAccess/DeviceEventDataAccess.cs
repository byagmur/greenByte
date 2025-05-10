using Dapper;
using GreenByte.Models;
using System.Collections.Generic;
using System.Linq;

namespace GreenByte.DataAccess
{
    public class DeviceEventDataAccess
    {
        public List<DeviceEvent> GetAll()
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, cihaz_id AS DeviceId, islem AS Action, tetikleyici AS Trigger, zaman AS Time FROM cihaz_olaylari";
                return connection.Query<DeviceEvent>(sql).ToList();
            }
        }

        public DeviceEvent GetById(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, cihaz_id AS DeviceId, islem AS Action, tetikleyici AS Trigger, zaman AS Time FROM cihaz_olaylari WHERE id = @Id";
                return connection.QueryFirstOrDefault<DeviceEvent>(sql, new { Id = id });
            }
        }

        public void Add(DeviceEvent deviceEvent)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "INSERT INTO cihaz_olaylari (cihaz_id, islem, tetikleyici) VALUES (@DeviceId, @Action, @Trigger)";
                connection.Execute(sql, deviceEvent);
            }
        }

        public void Update(DeviceEvent deviceEvent)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "UPDATE cihaz_olaylari SET cihaz_id = @DeviceId, islem = @Action, tetikleyici = @Trigger WHERE id = @Id";
                connection.Execute(sql, deviceEvent);
            }
        }

        public void Delete(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "DELETE FROM cihaz_olaylari WHERE id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
    }
}