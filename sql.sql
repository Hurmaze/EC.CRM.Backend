IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Locations] (
    [Uid] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [Address] nvarchar(100) NOT NULL,
    [City] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Locations] PRIMARY KEY ([Uid])
);
GO

CREATE TABLE [Roles] (
    [Uid] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY ([Uid])
);
GO

CREATE TABLE [States] (
    [Uid] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_States] PRIMARY KEY ([Uid])
);
GO

CREATE TABLE [UserInfos] (
    [Uid] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [Name] nvarchar(100) NOT NULL,
    [Description] nvarchar(500) NULL,
    [PhoneNumber] nvarchar(20) NULL,
    [Email] nvarchar(100) NOT NULL,
    [CurentSalary] decimal(10,3) NULL,
    [DateOfBirth] datetime2 NOT NULL,
    [Paid] decimal(10,3) NOT NULL,
    [RoleUid] uniqueidentifier NOT NULL,
    [LocationUid] uniqueidentifier NULL,
    CONSTRAINT [PK_UserInfos] PRIMARY KEY ([Uid]),
    CONSTRAINT [FK_UserInfos_Locations_LocationUid] FOREIGN KEY ([LocationUid]) REFERENCES [Locations] ([Uid]),
    CONSTRAINT [FK_UserInfos_Roles_RoleUid] FOREIGN KEY ([RoleUid]) REFERENCES [Roles] ([Uid]) ON DELETE CASCADE
);
GO

CREATE TABLE [Jobs] (
    [Uid] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [CompanyName] nvarchar(100) NOT NULL,
    [PositionName] nvarchar(100) NOT NULL,
    [Salary] decimal(10,3) NOT NULL,
    [StartTime] datetime2 NOT NULL,
    [EndTime] datetime2 NULL,
    [UserInfoUid] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Jobs] PRIMARY KEY ([Uid]),
    CONSTRAINT [FK_Jobs_UserInfos_UserInfoUid] FOREIGN KEY ([UserInfoUid]) REFERENCES [UserInfos] ([Uid]) ON DELETE CASCADE
);
GO

CREATE TABLE [Mentors] (
    [Uid] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [UserInfoUid] uniqueidentifier NOT NULL,
    [StartDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Mentors] PRIMARY KEY ([Uid]),
    CONSTRAINT [FK_Mentors_UserInfos_UserInfoUid] FOREIGN KEY ([UserInfoUid]) REFERENCES [UserInfos] ([Uid])
);
GO

CREATE TABLE [Students] (
    [Uid] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [UserInfoUid] uniqueidentifier NOT NULL,
    [MentorUid] uniqueidentifier NOT NULL,
    [StateUid] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Students] PRIMARY KEY ([Uid]),
    CONSTRAINT [FK_Students_Mentors_MentorUid] FOREIGN KEY ([MentorUid]) REFERENCES [Mentors] ([Uid]),
    CONSTRAINT [FK_Students_States_StateUid] FOREIGN KEY ([StateUid]) REFERENCES [States] ([Uid]) ON DELETE CASCADE,
    CONSTRAINT [FK_Students_UserInfos_UserInfoUid] FOREIGN KEY ([UserInfoUid]) REFERENCES [UserInfos] ([Uid])
);
GO

CREATE INDEX [IX_Jobs_UserInfoUid] ON [Jobs] ([UserInfoUid]);
GO

CREATE UNIQUE INDEX [IX_Mentors_UserInfoUid] ON [Mentors] ([UserInfoUid]);
GO

CREATE INDEX [IX_Students_MentorUid] ON [Students] ([MentorUid]);
GO

CREATE INDEX [IX_Students_StateUid] ON [Students] ([StateUid]);
GO

CREATE UNIQUE INDEX [IX_Students_UserInfoUid] ON [Students] ([UserInfoUid]);
GO

CREATE INDEX [IX_UserInfos_LocationUid] ON [UserInfos] ([LocationUid]);
GO

CREATE INDEX [IX_UserInfos_RoleUid] ON [UserInfos] ([RoleUid]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240208175713_InitialCreate', N'8.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[States]') AND [c].[name] = N'Name');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [States] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [States] ALTER COLUMN [Name] nvarchar(100) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Roles]') AND [c].[name] = N'Name');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Roles] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Roles] ALTER COLUMN [Name] nvarchar(100) NOT NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240208175851_UpdateConstraints', N'8.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240211095910_AddGuidDefaultValues', N'8.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Students] DROP CONSTRAINT [FK_Students_Mentors_MentorUid];
GO

ALTER TABLE [Students] DROP CONSTRAINT [PK_Students];
GO

DROP INDEX [IX_Students_MentorUid] ON [Students];
GO

ALTER TABLE [Mentors] DROP CONSTRAINT [PK_Mentors];
GO

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Students]') AND [c].[name] = N'Uid');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Students] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Students] DROP COLUMN [Uid];
GO

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Students]') AND [c].[name] = N'MentorUid');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Students] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Students] DROP COLUMN [MentorUid];
GO

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Mentors]') AND [c].[name] = N'Uid');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Mentors] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Mentors] DROP COLUMN [Uid];
GO

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInfos]') AND [c].[name] = N'Uid');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [UserInfos] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [UserInfos] ADD DEFAULT '73f8447e-8b35-4f32-adac-9fe9876529cf' FOR [Uid];
GO

ALTER TABLE [Students] ADD [Id] int NOT NULL IDENTITY;
GO

ALTER TABLE [Students] ADD [MentorId] int NOT NULL DEFAULT 0;
GO

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[States]') AND [c].[name] = N'Uid');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [States] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [States] ADD DEFAULT '14f705dc-a2af-437e-88a2-c6b6a90c1d2a' FOR [Uid];
GO

ALTER TABLE [States] ADD [OrderId] int NOT NULL DEFAULT 0;
GO

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Roles]') AND [c].[name] = N'Uid');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Roles] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Roles] ADD DEFAULT '940c8245-661d-4d10-b948-a5edbe18dee4' FOR [Uid];
GO

ALTER TABLE [Mentors] ADD [Id] int NOT NULL IDENTITY;
GO

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Locations]') AND [c].[name] = N'Uid');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Locations] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Locations] ADD DEFAULT '6fce367f-9c02-4b7e-9604-6f0004afd83f' FOR [Uid];
GO

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'Uid');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Jobs] ADD DEFAULT '9132b8a0-071c-467f-a146-becf9256dde4' FOR [Uid];
GO

ALTER TABLE [Students] ADD CONSTRAINT [PK_Students] PRIMARY KEY ([Id]);
GO

ALTER TABLE [Mentors] ADD CONSTRAINT [PK_Mentors] PRIMARY KEY ([Id]);
GO

CREATE INDEX [IX_Students_MentorId] ON [Students] ([MentorId]);
GO

ALTER TABLE [Students] ADD CONSTRAINT [FK_Students_Mentors_MentorId] FOREIGN KEY ([MentorId]) REFERENCES [Mentors] ([Id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240212181720_UpdateDefaultValues', N'8.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var10 sysname;
SELECT @var10 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInfos]') AND [c].[name] = N'Uid');
IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [UserInfos] DROP CONSTRAINT [' + @var10 + '];');
ALTER TABLE [UserInfos] ADD DEFAULT 'bf7f6023-f109-4782-b8c2-6ff67571a539' FOR [Uid];
GO

DECLARE @var11 sysname;
SELECT @var11 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[States]') AND [c].[name] = N'Uid');
IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [States] DROP CONSTRAINT [' + @var11 + '];');
ALTER TABLE [States] ADD DEFAULT 'ee97f425-d79e-416b-a6ee-0233dff83129' FOR [Uid];
GO

DECLARE @var12 sysname;
SELECT @var12 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Roles]') AND [c].[name] = N'Uid');
IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Roles] DROP CONSTRAINT [' + @var12 + '];');
ALTER TABLE [Roles] ADD DEFAULT 'f07ab32b-419f-4e3e-b1ff-58fa7b49932b' FOR [Uid];
GO

DECLARE @var13 sysname;
SELECT @var13 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Locations]') AND [c].[name] = N'Uid');
IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Locations] DROP CONSTRAINT [' + @var13 + '];');
ALTER TABLE [Locations] ADD DEFAULT '330328e9-3bed-4110-9f03-124397340471' FOR [Uid];
GO

DECLARE @var14 sysname;
SELECT @var14 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Jobs]') AND [c].[name] = N'Uid');
IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Jobs] DROP CONSTRAINT [' + @var14 + '];');
ALTER TABLE [Jobs] ADD DEFAULT '78f720ca-9212-470c-87ae-f9acef45c523' FOR [Uid];
GO

CREATE TABLE [Credentials] (
    [UserInfoUid] uniqueidentifier NOT NULL,
    [PasswordHash] varbinary(max) NOT NULL,
    [PasswordSalt] varbinary(max) NOT NULL,
    CONSTRAINT [PK_Credentials] PRIMARY KEY ([UserInfoUid]),
    CONSTRAINT [FK_Credentials_UserInfos_UserInfoUid] FOREIGN KEY ([UserInfoUid]) REFERENCES [UserInfos] ([Uid]) ON DELETE CASCADE
);
GO

CREATE TABLE [NonProfessionalInterest] (
    [Uid] uniqueidentifier NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_NonProfessionalInterest] PRIMARY KEY ([Uid])
);
GO

CREATE TABLE [Skill] (
    [Uid] uniqueidentifier NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_Skill] PRIMARY KEY ([Uid])
);
GO

CREATE TABLE [StudyField] (
    [Uid] uniqueidentifier NOT NULL,
    [Name] nvarchar(100) NOT NULL,
    CONSTRAINT [PK_StudyField] PRIMARY KEY ([Uid])
);
GO

CREATE TABLE [NonProfessionalInterestUserInfo] (
    [NonProfessionalInterestsUid] uniqueidentifier NOT NULL,
    [UsersUid] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_NonProfessionalInterestUserInfo] PRIMARY KEY ([NonProfessionalInterestsUid], [UsersUid]),
    CONSTRAINT [FK_NonProfessionalInterestUserInfo_NonProfessionalInterest_NonProfessionalInterestsUid] FOREIGN KEY ([NonProfessionalInterestsUid]) REFERENCES [NonProfessionalInterest] ([Uid]) ON DELETE CASCADE,
    CONSTRAINT [FK_NonProfessionalInterestUserInfo_UserInfos_UsersUid] FOREIGN KEY ([UsersUid]) REFERENCES [UserInfos] ([Uid]) ON DELETE CASCADE
);
GO

CREATE TABLE [SkillUserInfo] (
    [SkillsUid] uniqueidentifier NOT NULL,
    [UsersUid] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_SkillUserInfo] PRIMARY KEY ([SkillsUid], [UsersUid]),
    CONSTRAINT [FK_SkillUserInfo_Skill_SkillsUid] FOREIGN KEY ([SkillsUid]) REFERENCES [Skill] ([Uid]) ON DELETE CASCADE,
    CONSTRAINT [FK_SkillUserInfo_UserInfos_UsersUid] FOREIGN KEY ([UsersUid]) REFERENCES [UserInfos] ([Uid]) ON DELETE CASCADE
);
GO

CREATE TABLE [StudyFieldUserInfo] (
    [StudyFieldsUid] uniqueidentifier NOT NULL,
    [UsersUid] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_StudyFieldUserInfo] PRIMARY KEY ([StudyFieldsUid], [UsersUid]),
    CONSTRAINT [FK_StudyFieldUserInfo_StudyField_StudyFieldsUid] FOREIGN KEY ([StudyFieldsUid]) REFERENCES [StudyField] ([Uid]) ON DELETE CASCADE,
    CONSTRAINT [FK_StudyFieldUserInfo_UserInfos_UsersUid] FOREIGN KEY ([UsersUid]) REFERENCES [UserInfos] ([Uid]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_NonProfessionalInterestUserInfo_UsersUid] ON [NonProfessionalInterestUserInfo] ([UsersUid]);
GO

CREATE INDEX [IX_SkillUserInfo_UsersUid] ON [SkillUserInfo] ([UsersUid]);
GO

CREATE INDEX [IX_StudyFieldUserInfo_UsersUid] ON [StudyFieldUserInfo] ([UsersUid]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240310152851_AddNewUserInfoProperties', N'8.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [LocationUserInfo] (
    [LocationsUid] uniqueidentifier NOT NULL,
    [UsersUid] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_LocationUserInfo] PRIMARY KEY ([LocationsUid], [UsersUid]),
    CONSTRAINT [FK_LocationUserInfo_Locations_LocationsUid] FOREIGN KEY ([LocationsUid]) REFERENCES [Locations] ([Uid]) ON DELETE CASCADE,
    CONSTRAINT [FK_LocationUserInfo_UserInfos_UsersUid] FOREIGN KEY ([UsersUid]) REFERENCES [UserInfos] ([Uid]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_LocationUserInfo_UsersUid] ON [LocationUserInfo] ([UsersUid]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240401082410_update-locations', N'8.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240401091315_update-default-values-for-guids', N'8.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Criterias] (
    [Name] nvarchar(100) NOT NULL,
    [Weight] float NOT NULL,
    [IsBeneficial] bit NOT NULL,
    CONSTRAINT [PK_Criterias] PRIMARY KEY ([Name])
);
GO

CREATE TABLE [MentorValuations] (
    [MentorUid] uniqueidentifier NOT NULL,
    [StudentUid] uniqueidentifier NOT NULL,
    [Valuation] float NOT NULL
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240406122250_Add-criterias', N'8.0.1');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

EXEC sp_rename N'[States].[OrderId]', N'OrderingId', N'COLUMN';
GO

ALTER TABLE [MentorValuations] ADD [Id] int NOT NULL DEFAULT 0;
GO

DECLARE @var15 sysname;
SELECT @var15 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Locations]') AND [c].[name] = N'Address');
IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Locations] DROP CONSTRAINT [' + @var15 + '];');
ALTER TABLE [Locations] ALTER COLUMN [Address] nvarchar(100) NULL;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240501145058_ModelImprovements', N'8.0.1');
GO

COMMIT;
GO

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
    SET IDENTITY_INSERT [NonProfessionalInterest] ON;
INSERT INTO [NonProfessionalInterest] ([Uid], [Name])
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
INSERT INTO [NonProfessionalInterest] ([Uid], [Name])
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
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name') AND [object_id] = OBJECT_ID(N'[NonProfessionalInterest]'))
    SET IDENTITY_INSERT [NonProfessionalInterest] OFF;
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

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name') AND [object_id] = OBJECT_ID(N'[Skill]'))
    SET IDENTITY_INSERT [Skill] ON;
INSERT INTO [Skill] ([Uid], [Name])
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
('00000000-0000-0000-0000-000000000080', N'Azure Devops Ci'),
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
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name') AND [object_id] = OBJECT_ID(N'[Skill]'))
    SET IDENTITY_INSERT [Skill] OFF;
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

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name') AND [object_id] = OBJECT_ID(N'[StudyField]'))
    SET IDENTITY_INSERT [StudyField] ON;
INSERT INTO [StudyField] ([Uid], [Name])
VALUES ('00000000-0000-0000-0000-000000000100', N'QA/AQA'),
('00000000-0000-0000-0000-000000000101', N'Frontend'),
('00000000-0000-0000-0000-000000000102', N'Full stack'),
('00000000-0000-0000-0000-000000000103', N'Backend');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Uid', N'Name') AND [object_id] = OBJECT_ID(N'[StudyField]'))
    SET IDENTITY_INSERT [StudyField] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240501145204_BasicDataSeeding', N'8.0.1');
GO

COMMIT;
GO

