namespace Lab1
{
    public interface IStringHelper
    {
        /// <summary>
        /// Дан текст. В каждом слове вставить после заданного 3-буквенного сочетания заданное 2-буквенное
        /// </summary>
        /// <param name="source"></param>
        /// <param name="combination"></param>
        /// <param name="textToInsert"></param>
        /// <returns></returns>
        string InsertAfterCombinationInEveryWord(string source, string combination, string textToInsert);
    }
}