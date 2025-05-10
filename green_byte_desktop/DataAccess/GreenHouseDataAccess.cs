using Dapper;
using GreenByte.Models;
using System.Collections.Generic;
using System.Linq;

namespace GreenByte.DataAccess
{
    public class GreenHouseDataAccess
    {
        public List<Greenhouse> GetAll()
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, kullanici_id AS UserId, ad AS Name, konum AS Location, olusturma_tarihi AS CreationDate FROM seralar";
                return connection.Query<Greenhouse>(sql).ToList();
            }
        }

        public Greenhouse GetById(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "SELECT id AS Id, kullanici_id AS UserId, ad AS Name, konum AS Location, olusturma_tarihi AS CreationDate FROM seralar WHERE id = @Id";
                return connection.QueryFirstOrDefault<Greenhouse>(sql, new { Id = id });
            }
        }

        public void Add(Greenhouse greenhouse)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "INSERT INTO seralar (kullanici_id, ad, konum) VALUES (@UserId, @Name, @Location)";
                connection.Execute(sql, greenhouse);
            }
        }

        public void Update(Greenhouse greenhouse)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "UPDATE seralar SET kullanici_id = @UserId, ad = @Name, konum = @Location WHERE id = @Id";
                connection.Execute(sql, greenhouse);
            }
        }

        public void Delete(int id)
        {
            using (var connection = DBContext.GetConnection())
            {
                string sql = "DELETE FROM seralar WHERE id = @Id";
                connection.Execute(sql, new { Id = id });
            }
        }
    }
}