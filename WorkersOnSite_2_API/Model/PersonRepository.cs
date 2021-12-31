using System;
using System.Collections.Generic;
using System.Linq;
using WorkersOnSite_2.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Dapper;

namespace WorkersOnSite_2_API.Model
{
  public class PersonRepository : IPersonRepository
  {
    //private readonly AppDbContext appDbContext;

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
                                    SELECT cast(PersonID as varchar(36)) PersonID     
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

    //public Person GetPersonByID(string personID)
    //{
    //  return (Person)_persons.Find(x => x.PersonID == personID);
    //}




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

      var personByID = await db.QueryFirstOrDefaultAsync<Person>(sql, convertPersonIDToGUID);
      return personByID;
    }

    public Person AddPerson(Person person)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"
                  INSERT INTO PERSON 
                        ( PersonFireBase
                         ,PersonFName
                         ,PersonMInitial
                         ,PersonLName
                         ,PersonSSN
                         ,PersonBirthday
                         ,PersonSalary
                         ,PersonPhoneNumber1
                         ,PersonPhoneNumber2
                         ,PersonType)
                  VALUES (
                           @PersonFireBase
                          ,@PersonFName
                          ,@PersonMInitial
                          ,@PersonLName
                          ,@PersonSSN
                          ,@PersonBirthday
                          ,@PersonSalary
                          ,@PersonPhoneNumber1
                          ,@PersonPhoneNumber2
                          ,@PersonType
                          )";

      var parameters = new
      {
        PersonFireBase     = person.PersonFireBaseKey,
        PersonFName        = person.PersonFName,
        PersonMInitial     = person.PersonMInitial,
        PersonLName        = person.PersonLName,
        PersonSSN          = person.PersonSSN,
        PersonBirthday     = person.PersonBirthday,
        PersonSalary       = person.Salary,
        PersonPhoneNumber1 = person.PersonPhoneNumber1,
        PersonPhoneNumber2 = person.PersonPhoneNumber2,
        PersonType         = 2
      };

      return db.QueryFirstOrDefault<Person>(sql, parameters);
    }


    public Person UpdatePerson(Person person)
    {
      using var db = new SqlConnection(_connectionString);

      var sql = @"
                  UPDATE PERSON 
                          PersonFireBase     = @PersonFireBase
                         ,PersonFName        = @PersonFName
                         ,PersonMInitial     = @PersonMInitial
                         ,PersonLName        = @PersonLName
                         ,PersonSSN          = @PersonSSN
                         ,PersonBirthday     = @PersonBirthday
                         ,PersonSalary       = @PersonSalary
                         ,PersonPhoneNumber1 = @PersonPhoneNumber1
                         ,PersonPhoneNumber2 = @PersonPhoneNumber2
                         ,PersonType         = @PersonType 
                  WHERE PersonID = CAST(@PersonID AS uniqueidentifier)
                   ";

      var parameters = new
      {
        PersonID = person.PersonID,
        PersonFireBase = person.PersonFireBaseKey,
        PersonFName = person.PersonFName,
        PersonMInitial = person.PersonMInitial,
        PersonLName = person.PersonLName,
        PersonSSN = person.PersonSSN,
        PersonBirthday = person.PersonBirthday,
        PersonSalary = person.Salary,
        PersonPhoneNumber1 = person.PersonPhoneNumber1,
        PersonPhoneNumber2 = person.PersonPhoneNumber2,
        PersonType = 2
      };

      return db.QueryFirstOrDefault<Person>(sql, parameters);
    }

    public void DeletePerson(string personID)
    {
      using var db = new SqlConnection(_connectionString);
      var sql = @"
                  DELETE 
                  FROM PERSON
                  WHERE PersonID = CAST(@personID  AS uniqueidentifier)
                  ";

      db.Execute(sql, new { personID });
    }



  }
}
