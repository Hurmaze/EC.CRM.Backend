BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN ('Uid', 'Address', 'City') AND [object_id] = OBJECT_ID('[Locations]'))
    SET IDENTITY_INSERT [Locations] ON;
INSERT INTO [Locations] ([Uid], [Address], [City])
VALUES ('00000000-0000-0000-0000-000000000004', 'Ковальский провулок 19', 'Київ'),
('00000000-0000-0000-0000-000000000005', 'вулиця Травнева, 10, Броварський район, Київська область, 07443', 'Калинівка'),
('00000000-0000-0000-0000-000000000006', 'вулиця Відродження 31, Волиньска область, 43000', 'Луцьк'),
('00000000-0000-0000-0000-000000000007', NULL, 'Online');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN ('Uid', 'Address', 'City') AND [object_id] = OBJECT_ID('[Locations]'))
    SET IDENTITY_INSERT [Locations] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN ('Uid', 'Name') AND [object_id] = OBJECT_ID('[NonProfessionalInterest]'))
    SET IDENTITY_INSERT [NonProfessionalInterests] ON;
INSERT INTO [NonProfessionalInterests] ([Uid], [Name])
VALUES ('00000000-0000-0000-0000-000000000008', 'Читання'),
('00000000-0000-0000-0000-000000000009', 'Писання'),
('00000000-0000-0000-0000-000000000010', 'Малювання'),
('00000000-0000-0000-0000-000000000011', 'Живопис'),
('00000000-0000-0000-0000-000000000012', 'Фотографія'),
('00000000-0000-0000-0000-000000000013', 'Гра на музичних інструментах'),
('00000000-0000-0000-0000-000000000014', 'Спів'),
('00000000-0000-0000-0000-000000000015', 'Танці'),
('00000000-0000-0000-0000-000000000016', 'Кулінарія'),
('00000000-0000-0000-0000-000000000017', 'Пекарство'),
('00000000-0000-0000-0000-000000000018', 'Садівництво'),
('00000000-0000-0000-0000-000000000019', 'Походи в гори'),
('00000000-0000-0000-0000-000000000020', 'Кемпінг'),
('00000000-0000-0000-0000-000000000021', 'Риболовля'),
('00000000-0000-0000-0000-000000000022', 'Спостереження за птахами'),
('00000000-0000-0000-0000-000000000023', 'В''язання'),
('00000000-0000-0000-0000-000000000024', 'В''язання гачком'),
('00000000-0000-0000-0000-000000000025', 'Шиття'),
('00000000-0000-0000-0000-000000000026', 'Гончарство'),
('00000000-0000-0000-0000-000000000027', 'Скульптура'),
('00000000-0000-0000-0000-000000000028', 'Робота з деревом'),
('00000000-0000-0000-0000-000000000029', 'DIY проекти'),
('00000000-0000-0000-0000-000000000030', 'Збір марок'),
('00000000-0000-0000-0000-000000000031', 'Збір монет'),
('00000000-0000-0000-0000-000000000032', 'Збір антикваріату'),
('00000000-0000-0000-0000-000000000033', 'Збір винтажних речей'),
('00000000-0000-0000-0000-000000000034', 'Збір коміксів'),
('00000000-0000-0000-0000-000000000035', 'Збір фігурок'),
('00000000-0000-0000-0000-000000000036', 'Збір спортивної меморабілії'),
('00000000-0000-0000-0000-000000000037', 'Дивитися фільми'),
('00000000-0000-0000-0000-000000000038', 'Дивитися телешоу'),
('00000000-0000-0000-0000-000000000039', 'Грати в відеоігри'),
('00000000-0000-0000-0000-000000000040', 'Настільні ігри'),
('00000000-0000-0000-0000-000000000041', 'Розв''язування пазлів'),
('00000000-0000-0000-0000-000000000042', 'Кросворди'),
('00000000-0000-0000-0000-000000000043', 'Судоку'),
('00000000-0000-0000-0000-000000000044', 'Йога'),
('00000000-0000-0000-0000-000000000045', 'Медитація'),
('00000000-0000-0000-0000-000000000046', 'Біг'),
('00000000-0000-0000-0000-000000000047', 'Джоггінг'),
('00000000-0000-0000-0000-000000000048', 'Велосипед'),
('00000000-0000-0000-0000-000000000049', 'Плавання');
INSERT INTO [NonProfessionalInterests] ([Uid], [Name])
VALUES ('00000000-0000-0000-0000-000000000050', 'Серфінг'),
('00000000-0000-0000-0000-000000000051', 'Катання на лижах'),
('00000000-0000-0000-0000-000000000052', 'Сноубординг'),
('00000000-0000-0000-0000-000000000053', 'Скейтбординг'),
('00000000-0000-0000-0000-000000000054', 'Скелелазіння'),
('00000000-0000-0000-0000-000000000055', 'Настільний теніс'),
('00000000-0000-0000-0000-000000000056', 'Теніс'),
('00000000-0000-0000-0000-000000000057', 'Волейбол'),
('00000000-0000-0000-0000-000000000058', 'Футбол'),
('00000000-0000-0000-0000-000000000059', 'Баскетбол'),
('00000000-0000-0000-0000-000000000060', 'Інший спорт');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN ('Uid', 'Name') AND [object_id] = OBJECT_ID('[NonProfessionalInterests]'))
    SET IDENTITY_INSERT [NonProfessionalInterests] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN ('Uid', 'Name') AND [object_id] = OBJECT_ID('[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([Uid], [Name])
VALUES ('00000000-0000-0000-0000-000000000001', 'Director'),
('00000000-0000-0000-0000-000000000002', 'Mentor'),
('00000000-0000-0000-0000-000000000003', 'Student');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN ('Uid', 'Name') AND [object_id] = OBJECT_ID('[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN ('Uid', 'Name') AND [object_id] = OBJECT_ID('[Skills]'))
    SET IDENTITY_INSERT [Skills] ON;
INSERT INTO [Skills] ([Uid], [Name])
VALUES ('00000000-0000-0000-0000-000000000061', 'Java'),
('00000000-0000-0000-0000-000000000062', 'Python'),
('00000000-0000-0000-0000-000000000063', 'JavaScript/TypeScript'),
('00000000-0000-0000-0000-000000000064', 'Powershell'),
('00000000-0000-0000-0000-000000000065', 'Bash'),
('00000000-0000-0000-0000-000000000066', 'CMD'),
('00000000-0000-0000-0000-000000000067', 'Linux'),
('00000000-0000-0000-0000-000000000068', 'CSS'),
('00000000-0000-0000-0000-000000000069', 'Html'),
('00000000-0000-0000-0000-000000000070', 'Other programming languages'),
('00000000-0000-0000-0000-000000000071', 'SQL'),
('00000000-0000-0000-0000-000000000072', 'MsSQL'),
('00000000-0000-0000-0000-000000000073', 'Postgres'),
('00000000-0000-0000-0000-000000000074', 'MySql'),
('00000000-0000-0000-0000-000000000075', 'AWS'),
('00000000-0000-0000-0000-000000000076', 'Azure services'),
('00000000-0000-0000-0000-000000000077', 'Git'),
('00000000-0000-0000-0000-000000000078', 'GitHub CI'),
('00000000-0000-0000-0000-000000000079', 'GitLab CI'),
('00000000-0000-0000-0000-000000000080', 'Azure Devops CI'),
('00000000-0000-0000-0000-000000000081', 'Jenkins'),
('00000000-0000-0000-0000-000000000082', 'Allure'),
('00000000-0000-0000-0000-000000000083', 'React'),
('00000000-0000-0000-0000-000000000084', 'Angular'),
('00000000-0000-0000-0000-000000000085', 'ASP.NET'),
('00000000-0000-0000-0000-000000000086', 'Spring Boot'),
('00000000-0000-0000-0000-000000000087', 'Junit'),
('00000000-0000-0000-0000-000000000088', 'TestNG'),
('00000000-0000-0000-0000-000000000089', 'NUnit'),
('00000000-0000-0000-0000-000000000090', 'XUnit'),
('00000000-0000-0000-0000-000000000091', 'Mocha'),
('00000000-0000-0000-0000-000000000092', 'C#'),
('00000000-0000-0000-0000-000000000093', 'Pytest'),
('00000000-0000-0000-0000-000000000094', 'Playwright'),
('00000000-0000-0000-0000-000000000095', 'Selenium'),
('00000000-0000-0000-0000-000000000096', 'Selenide'),
('00000000-0000-0000-0000-000000000097', 'Selenoid');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN ('Uid', 'Name') AND [object_id] = OBJECT_ID('[Skills]'))
    SET IDENTITY_INSERT [Skills] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN ('Uid', 'Name', 'OrderingId') AND [object_id] = OBJECT_ID('[States]'))
    SET IDENTITY_INSERT [States] ON;
INSERT INTO [States] ([Uid], [Name], [OrderingId])
VALUES ('00000000-0000-0000-0000-000000000200', 'Робота над тестовим завданням', 0),
('00000000-0000-0000-0000-000000000201', 'Випробовувальний період', 0),
('00000000-0000-0000-0000-000000000202', 'Навчається', 0),
('00000000-0000-0000-0000-000000000203', 'Ходить по співбесідам', 0),
('00000000-0000-0000-0000-000000000204', 'Отримав роботу', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN ('Uid', 'Name', 'OrderingId') AND [object_id] = OBJECT_ID('[States]'))
    SET IDENTITY_INSERT [States] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN ('Uid', 'Name') AND [object_id] = OBJECT_ID('[StudyFields]'))
    SET IDENTITY_INSERT [StudyFields] ON;
INSERT INTO [StudyFields] ([Uid], [Name])
VALUES ('00000000-0000-0000-0000-000000000100', 'QA/AQA'),
('00000000-0000-0000-0000-000000000101', 'Frontend'),
('00000000-0000-0000-0000-000000000102', 'Full stack'),
('00000000-0000-0000-0000-000000000103', 'Backend');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN ('Uid', 'Name') AND [object_id] = OBJECT_ID('[StudyFields]'))
    SET IDENTITY_INSERT [StudyFields] OFF;
GO

INSERT INTO [Criterias] ([Name], [Weight], [IsBeneficial])
VALUES ('MentorsValuation', null, 1),
('SkillsMatchingValuation', null, 1),
('MentorsWorkloadEstimation', null, 0),
('MentorSuccessEstimation', null, 1),
('NonProffesionalInterests', null, 1);

GO

DECLARE @counter INT = 1;

WHILE @counter <= 200
BEGIN
  INSERT INTO [EngineeringClub].[dbo].UserInfos (Uid, Name, Description, PhoneNumber, Email, CurrentSalary, DateOfBirth, JoinDate, Paid, RoleUid)
  VALUES (
    NEWID(),  -- Generate random GUID
    CONCAT('User', @counter),
    SUBSTRING((
        SELECT TOP (CAST(FLOOR(RAND() * 60) AS INT) + 3)  -- Random words between 3 and 60
        'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.'
        FOR XML PATH(''), TYPE).value('.','VARCHAR(MAX)'), 1, 8000), -- Max length for description
    CAST(FLOOR(RAND() * 9999999999999) AS VARCHAR(15)) + '-' + CAST(FLOOR(RAND() * 10000) AS VARCHAR(4)), -- Phone number with randomness
    CONCAT('user', @counter, '@example.com'),
    RAND() * 100000, -- Random decimal value
    DATEADD(year, -RAND() * 80, GETDATE()),
	DATEADD(year, -RAND() * 80, GETDATE()),
    0,  -- Paid
    CASE WHEN @counter <= 5 THEN '00000000-0000-0000-0000-000000000001'
          WHEN @counter <= 25 THEN '00000000-0000-0000-0000-000000000002'
          ELSE '00000000-0000-0000-0000-000000000003' END
  );

  SET @counter = @counter + 1;
END;

GO

INSERT INTO [EngineeringClub].[dbo].[Mentors] (UserInfoUid, StartDate)
SELECT [EngineeringClub].[dbo].UserInfos.Uid AS UserInfoUid, 
       GETDATE() AS StartDate  -- Inserts current date as StartDate
FROM [EngineeringClub].[dbo].UserInfos
WHERE UserInfos.RoleUid = '00000000-0000-0000-0000-000000000002'
ORDER BY UserInfos.Uid;  -- Optional: Order by UserInfo.Uid (if desired)

GO

-- Create a temporary table to store UserInfoUid values
CREATE TABLE #TempUserInfoUid (
    UserInfoUid UNIQUEIDENTIFIER
);

-- Insert unique UserInfoUid values into the temporary table
INSERT INTO #TempUserInfoUid (UserInfoUid)
SELECT DISTINCT Uid
FROM UserInfos
WHERE RoleUid = '00000000-0000-0000-0000-000000000003';

-- Declare variables for iteration
DECLARE @UserInfoUid UNIQUEIDENTIFIER;
DECLARE @Counter INT;
DECLARE @MaxCounter INT;

-- Initialize variables
SELECT @Counter = 1, @MaxCounter = COUNT(*) FROM #TempUserInfoUid;

-- Iterate over the temporary table and insert rows into the Students table
WHILE @Counter <= @MaxCounter
BEGIN
    SELECT @UserInfoUid = UserInfoUid FROM #TempUserInfoUid WHERE UserInfoUid = (SELECT MIN(UserInfoUid) FROM #TempUserInfoUid);

    -- Insert row into the Students table
    INSERT INTO Students (UserInfoUid, StateUid, MentorId)
    VALUES (
        @UserInfoUid,
        (SELECT TOP 1 Uid FROM States ORDER BY NEWID()), -- Randomly select StateUid
        (SELECT TOP 1 Id FROM Mentors ORDER BY NEWID()) -- Randomly select MentorId
    );

    -- Remove processed UserInfoUid from temporary table
    DELETE FROM #TempUserInfoUid WHERE UserInfoUid = @UserInfoUid;

    -- Increment counter
    SET @Counter = @Counter + 1;
END;

-- Drop the temporary table
DROP TABLE #TempUserInfoUid;

GO 

-- Create a temporary table to store UserInfoUid and SkillsUid combinations
CREATE TABLE #TempSkillUserInfo (
    UserInfoUid UNIQUEIDENTIFIER,
    SkillsUid UNIQUEIDENTIFIER
);

-- Insert rows into the temporary table
INSERT INTO #TempSkillUserInfo (UserInfoUid, SkillsUid)
SELECT 
    U.Uid AS UserInfoUid,
    S.Uid AS SkillsUid
FROM 
    (SELECT Uid FROM UserInfos) AS U,
    (SELECT Uid FROM Skills) AS S;

-- Declare variables for iteration
DECLARE @UserInfoUid UNIQUEIDENTIFIER;
DECLARE @SkillsCounter INT;

-- Iterate over the UserInfoUid values and assign random skills
DECLARE userInfoCursor CURSOR FOR
SELECT DISTINCT UserInfoUid FROM #TempSkillUserInfo;

OPEN userInfoCursor;

FETCH NEXT FROM userInfoCursor INTO @UserInfoUid;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Randomly select a number of skills for the current user (between 1 and 10)
    SET @SkillsCounter = CAST(RAND() * 10 + 1 AS INT);

    -- Insert rows into the SkillUserInfo table for the current user
    INSERT INTO SkillUserInfo (UsersUid, SkillsUid)
    SELECT TOP (@SkillsCounter) UserInfoUid, SkillsUid
    FROM #TempSkillUserInfo
    WHERE UserInfoUid = @UserInfoUid
    ORDER BY NEWID();

    FETCH NEXT FROM userInfoCursor INTO @UserInfoUid;
END;

CLOSE userInfoCursor;
DEALLOCATE userInfoCursor;

-- Drop the temporary table
DROP TABLE #TempSkillUserInfo;

GO

-- Create a temporary table to store UserInfoUid and SkillsUid combinations
CREATE TABLE #TempSkillUserInfo (
    UserInfoUid UNIQUEIDENTIFIER,
    SkillsUid UNIQUEIDENTIFIER
);

-- Insert rows into the temporary table
INSERT INTO #TempSkillUserInfo (UserInfoUid, SkillsUid)
SELECT 
    U.Uid AS UserInfoUid,
    S.Uid AS SkillsUid
FROM 
    (SELECT Uid FROM UserInfos) AS U,
    (SELECT Uid FROM NonProfessionalInterests) AS S;

-- Declare variables for iteration
DECLARE @UserInfoUid UNIQUEIDENTIFIER;
DECLARE @SkillsCounter INT;

-- Iterate over the UserInfoUid values and assign random skills
DECLARE userInfoCursor CURSOR FOR
SELECT DISTINCT UserInfoUid FROM #TempSkillUserInfo;

OPEN userInfoCursor;

FETCH NEXT FROM userInfoCursor INTO @UserInfoUid;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Randomly select a number of skills for the current user (between 1 and 10)
    SET @SkillsCounter = CAST(RAND() * 5 + 1 AS INT);

    -- Insert rows into the SkillUserInfo table for the current user
    INSERT INTO NonProfessionalInterestUserInfo (UsersUid, NonProfessionalInterestsUid)
    SELECT TOP (@SkillsCounter) UserInfoUid, SkillsUid
    FROM #TempSkillUserInfo
    WHERE UserInfoUid = @UserInfoUid
    ORDER BY NEWID();

    FETCH NEXT FROM userInfoCursor INTO @UserInfoUid;
END;

CLOSE userInfoCursor;
DEALLOCATE userInfoCursor;

-- Drop the temporary table
DROP TABLE #TempSkillUserInfo;

GO

-- Create a temporary table to store UserInfoUid and SkillsUid combinations
CREATE TABLE #TempSkillUserInfo (
    UserInfoUid UNIQUEIDENTIFIER,
    SkillsUid UNIQUEIDENTIFIER
);

-- Insert rows into the temporary table
INSERT INTO #TempSkillUserInfo (UserInfoUid, SkillsUid)
SELECT 
    U.Uid AS UserInfoUid,
    S.Uid AS SkillsUid
FROM 
    (SELECT Uid FROM UserInfos) AS U,
    (SELECT Uid FROM Locations) AS S;

-- Declare variables for iteration
DECLARE @UserInfoUid UNIQUEIDENTIFIER;
DECLARE @SkillsCounter INT;

-- Iterate over the UserInfoUid values and assign random skills
DECLARE userInfoCursor CURSOR FOR
SELECT DISTINCT UserInfoUid FROM #TempSkillUserInfo;

OPEN userInfoCursor;

FETCH NEXT FROM userInfoCursor INTO @UserInfoUid;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Randomly select a number of skills for the current user (between 1 and 2)
    SET @SkillsCounter = CAST(RAND() * 2 + 1 AS INT);

    -- Insert rows into the SkillUserInfo table for the current user
    INSERT INTO LocationUserInfo (UsersUid, LocationsUid)
    SELECT TOP (@SkillsCounter) UserInfoUid, SkillsUid
    FROM #TempSkillUserInfo
    WHERE UserInfoUid = @UserInfoUid
    ORDER BY NEWID();

    FETCH NEXT FROM userInfoCursor INTO @UserInfoUid;
END;

CLOSE userInfoCursor;
DEALLOCATE userInfoCursor;

-- Drop the temporary table
DROP TABLE #TempSkillUserInfo;

GO

-- Create a temporary table to store UserInfoUid and SkillsUid combinations
CREATE TABLE #TempSkillUserInfo (
    UserInfoUid UNIQUEIDENTIFIER,
    SkillsUid UNIQUEIDENTIFIER
);

-- Insert rows into the temporary table
INSERT INTO #TempSkillUserInfo (UserInfoUid, SkillsUid)
SELECT 
    U.Uid AS UserInfoUid,
    S.Uid AS SkillsUid
FROM 
    (SELECT Uid FROM UserInfos) AS U,
    (SELECT Uid FROM StudyFields) AS S;

-- Declare variables for iteration
DECLARE @UserInfoUid UNIQUEIDENTIFIER;
DECLARE @SkillsCounter INT;

-- Iterate over the UserInfoUid values and assign random skills
DECLARE userInfoCursor CURSOR FOR
SELECT DISTINCT UserInfoUid FROM #TempSkillUserInfo;

OPEN userInfoCursor;

FETCH NEXT FROM userInfoCursor INTO @UserInfoUid;

WHILE @@FETCH_STATUS = 0
BEGIN
    -- Randomly select a number of skills for the current user (between 1 and 2)
    SET @SkillsCounter = CAST(RAND() * 2 + 1 AS INT);

    -- Insert rows into the SkillUserInfo table for the current user
    INSERT INTO StudyFieldUserInfo (UsersUid, StudyFieldsUid)
    SELECT TOP (@SkillsCounter) UserInfoUid, SkillsUid
    FROM #TempSkillUserInfo
    WHERE UserInfoUid = @UserInfoUid
    ORDER BY NEWID();

    FETCH NEXT FROM userInfoCursor INTO @UserInfoUid;
END;

CLOSE userInfoCursor;
DEALLOCATE userInfoCursor;

-- Drop the temporary table
DROP TABLE #TempSkillUserInfo;

GO
-- setting password 'admin' for all users
INSERT INTO Credentials (UserInfoUid, PasswordHash, PasswordSalt)
SELECT u.Uid AS UserInfoUid, 
0xD42FB46CF33C0EF678E849A2D4F03CCA3F39AB2A3A8BF01B074257445F6590DFE0E9020814F93FD2564E522A1CACC67B3E1E8FD96EBC9B7E4CE50BB4AA103BA6, 
0x4F170682FA547618FE86FD880981584F0EFB3DB70D504A38E7A438A81D8F82FCD7F79E0EA0AD6823C10B3A1CCB2FA53CD0A3CCA392D1F57D10F24A0793B8DA8497A47B38B024E8C326A26C8A403C5727C6735B18BF225C4E7A72DC7DE762454F89FD95D5AC1C94B55D7140B639E683BD87052E2A75C7EFF9F2A474715DB383DB
FROM UserInfos u;

COMMIT;