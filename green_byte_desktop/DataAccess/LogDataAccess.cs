using Dapper;
using GreenByte.Models;
using System.Collections.Generic;
using System.Linq;

namespace GreenByte.DataAccess
{
    public static class LogDataAccess
    {
        public static void Add(LogModel log)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "INSERT INTO log_kayitlari (kullanici_id, log_tipi, mesaj, log_zamani) VALUES (@KullaniciId, @LogTipi, @Mesaj, @LogZamani)";
                connection.Execute(sql, log);
            }
        }

        public static List<LogModel> GetAll()
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, kullanici_id AS KullaniciId, log_tipi AS LogTipi, mesaj AS Mesaj, log_zamani AS LogZamani FROM log_kayitlari";
                return connection.Query<LogModel>(sql).ToList();
            }
        }

        public static List<LogModel> GetByKullaniciId(int kullaniciId)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, kullanici_id AS KullaniciId, log_tipi AS LogTipi, mesaj AS Mesaj, log_zamani AS LogZamani FROM log_kayitlari WHERE kullanici_id = @KullaniciId";
                return connection.Query<LogModel>(sql, new { KullaniciId = kullaniciId }).ToList();
            }
        }
    }
}