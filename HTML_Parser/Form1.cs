using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTML_Parser.Core;
using HTML_Parser.Core.Habr;

namespace HTML_Parser
{
    public partial class FormMain : Form
    {

        ParserWorker<string[]> parser;

        public FormMain()
        {
            InitializeComponent();
            parser = new ParserWorker<string[]>(
                     new HabrParser());
            parser.OnCompleted += Parse_OnCompleted;
            parser.OnNewData += Parse_OnNewData;
        }

        private void Parse_OnNewData(object arg1, string[] arg2)
        {
            ListTitles.Items.AddRange(arg2);   
        } 

        private void Parse_OnCompleted(object obj)
        {
            MessageBox.Show("All works done");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            parser.Settings = new HabrSettings((int)NumericStart.Value, (int)NumericEnd.Value);
            parser.Start();

        }

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }
    }
}
