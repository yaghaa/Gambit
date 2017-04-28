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
    public class PhoneRepository : IRepository<Phone, string>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Gambit"].ConnectionString;

        public Phone Get(string id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Phone>("Select Top(1) * From Telefon where numer = @id", new {id}).FirstOrDefault();
            }
        }

        public void Add(Phone model)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query(@"insert into dbo.Telefon 
                                 ([numer]
                                 ,[typ])
                           values(@numer
                                 ,@typ)", new
                {
                    numer = model.Numer,
                    typ = model.Typ
                });
            }
        }

        public void Modify(Phone model)
        {
            throw new NotImplementedException();
        }

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Phone> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}