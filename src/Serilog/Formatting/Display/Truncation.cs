namespace Serilog.Formatting.Display
{
    static class Truncation
    {
        public static string Apply(string text, int maximumLength)
        {
            if (text.Length > maximumLength)
            {
                return text.Substring(0, maximumLength - 1) + "…";
            }

            return text;
        }
    }
}