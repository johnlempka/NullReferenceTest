using System.Configuration;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.OrmLite;

namespace NullReferenceTest
{
    public class Foo
    {
        public string Name { get; set; }

        public string Key { get; set; }
    }


    [TestClass]
    public class NullReferenceTest
    {

        [TestInitialize]
        public void Setup()
        {
            var dbFactory =
                new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["Default"].ConnectionString, MySqlDialect.Provider);
            Db = dbFactory.Open();
        }

        public IDbConnection Db { get; set; }

        [TestMethod]
        public void TestNullReference()
        {
            Db.CreateTableIfNotExists(typeof(Foo));

            Db.AlterColumn(typeof(Foo), new FieldDefinition()
            {
                Name = "Name",
                FieldType = typeof(string),
                IsNullable = true,
                DefaultValue = null
            });
        }
    }
}
