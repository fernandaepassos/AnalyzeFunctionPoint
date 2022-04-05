using System.Text;
using System.IO;
using System.Data;
using System;

namespace Framework.Util
{
    public class Excel
    {
        // Methods
        public static void ConverterEmExcel(DataSet dsInput, string filename)
        {
            string format = getXMLWorkbookTemplate();
            string str2 = "<Worksheet ss:Name=\"Result\">";
            str2 = str2 + "<Table>";
            foreach (DataTable table in dsInput.Tables)
            {
                str2 = str2 + GetExcelTableXml(table, true);
            }
            str2 = str2 + "</Table>" + "</Worksheet>";
            string str3 = string.Format(format, str2);
            try
            {
                File.Delete(filename);
                StreamWriter writer = new StreamWriter(filename);
                writer.Write(str3);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                writer = null;
            }
            catch (Exception)
            {
            }
        }

        private static string getCellXml(Type type, object cellData, bool hasBorder)
        {
            object obj2 = (cellData is DBNull) ? "" : cellData;
            string str = "";
            if (hasBorder)
            {
                str = " ss:StyleID=\"s60\"";
            }
            if (((type.Name.Contains("Int") || type.Name.Contains("Double")) || type.Name.Contains("Decimal")) || type.Name.Contains("decimal"))
            {
                return string.Format("<Cell" + str + "><Data ss:Type=\"Number\">{0}</Data></Cell>", obj2);
            }
            if (type.Name.Contains("DateTime") && (obj2.ToString() != string.Empty))
            {
                return string.Format("<Cell ss:StyleID=\"s63\"><Data ss:Type=\"DateTime\">{0}</Data></Cell>", Convert.ToDateTime(obj2).ToString("g"));
            }
            decimal result = 0M;
            if (decimal.TryParse(cellData.ToString(), out result))
            {
                return string.Format("<Cell" + str + "><Data ss:Type=\"Number\">{0}</Data></Cell>", obj2);
            }
            return string.Format("<Cell" + str + "><Data ss:Type=\"String\">{0}</Data></Cell>", replaceXmlChar(obj2.ToString()));
        }

        public static string GetExcelTableXml(DataTable dt, bool hasBorder)
        {
            string str = "";
            str = "<Row>";
            foreach (DataColumn column in dt.Columns)
            {
                str = str + string.Format("<Cell ss:StyleID=\"s62\"><Data ss:Type=\"String\">{0}</Data></Cell>", replaceXmlChar(column.ColumnName));
            }
            str = str + "</Row>";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                str = str + "<Row>";
                foreach (DataColumn column in dt.Columns)
                {
                    str = str + getCellXml(column.DataType, dt.Rows[i][column.ColumnName], hasBorder);
                }
                str = str + "</Row>";
            }
            return str;
        }

        private static string getXMLWorkbookTemplate()
        {
            StringBuilder builder = new StringBuilder(0x332);
            builder.AppendFormat("<?xml version=\"1.0\"?>{0}", Environment.NewLine);
            builder.AppendFormat("<?mso-application progid=\"Excel.Sheet\"?>{0}", Environment.NewLine);
            builder.AppendFormat("<Workbook xmlns=\"urn:schemas-microsoft-com:office:spreadsheet\"{0}", Environment.NewLine);
            builder.AppendFormat(" xmlns:o=\"urn:schemas-microsoft-com:office:office\"{0}", Environment.NewLine);
            builder.AppendFormat(" xmlns:x=\"urn:schemas-microsoft-com:office:excel\"{0}", Environment.NewLine);
            builder.AppendFormat(" xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\"{0}", Environment.NewLine);
            builder.AppendFormat(" xmlns:html=\"http://www.w3.org/TR/REC-html40\">{0}", Environment.NewLine);
            builder.AppendFormat(" <ss:Styles>{0}", Environment.NewLine);
            builder.AppendFormat("  <ss:Style ss:ID=\"Default\" ss:Name=\"Normal\">{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Alignment ss:Vertical=\"Bottom\"/>{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\"/>{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Interior/>{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:NumberFormat/>{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Protection/>{0}", Environment.NewLine);
            builder.AppendFormat("  </ss:Style>{0}", Environment.NewLine);
            builder.AppendFormat("  <ss:Style ss:ID=\"s62\">{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Borders>{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" />{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" />{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" />{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" />{0}", Environment.NewLine);
            builder.AppendFormat("   </ss:Borders>{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Font ss:FontName=\"Calibri\" x:Family=\"Swiss\" ss:Size=\"11\" ss:Color=\"#000000\"{0}", Environment.NewLine);
            builder.AppendFormat("    ss:Bold=\"1\"/>{0}", Environment.NewLine);
            builder.AppendFormat("  </ss:Style>{0}", Environment.NewLine);
            builder.AppendFormat("  <ss:Style ss:ID=\"s63\">{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:NumberFormat ss:Format=\"Short Date\"/>{0}", Environment.NewLine);
            builder.AppendFormat("  </ss:Style>{0}", Environment.NewLine);
            builder.AppendFormat("  <ss:Style ss:ID=\"s60\">{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Alignment ss:Vertical=\"Bottom\"/>{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Borders>{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Border ss:Position=\"Bottom\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" />{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Border ss:Position=\"Top\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" />{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Border ss:Position=\"Left\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" />{0}", Environment.NewLine);
            builder.AppendFormat("   <ss:Border ss:Position=\"Right\" ss:LineStyle=\"Continuous\" ss:Weight=\"1\" />{0}", Environment.NewLine);
            builder.AppendFormat("   </ss:Borders>{0}", Environment.NewLine);
            builder.AppendFormat("  </ss:Style>{0}", Environment.NewLine);
            builder.AppendFormat(" </ss:Styles>{0}", Environment.NewLine);
            builder.Append(@"{0}</Workbook>");
            return builder.ToString();
        }

        private static string replaceXmlChar(string input)
        {
            input = input.Replace("&", "&amp");
            input = input.Replace("<", "&lt;");
            input = input.Replace(">", "&gt;");
            input = input.Replace("\"", "&quot;");
            input = input.Replace("'", "&apos;");
            return input;
        }
    }


}
 
