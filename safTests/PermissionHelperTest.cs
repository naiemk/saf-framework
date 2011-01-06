using saf.Attributes;
using saf.Extraction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using saf.Base;
using System.Security.Principal;
using System.Collections.Generic;
using System.Reflection;
using saf.Providers;
using System.Security;

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


        [Grant(Roles = new[] { "Everyone" }, Permission = Permission.View)]
        [Grant(Roles = new[] { "QLDAdmin", "NSWAdmin" }, Permission = Permission.View | Permission.Edit | Permission.Create)]
        [Grant(Roles = new[] { "Deleter" }, Permission = Permission.Delete)]
        [Grant(Roles = new[] { "God" }, Permission = Permission.Own)]
        [Deny(Roles = new[] { "NSWAdmin" }, Permission = Permission.Edit)]
        public class TestObject
        {
            [Grant(Roles = new[] { "Everyone" }, Permission = Permission.View)]
            [Deny(Roles = new[] { "God" }, Permission = Permission.View)]
            public int YouCanSeeMe { get; set; }

            [Grant(Roles = new[] { "Everyone" }, Permission = Permission.Edit)]
            [Deny(Roles = new[] { "God" }, Permission = Permission.Edit | Permission.View)]
            public string YouCanEditMe { get; set; }

            [Deny(Roles = new[] { "Everyone" }, Permission = Permission.View)]
            public string YouCanNotSeeMe { get; set; }

            [Deny(Roles = new[] { "Everyone" }, Permission = Permission.Edit)]
            public string YouCanSeeMeButNotEditMe { get; set; }

            public string[] States { get; set; }
        }


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
        }

        /// <summary>
        ///A test for GetPropertyLevelPremissions
        ///</summary>
        public void GetPropertyLevelPremissionsTestHelper<TP>()
        {
            
        }

        [TestMethod()]
        public void GetPropertyLevelPremissionsTest()
        {
            GetPropertyLevelPremissionsTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for GetPropertyPermissions
        ///</summary>
        public void GetPropertyPermissionsTestHelper<TP>()
        {
            
        }

        [TestMethod()]
        public void GetPropertyPermissionsTest()
        {
            GetPropertyPermissionsTestHelper<GenericParameterHelper>();
        }
    }
}
