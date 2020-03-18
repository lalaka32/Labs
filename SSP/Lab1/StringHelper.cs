using System;
using System.Linq;

namespace Lab1
{
    public class StringHelper : IStringHelper
    {
        public string InsertAfterCombinationInEveryWord(string source, string combination, string textToInsert)
        {
            var wordsInText = source.Split(" ");

            for (var i = 0; i < wordsInText.Length; i++)
            {
                wordsInText[i] = InsertAfter(wordsInText[i], combination, textToInsert);
            }

            return string.Join(" ", wordsInText);
        }

        private string InsertAfter(string source, string combination, string textToInsert)
        {
            for (var iSourceChar = 0; iSourceChar < source.Length; iSourceChar++)
            {
                var matchIndex = iSourceChar;
                foreach (var combinationChar in combination)
                {
                    var isLastCombinationChar = combinationChar == combination.Last();
                    if (source[matchIndex] == combinationChar && isLastCombinationChar)
                    {
                        var result = source.Insert(matchIndex + 1, textToInsert);
                        return result;
                    }

                    matchIndex++;
                    if (matchIndex >= source.Length)
                    {
                        return source;
                    }
                }
            }

            return source;
        }
    }
}