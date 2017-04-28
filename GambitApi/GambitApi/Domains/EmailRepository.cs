using System;
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
    public class EmailRepository : IRepository<Email, string>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Gambit"].ConnectionString;

        public Email Get(string id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Email>("Select Top(1) * From Email where kontaktEmail = @id", new { id }).FirstOrDefault();
            }
        }

        public void Add(Email model)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query(@"insert into dbo.Email 
                                 ([kontaktEmail])
                           values(@kontaktEmail)",
                    new {kontaktEmail = model.KontaktEmail});
            }
        }

        public void Modify(Email model)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Email> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}