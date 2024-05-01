using Bogus;
using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Persistence.DataContext.Seeding
{
    public class DatabaseSeeder
    {
        private string randomString => new Faker().Random.String(0, 6);

        #region Basic Data
        public List<Location> Locations { get; } = [];
        public List<Role> Roles { get; } = [];
        public List<Skill> Skills { get; } = [];
        public List<NonProfessionalInterest> NonProfessionalInterests { get; } = [];
        public List<State> States { get; } = [];
        public List<StudyField> StudyFields { get; } = [];
        #endregion
        #region Test Data
        public List<Job> Jobs { get; } = [];
        public List<Mentor> Mentors { get; } = [];
        public List<Student> Students { get; } = [];
        public List<UserInfo> UserInfos { get; } = [];
        public List<Credentials> Credentials { get; } = [];
        #endregion

        public DatabaseSeeder()
        {
            Locations = GenerateLocations();
            Roles = GenerateRoles();
            Skills = GenerateSkills();
            NonProfessionalInterests = GenerateNonProfessionalInterests();
            States = GenerateStates();
            StudyFields = GenerateStudyFields();

            UserInfos = GenerateUserInfos(amount: 1000);
            Students = GenerateStudents();
            Mentors = GenerateMentors();
        }

        private List<Skill> GenerateSkills()
        {
            return new List<Skill>
            {
                new Skill { Name = "C#", Uid = Guid.Parse("00000000-0000-0000-0000-000000000092") },
                new Skill { Name = "Java", Uid = Guid.Parse("00000000-0000-0000-0000-000000000061") },
                new Skill { Name = "Python", Uid = Guid.Parse("00000000-0000-0000-0000-000000000062") },
                new Skill { Name = "JavaScript/TypeScript", Uid = Guid.Parse("00000000-0000-0000-0000-000000000063") },
                new Skill { Name = "Powershell", Uid = Guid.Parse("00000000-0000-0000-0000-000000000064") },
                new Skill { Name = "Bash", Uid = Guid.Parse("00000000-0000-0000-0000-000000000065") },
                new Skill { Name = "CMD", Uid = Guid.Parse("00000000-0000-0000-0000-000000000066") },
                new Skill { Name = "Linux", Uid = Guid.Parse("00000000-0000-0000-0000-000000000067") },
                new Skill { Name = "CSS", Uid = Guid.Parse("00000000-0000-0000-0000-000000000068") },
                new Skill { Name = "Html", Uid = Guid.Parse("00000000-0000-0000-0000-000000000069") },
                new Skill { Name = "Other programming languages", Uid = Guid.Parse("00000000-0000-0000-0000-000000000070") },
                new Skill { Name = "SQL", Uid = Guid.Parse("00000000-0000-0000-0000-000000000071") },
                new Skill { Name = "MsSQL", Uid = Guid.Parse("00000000-0000-0000-0000-000000000072") },
                new Skill { Name = "Postgres", Uid = Guid.Parse("00000000-0000-0000-0000-000000000073") },
                new Skill { Name = "MySql", Uid = Guid.Parse("00000000-0000-0000-0000-000000000074") },
                new Skill { Name = "AWS", Uid = Guid.Parse("00000000-0000-0000-0000-000000000075") },
                new Skill { Name = "Azure services", Uid = Guid.Parse("00000000-0000-0000-0000-000000000076") },
                new Skill { Name = "Git", Uid = Guid.Parse("00000000-0000-0000-0000-000000000077") },
                new Skill { Name = "GitHub CI", Uid = Guid.Parse("00000000-0000-0000-0000-000000000078") },
                new Skill { Name = "GitLab CI", Uid = Guid.Parse("00000000-0000-0000-0000-000000000079") },
                new Skill { Name = "Azure Devops Ci", Uid = Guid.Parse("00000000-0000-0000-0000-000000000080") },
                new Skill { Name = "Jenkins", Uid = Guid.Parse("00000000-0000-0000-0000-000000000081") },
                new Skill { Name = "Allure", Uid = Guid.Parse("00000000-0000-0000-0000-000000000082") },
                new Skill { Name = "React", Uid = Guid.Parse("00000000-0000-0000-0000-000000000083") },
                new Skill { Name = "Angular", Uid = Guid.Parse("00000000-0000-0000-0000-000000000084") },
                new Skill { Name = "ASP.NET", Uid = Guid.Parse("00000000-0000-0000-0000-000000000085") },
                new Skill { Name = "Spring Boot", Uid = Guid.Parse("00000000-0000-0000-0000-000000000086") },
                new Skill { Name = "Junit", Uid = Guid.Parse("00000000-0000-0000-0000-000000000087") },
                new Skill { Name = "TestNG", Uid = Guid.Parse("00000000-0000-0000-0000-000000000088") },
                new Skill { Name = "NUnit", Uid = Guid.Parse("00000000-0000-0000-0000-000000000089") },
                new Skill { Name = "XUnit", Uid = Guid.Parse("00000000-0000-0000-0000-000000000090") },
                new Skill { Name = "Mocha", Uid = Guid.Parse("00000000-0000-0000-0000-000000000091") },
                new Skill { Name = "Pytest", Uid = Guid.Parse("00000000-0000-0000-0000-000000000093") },
                new Skill { Name = "Playwright", Uid = Guid.Parse("00000000-0000-0000-0000-000000000094") },
                new Skill { Name = "Selenium", Uid = Guid.Parse("00000000-0000-0000-0000-000000000095") },
                new Skill { Name = "Selenide", Uid = Guid.Parse("00000000-0000-0000-0000-000000000096") },
                new Skill { Name = "Selenoid", Uid = Guid.Parse("00000000-0000-0000-0000-000000000097") },
            };
        }

        private List<NonProfessionalInterest> GenerateNonProfessionalInterests()
        {
            return new List<NonProfessionalInterest>
            {
                new NonProfessionalInterest { Name = "Читання", Uid = Guid.Parse("00000000-0000-0000-0000-000000000008") },
                new NonProfessionalInterest { Name = "Писання", Uid = Guid.Parse("00000000-0000-0000-0000-000000000009") },
                new NonProfessionalInterest { Name = "Малювання", Uid = Guid.Parse("00000000-0000-0000-0000-000000000010") },
                new NonProfessionalInterest { Name = "Живопис", Uid = Guid.Parse("00000000-0000-0000-0000-000000000011") },
                new NonProfessionalInterest { Name = "Фотографія", Uid = Guid.Parse("00000000-0000-0000-0000-000000000012") },
                new NonProfessionalInterest { Name = "Гра на музичних інструментах", Uid = Guid.Parse("00000000-0000-0000-0000-000000000013") },
                new NonProfessionalInterest { Name = "Спів", Uid = Guid.Parse("00000000-0000-0000-0000-000000000014") },
                new NonProfessionalInterest { Name = "Танці", Uid = Guid.Parse("00000000-0000-0000-0000-000000000015") },
                new NonProfessionalInterest { Name = "Кулінарія", Uid = Guid.Parse("00000000-0000-0000-0000-000000000016") },
                new NonProfessionalInterest { Name = "Пекарство", Uid = Guid.Parse("00000000-0000-0000-0000-000000000017") },
                new NonProfessionalInterest { Name = "Садівництво", Uid = Guid.Parse("00000000-0000-0000-0000-000000000018") },
                new NonProfessionalInterest { Name = "Походи в гори", Uid = Guid.Parse("00000000-0000-0000-0000-000000000019") },
                new NonProfessionalInterest { Name = "Кемпінг", Uid = Guid.Parse("00000000-0000-0000-0000-000000000020") },
                new NonProfessionalInterest { Name = "Риболовля", Uid = Guid.Parse("00000000-0000-0000-0000-000000000021") },
                new NonProfessionalInterest { Name = "Спостереження за птахами", Uid = Guid.Parse("00000000-0000-0000-0000-000000000022") },
                new NonProfessionalInterest { Name = "В'язання", Uid = Guid.Parse("00000000-0000-0000-0000-000000000023") },
                new NonProfessionalInterest { Name = "В'язання гачком", Uid = Guid.Parse("00000000-0000-0000-0000-000000000024") },
                new NonProfessionalInterest { Name = "Шиття", Uid = Guid.Parse("00000000-0000-0000-0000-000000000025") },
                new NonProfessionalInterest { Name = "Гончарство", Uid = Guid.Parse("00000000-0000-0000-0000-000000000026") },
                new NonProfessionalInterest { Name = "Скульптура", Uid = Guid.Parse("00000000-0000-0000-0000-000000000027") },
                new NonProfessionalInterest { Name = "Робота з деревом", Uid = Guid.Parse("00000000-0000-0000-0000-000000000028") },
                new NonProfessionalInterest { Name = "DIY проекти", Uid = Guid.Parse("00000000-0000-0000-0000-000000000029") },
                new NonProfessionalInterest { Name = "Збір марок", Uid = Guid.Parse("00000000-0000-0000-0000-000000000030") },
                new NonProfessionalInterest { Name = "Збір монет", Uid = Guid.Parse("00000000-0000-0000-0000-000000000031") },
                new NonProfessionalInterest { Name = "Збір антикваріату", Uid = Guid.Parse("00000000-0000-0000-0000-000000000032") },
                new NonProfessionalInterest { Name = "Збір винтажних речей", Uid = Guid.Parse("00000000-0000-0000-0000-000000000033") },
                new NonProfessionalInterest { Name = "Збір коміксів", Uid = Guid.Parse("00000000-0000-0000-0000-000000000034") },
                new NonProfessionalInterest { Name = "Збір фігурок", Uid = Guid.Parse("00000000-0000-0000-0000-000000000035") },
                new NonProfessionalInterest { Name = "Збір спортивної меморабілії", Uid = Guid.Parse("00000000-0000-0000-0000-000000000036") },
                new NonProfessionalInterest { Name = "Дивитися фільми", Uid = Guid.Parse("00000000-0000-0000-0000-000000000037") },
                new NonProfessionalInterest { Name = "Дивитися телешоу", Uid = Guid.Parse("00000000-0000-0000-0000-000000000038") },
                new NonProfessionalInterest { Name = "Грати в відеоігри", Uid = Guid.Parse("00000000-0000-0000-0000-000000000039") },
                new NonProfessionalInterest { Name = "Настільні ігри", Uid = Guid.Parse("00000000-0000-0000-0000-000000000040") },
                new NonProfessionalInterest { Name = "Розв'язування пазлів", Uid = Guid.Parse("00000000-0000-0000-0000-000000000041") },
                new NonProfessionalInterest { Name = "Кросворди", Uid = Guid.Parse("00000000-0000-0000-0000-000000000042") },
                new NonProfessionalInterest { Name = "Судоку", Uid = Guid.Parse("00000000-0000-0000-0000-000000000043") },
                new NonProfessionalInterest { Name = "Йога", Uid = Guid.Parse("00000000-0000-0000-0000-000000000044") },
                new NonProfessionalInterest { Name = "Медитація", Uid = Guid.Parse("00000000-0000-0000-0000-000000000045") },
                new NonProfessionalInterest { Name = "Біг", Uid = Guid.Parse("00000000-0000-0000-0000-000000000046") },
                new NonProfessionalInterest { Name = "Джоггінг", Uid = Guid.Parse("00000000-0000-0000-0000-000000000047") },
                new NonProfessionalInterest { Name = "Велосипед", Uid = Guid.Parse("00000000-0000-0000-0000-000000000048") },
                new NonProfessionalInterest { Name = "Плавання", Uid = Guid.Parse("00000000-0000-0000-0000-000000000049") },
                new NonProfessionalInterest { Name = "Серфінг", Uid = Guid.Parse("00000000-0000-0000-0000-000000000050") },
                new NonProfessionalInterest { Name = "Катання на лижах", Uid = Guid.Parse("00000000-0000-0000-0000-000000000051") },
                new NonProfessionalInterest { Name = "Сноубординг", Uid = Guid.Parse("00000000-0000-0000-0000-000000000052") },
                new NonProfessionalInterest { Name = "Скейтбординг", Uid = Guid.Parse("00000000-0000-0000-0000-000000000053") },
                new NonProfessionalInterest { Name = "Скелелазіння", Uid = Guid.Parse("00000000-0000-0000-0000-000000000054") },
                new NonProfessionalInterest { Name = "Настільний теніс", Uid = Guid.Parse("00000000-0000-0000-0000-000000000055") },
                new NonProfessionalInterest { Name = "Теніс", Uid = Guid.Parse("00000000-0000-0000-0000-000000000056") },
                new NonProfessionalInterest { Name = "Волейбол", Uid = Guid.Parse("00000000-0000-0000-0000-000000000057") },
                new NonProfessionalInterest { Name = "Футбол", Uid = Guid.Parse("00000000-0000-0000-0000-000000000058") },
                new NonProfessionalInterest { Name = "Баскетбол", Uid = Guid.Parse("00000000-0000-0000-0000-000000000059") },
                new NonProfessionalInterest { Name = "Інший спорт", Uid = Guid.Parse("00000000-0000-0000-0000-000000000060") },
            };
        }

        private List<StudyField> GenerateStudyFields()
        {
            return new List<StudyField>
            {
                new StudyField { Name = "QA/AQA", Uid = Guid.Parse("00000000-0000-0000-0000-000000000100") },
                new StudyField { Name = "Frontend", Uid = Guid.Parse("00000000-0000-0000-0000-000000000101") },
                new StudyField { Name = "Full stack", Uid = Guid.Parse("00000000-0000-0000-0000-000000000102") },
                new StudyField { Name = "Backend", Uid = Guid.Parse("00000000-0000-0000-0000-000000000103") },
            };
        }

        private List<State> GenerateStates()
        {
            return new List<State>
            {
                new State { Name = "Робота над тестовим завданням", Uid = Guid.Parse("00000000-0000-0000-0000-000000000200") },
                new State { Name = "Випробовувальний період", Uid = Guid.Parse("00000000-0000-0000-0000-000000000201") },
                new State { Name = "Навчається", Uid = Guid.Parse("00000000-0000-0000-0000-000000000202") },
                new State { Name = "Ходить по співбесідам", Uid = Guid.Parse("00000000-0000-0000-0000-000000000203") },
                new State { Name = "Отримав роботу", Uid = Guid.Parse("00000000-0000-0000-0000-000000000204") },
            };
        }

        private List<Location> GenerateLocations()
        {
            return new List<Location>
            {
                new Location { City = "Київ", Address = "Ковальский провулок 19", Uid = Guid.Parse("00000000-0000-0000-0000-000000000004") },
                new Location { City = "Калинівка", Address = "вулиця Травнева, 10, Броварський район, Київська область, 07443", Uid = Guid.Parse("00000000-0000-0000-0000-000000000005") },
                new Location { City = "Луцьк", Address = "вулиця Відродження 31, Волиньска область, 43000", Uid = Guid.Parse("00000000-0000-0000-0000-000000000006") },
                new Location { City = "Online", Address = null, Uid = Guid.Parse("00000000-0000-0000-0000-000000000007") },
            };
        }

        private List<Role> GenerateRoles()
        {
            return new List<Role>
            {
                new Role { Name = Domain.Roles.Director, Uid = Guid.Parse("00000000-0000-0000-0000-000000000001") },
                new Role { Name = Domain.Roles.Mentor, Uid = Guid.Parse("00000000-0000-0000-0000-000000000002") },
                new Role { Name = Domain.Roles.Student, Uid = Guid.Parse("00000000-0000-0000-0000-000000000003") },
            };
        }

        private List<UserInfo> GenerateUserInfos(int amount)
        {
            int userInfoUidCounter = 1000;
            var userFaker = new Faker<UserInfo>("uk")
                .UseSeed(777)
                .RuleFor(x => x.Uid, f => Guid.Parse($"00000000-0000-0000-0000-00000000{userInfoUidCounter++}")) // Each product will have an incrementing id.
                .RuleFor(x => x.Name, f => f.Name.FullName())
                .RuleFor(x => x.Description, f => f.Lorem.Paragraph())
                .RuleFor(x => x.CurentSalary, f => f.Random.Decimal(1000, 7000))
                .RuleFor(x => x.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(x => x.Email, f => f.Internet.Email())
                .RuleFor(x => x.StudyFields, f => [f.PickRandom(StudyFields)])
                .RuleFor(x => x.DateOfBirth, f => f.Date.Between(DateTime.Now.AddYears(50), DateTime.Now.AddYears(20)))
                .RuleFor(x => x.Role, f => f.PickRandom(Roles))
                .RuleFor(x => x.Locations, f => [f.PickRandom(Locations)])
                .RuleFor(x => x.NonProfessionalInterests, f => f.PickRandom(NonProfessionalInterests, randomString.Length).ToList())
                .RuleFor(x => x.Skills, f => f.PickRandom(Skills, randomString.Length).ToList());
            //.RuleFor(x => x.MentorProperties, (f, x) => x.Role.Name == Domain.Roles.Mentor ? f.PickRandom(Mentors) : null);

            var users = Enumerable.Range(1, amount)
                .Select(i => SeedRow(userFaker, i))
                .ToList();

            return users;
        }

        private List<Student> GenerateStudents()
        {
            var students = UserInfos.Where(UserInfo => UserInfo.Role.Name == Domain.Roles.Student).ToList();

            var categoryId = 1;
            var categoryFaker = new Faker<Student>()
                .RuleFor(x => x.Id, f => categoryId++) // Each category will have an incrementing id.
                .RuleFor(x => x.State, f => f.PickRandom(States)) // Each category will have an incrementing id.
                .RuleFor(x => x.UserInfo, (f, x) =>
                {
                    if (students.Any())
                    {
                        var student = f.PickRandom(students);
                        students.Remove(student);

                        student.StudentPropertiesUid = x.UserInfo.Uid;

                        return student;
                    }
                    return null;
                })
                .RuleFor(x => x.UserInfoUid, (f, x) => x.UserInfo.Uid);

            var categories = Enumerable.Range(1, students.Count)
                .Select(i => SeedRow(categoryFaker, i))
                .ToList();

            return categories;
        }

        private List<Mentor> GenerateMentors()
        {
            var mentors = UserInfos.Where(UserInfo => UserInfo.Role.Name == Domain.Roles.Mentor).ToList();
            var students = Students.ToList();

            var categoryId = 1;
            var categoryFaker = new Faker<Mentor>()
                .RuleFor(x => x.Id, f => categoryId++) // Each category will have an incrementing id.
                .RuleFor(x => x.UserInfo, (f, x) =>
                {
                    var user = f.PickRandom(mentors);

                    mentors.Remove(user);

                    user.MentorPropertiesUid = x.UserInfo.Uid;

                    return user;
                })
                .RuleFor(x => x.UserInfoUid, (f, x) => x.UserInfo.Uid)
                .RuleFor(x => x.Students, (f, x) =>
                {
                    if (!students.Any())
                    {
                        return [];
                    }
                    var studentRange = f.PickRandom(students, ToPickCount(students)).ToList();

                    students = students.Except(studentRange).ToList();

                    studentRange.ForEach(student => { student.Mentor = x; student.MentorUid = x.UserInfo.Uid; });

                    return studentRange;
                });

            var categories = Enumerable.Range(1, mentors.Count)
                .Select(i => SeedRow(categoryFaker, i))
                .ToList();

            return categories;
        }

        private static T SeedRow<T>(Faker<T> faker, int rowId) where T : class
        {
            var recordRow = faker.UseSeed(rowId).Generate();
            return recordRow;
        }

        private int ToPickCount<T>(IEnumerable<T> objects)
        {
            var randomStringValue = randomString.Length;

            return randomStringValue > objects.Count() ? objects.Count() : randomStringValue;
        }
    }
}
