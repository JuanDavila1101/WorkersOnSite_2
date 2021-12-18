




    SELECT * FROM PERSON
    SELECT * FROM TEAMS
    SELECT * FROM PERSONTEAM
    SELECT * FROM SITES


   -- INSERT INTO PERSON ( PersonFireBase
   --                     ,PersonFName
   --                     ,PersonMInitial
   --                     ,PersonLName
   --                     ,PersonSSN
   --                     ,PersonBirthday
   --                     ,PersonSalary
   --                     ,PersonPhoneNumber1
   --                     ,PersonPhoneNumber2
   --                     ,PersonType)
   -- VALUES ('1', 'Juan1', 'I', 'Davila', '555555551', CAST('1976-07-13' AS datetime), 60000, '9105461061', '9105453304', 0)


   --     INSERT INTO PERSON ( PersonFireBase
   --                     ,PersonFName
   --                     ,PersonMInitial
   --                     ,PersonLName
   --                     ,PersonSSN
   --                     ,PersonBirthday
   --                     ,PersonSalary
   --                     ,PersonPhoneNumber1
   --                     ,PersonPhoneNumber2
   --                     ,PersonType)
   -- VALUES ('2', 'Juan2', 'I', 'Davila', '555555552', CAST('1976-07-13' AS datetime), 60000, '9105461061', '9105453304', 0)


   --     INSERT INTO PERSON ( PersonFireBase
   --                     ,PersonFName
   --                     ,PersonMInitial
   --                     ,PersonLName
   --                     ,PersonSSN
   --                     ,PersonBirthday
   --                     ,PersonSalary
   --                     ,PersonPhoneNumber1
   --                     ,PersonPhoneNumber2
   --                     ,PersonType)
   -- VALUES ('3', 'Juan3', 'I', 'Davila', '555555553', CAST('1976-07-13' AS datetime), 60000, '9105461061', '9105453304', 0)


   --     INSERT INTO PERSON ( PersonFireBase
   --                     ,PersonFName
   --                     ,PersonMInitial
   --                     ,PersonLName
   --                     ,PersonSSN
   --                     ,PersonBirthday
   --                     ,PersonSalary
   --                     ,PersonPhoneNumber1
   --                     ,PersonPhoneNumber2
   --                     ,PersonType)
   -- VALUES ('4', 'Juan4', 'I', 'Davila', '555555554', CAST('1976-07-13' AS datetime), 60000, '9105461061', '9105453304', 0)
          

   -- INSERT INTO PERSON ( PersonFireBase
   --                     ,PersonFName
   --                     ,PersonMInitial
   --                     ,PersonLName
   --                     ,PersonSSN
   --                     ,PersonBirthday
   --                     ,PersonSalary
   --                     ,PersonPhoneNumber1
   --                     ,PersonPhoneNumber2
   --                     ,PersonType)
   -- VALUES ('5', 'Danielle1', 'Y', 'Davila', '777777771', CAST('1975-10-04' AS datetime), 60000, '9105453304', '9105461061', 0)


    
   -- INSERT INTO PERSON ( PersonFireBase
   --                     ,PersonFName
   --                     ,PersonMInitial
   --                     ,PersonLName
   --                     ,PersonSSN
   --                     ,PersonBirthday
   --                     ,PersonSalary
   --                     ,PersonPhoneNumber1
   --                     ,PersonPhoneNumber2
   --                     ,PersonType)
   -- VALUES ('6', 'Danielle2', 'Y', 'Davila', '777777772', CAST('1975-10-04' AS datetime), 60000, '9105453304', '9105461061', 0)
    
    
   -- INSERT INTO PERSON ( PersonFireBase
   --                     ,PersonFName
   --                     ,PersonMInitial
   --                     ,PersonLName
   --                     ,PersonSSN
   --                     ,PersonBirthday
   --                     ,PersonSalary
   --                     ,PersonPhoneNumber1
   --                     ,PersonPhoneNumber2
   --                     ,PersonType)
   -- VALUES ('7', 'Danielle3', 'Y', 'Davila', '777777773', CAST('1975-10-04' AS datetime), 60000, '9105453304', '9105461061', 0)
         
         
   -- INSERT INTO PERSON ( PersonFireBase
   --                     ,PersonFName
   --                     ,PersonMInitial
   --                     ,PersonLName
   --                     ,PersonSSN
   --                     ,PersonBirthday
   --                     ,PersonSalary
   --                     ,PersonPhoneNumber1
   --                     ,PersonPhoneNumber2
   --                     ,PersonType)
   -- VALUES ('4', 'Danielle4', 'Y', 'Davila', '777777774', CAST('1975-10-04' AS datetime), 60000, '9105453304', '9105461061', 0)

          
   -- INSERT INTO TEAMS (TeamName, TeamLocation, TeamPhoneNumber)
   --      VALUES ('Team #1', 'Murfreesboro', '1')

   -- INSERT INTO TEAMS (TeamName, TeamLocation, TeamPhoneNumber)
   --      VALUES ('Team #2', 'Murfreesboro2', '2')
  

   --   INSERT INTO TEAMS (TeamName, TeamLocation, TeamPhoneNumber)
   --      VALUES ('Team #3', 'Murfreesboro3', '3')

           
   --INSERt INTO PERSONTEAM (PersonTeamPersonID, PersonTeamTeamID)
   --      VALUES ( CAST((SELECT PersonID FROM PERSON WHERE PersonFName = 'Juan2') AS uniqueidentifier) 
   --              ,CAST((SELECT TeamID FROM TEAMS WHERE TeamName = 'Team #2' ) AS uniqueidentifier))

   --INSERt INTO PERSONTEAM (PersonTeamPersonID, PersonTeamTeamID)
   --      VALUES ( CAST((SELECT PersonID FROM PERSON WHERE PersonFName = 'Danielle2') AS uniqueidentifier) 
   --              ,CAST((SELECT TeamID FROM TEAMS WHERE TeamName = 'Team #2' ) AS uniqueidentifier))


   --INSERt INTO PERSONTEAM (PersonTeamPersonID, PersonTeamTeamID)
   --      VALUES ( CAST((SELECT PersonID FROM PERSON WHERE PersonFName = 'Juan3') AS uniqueidentifier) 
   --              ,CAST((SELECT TeamID FROM TEAMS WHERE TeamName = 'Team #3' ) AS uniqueidentifier))

   --INSERt INTO PERSONTEAM (PersonTeamPersonID, PersonTeamTeamID)
   --      VALUES ( CAST((SELECT PersonID FROM PERSON WHERE PersonFName = 'Danielle3') AS uniqueidentifier) 
   --              ,CAST((SELECT TeamID FROM TEAMS WHERE TeamName = 'Team #3' ) AS uniqueidentifier))



   --INSERT INTO SITES (SiteName, SiteLocation, SiteNumber, SitesPersonID)
   --      VALUES ( 'Casa De Juan1', 'Murfressboro1', '1' 
   --              ,CAST((SELECT PersonID FROM PERSON WHERE PersonFName = 'Juan4') AS uniqueidentifier)
   --              )

   --INSERT INTO SITES (SiteName, SiteLocation, SiteNumber, SitesPersonID)
   --      VALUES ( 'Casa De Danielle1', 'Murfressboro1', '1' 
   --              ,CAST((SELECT PersonID FROM PERSON WHERE PersonFName = 'Danielle4') AS uniqueidentifier)
   --              )

   --INSERT INTO SITES (SiteName, SiteLocation, SiteNumber, SitesTeamID, SitesPersonID)
   --      VALUES ( 'Casa De Juan', 'Murfressboro', '2' 
   --              ,CAST((SELECT TeamID FROM TEAMS WHERE TeamName = 'Team #2') AS uniqueidentifier)
   --              ,CAST((SELECT PersonID FROM PERSON WHERE PersonFName = 'Juan1') AS uniqueidentifier)
   --              )

   --INSERT INTO SITES (SiteName, SiteLocation, SiteNumber, SitesTeamID, SitesPersonID)
   --      VALUES ( 'Casa De Danielle', 'Murfressboro', '3' 
   --              ,CAST((SELECT TeamID FROM TEAMS WHERE TeamName = 'Team #3') AS uniqueidentifier)
   --              ,CAST((SELECT PersonID FROM PERSON WHERE PersonFName = 'Danielle1') AS uniqueidentifier)
   --              )

      ---       CAST(() AS uniqueidentifier)







    SELECT * FROM PERSON
    SELECT * FROM TEAMS
    SELECT * FROM PERSONTEAM
    SELECT * FROM SITES














