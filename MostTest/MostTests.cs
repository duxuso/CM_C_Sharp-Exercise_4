using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MostCommon;

namespace MostTest
{
    /// <summary>
    /// Test Class 'MostTests' 
    /// </summary>
    [TestClass]
    public class MostTests
    {
        /// <summary>
        /// Sample tests for finding most common integers
        ///    Because it doesn't care the order inside the expected and actual array, thus 
        ///    it can't use - CollectionAssert.AreEqual(expected, actual), the same below
        /// </summary>        
        [TestMethod]
        public void Test_SampleInputsArrayOne()
        {
            // arrange the first sample array from benchmarks
            int[] sam_array1 = new int[] {5,4,3,2,4,5,1,6,1,2,5,4};
            int[] expected = new int[] {5,4};
            int[] actual;

            MostCommonInteger mci = new MostCommonInteger();
            
            // act
            actual = mci.Most(sam_array1);
            
            // assert
            CollectionAssert.AreEquivalent(expected, actual);
            
        }

        /// <summary>
        /// The second test, only has one most common integer
        /// </summary>
        [TestMethod]
        public void Test_SampleInputsArrayTwo()
        {
            // arrange the second sample array from benchmarks
            int[] sam_array2 = new int[] {1,2,3,4,5,1,6,7};
            int[] expected = new int[] {1};
            int[] actual;

            MostCommonInteger mci = new MostCommonInteger();

            // act
            actual = mci.Most(sam_array2);

            // assert
            CollectionAssert.AreEquivalent(expected, actual);       
        }

        /// <summary>
        /// In the third situation, no one counted greater than 1, so returns them all.  
        /// </summary>
        [TestMethod]
        public void Test_SampleInputsArrayThree()
        {
            // arrange the third sample array with decending order
            int[] sam_array3 = new int[] { 7, 6, 5, 4, 3, 2, 1 };
            int[] expected = new int[] {1, 2, 3, 4, 5, 6, 7 };
            int[] actual;

            MostCommonInteger mci = new MostCommonInteger();

            // act
            actual = mci.Most(sam_array3);

            // assert 
            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}
