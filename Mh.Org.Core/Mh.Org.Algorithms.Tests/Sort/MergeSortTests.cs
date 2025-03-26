using Xunit;
using Xunit.Sdk;

namespace Mh.Org.Algorithms.Sort
{
    public class MergeSortTests
    {
        [Fact]
        public void Sort_EmptyArray_Test()
        {
            var actual = MergeSort.Sort<IComparable>([]);

            Assert.Equal([], actual);
        }

        [Fact]
        public void Sort_SingleItemArray_Test()
        {
            var actual = MergeSort.Sort([1]);

            Assert.Equal([1], actual);
        }

        [Theory]
        [InlineData([new int[] { 1, 2 }, new int[] { 1, 2 }])]
        [InlineData([new int[] { 2, 1 }, new int[] { 1, 2 }])]
        [InlineData([new int[] { 1, 2, 3 }, new int[] { 1, 2, 3 }])]
        [InlineData([new int[] { 3, 2, 1 }, new int[] { 1, 2, 3 }])]
        [InlineData([new int[] { 1, 1, 1, 1 }, new int[] { 1, 1, 1, 1 }])]
        [InlineData([new int[] { 5, 4, 3, 2, 1 }, new int[] { 1, 2, 3, 4, 5 }])]
        public void Sort_Test(int[] unsorted, int[] expected)
        {
            var actual = MergeSort.Sort(unsorted);

            Assert.Equal(expected, actual);
        }
    }
}
