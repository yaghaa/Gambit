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
    public class NoteRepository : IRepository<Note, int>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Gambit"].ConnectionString;

        public Note Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Note>("Select Top(1) * From Notatka where notatkaId = @id", new { id }).FirstOrDefault();
            }
        }

        public void Add(Note model)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query(@"insert into dbo.Notatka 
                                 ([tytul]
	                             ,[opis]
	                             ,[data]
	                             ,[notatkaId]
	                             ,[wydarzenieId]
	                             ,[Id])
                           values(@tytul
	                             ,@opis
	                             ,@data
	                             ,@notatkaId
	                             ,@wydarzenieId
	                             ,@Id)", new
                {
                    tytul = model.Title,
                    opis = model.Description,
                    data = model.Date,
                    notatkaId = model.NotatkaId,
                    wydarzenieId = model.WydarzenieId,
                    id = model.Id
                });
            }
        }

        public void Modify(Note model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Note> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}