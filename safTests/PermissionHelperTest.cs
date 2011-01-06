using System.Linq;
using System.Security.Principal;
using saf.Attributes;
using saf.Extraction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using saf.Base;
using saf.Providers;

namespace safTests
{
    
    
    /// <summary>
    ///This is a test class for PermissionHelperTest and is intended
    ///to contain all PermissionHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PermissionHelperTest
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



        /// <summary>
        ///A test for GetObjectLevelPremission
        ///</summary>
        [TestMethod()]
        public void GetObjectLevelPremissionTest()
        {
            IMetadataClassProvider metadataProvider = new SelfMetadata();
            var to = new TestObject();
            var everyone = new TestUser() { Roles = new[] { "Everyone" } };
            var god = new TestUser() { Roles = new[] { "God" } };
            var adminNsw = new TestUser() { Roles = new[] { "NSWAdmin" } };
            var adminQld = new TestUser() { Roles = new[] { "QLDAdmin" } };
            var userWA = new TestUser() { Roles = new[] { "WAuser" } };
            var userQLD = new TestUser() { Roles = new[] { "QLDuser" } };

            var actual = PermissionHelper.GetObjectLevelPremission(metadataProvider, typeof(TestObject), to, everyone);
            Assert.AreEqual(true, actual.Key.HasFlag(Permission.View));
            Assert.AreEqual(false, actual.Key.HasFlag(Permission.Edit));
            Assert.AreEqual(false, actual.Key.HasFlag(Permission.Create));

            actual = PermissionHelper.GetObjectLevelPremission(metadataProvider, typeof(TestObject), to, god);
            Assert.AreEqual(true, actual.Key.HasFlag(Permission.Own));

            actual = PermissionHelper.GetObjectLevelPremission(metadataProvider, typeof(TestObject), to, adminNsw);
            Assert.AreEqual(false, actual.Key.HasFlag(Permission.Edit));
            Assert.AreEqual(true, actual.Key.HasFlag(Permission.View));

            actual = PermissionHelper.GetObjectLevelPremission(metadataProvider, typeof(TestObject), to, adminQld);
            Assert.AreEqual(true, actual.Key.HasFlag(Permission.Edit));
            Assert.AreEqual(true, actual.Key.HasFlag(Permission.View));

            to = new TestObject() { States = new[] { "QLD", "NSW" } };
            actual = PermissionHelper.GetObjectLevelPremission(metadataProvider, typeof(TestObject), to, userWA);
            Assert.IsNull(actual);

            actual = PermissionHelper.GetObjectLevelPremission(metadataProvider, typeof(TestObject), to, userQLD);
            Assert.AreEqual(true, actual.Key.HasFlag(Permission.View));
            Assert.AreEqual(true, actual.Key.HasFlag(Permission.Create));

            actual = PermissionHelper.GetObjectLevelPremission(metadataProvider, typeof(TestObject), to, adminQld);
            Assert.AreEqual(true, actual.Key.HasFlag(Permission.Delete));
            Assert.AreEqual(true, actual.Key.HasFlag(Permission.View));
        }


        [TestMethod()]
        public void GetPropertyLevelPremissionsTest()
        {
            IMetadataClassProvider metadataProvider = new SelfMetadata();
            var to = new TestObject();
            var everyone = new TestUser() { Roles = new[] { "Everyone" } };
            var god = new TestUser() { Roles = new[] { "God" } };
            var anon = new TestUser() { Roles = new string[0] };

            var parent = PermissionHelper.GetObjectLevelPremission(metadataProvider, typeof(TestObject), to, everyone);
            var actual = PermissionHelper.GetPropertyLevelPremissions(metadataProvider, parent, typeof(TestObject), to, everyone);
            Assert.AreEqual(true, actual["YouCanSeeMe"].Key.HasFlag(Permission.View));
            Assert.AreEqual(false, actual["YouCanSeeMe"].Key.HasFlag(Permission.Edit));
            Assert.AreEqual(false, actual["YouCanSeeMe"].Key.HasFlag(Permission.Create));
            Assert.AreEqual(false, actual["YouCanNotSeeMe"].Key.HasFlag(Permission.View));
            Assert.AreEqual(true, actual["YouCanSeeMeButNotEditMe"].Key.HasFlag(Permission.View));
            Assert.AreEqual(false, actual["YouCanSeeMeButNotEditMe"].Key.HasFlag(Permission.Edit));

            parent = PermissionHelper.GetObjectLevelPremission(metadataProvider, typeof(TestObject), to, god);
            actual = PermissionHelper.GetPropertyLevelPremissions(metadataProvider, parent, typeof(TestObject), to, god);
            Assert.AreEqual(false, actual["YouCanSeeMe"].Key.HasFlag(Permission.View));
            Assert.AreEqual(false, actual["YouCanEditMe"].Key.HasFlag(Permission.View));
            Assert.AreEqual(false, actual["YouCanEditMe"].Key.HasFlag(Permission.Edit));
            Assert.AreEqual(false, actual.ContainsKey("YouCanNotSeeMe"));

            parent = null;
            actual = PermissionHelper.GetPropertyLevelPremissions(metadataProvider, parent, typeof(TestObject), to, everyone);
            Assert.AreEqual(true, actual["YouCanSeeMe"].Key.HasFlag(Permission.View));

            parent = PermissionHelper.GetObjectLevelPremission(metadataProvider, typeof(TestObject), to, anon);
            actual = PermissionHelper.GetPropertyLevelPremissions(metadataProvider, parent, typeof(TestObject), to, anon);
            Assert.AreEqual(true, actual["EverybodyCanSeeMe"].Key.HasFlag(Permission.View));

            var qldMan = new TestUser() { Roles = new[] { "QLDMan" } };
            to = new TestObject() {YouCanSeeMe = 0, States = new[] {"QLD", "NSW"}};
            parent = PermissionHelper.GetObjectLevelPremission(metadataProvider, typeof(TestObject), to, qldMan);
            actual = PermissionHelper.GetPropertyLevelPremissions(metadataProvider, parent, typeof(TestObject), to, qldMan);
            Assert.AreEqual(false, actual["EverybodyCanSeeMe"].Key.HasFlag(Permission.View));
        }

    }
}
