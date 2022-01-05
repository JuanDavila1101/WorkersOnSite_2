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
                                    SELECT CAST(PersonID AS varchar(36)) PersonID     
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
                                          ,ISNULL((SELECT CAST(PersonTeamTeamID AS VARCHAR(36)) TeamID 
                                                   FROM PersonTeam
                                                   WHERE PersonTeamPersonID = CAST(PersonID AS VARCHAR(36))), '') AS TeamID
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
                  SELECT CAST(PersonID AS VARCHAR(36)) PersonID          
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
                        ,ISNULL((SELECT CAST(PersonTeamTeamID AS VARCHAR(36)) TeamID 
                                 FROM PersonTeam
                                 WHERE PersonTeamPersonID = CAST(@personID AS VARCHAR(36))), '') AS TeamID
                  FROM [WorkersOnSite2DB].[dbo].[PERSON]
                  WHERE PersonID = CAST(@personID AS uniqueidentifier)
                  ";

      //var convertPersonIDToGUID = new
      //{
      //  PersonID = personID
      //};


      var personByID = db.QueryFirstOrDefault<Person>(sql, new { personID });

      //var personByID = await db.QueryFirstOrDefaultAsync<Person>(sql, convertPersonIDToGUID);
      return personByID;
    }

    public async Task<Person> AddPerson(Person person)
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
        PersonType         = (int)person._PersonType
      };

      var tempPerson = db.QueryFirstOrDefault<Person>(sql, parameters);

      HandleTeam(tempPerson);

      return tempPerson;
    }

    void HandleTeam(Person person)
    {
      if (person == null) return;

      using var db = new SqlConnection(_connectionString);

      var sql = string.Empty;

      if (string.IsNullOrWhiteSpace(person.TeamID))
      {
        DeleteTeam(person.PersonID);
      } 
      else
      {
        sql = @"
                IF NOT EXISTS(
                              SELECT * 
                              FROM PersonTeam
                              WHERE PersonTeamPersonID = CAST(@PersonID AS uniqueidentifier)
                              )
                              INSERT INTO PersonTeam
                                    (
                                     PersonTeamPersonID
                                    ,PersonTeamTeamID
                                     )
                              VALUES(
                                     @PersonID
                                    ,@TeamID
                                     )
                ELSE 
                    UPDATE PersonTeam
                    SET PersonTeamTeamID = CAST(@TeamID AS uniqueidentifier)
                    WHERE PersonTeamPersonID = CAST(@PersonID AS uniqueidentifier)
                "; 
      }

      db.Execute(sql, person);
    }

    void DeleteTeam(string personID)
    {
      using var db = new SqlConnection(_connectionString);
      var teamsql = @"
                      DELETE FROM PersonTeam
                      WHERE PersonTeamPersonID = CAST(@personID AS uniqueidentifier)
                      ";
      db.Execute(teamsql, new { personID });
    }


    public async Task<Person> UpdatePerson(Person person)
    {
      HandleTeam(person);

      using var db = new SqlConnection(_connectionString);

      var sql = @"
                  UPDATE PERSON 
                     SET  PersonFireBase     = @PersonFireBase
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
        PersonType = (int)person._PersonType
      };

      return db.QueryFirstOrDefault<Person>(sql, parameters);
    }

    public void DeletePerson(string personID)
    {
      DeleteTeam(personID);

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
