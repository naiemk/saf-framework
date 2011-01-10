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

        }

        /// <summary>
        ///A test for CanInsert
        ///</summary>
        [TestMethod()]
        public void CanInsertTest()
        {

        }

        /// <summary>
        ///A test for CanUpdate
        ///</summary>
        [TestMethod()]
        public void CanUpdateTest()
        {

        }

        /// <summary>
        ///A test for GetAuthorizationToken
        ///</summary>
        [TestMethod()]
        public void GetAuthorizationTokenTest()
        {
           
        }
    }
}
