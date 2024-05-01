using EC.CRM.Backend.Domain.Entities;

namespace EC.CRM.Backend.Persistence.DataContext.Seeding
{
    public class DatabaseSeeder
    {
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

            /*Products = GenerateProducts(amount: 1000);
            ProductCategories = GenerateProductCategories(amount: 50);
            ProductProductCategories = GenerateProductProductCategories(amount: 1000, Products, ProductCategories);*/
        }

        private List<Skill> GenerateSkills()
        {
            return new List<Skill>
            {
                new Skill { Name = "C#" },
                new Skill { Name = "Java" },
                new Skill { Name = "Python" },
                new Skill { Name = "JavaScript/TypeScript" },
                new Skill { Name = "Powershell" },
                new Skill { Name = "Bash" },
                new Skill { Name = "CMD" },
                new Skill { Name = "Linux" },
                new Skill { Name = "CSS" },
                new Skill { Name = "Html" },
                new Skill { Name = "Other programming languages" },
                new Skill { Name = "SQL" },
                new Skill { Name = "MsSQL" },
                new Skill { Name = "Postgres" },
                new Skill { Name = "MySql" },
                new Skill { Name = "AWS" },
                new Skill { Name = "Azure services" },
                new Skill { Name = "Git" },
                new Skill { Name = "GitHub CI" },
                new Skill { Name = "GitLab CI" },
                new Skill { Name = "Azure Devops Ci" },
                new Skill { Name = "Jenkins" },
                new Skill { Name = "Allure" },
                new Skill { Name = "React" },
                new Skill { Name = "Angular" },
                new Skill { Name = "ASP.NET" },
                new Skill { Name = "Spring Boot" },
                new Skill { Name = "Junit" },
                new Skill { Name = "TestNG" },
                new Skill { Name = "NUnit" },
                new Skill { Name = "XUnit" },
                new Skill { Name = "Mocha" },
                new Skill { Name = "Pytest" },
                new Skill { Name = "Playwright" },
                new Skill { Name = "Selenium" },
                new Skill { Name = "Selenide" },
                new Skill { Name = "Selenoid" },
            };
        }

        private List<NonProfessionalInterest> GenerateNonProfessionalInterests()
        {
            return new List<NonProfessionalInterest>
            {
            new NonProfessionalInterest { Name = "Читання" },
            new NonProfessionalInterest { Name = "Писання" },
            new NonProfessionalInterest { Name = "Малювання" },
            new NonProfessionalInterest { Name = "Живопис" },
            new NonProfessionalInterest { Name = "Фотографія" },
            new NonProfessionalInterest { Name = "Гра на музичних інструментах" },
            new NonProfessionalInterest { Name = "Спів" },
            new NonProfessionalInterest { Name = "Танці" },
            new NonProfessionalInterest { Name = "Кулінарія" },
            new NonProfessionalInterest { Name = "Пекарство" },
            new NonProfessionalInterest { Name = "Садівництво" },
            new NonProfessionalInterest { Name = "Походи в гори" },
            new NonProfessionalInterest { Name = "Кемпінг" },
            new NonProfessionalInterest { Name = "Риболовля" },
            new NonProfessionalInterest { Name = "Спостереження за птахами" },
            new NonProfessionalInterest { Name = "В'язання" },
            new NonProfessionalInterest { Name = "В'язання гачком" },
            new NonProfessionalInterest { Name = "Шиття" },
            new NonProfessionalInterest { Name = "Гончарство" },
            new NonProfessionalInterest { Name = "Скульптура" },
            new NonProfessionalInterest { Name = "Робота з деревом" },
            new NonProfessionalInterest { Name = "DIY проекти" },
            new NonProfessionalInterest { Name = "Збір марок" },
            new NonProfessionalInterest { Name = "Збір монет" },
            new NonProfessionalInterest { Name = "Збір антикваріату" },
            new NonProfessionalInterest { Name = "Збір винтажних речей" },
            new NonProfessionalInterest { Name = "Збір коміксів" },
            new NonProfessionalInterest { Name = "Збір фігурок" },
            new NonProfessionalInterest { Name = "Збір спортивної меморабілії" },
            new NonProfessionalInterest { Name = "Дивитися фільми" },
            new NonProfessionalInterest { Name = "Дивитися телешоу" },
            new NonProfessionalInterest { Name = "Грати в відеоігри" },
            new NonProfessionalInterest { Name = "Настільні ігри" },
            new NonProfessionalInterest { Name = "Розв'язування пазлів" },
            new NonProfessionalInterest { Name = "Кросворди" },
            new NonProfessionalInterest { Name = "Судоку" },
            new NonProfessionalInterest { Name = "Йога" },
            new NonProfessionalInterest { Name = "Медитація" },
            new NonProfessionalInterest { Name = "Біг" },
            new NonProfessionalInterest { Name = "Джоггінг" },
            new NonProfessionalInterest { Name = "Велосипед" },
            new NonProfessionalInterest { Name = "Плавання" },
            new NonProfessionalInterest { Name = "Серфінг" },
            new NonProfessionalInterest { Name = "Катання на лижах" },
            new NonProfessionalInterest { Name = "Сноубординг" },
            new NonProfessionalInterest { Name = "Скейтбординг" },
            new NonProfessionalInterest { Name = "Скелелазіння" },
            new NonProfessionalInterest { Name = "Настільний теніс" },
            new NonProfessionalInterest { Name = "Теніс" },
            new NonProfessionalInterest { Name = "Волейбол" },
            new NonProfessionalInterest { Name = "Футбол" },
            new NonProfessionalInterest { Name = "Баскетбол" },
            new NonProfessionalInterest { Name = "Інший спорт" },
        };
        }

        private List<StudyField> GenerateStudyFields()
        {
            return new List<StudyField>
            {
                new StudyField { Name = "QA/AQA" },
                new StudyField { Name = "Frontend" },
                new StudyField { Name = "Full stack" },
                new StudyField { Name = "Backend" },
            };
        }

        private List<State> GenerateStates()
        {
            return new List<State>
            {
                new State { Name = "Робота над тестовим завданням" },
                new State { Name = "Випробовувальний період" },
                new State { Name = "Навчається" },
                new State { Name = "Ходить по співбесідам" },
                new State { Name = "Отримав роботу" },
            };
        }

        private static List<Location> GenerateLocations()
        {
            return new List<Location>
            {
                new Location { City = "Київ", Address = "Ковальский провулок 19", Uid = Guid.Parse("00000000-0000-0000-0000-000000000004") },
                new Location { City = "Калинівка", Address = "вулиця Травнева, 10, Броварський район, Київська область, 07443", Uid = Guid.Parse("00000000-0000-0000-0000-000000000005") },
                new Location { City = "Луцьк", Address = "вулиця Відродження 31, Волиньска область, 43000", Uid = Guid.Parse("00000000-0000-0000-0000-000000000006") },
                new Location { City = "Online", Address = null, Uid = Guid.Parse("00000000-0000-0000-0000-000000000007") },
            };
        }

        private static List<Role> GenerateRoles()
        {
            return new List<Role>
            {
                new Role { Name = Domain.Roles.Director, Uid = Guid.Parse("00000000-0000-0000-0000-000000000001") },
                new Role { Name = Domain.Roles.Mentor, Uid = Guid.Parse("00000000-0000-0000-0000-000000000002") },
                new Role { Name = Domain.Roles.Student, Uid = Guid.Parse("00000000-0000-0000-0000-000000000003") },
            };
        }

        /* private static List<Product> UserInfos(int amount)
         {
             var productId = 1;
             var productFaker = new Faker<Product>()
                 .RuleFor(x => x.Id, f => productId++) // Each product will have an incrementing id.
                 .RuleFor(x => x.Name, f => f.Commerce.ProductName())
                 // The refDate is very important! Without it, it will generate a random date based on the CURRENT date on your system.
                 // Generating a date based on the system date is not deterministic!
                 // So the solution is to pass in a constant date instead which will be used to generate a random date
                 .RuleFor(x => x.CreationDate, f => f.Date.FutureOffset(
                     refDate: new DateTimeOffset(2024, 4, 15, 18, 0, 0, TimeSpan.FromHours(1))));

             // DEMO: Uncomment this line
             //.RuleFor(x => x.Description, f => f.Commerce.ProductDescription());

             var products = Enumerable.Range(1, amount)
                 .Select(i => SeedRow(productFaker, i))
                 .ToList();

             return products;
         }

         private static List<ProductCategory> GenerateProductCategories(int amount)
         {
             var categoryId = 1;
             var categoryFaker = new Faker<ProductCategory>()
                 .RuleFor(x => x.Id, f => categoryId++) // Each category will have an incrementing id.
                 .RuleFor(x => x.Name, f => f.Commerce.Categories(1).First());

             var categories = Enumerable.Range(1, amount)
                 .Select(i => SeedRow(categoryFaker, i))
                 .ToList();

             return categories;
         }

         private static List<ProductProductCategory> GenerateProductProductCategories(
             int amount,
             IEnumerable<Product> products,
             IEnumerable<ProductCategory> productCategories)
         {
             // Now we set up the faker for our join table.
             // We do this by grabbing a random product and category that were generated.
             var productProductCategoryFaker = new Faker<ProductProductCategory>()
                 .RuleFor(x => x.ProductId, f => f.PickRandom(products).Id)
                 .RuleFor(x => x.CategoryId, f => f.PickRandom(productCategories).Id);

             var productProductCategories = Enumerable.Range(1, amount)
                 .Select(i => SeedRow(productProductCategoryFaker, i))
                 // We do this GroupBy() + Select() to remove the duplicates from the generated join table entities
                 .GroupBy(x => new { x.ProductId, x.CategoryId })
                 .Select(x => x.First())
                 .ToList();

             return productProductCategories;
         }

         private static T SeedRow<T>(Faker<T> faker, int rowId) where T : class
         {
             var recordRow = faker.UseSeed(rowId).Generate();
             return recordRow;
         }*/
    }
}
