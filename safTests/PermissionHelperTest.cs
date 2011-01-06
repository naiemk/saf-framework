using saf.Extraction;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using saf.Base;
using System.Security.Principal;
using System.Collections.Generic;
using System.Reflection;

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
            IMetadataClassProvider metadataProvider = null; // TODO: Initialize to an appropriate value
            Type type = null; // TODO: Initialize to an appropriate value
            object instance = null; // TODO: Initialize to an appropriate value
            IPrincipal principal = null; // TODO: Initialize to an appropriate value
            IAccess<Permission, IAccessExtension> expected = null; // TODO: Initialize to an appropriate value
            IAccess<Permission, IAccessExtension> actual;
            actual = PermissionHelper.GetObjectLevelPremission(metadataProvider, type, instance, principal);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetPropertyLevelPremissions
        ///</summary>
        public void GetPropertyLevelPremissionsTestHelper<TP>()
        {
            IMetadataClassProvider metadataProvider = null; // TODO: Initialize to an appropriate value
            IAccess<TP, IAccessExtension> reflectedPermission = null; // TODO: Initialize to an appropriate value
            Type type = null; // TODO: Initialize to an appropriate value
            object instance = null; // TODO: Initialize to an appropriate value
            IPrincipal principal = null; // TODO: Initialize to an appropriate value
            IDictionary<string, IAccess<TP, IAccessExtension>> expected = null; // TODO: Initialize to an appropriate value
            IDictionary<string, IAccess<TP, IAccessExtension>> actual;
            actual = PermissionHelper.GetPropertyLevelPremissions<TP>(metadataProvider, reflectedPermission, type, instance, principal);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
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
            PropertyInfo propertyInfo = null; // TODO: Initialize to an appropriate value
            object instance = null; // TODO: Initialize to an appropriate value
            IPrincipal principal = null; // TODO: Initialize to an appropriate value
            IAccess<TP, IAccessExtension> expected = null; // TODO: Initialize to an appropriate value
            IAccess<TP, IAccessExtension> actual;
            actual = PermissionHelper.GetPropertyPermissions<TP>(propertyInfo, instance, principal);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void GetPropertyPermissionsTest()
        {
            GetPropertyPermissionsTestHelper<GenericParameterHelper>();
        }
    }
}
