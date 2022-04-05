using System.Data;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace Framework.Util
{
    public class Cls_HTML
    {
        // Methods
        public DataTable ReadHtmlTable(string tableHtml)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Data", typeof(DateTime));
            table.Columns.Add("Descricao", typeof(string));
            MatchCollection matchs = Regex.Matches(tableHtml, "<TR.*?>(.*?)</TR>");
            foreach (Match match in matchs)
            {
                if (match.Success)
                {
                    foreach (Capture capture in match.Captures)
                    {
                        string str = capture.Value;
                        MatchCollection matchs2 = Regex.Matches(tableHtml, "<TD.*?>(.*?)</TD>");
                        List<string> list = new List<string>();
                        foreach (Match match2 in matchs2)
                        {
                            if (match.Success)
                            {
                                foreach (Capture capture2 in match.Captures)
                                {
                                    list.Add(capture2.Value);
                                }
                            }
                        }
                        table.Rows.Add(new object[] { list[0], list[2] });
                    }
                }
            }
            return table;
        }
    }
}