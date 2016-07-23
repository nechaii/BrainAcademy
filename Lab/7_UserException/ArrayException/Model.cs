
namespace ArrayException
{
    static class Model
    {
        public static string[] GetStringArray()
        {
            return new string[] { "Onix","Picachu","Caterpy"};
        }

        public static string GetHeaderMenuText()
        {
            return "Exception Menu";
        }

        public static string GetMainMenuText()
        {
            return "1 - NullReferenceException\n2 - FormatException\n3 - IndexOutOfRangeException\n4 - UserException";
        }
    }
}
