namespace HrManagement.Domain.Utils
{
    public class StringUtils
    {
        public static string FormantStringToCompare(string input) => input.Trim().ToLower();

        public static bool Compare(string input1, string input2)
        {
            return FormantStringToCompare(input1).Equals(FormantStringToCompare(input2));
        }
    }
}
