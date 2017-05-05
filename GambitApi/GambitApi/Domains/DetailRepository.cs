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
    public class DetailRepository : IRepository<Details, int>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Gambit"].ConnectionString;

        public Details Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Details>("Select dzienImienin as NameDay, dataUrodzenia as BirthDay, infoId as InfoId From Info where infoId = @id", new { id }).FirstOrDefault();
            }
        }

        public void Add(Details model)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query(@"insert into dbo.Info 
                                 ([dzienImienin]
                                 ,[dataUrodzenia]
                                 ,[infoId])
                           values(@dzienImienin
	                             ,@dataUrodzenia
	                             ,@infoId)", new
                {
                    dzienImienin = model.NameDay,
                    dataUrodzenia = model.BirthDay,
                    infoId = model.InfoId
                });
            }
        }

        public void Modify(Details model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Details> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}