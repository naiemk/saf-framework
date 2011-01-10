using saf.Authorization;
using saf.Authorization.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using saf.Base;
using saf.Providers;
using System.Linq;

namespace safTests
{
    
    
    /// <summary>
    ///This is a test class for EnumerableExtensionTest and is intended
    ///to contain all EnumerableExtensionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EnumerableExtensionTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion



        [TestMethod()]
        public void FilterAuthorizedTest()
        {
            IMetadataClassProvider sm = new SelfMetadata();
            var appProv = new AttributeAuthorizationProvider<Permission>(sm);
            var contx = new AuthorizationContext(appProv, new TestUser());
            var everyone = new TestUser() { Roles = new[] { "Everyone" } };
            var qldMan = new TestUser() { Roles = new[] { "QLDMan" } };

            var coll = new[]
                           {
                               new TestObject() {YouCanSeeMe = 0, States = new[] {"QLD", "NSW"}},
                               new TestObject() {YouCanSeeMe = 1},
                               new TestObject() {YouCanSeeMe = 2, YouCanNotSeeMe = "a", States = new[] {"QLD"}},
                               new TestObject() {YouCanSeeMe = 3},
                               new TestObject() {YouCanSeeMe = 4, YouCanNotSeeMe = "b"}
                           };

            contx = new AuthorizationContext(appProv, everyone);
            var filtered = coll.FilterUnAuthorized(contx).ToList();
            Assert.AreEqual(5, filtered.Count());

            contx = new AuthorizationContext(appProv, qldMan);
            filtered = coll.FilterUnAuthorized(contx).ToList();
            Assert.AreEqual(2, filtered.Count());

            //Ensure unavailable data is scraped.
        }

    }
}
