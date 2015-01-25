using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeParser
{
    public class LexicAnalyzer
    {
        //public string[] ReadLines()
        //{
        //    for (int i = 0; i >= richTextBox1.Lines.Count; i++)
        //    {
        //        lines = richTextBox1.Lines[i];
        //    }
        //    return lines;
        //}

        string[] separators = { "(", ")", ".", ",", ":", ";", "'", "<", "+", "=", ":=" };
        string[] keywords = { "procedure", "Sender", "var", "extended", "rec", "integer", "begin", "end", "if", "else", "and", "then", "ShowMessage", "exit",
                                "Reset", "StrTofloat", "Text", "while", "while not", "EoF", "IntToStr", "do", "Read" };

        public List<string> identifiers = new List<string>();
        public List<string> literals = new List<string>();


       




        public string DoWork(string textString)
        {
            string myString = RemoveReturns(textString);
            string result = null;

            SyntaxAnalyzer syntax = new SyntaxAnalyzer();
            result = syntax.CheckOpenClosing(myString);
            syntax.IfThenAnalyzer(myString);

            RgxMatchLiterals(myString);
            RgxMatchIdentifiers(myString);

            return result;


        }

        public string RemoveReturns(string text)
        {
            string myString = text.Replace("\n", " ");
            return myString;
        }

        //compare char to keywords and separators and removes them from begining of string
        private string CheckChar(string myString)
        {
            //string tempString = null;
            while (myString != null)
            {
                //for (int i = 0; i < myString.Length; i++)
                //{

                //    tempString = tempString + myString[i];
                //    foreach (var item in keywords)
                //    {
                //        if (tempString == item)
                //        {
                //            //keywordAction[item]
                //        }
                //    }
                //}

                //removes keywords from begining of string
                foreach (var item in keywords)
                {
                    if (myString.Trim().StartsWith(item))
                    {
                        myString = myString.Substring(item.Length);
                    }
                }
                //removes separators from begining of string
                foreach (var item in separators)
                {
                    if (myString.Trim().StartsWith(item))
                    {
                        myString = myString.Substring(item.Length);
                    }
                }
            }
            return myString;

        }

        public bool CheckForKeywordsAndSeparators(string myString)
        {
            bool result = false; 
            foreach (var item in keywords)
            {
                if (myString.Contains(item))
                {
                    result = true;
                }
            }
            return result;
        }


        public string RgxMatchIdentifiers(string myString)
        {
            List<string> rgxIdentifiers = new List<string>();

            rgxIdentifiers.Add("(([A-Z]|[0-9])\\w+)\\."); //procedure name first part
            rgxIdentifiers.Add("\\.(([A-Z]|[0-9])\\w+)"); //procedure name second part
            rgxIdentifiers.Add("(\\w+):"); //variables ending with :
            rgxIdentifiers.Add("(\\w+\\))"); //text and numbers in brackets
            rgxIdentifiers.Add("(:\\w+)"); //text and numbers after :
            rgxIdentifiers.Add("(\\w+):="); //text and numbers before :=

            string result = null;
            foreach (var item in rgxIdentifiers)
	        {
                MatchCollection coll = Regex.Matches(myString, item);
                //myString = item.Replace(myString, " ");   //doesn't work
                foreach (var c in coll)
                {
                    result = c.ToString();
                    
                    //removes separatos at the begining
                    if (separators.Any(x => result.StartsWith(x)))
                    {
                        result = result.Substring(1);
                    }
                    //removes separators at the end
                    if (separators.Any(x => result.EndsWith(x)))
                    {
                        result = result.Remove(result.Length - 1);
                    }
                    //removes : from words ending with :=
                    if (result.EndsWith(":"))
                    {
                        result = result.Remove(result.Length - 1);
                    }

                    //bool resultEndsWith = separators.Any(x => result.EndsWith(x));

                    //does NOT add if already contains the same
                    if (!identifiers.Contains(result))
                    {
                        identifiers.Add(result);
                    }
                }
	        }
            return myString;
        }

        public string RgxMatchLiterals(string myString)
        {
            List<string> rgxLiterals = new List<string>();

            rgxLiterals.Add("'([^']*?)'"); //text between ''
            rgxLiterals.Add("[0-9]+;"); //numbers before ;

            string result = null;
            foreach (var item in rgxLiterals)
            {
                MatchCollection coll = Regex.Matches(myString, item);
                //myString = item.Replace(myString, " ");   //doesn't work
                foreach (var c in coll)
                {
                    result = c.ToString();
                    //removes ' at the begining
                    if (result.StartsWith("'"))
                    {
                        result = result.Substring(1);
                    }
                    //removes ' at the end
                    if (result.EndsWith("'") | result.EndsWith(";"))
                    {
                        result = result.Remove(result.Length - 1);
                    }
                    //does NOT add if already contains the same or is null or empty
                    if (!string.IsNullOrEmpty(result) && !literals.Contains(result))
                    {
                        literals.Add(result);
                    }
                }
            }
            return myString;
        }

    }


    
    /*
     * Code to analyze:
     
procedure TForm1.Button3Click(Sender: TObject);
var
    i:extended;
    R:rec;
    kol:integer;
begin
    if (CEdit1.Text='') and (Kedit2.Text='') then
    begin
        ShowMessage('Please enter data');
        exit
    end;
    else
        Reset(F);
    i:=StrTofloat(CEdit1.Text);
    kol:=0;
    while not EoF(F) do
    begin
        Read(F,R);
        if R.Price < i then
            kol:=kol+1;
    end;
    KEdit2.Text:=IntToStr(kol)
end;
     */
}
