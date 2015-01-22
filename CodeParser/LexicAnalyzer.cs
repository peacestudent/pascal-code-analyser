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
        string[] keywords = { "procedure", "Sender", "var", "extended", "rec", "integer", "begin", "end", "if", "else", "and", "then", "ShowMessage", "exit", "Reset", "StrTofloat", "Text", "while", "while not", "EoF", "IntToStr", "do" };
        //string[] keywordAction = {" ([A-Z]|[0-9])\w+\.([A-Z]|[0-9])\w+", };
        string[] regxForIdent = { @" ([A-Z]|[0-9])\w+\.([A-Z]|[0-9])\w+|\w+:" };
        public List<string> identifiers = new List<string>();
        public List<string> literals = new List<string>();


       




        public string DoWork(string textString)
        {
            string result = RemoveReturns(textString);

            SyntaxAnalyzer syntax = new SyntaxAnalyzer();
            syntax.BeginEndCount(textString);
            syntax.IfThenCount(textString);

            return RgxMatching(result);


        }

        public string RemoveReturns(string text)
        {
            string myString = text.Replace("\n", " ");
            return myString;
        }

        private string CheckChar(string myString)
        {
            //compare char to predefined array
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

                RgxMatching(myString);
                //check if match regex
                //String rgx = (@" ([A-Z]|[0-9])\w+\.([A-Z]|[0-9])\w+"); //name of procedure
                //MatchCollection coll = Regex.Matches(myString, rgx);
                //String result = coll[0].Value;
                //identifiers.Add(result);
                //myString = myString.Substring(result.Length);

                //rgx = (@"\(([A-Z]+\w+: *[A-Z]+\w+)\)"); //procedure signature in ()

            }
            return myString;

        }


        public string RgxMatching(string myString)
        {
            List<string> rgx = new List<string>();
            rgx.Add("procedure (([A-Z]|[0-9])\\w+\\.([A-Z]|[0-9])\\w+)");  //procedure name
            rgx.Add("\\(([A-Z]+\\w+: *[A-Z]+\\w+)\\)");         //procedure signature in ()
            rgx.Add("");

            string result = null;
            foreach (var item in rgx)
	        {
                MatchCollection coll = Regex.Matches(myString, item);
                result = coll[0].Groups[1].Value;
                identifiers.Add(result);
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
