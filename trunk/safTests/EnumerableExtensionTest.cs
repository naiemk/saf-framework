using saf.Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using saf.Base;
using System.Security.Principal;
using saf.Authorization;

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


        /// <summary>
        ///A test for FilterAuthorized
        ///</summary>
        public void FilterAuthorizedTestHelper<T>()
        {
            IEnumerable<T> list = null; // TODO: Initialize to an appropriate value
            IMetadataClassProvider meta = null; // TODO: Initialize to an appropriate value
            IPrincipal principal = null; // TODO: Initialize to an appropriate value
            IEnumerable<Tuple<T, AuthorizationToken>> expected = null; // TODO: Initialize to an appropriate value
            IEnumerable<Tuple<T, AuthorizationToken>> actual;
            actual = EnumerableExtension.FilterAuthorized<T>(list, meta, principal);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void FilterAuthorizedTest()
        {
            FilterAuthorizedTestHelper<GenericParameterHelper>();
        }

        /// <summary>
        ///A test for Intersect
        ///</summary>
        public void IntersectTestHelper<TP, TE>()

            where TE : IAccessExtension
        {
            IEnumerable<IAccess<TP, TE>> list = null; // TODO: Initialize to an appropriate value
            IAccess<TP, TE> expected = null; // TODO: Initialize to an appropriate value
            IAccess<TP, TE> actual;
            actual = EnumerableExtension.Intersect<TP, TE>(list);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void IntersectTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TE." +
                    " Please call IntersectTestHelper<TP, TE>() with appropriate type parameters.");
        }

        /// <summary>
        ///A test for Union
        ///</summary>
        public void UnionTestHelper<TP, TE>()

            where TE : IAccessExtension
        {
            IEnumerable<IAccess<TP, TE>> list = null; // TODO: Initialize to an appropriate value
            IAccess<TP, TE> expected = null; // TODO: Initialize to an appropriate value
            IAccess<TP, TE> actual;
            actual = EnumerableExtension.Union<TP, TE>(list);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        public void UnionTest()
        {
            Assert.Inconclusive("No appropriate type parameter is found to satisfies the type constraint(s) of TE." +
                    " Please call UnionTestHelper<TP, TE>() with appropriate type parameters.");
        }
    }
}
