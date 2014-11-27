﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeParser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] keywords = { "procedure", "Sender", "var", "extended", "rec", "integer", "begin", "end", "if", "else", "and", "then", "ShowMessage", "exit", "Reset", "StrTofloat", "Text", "while", "not", "EoF", "IntToStr", "do" };
        string[] separators = { "(", ")", ".", ",", ":", ";", "'", "<", "+", "=", ":=" };


        private void button1_Click(object sender, EventArgs e)
        {
            LexicAnalyzer lex = new LexicAnalyzer();
            dataGridView1.Columns.Add("keywords", "Keywords");
            dataGridView1.Columns.Add("seperators", "Separators");
            int j = 0;
            for (int i = 0; i < keywords.Length; i++)
            { 
                if (j < separators.Length)
                {
                    dataGridView1.Rows.Add(keywords[i], separators[j]);
                    j++;
                }
                else
                dataGridView1.Rows.Add(keywords[i],"");
            }
            var result = lex.ParseLines(this.richTextBox1.Lines.ToList());
        }
    }
}
