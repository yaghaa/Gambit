using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Http;
using Dapper;
using GambitApi.Domains.Interfaces;
using GambitApi.Models.Entities;

namespace GambitApi.Domains
{
    public class FriendRepository : IRepository<Friend, int>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Gambit"].ConnectionString;

        public Friend Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Friend>("Select Top(1) * From Kontakt where kontaktId = @id", new {id}).FirstOrDefault();
            }
        }

        public void Add(Friend model)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query(@"insert into dbo.Kontakt 
                                 ([kontaktId]
                                 ,[addressId]
                                 ,[infoId]
                                 ,[numer]
                                 ,[kontaktEmail]
                                 ,[imie]
                                 ,[imie2]
                                 ,[nazwisko])
                           values(@kontaktId
                                 ,@addressId
                                 ,@infoId
                                 ,@numer
                                 ,@kontaktEmail
                                 ,@imie
                                 ,@imie2
                                 ,@nazwisko)", new {kontaktId = model.Id,
                                                    addressId = model.Address?.AddressId,
                                                    infoId = model.Details?.InfoId,
                                                    numer = model.Number,
                                                    kontaktEmail = model.Email,
                                                    imie = model.Name,
                                                    imie2 = model.Name2,
                                                    nazwisko = model.Surname});
            }
        }

        public void Modify(Friend model)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query(@"Update dbo.Kontakt set  
                                  [addressId] = @addressId
                                 ,[infoId] =@infoId
                                 ,[numer] =@numer
                                 ,[kontaktEmail] =@kontaktEmail
                                 ,[imie] =@imie
                                 ,[imie2] =@imie2
                                 ,[nazwisko] =@nazwisko
                           Where [kontaktId] = @kontaktId", new{kontaktId = model.Id,
                                                                addressId = model.Address?.AddressId,
                                                                infoId = model.Details?.InfoId,
                                                                numer = model.Number,
                                                                kontaktEmail = model.Email,
                                                                imie = model.Name,
                                                                imie2 = model.Name2,
                                                                nazwisko = model.Surname});
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                db.Query("delete from Kontakt where kontaktId = @id", new {id});
            }
        }

        public List<Friend> GetAll()
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                return db.Query<Friend>("Select * From Kontakt").ToList();
            }
        }
    }
}