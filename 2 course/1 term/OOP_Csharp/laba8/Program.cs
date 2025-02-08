namespace laba8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            User user = new User();

            user.workNotify += user.Upgrade;

            for (int i = 0; i < 8; i++)
            {
                user.Work();
            }

            string str1 = "{str1 ,}";
            string str2 = "{str2 ,}";
            StringCorrector.DoOperation(str1, str2, StringCorrector.Concat);
            StringCorrector.DoOperation(str1, str2, StringCorrector.NoSpace);
            StringCorrector.DoOperation(str1, str2, StringCorrector.toUpper);
            StringCorrector.DoOperation(str1, str2, StringCorrector.toLower);
            StringCorrector.DoOperation(str1, str2, StringCorrector.NoComas);
        }
    }
}
