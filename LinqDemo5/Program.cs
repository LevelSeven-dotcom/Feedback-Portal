namespace LinqDemo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> words = new List<string>() { "one", "two", "three", "four", "five", "six" };

           // get words with 3 or less charectors

           var shortWords1 = from w in words
                             where w.Length <= 3
                             select w;

            var shortWords11 = words.Where(w => w.Length <= 3).ToList();


            var shortWords2 = from w in words
                              where w.Length <= 3
                              select w.ToUpper();

            // how many short words?

            var shortWords3 = (from w in words
                               where w.Length <= 3
                               select w).Count();

            // get first short word only

            var shortWords4 = (from w in words
                               where w.Length <= 3
                               select w).FirstOrDefault();


        }
    }
}
