using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodeParser
{
    class SyntaxAnalyzer
    {

        public bool BeginEndCount(string myString)
        {
            string rgxBegin = "begin";
            string rgxEnd = "end;";
            MatchCollection beginColl = Regex.Matches(myString, rgxBegin);
            MatchCollection endColl = Regex.Matches(myString, rgxEnd);

            if (beginColl.Count == endColl.Count)
            {
                return true;
            }
            return false;
        }

        public bool IfThenCount(string myString)
        {
            string rgxIf = " if ";
            string rgxThen = " then ";

            MatchCollection collIf = Regex.Matches(myString, rgxIf);
            MatchCollection collThen = Regex.Matches(myString, rgxThen);
            if (collIf.Count == collThen.Count)
            {
                return true;
            }
            return false;
        }

        public bool IfThenAnalyzer(string myString)
        {
            string rgxIfThen = " if (.*) then ";
            MatchCollection collIfThen = Regex.Matches(myString, rgxIfThen);
            return false;
        }



    }
}
