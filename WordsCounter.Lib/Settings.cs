
namespace WordsCounter.Lib
{
    public static class Settings
    {
        public const string FileExtention = @".txt";
        public static string FileName = @"HtmlContet";
        public static string DefaultPath = @"D:\test\";

        public static char[] ReservedChars = { '\u00A0','\u0020','\u000A','\u000B','\u000C','\u000D','\u003F','\u0009','\u2212', '\u00AB', '\u002E', '\u0028', '\u0029', '\u002D', '\u002F', '\u003A', '\u002A', '\u0022', '\u003C',
                '\u003E', '\u007B', '\u007D', '\u002B','\u002C', '\u003F','\u0025','\u2014', '\u0021','\u003E','\u00BB','\uFE63','\u2011','\u2013' ,'0','1','2','3','4','5','6','7','8','9'};
    }
}
