using System;
using Lab1;
using Xunit;

namespace Tests
{
    public class StringHelperTests
    {
        private readonly IStringHelper _stringHelper;

        public StringHelperTests()
        {
            _stringHelper = new StringHelper();
        }

        [Fact]
        public void Insert()
        {
            //arrange
            var source = "abcd abch";
            var combination = "abc";
            var textToInsert = "cba";

            //act
            var result = _stringHelper.InsertAfterCombinationInEveryWord(source, combination, textToInsert);

            //assert
            Assert.Equal("abccbad abccbah", result);
        }

        [Fact]
        public void InsertSourceNull()
        {
            //arrange
            string source = null;
            string combination = null;
            string textToInsert = null;

            //act
            Action action = () => { _stringHelper.InsertAfterCombinationInEveryWord(source, combination, textToInsert); };

            //assert
            Assert.Throws<NullReferenceException>(action);
        }
    }
}