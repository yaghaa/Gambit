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
    public class AddressRepository : IRepository<Address, int>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Gambit"].ConnectionString;
        public Address Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Address>("Select Top(1) * From Address where addressId = @id", new { id }).FirstOrDefault();
            }
        }

        public void Add(Address model)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query(@"INSERT INTO [dbo].[Address]
           ([miejscowosc]
           ,[nrDomu]
           ,[nrLokalu]
           ,[kodPocztowy]
           ,[wojewodztwo]
           ,[kraj]
           ,[addressId])
     VALUES
           (@miejscowosc
           ,@nrDomu
           ,@nrLokalu
           ,@kodPocztowy
           ,@wojewodztwo 
           ,@kraj 
           ,@addressId)", new
                {
                    miejscowosc = model.City,
                    nrDomu = model.HouseNumber,
                    nrLokalu = model.FlatNumber,
                    kodPocztowy = model.ZipCode,
                    wojewodztwo = model.County,
                    kraj = model.Country,
                    addressId = model.AddressId
                });
            }
        }

        public void Modify(Address model)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Address> GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}