using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using GambitApi.Domains.Interfaces;
using GambitApi.Models.Entities;

namespace GambitApi.Domains
{
    public class EventRepository : IRepository<Event, int>, IRepositoryExtensions<Event>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Gambit"].ConnectionString;

        public Event Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var e = db.Query<Event>("Select Top(1) nazwa as Name, dataWydarzenia as Date, godzina as Hour, rodzaj as Kind, wydarzenieId as WydarzenieId From Wydarzenie where wydarzenieId = @id", new { id }).FirstOrDefault();
                return e;
            }
        }

        public void Add(Event model)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query(@"insert into dbo.Wydarzenie 
                                 ([nazwa]
                                 ,[dataWydarzenia]
                                 ,[godzina]
                                 ,[rodzaj]
                                 ,[wydarzenieId]
                                 ,[Id])
                           values(@nazwa
                                 ,@dataWydarzenia
                                 ,@godzina
                                 ,@rodzaj
                                 ,@wydarzenieId
                                 ,@Id)", new
                {
                    nazwa = model.Name,
                    dataWydarzenia = model.Date,
                    godzina = model.Hour,
                    rodzaj = model.Kind,
                    wydarzenieId = model.WydarzenieId,
                    model.Id,
                });
            }
        }

        public void Modify(Event model)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query(@"Update dbo.Wydarzenie set 
                                 [nazwa] = @nazwa
                                 ,[dataWydarzenia] = @dataWydarzenia
                                 ,[godzina] = @godzina
                                 ,[rodzaj] = @rodzaj
                           Where [wydarzenieId] = @wydarzenieId", new
                {
                    nazwa = model.Name,
                    dataWydarzenia = model.Date,
                    godzina = model.Hour,
                    rodzaj = model.Kind,
                    wydarzenieId = model.WydarzenieId
                });
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query("delete from Wydarzenie where wydarzenieId = @id", new { id });
            }
        }

        public List<Event> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Event>("Select nazwa as Name, dataWydarzenia as Date, godzina as Hour, rodzaj as Kind, wydarzenieId as WydarzenieId From Wydarzenie").ToList();
            }
        }

        public List<Event> GetAllForUser(string id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Event>("Select nazwa as Name, dataWydarzenia as Date, godzina as Hour, rodzaj as Kind, wydarzenieId as WydarzenieId From Wydarzenie where Id = @id", new {id}).ToList();
            }
        }
    }
}