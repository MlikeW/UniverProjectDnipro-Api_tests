using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace Tests.Steps
{
    public static class SpecFlowMethods
    {
        internal static List<Dictionary<string, string>> ToListDictionary(this Table table)
            => table.Rows.Select(row => table.Header.ToDictionary(head => head, head => row[head])).ToList();

        internal static Dictionary<string, string> ToVerticalDictionary(this Table table)
            => table.Rows.ToDictionary(row => row[0], row => row[1]);

        internal static Dictionary<string, string> ToHorizontalDictionary(this Table table)
            => table.Header.ToDictionary(head => head, head => table.Rows[0][head]);

        public static List<string> ToList(this Table table)
            => table.Rows.Select(row => row[0]).ToList();

        public static Dictionary<string, string[]> ToVerticalDictionaryValueArray(this Table table)
            => table.Rows.ToDictionary(row => row[0], row => row[1].Split('/').ToArray());

        public static List<string[]> ToListOfArrays(this Table table)
            => table.Rows.Select(row => row[0].Split("\r\n")).ToList();
    }
}
