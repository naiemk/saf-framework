using saf.Authorization.Management;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using saf.Base;
using System.Security.Principal;
using saf.Authorization;

namespace safTests
{
    
    
    /// <summary>
    ///This is a test class for AuthorizationHelperTest and is intended
    ///to contain all AuthorizationHelperTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AuthorizationHelperTest
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
        ///A test for CanDelete
        ///</summary>
        [TestMethod()]
        public void CanDeleteTest()
        {
            IMetadataClassProvider meta = null; // TODO: Initialize to an appropriate value
            Type type = null; // TODO: Initialize to an appropriate value
            object instance = null; // TODO: Initialize to an appropriate value
            IPrincipal principal = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = AuthorizationHelper.CanDelete(meta, type, instance, principal);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CanInsert
        ///</summary>
        [TestMethod()]
        public void CanInsertTest()
        {
            IMetadataClassProvider meta = null; // TODO: Initialize to an appropriate value
            Type type = null; // TODO: Initialize to an appropriate value
            object instance = null; // TODO: Initialize to an appropriate value
            IPrincipal principal = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = AuthorizationHelper.CanInsert(meta, type, instance, principal);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CanUpdate
        ///</summary>
        [TestMethod()]
        public void CanUpdateTest()
        {
            IMetadataClassProvider meta = null; // TODO: Initialize to an appropriate value
            Type type = null; // TODO: Initialize to an appropriate value
            object instance = null; // TODO: Initialize to an appropriate value
            IPrincipal principal = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = AuthorizationHelper.CanUpdate(meta, type, instance, principal);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAuthorizationToken
        ///</summary>
        [TestMethod()]
        public void GetAuthorizationTokenTest()
        {
            IMetadataClassProvider meta = null; // TODO: Initialize to an appropriate value
            Type type = null; // TODO: Initialize to an appropriate value
            object instance = null; // TODO: Initialize to an appropriate value
            IPrincipal principal = null; // TODO: Initialize to an appropriate value
            AuthorizationToken expected = null; // TODO: Initialize to an appropriate value
            AuthorizationToken actual;
            actual = AuthorizationHelper.GetAuthorizationToken(meta, type, instance, principal);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
