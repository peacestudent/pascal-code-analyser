using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        string[] keywords = { "procedure", "Sender", "var", "extended", "rec", "integer", "begin", "end", "if", "else", "and", "then", "ShowMessage", "exit", "Reset", "StrTofloat", "Text", "while", "not", "EoF", "IntToStr", "do" };
        string[] separators = { "(", ")", ".", ",", ":", ";", "'", "<", "+", "=", ":=" };

        public string DoWork(string textString)
        {
            string result = RemoveReturns(textString);
            result = CheckChar(result);
            return result;

        }

        public string RemoveReturns(string text)
        {
            string myString = text.Replace("\n", " ");
            return myString;
        }

        private string CheckChar(string myString)
        {
            //compare char to predefined array
            string tempString = null;
            for (int i = 0; i < myString.Length; i++)
			{
                
                tempString = tempString + myString[i];
                foreach (var item in keywords)
                {
                    if (tempString == item)
                    {
                        
                        break;
                    }
                }
			}
            return tempString;
        }


        //public List<char> CharCollection { get; set; }
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
    end
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
