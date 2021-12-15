﻿using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkersOnSite_2.Shared;

namespace WorkersOnSite_2.Model
{
  public class PersonRepository : IPersonRepository
  {
    static List<Person> _persons = new List<Person>();

    readonly string _connectionString;

    public PersonRepository(IConfiguration config)
    {
      _connectionString = config.GetConnectionString("WorkersonSite2DB");
      LoadAllPeople();
    }

    private void LoadAllPeople()
    {
      using var db = new SqlConnection(_connectionString);
      _persons = db.Query<Person>(@"
                                    SELECT PersonID          
                                          ,PersonFireBase    
                                          ,PersonFName       
                                          ,PersonMInitial    
                                          ,PersonLName       
                                          ,PersonSSN         
                                          ,PersonBirthday    
                                          ,PersonSalary      
                                          ,PersonPhoneNumber1
                                          ,PersonPhoneNumber2
                                          ,PersonType        
                                    FROM PERSON                                    
                                    ").ToList();
    }

    public IEnumerable<Person> GetAllPersons()
    {
      return _persons;
    }

    public async Task<Person> GetPersonByID(string personID)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"
                  SELECT PersonID          
                        ,PersonFireBase    
                        ,PersonFName       
                        ,PersonMInitial    
                        ,PersonLName       
                        ,PersonSSN         
                        ,PersonBirthday    
                        ,PersonSalary      
                        ,PersonPhoneNumber1
                        ,PersonPhoneNumber2
                        ,PersonType        
                  FROM PERSON
                  WHERE PersonID = CAST(@PersonID AS uniqueidentifier)
                  ";

      var convertPersonIDToGUID = new
      {
        PersonID = personID
      };

      var personByID = await db.QueryFirstOrDefaultAsync<Person>(sql, convertPersonIDToGUID );
      return personByID;
    }


  }
}
