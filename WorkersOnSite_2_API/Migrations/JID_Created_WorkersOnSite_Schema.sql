



    ----DROP TABLE PERSON
    --CREATE TABLE dbo.PERSON 
    --(
    --    PersonID                  uniqueidentifier NOT NULL Primary Key Default(newsequentialid())
    --   ,PersonFireBase            nvarchar(50)     NULL Default('')
    --   ,PersonFName               nvarchar(50)     NULL Default('')
    --   ,PersonMInitial            nvarchar(50)     NULL Default('')
    --   ,PersonLName               nvarchar(50)     NULL Default('')
    --   ,PersonSSN                 nvarchar(50)     NULL Default('')
    --   ,PersonBirthday            DateTime         NULL
    --   ,PersonSalary              int              NULL Default(0)
    --   ,PersonPhoneNumber1        nvarchar(50)     NULL Default('')
    --   ,PersonPhoneNumber2        nvarchar(50)     NULL Default('')
    --   ,PersonType                int              NULL Default('')
    --)
    --SELECT * FROM PERSON


    ----DROP TABLE TEAMS
    --CREATE TABLE dbo.TEAMS 
    --(
    --    TeamID                  uniqueidentifier NOT NULL Primary Key Default(newsequentialid())
    --   ,TeamFName               nvarchar(50)     NULL Default('')
    --   ,TeamLocation            nvarchar(50)     NULL Default('')
    --   ,TeamPhoneNumber         nvarchar(50)     NULL Default('')
    --)
    --SELECT * FROM TEAMS


    ----DROP TABLE PERSONTEAM    
    --CREATE TABLE dbo.PERSONTEAM 
    --(
    --    PersonTeamID         uniqueidentifier     NOT NULL Primary Key Default(newsequentialid())
    --   ,PersonTeamPersonID   uniqueidentifier     NOT NULL Default('')
    --   ,PersonTeamTeamID     uniqueidentifier     NOT NULL Default('')
    --)
    --ALTER TABLE dbo.PERSONTEAM 
    --ADD FOREIGN KEY (PersonTeamPersonID) REFERENCES dbo.PERSON (PersonID)
    --   ,FOREIGN KEY (PersonTeamTeamID) REFERENCES dbo.TEAMS (TeamID)
    --SELECT * FROM PERSONTEAM


    ----DROP TABLE SITES
    --CREATE TABLE dbo.SITES 
    --(
    --    SiteID               uniqueidentifier    NOT NULL Primary Key Default(newsequentialid())
    --   ,SiteName             nvarchar(50)        NULL Default('')
    --   ,SiteLocation         nvarchar(50)        NULL Default('')
    --   ,SiteNumber           nvarchar(50)        NULL Default('')
    --   ,SiteStartTime        DateTime            NULL Default(dateadd(mm, 1, dateadd(dd, -day(getdate())+1, getdate())))
    --   ,SiteIsCompleted      bit                 NULL Default(0)
    --   ,SitesTeamID          uniqueidentifier    NULL Default('')
    --   ,SitesPersonID        uniqueidentifier    NULL Default('')
    --)
    --ALTER TABLE dbo.SITES 
    --   ADD FOREIGN KEY (SitesTeamID) REFERENCES dbo.TEAMS (TeamID)
    --      ,FOREIGN KEY (SitesPersonID) REFERENCES dbo.PERSON (PersonID)
    --SELECT * FROM SITES



    SELECT * FROM PERSON
    SELECT * FROM TEAMS
    SELECT * FROM PERSONTEAM
    SELECT * FROM SITES

