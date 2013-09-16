using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BeerCalcDataModel.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static Uri GetAsUri(this String str)
        {
            Uri result = new Uri(str);

            return result;
        }

        /// <summary>
        /// Returns first occurence of string between the two strings given as input
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strBegin"></param>
        /// <param name="strEnd"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        [Obsolete("GetStringBetween is deprecated, please use Substring instead.")]
        public static String GetStringBetween(this String str, String strBegin, String strEnd, bool caseSensitive = false)
        {
            String result = "";

            List<String> stringList = str.GetListOfStringBetween(strBegin, strEnd, caseSensitive);
            if (stringList.Count > 0)
            {
                result = stringList[0];
            }

            return result;
        }

        [Obsolete("GetListOfStringBetween is deprecated, please use Substrings instead.")]
        public static List<String> GetListOfStringBetween(this String str, String strBegin, String strEnd, bool caseSensitive = false)
        {
            List<String> result = new List<string>();

            String input = str;
            if (!caseSensitive)
            {
                str = str.ToLower();
                strBegin = strBegin.ToLower();
                strEnd = strEnd.ToLower();
            }

            while (str.IndexOf(strBegin) != -1)
            {
                int beginIndex = str.IndexOf(strBegin);

                beginIndex = beginIndex + strBegin.Length;
                int endIndex = str.Substring(beginIndex).IndexOf(strEnd);

                if (endIndex != -1)
                {
                    result.Add(input.Substring(beginIndex, endIndex));
                }

                str = str.Substring(beginIndex + endIndex + strEnd.Length);
                input = input.Substring(beginIndex + endIndex + strEnd.Length);
            }

            return result;
        }

        public static string ReplaceStringsBetween(this String str, String strBegin, String strEnd, string replaceString, bool replaceSearchCharacters = false, bool caseSensitive = false)
        {
            String output = str;
            if (!caseSensitive)
            {
                str = str.ToLower();
                strBegin = strBegin.ToLower();
                strEnd = strEnd.ToLower();
            }

            while (str.IndexOf(strBegin) != -1)
            {
                int beginIndex = str.IndexOf(strBegin);

                beginIndex = beginIndex + strBegin.Length;
                int endIndex = str.Substring(beginIndex).IndexOf(strEnd);

                if (endIndex != -1)
                {
                    if (replaceSearchCharacters)
                    {
                        beginIndex = beginIndex - strBegin.Length;
                        endIndex = endIndex + strBegin.Length + strEnd.Length;
                    }
                    output = output.Remove(beginIndex, endIndex);
                    output = output.Insert(beginIndex, replaceString);

                    str = str.Remove(beginIndex, endIndex);
                    str = str.Insert(beginIndex, replaceString);
                }
            }

            return output;
        }

        public static long AsLong(this String str)
        {
            if (string.IsNullOrEmpty(str))
            {
                str = "0";
            }
            return long.Parse(str);
        }

        public static String RemoveTags(this String str, String tagName)
        {
            String input = str;

            input = input.ToLower();
            tagName = "<" + tagName.ToLower();

            int beginIndex = -1;
            while (input.IndexOf(tagName) != -1)
            {
                beginIndex = input.IndexOf(tagName);

                int endIndex = input.Substring(beginIndex + tagName.Length).IndexOf(">");
                if (endIndex != -1)
                {
                    str = str.Substring(0, beginIndex) + str.Substring(beginIndex + tagName.Length + endIndex + 1);
                    input = str.ToLower();
                }
            }

            return str;
        }

        public static StringBuilder IndentLines(this string input, int indentLevel = 1, string indentLevelString = "\t", bool trimInput = true)
        {
            StringBuilder result = new StringBuilder();
            string indentString = "";
            for (int i = 0; i < indentLevel; i++)
            {
                indentString += indentLevelString;
            }
            if (trimInput)
            {
                input = input.Trim();
            }
            string[] lines = input.Split('\n');
            foreach (string line in lines)
            {
                result.Append(string.Format("{0}{1}", indentString, line));
                result.Append("\n");
            }

            return result;
        }

        public static StringBuilder IndentLines(this StringBuilder input, int indentLevel = 1, string indentLevelString = "\t", bool trimInput = true)
        {
            return IndentLines(input.ToString(), indentLevel, indentLevelString, trimInput);
        }

        public static List<string> ConcatElements(this List<string> list1, List<string> list2, bool trimElements = true)
        {
            List<string> results = new List<string>();
            foreach (string e1 in list1)
            {
                string element1 = e1;
                foreach (string e2 in list2)
                {
                    string element2 = e2;
                    if (trimElements)
                    {
                        element1 = element1.Trim();
                        element2 = element2.Trim();
                    }
                    results.Add(string.Format("{0}{1}", element1, element2));
                }
            }

            return results;
        }

        public static StringBuilder RemoveMatchingLines(this StringBuilder input, string regexPattern, bool ignoreCase)
        {
            return RemoveMatchingLines(input.ToString(), regexPattern, ignoreCase);
        }

        public static StringBuilder RemoveMatchingLines(this string input, string regexPattern, bool ignoreCase)
        {
            StringBuilder result = new StringBuilder();

            string[] lines = input.Split('\n');
            foreach (string line in lines)
            {
                RegexOptions option = ignoreCase ? RegexOptions.IgnoreCase : RegexOptions.None;
                Match match = Regex.Match(line, regexPattern, option);

                if (!match.Success)
                {
                    result.Append(line);
                    result.Append("\n");
                }
            }

            return result;
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts after the specified start string.
        /// </summary>
        /// <param name="str">the string instance</param>
        /// <param name="startString">the string to start substring after</param>
        /// <param name="caseSensitive">telling whether or not the search for the start string should be case sensitive</param>
        /// <returns></returns>
        public static string Substring(this string str, string startString, bool caseSensitive = false)
        {
            String output = str;
            if (!caseSensitive)
            {
                str = str.ToLower();
                startString = startString.ToLower();
            }

            int beginIndex = str.IndexOf(startString);
            if (beginIndex != -1)
            {
                beginIndex = beginIndex + startString.Length;
                output = output.Substring(beginIndex);
            }

            return output;
        }

        /// <summary>
        /// Retrieves a substring from this instance.
        /// The substring starts after first occurence of the specified start string and ends before the
        /// first occurence of the specified end occuring after the specificed start string.
        /// </summary>
        /// <param name="str">the string instance</param>
        /// <param name="startString">the string to start substring after</param>
        /// <param name="endString">the string to end substring before</param>
        /// <param name="caseSensitive">telling whether or not the search for the start string should be case sensitive</param>
        /// <returns></returns>
        public static string Substring(this string str, string startString, string endString, bool caseSensitive = false)
        {
            return str.GetStringBetween(startString, endString, caseSensitive);
        }

        public static List<string> Substrings(this string str, string startString, string endString, bool caseSensitive = false)
        {
            return str.GetListOfStringBetween(startString, endString, caseSensitive);
        }
    }
}
