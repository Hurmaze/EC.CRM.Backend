BEGIN TRANSACTION;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Address', N'City') AND [object_id] = OBJECT_ID(N'[Locations]'))
    SET IDENTITY_INSERT [Locations] ON;
INSERT INTO [Locations] ([Uid], [Address], [City])
VALUES ('00000000-0000-0000-0000-000000000004', N'Ковальский провулок 19', N'Київ'),
('00000000-0000-0000-0000-000000000005', N'вулиця Травнева, 10, Броварський район, Київська область, 07443', N'Калинівка'),
('00000000-0000-0000-0000-000000000006', N'вулиця Відродження 31, Волиньска область, 43000', N'Луцьк'),
('00000000-0000-0000-0000-000000000007', NULL, N'Online');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Address', N'City') AND [object_id] = OBJECT_ID(N'[Locations]'))
    SET IDENTITY_INSERT [Locations] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name') AND [object_id] = OBJECT_ID(N'[NonProfessionalInterest]'))
    SET IDENTITY_INSERT [NonProfessionalInterests] ON;
INSERT INTO [NonProfessionalInterests] ([Uid], [Name])
VALUES ('00000000-0000-0000-0000-000000000008', N'Читання'),
('00000000-0000-0000-0000-000000000009', N'Писання'),
('00000000-0000-0000-0000-000000000010', N'Малювання'),
('00000000-0000-0000-0000-000000000011', N'Живопис'),
('00000000-0000-0000-0000-000000000012', N'Фотографія'),
('00000000-0000-0000-0000-000000000013', N'Гра на музичних інструментах'),
('00000000-0000-0000-0000-000000000014', N'Спів'),
('00000000-0000-0000-0000-000000000015', N'Танці'),
('00000000-0000-0000-0000-000000000016', N'Кулінарія'),
('00000000-0000-0000-0000-000000000017', N'Пекарство'),
('00000000-0000-0000-0000-000000000018', N'Садівництво'),
('00000000-0000-0000-0000-000000000019', N'Походи в гори'),
('00000000-0000-0000-0000-000000000020', N'Кемпінг'),
('00000000-0000-0000-0000-000000000021', N'Риболовля'),
('00000000-0000-0000-0000-000000000022', N'Спостереження за птахами'),
('00000000-0000-0000-0000-000000000023', N'В''язання'),
('00000000-0000-0000-0000-000000000024', N'В''язання гачком'),
('00000000-0000-0000-0000-000000000025', N'Шиття'),
('00000000-0000-0000-0000-000000000026', N'Гончарство'),
('00000000-0000-0000-0000-000000000027', N'Скульптура'),
('00000000-0000-0000-0000-000000000028', N'Робота з деревом'),
('00000000-0000-0000-0000-000000000029', N'DIY проекти'),
('00000000-0000-0000-0000-000000000030', N'Збір марок'),
('00000000-0000-0000-0000-000000000031', N'Збір монет'),
('00000000-0000-0000-0000-000000000032', N'Збір антикваріату'),
('00000000-0000-0000-0000-000000000033', N'Збір винтажних речей'),
('00000000-0000-0000-0000-000000000034', N'Збір коміксів'),
('00000000-0000-0000-0000-000000000035', N'Збір фігурок'),
('00000000-0000-0000-0000-000000000036', N'Збір спортивної меморабілії'),
('00000000-0000-0000-0000-000000000037', N'Дивитися фільми'),
('00000000-0000-0000-0000-000000000038', N'Дивитися телешоу'),
('00000000-0000-0000-0000-000000000039', N'Грати в відеоігри'),
('00000000-0000-0000-0000-000000000040', N'Настільні ігри'),
('00000000-0000-0000-0000-000000000041', N'Розв''язування пазлів'),
('00000000-0000-0000-0000-000000000042', N'Кросворди'),
('00000000-0000-0000-0000-000000000043', N'Судоку'),
('00000000-0000-0000-0000-000000000044', N'Йога'),
('00000000-0000-0000-0000-000000000045', N'Медитація'),
('00000000-0000-0000-0000-000000000046', N'Біг'),
('00000000-0000-0000-0000-000000000047', N'Джоггінг'),
('00000000-0000-0000-0000-000000000048', N'Велосипед'),
('00000000-0000-0000-0000-000000000049', N'Плавання');
INSERT INTO [NonProfessionalInterests] ([Uid], [Name])
VALUES ('00000000-0000-0000-0000-000000000050', N'Серфінг'),
('00000000-0000-0000-0000-000000000051', N'Катання на лижах'),
('00000000-0000-0000-0000-000000000052', N'Сноубординг'),
('00000000-0000-0000-0000-000000000053', N'Скейтбординг'),
('00000000-0000-0000-0000-000000000054', N'Скелелазіння'),
('00000000-0000-0000-0000-000000000055', N'Настільний теніс'),
('00000000-0000-0000-0000-000000000056', N'Теніс'),
('00000000-0000-0000-0000-000000000057', N'Волейбол'),
('00000000-0000-0000-0000-000000000058', N'Футбол'),
('00000000-0000-0000-0000-000000000059', N'Баскетбол'),
('00000000-0000-0000-0000-000000000060', N'Інший спорт');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name') AND [object_id] = OBJECT_ID(N'[NonProfessionalInterests]'))
    SET IDENTITY_INSERT [NonProfessionalInterests] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] ON;
INSERT INTO [Roles] ([Uid], [Name])
VALUES ('00000000-0000-0000-0000-000000000001', N'Director'),
('00000000-0000-0000-0000-000000000002', N'Mentor'),
('00000000-0000-0000-0000-000000000003', N'Student');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name') AND [object_id] = OBJECT_ID(N'[Roles]'))
    SET IDENTITY_INSERT [Roles] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name') AND [object_id] = OBJECT_ID(N'[Skills]'))
    SET IDENTITY_INSERT [Skills] ON;
INSERT INTO [Skills] ([Uid], [Name])
VALUES ('00000000-0000-0000-0000-000000000061', N'Java'),
('00000000-0000-0000-0000-000000000062', N'Python'),
('00000000-0000-0000-0000-000000000063', N'JavaScript/TypeScript'),
('00000000-0000-0000-0000-000000000064', N'Powershell'),
('00000000-0000-0000-0000-000000000065', N'Bash'),
('00000000-0000-0000-0000-000000000066', N'CMD'),
('00000000-0000-0000-0000-000000000067', N'Linux'),
('00000000-0000-0000-0000-000000000068', N'CSS'),
('00000000-0000-0000-0000-000000000069', N'Html'),
('00000000-0000-0000-0000-000000000070', N'Other programming languages'),
('00000000-0000-0000-0000-000000000071', N'SQL'),
('00000000-0000-0000-0000-000000000072', N'MsSQL'),
('00000000-0000-0000-0000-000000000073', N'Postgres'),
('00000000-0000-0000-0000-000000000074', N'MySql'),
('00000000-0000-0000-0000-000000000075', N'AWS'),
('00000000-0000-0000-0000-000000000076', N'Azure services'),
('00000000-0000-0000-0000-000000000077', N'Git'),
('00000000-0000-0000-0000-000000000078', N'GitHub CI'),
('00000000-0000-0000-0000-000000000079', N'GitLab CI'),
('00000000-0000-0000-0000-000000000080', N'Azure Devops CI'),
('00000000-0000-0000-0000-000000000081', N'Jenkins'),
('00000000-0000-0000-0000-000000000082', N'Allure'),
('00000000-0000-0000-0000-000000000083', N'React'),
('00000000-0000-0000-0000-000000000084', N'Angular'),
('00000000-0000-0000-0000-000000000085', N'ASP.NET'),
('00000000-0000-0000-0000-000000000086', N'Spring Boot'),
('00000000-0000-0000-0000-000000000087', N'Junit'),
('00000000-0000-0000-0000-000000000088', N'TestNG'),
('00000000-0000-0000-0000-000000000089', N'NUnit'),
('00000000-0000-0000-0000-000000000090', N'XUnit'),
('00000000-0000-0000-0000-000000000091', N'Mocha'),
('00000000-0000-0000-0000-000000000092', N'C#'),
('00000000-0000-0000-0000-000000000093', N'Pytest'),
('00000000-0000-0000-0000-000000000094', N'Playwright'),
('00000000-0000-0000-0000-000000000095', N'Selenium'),
('00000000-0000-0000-0000-000000000096', N'Selenide'),
('00000000-0000-0000-0000-000000000097', N'Selenoid');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name') AND [object_id] = OBJECT_ID(N'[Skills]'))
    SET IDENTITY_INSERT [Skills] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name', N'OrderingId') AND [object_id] = OBJECT_ID(N'[States]'))
    SET IDENTITY_INSERT [States] ON;
INSERT INTO [States] ([Uid], [Name], [OrderingId])
VALUES ('00000000-0000-0000-0000-000000000200', N'Робота над тестовим завданням', 0),
('00000000-0000-0000-0000-000000000201', N'Випробовувальний період', 0),
('00000000-0000-0000-0000-000000000202', N'Навчається', 0),
('00000000-0000-0000-0000-000000000203', N'Ходить по співбесідам', 0),
('00000000-0000-0000-0000-000000000204', N'Отримав роботу', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name', N'OrderingId') AND [object_id] = OBJECT_ID(N'[States]'))
    SET IDENTITY_INSERT [States] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name') AND [object_id] = OBJECT_ID(N'[StudyFields]'))
    SET IDENTITY_INSERT [StudyFields] ON;
INSERT INTO [StudyFields] ([Uid], [Name])
VALUES ('00000000-0000-0000-0000-000000000100', N'QA/AQA'),
('00000000-0000-0000-0000-000000000101', N'Frontend'),
('00000000-0000-0000-0000-000000000102', N'Full stack'),
('00000000-0000-0000-0000-000000000103', N'Backend');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name') AND [object_id] = OBJECT_ID(N'[StudyFields]'))
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