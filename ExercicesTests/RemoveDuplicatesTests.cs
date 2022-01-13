using Xunit;
using Exercices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Exercices.Tests
{
    public class RemoveDuplicatesTests
    {
        [Theory]
        [InlineData(null, null)]
        [InlineData(new int[]{}, new int[] {})]
        [InlineData(new int[]{1}, new int[] {1})]
        [InlineData(new int[] { 1, 1 }, new int[] { 1 })]
        [InlineData(new int[] { 1, 2 }, new int[] { 1, 2 })]
        [InlineData(new int[] { 7, 4, 7, 6, 12, 1, 4, -6}, new int[] { 7, 4, 6, 12, 1, -6 })]
        [InlineData(new int[] { 1245 , 1245, 1245, 1245, 1245, 1245, 1245, 1245, 1247}, new int[] { 1245, 1247 })]
        public void RunTest(int[] source, int[] result)
        {
            //act
            var actualResult = RemoveDuplicates.Run(source);
            //assert
            if (source == null)
            {
                Assert.True(actualResult is null);
                return;
            }    
            Assert.Equal(result.Length, actualResult.Length);
            for(int i=0; i<result.Length; i++)
                Assert.Equal(result[i], actualResult[i]);
        }

        [Fact]
        public void Run_When_OversizedSource_Then_ExceptionIsThrown()
        {
            var sourceBuilder = new List<int>();
            for (int i=0; i<101; i++)
                sourceBuilder.Add(i);
            var source = sourceBuilder.ToArray();
            var ex = Assert.Throws<ArgumentException>(() => RemoveDuplicates.Run(source));
            Assert.Equal("Source array is too long", ex.Message);
        }
    }
}