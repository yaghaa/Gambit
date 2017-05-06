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
    public class FriendRepository : IRepository<Friend, int>, IRepositoryExtensions<Friend>
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["Gambit"].ConnectionString;

        private string sql = @"Select kontaktId as Id
                                         ,numer as Number
                                         ,kontaktEmail as Email
                                         ,imie as Name
                                         ,imie2 as Name2
                                         ,nazwisko as Surname
                                         ,miejscowosc as City
                                         ,kodPocztowy as ZipCode
                                         ,nrDomu as HouseNumber
                                         ,nrLokalu as FlatNumber
                                         ,wojewodztwo as County
                                         ,kraj as Country
                                         ,k.addressId as AddressId
                                         ,dzienImienin as NameDay
                                         ,dataUrodzenia as BirthDay
                                         ,k.infoId as InfoId
                                         From Kontakt k
                                         left Join Address a on a.addressId = k.addressId
                                         left Join Info i on k.infoId = i.infoId
                                         where kontaktId = @id";
        private string sqlAll = @"Select kontaktId as Id
                                         ,numer as Number
                                         ,kontaktEmail as Email
                                         ,imie as Name
                                         ,imie2 as Name2
                                         ,nazwisko as Surname
                                         ,miejscowosc as City
                                         ,kodPocztowy as ZipCode
                                         ,nrDomu as HouseNumber
                                         ,nrLokalu as FlatNumber
                                         ,wojewodztwo as County
                                         ,kraj as Country
                                         ,k.addressId as AddressId
                                         ,dzienImienin as NameDay
                                         ,dataUrodzenia as BirthDay
                                         ,k.infoId as InfoId
                                         From Kontakt k
                                         left Join Address a on a.addressId = k.addressId
                                         left Join Info i on k.infoId = i.infoId";
        private string sqlAllForUser = @"Select k.kontaktId as Id
                                         ,numer as Number
                                         ,kontaktEmail as Email
                                         ,imie as Name
                                         ,imie2 as Name2
                                         ,nazwisko as Surname
                                         ,miejscowosc as City
                                         ,kodPocztowy as ZipCode
                                         ,nrDomu as HouseNumber
                                         ,nrLokalu as FlatNumber
                                         ,wojewodztwo as County
                                         ,kraj as Country
                                         ,k.addressId as AddressId
                                         ,dzienImienin as NameDay
                                         ,dataUrodzenia as BirthDay
                                         ,k.infoId as InfoId
                                         From KontaktyUzytkownikow ku
                                         left Join Kontakt k on k.kontaktId = ku.kontaktId
                                         left Join Address a on a.addressId = k.addressId
                                         left Join Info i on k.infoId = i.infoId
                                         where ku.Id = @id";

        public Friend Get(int id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var f = db.Query<Friend, Address, Details, Friend>(sql, (friend, address, details) =>
                {
                    if (address != null)
                    {
                        friend.Address = address;
                    }

                    if (details != null)
                    {
                        friend.Details = details;
                    }

                    return friend;
                }, new { id }, splitOn: "City, NameDay").AsQueryable();
                   
                return f.First();
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
                                 ,@nazwisko)", new
                {
                    kontaktId = model.Id,
                    addressId = model.Address?.AddressId,
                    infoId = model.Details?.InfoId,
                    numer = model.Number,
                    kontaktEmail = model.Email,
                    imie = model.Name,
                    imie2 = model.Name2,
                    nazwisko = model.Surname
                });
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
                           Where [kontaktId] = @kontaktId", new
                {
                    kontaktId = model.Id,
                    addressId = model.Address?.AddressId,
                    infoId = model.Details?.InfoId,
                    numer = model.Number,
                    kontaktEmail = model.Email,
                    imie = model.Name,
                    imie2 = model.Name2,
                    nazwisko = model.Surname
                });
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
                var f = db.Query<Friend, Address, Details, Friend>(sqlAll, (friend, address, details) =>
                {
                    if (address != null)
                    {
                        friend.Address = address;
                    }

                    if (details != null)
                    {
                        friend.Details = details;
                    }

                    return friend;
                }, splitOn: "City, NameDay").ToList();

                return f;
            }
        }

        public List<Friend> GetAllForUser(string id)
        {
            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                var f = db.Query<Friend, Address, Details, Friend>(sqlAllForUser, (friend, address, details) =>
                {
                    if (address != null)
                    {
                        friend.Address = address;
                    }

                    if (details != null)
                    {
                        friend.Details = details;
                    }

                    return friend;
                }, new { id }, splitOn: "City, NameDay").ToList();

                return f;
            }
        }
    }
}