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

        public string ParseLines(List<string> lines)
        {
            List<string> textLines = lines;
            var result = "";

            foreach (var line in textLines)
            {
                
            }

            return result;
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
