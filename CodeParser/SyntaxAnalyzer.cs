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

        
        public string CheckOpenClosing (string myString)
        {
            string result = "OK";
            if (!BeginEndCount(myString))
            {
                result = "Begin - End count doesn't match";
            }
            else if (!IfThenCount(myString))
            {
                result = "IF - THEN count doesn't match";
            }
            else if (!BracketCount(myString))
            {
                result = "Open and closing bracket count doesn't match";
            }
            return result;
        }
        
        public bool BeginEndCount(string myString)
        {
            string rgxBegin = "begin";
            string rgxEnd = " end;";
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

        public bool BracketCount (string myString)
        {
            string rgxOpenBr = "\\(";
            string rgxClosingBr = "\\)";
            MatchCollection OpenBrColl = Regex.Matches(myString, rgxOpenBr);
            MatchCollection ClosingBrColl = Regex.Matches(myString, rgxClosingBr);

            if (OpenBrColl.Count == ClosingBrColl.Count)
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

        public string ProcedureCheck(string myString)
        {
            string rgxProc = "";
            MatchCollection collIfThen = Regex.Matches(myString, rgxProc);
            string result = null;
            return result;
        }

    }
}
