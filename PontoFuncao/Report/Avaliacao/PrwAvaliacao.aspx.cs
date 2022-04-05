using System;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Web.UI;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Diagnostics;
using System.IO;
public partial class Report_Avaliacao_PrwAvaliacao : System.Web.UI.Page
{
    //// Fields
    //protected HtmlForm form1;
    //private int m_currentPageIndex;
    //private IList<Stream> m_streams;
    //protected ReportViewer ReportViewer1;
    //protected ScriptManager ScriptManager1;

    private int m_currentPageIndex;
    private IList<Stream> m_streams;

    // Methods
    private void CarregaReport(DataSet dsPopuladoPreview)
    {
        this.ReportViewer1.ProcessingMode = 0;
        LocalReport report = this.ReportViewer1.LocalReport;
        report.ReportPath = (base.Server.MapPath("Avaliacao.rdlc"));
        report.EnableExternalImages = (true);
        DataSet set = new DataSet("DsRptAvaliacao");
        set = dsPopuladoPreview;
        report.DataSources.Clear();
        ReportDataSource item = new ReportDataSource("DsRptAvaliacao", set.Tables[0]);
        this.ReportViewer1.LocalReport.DataSources.Add(item);
        byte[] buffer = null;
        if (this.Session["ModoSaida"] != null)
        {
            string str;
            string str2;
            string str3;
            Warning[] warningArray;
            string[] strArray;
            switch (Convert.ToInt32(this.Session["ModoSaida"]))
            {
                case 1:
                    buffer = ReportViewer1.LocalReport.Render("EXCEL", null, out str, out str2, out str3, out strArray, out warningArray);
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ContentType = str;
                    HttpContext.Current.Response.AddHeader("content-disposition", "inline; filename=ExportedReport." + str3);
                    HttpContext.Current.Response.BinaryWrite(buffer);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();
                    goto Label_023D;

                case 2:
                    this.Export(this.ReportViewer1.LocalReport);
                    this.m_currentPageIndex = 0;
                    this.Print();
                    goto Label_023D;

                case 3:
                    buffer = ReportViewer1.LocalReport.Render("PDF", null, out str, out str2, out str3, out strArray, out warningArray);
                    HttpContext.Current.Response.Buffer = true;
                    HttpContext.Current.Response.Clear();
                    HttpContext.Current.Response.ContentType = str;
                    HttpContext.Current.Response.AddHeader("content-disposition", "inline; filename=ExportedReport." + str3);
                    HttpContext.Current.Response.BinaryWrite(buffer);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.End();
                    goto Label_023D;
            }
            this.ReportViewer1.LocalReport.Refresh();
        }
    Label_023D:
        set.Dispose();
        dsPopuladoPreview.Dispose();
        if (this.m_streams != null)
        {
            foreach (Stream stream in this.m_streams)
            {
                stream.Close();
            }
            this.m_streams = null;
        }
    }

    private Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
    {
        Stream item = new FileStream(name + "." + fileNameExtension, FileMode.Create);
        this.m_streams.Add(item);
        return item;
    }

    private void Export(LocalReport report)
    {
        string deviceInfo =
          "<DeviceInfo>" +
          "  <OutputFormat>EMF</OutputFormat>" +
          "  <PageWidth>8.5in</PageWidth>" +
          "  <PageHeight>11in</PageHeight>" +
          "  <MarginTop>0.25in</MarginTop>" +
          "  <MarginLeft>0.25in</MarginLeft>" +
          "  <MarginRight>0.25in</MarginRight>" +
          "  <MarginBottom>0.25in</MarginBottom>" +
          "</DeviceInfo>";
        Warning[] warnings;
        m_streams = new List<Stream>();
        report.Render("Image", deviceInfo, CreateStream, out warnings);

        foreach (Stream stream in m_streams)
            stream.Position = 0;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Framework.Util.ClsUtil.GetVarGlobalStatic("IdUsuario"))) Response.Redirect("~/Login.aspx");

        if (!this.Page.IsPostBack)
        {
            if (this.Session["dsPopulado"] != null)
            {
                DataSet dsPopuladoPreview = (DataSet)this.Session["dsPopulado"];
                this.CarregaReport(dsPopuladoPreview);
            }
            else
            {
                base.ClientScript.RegisterStartupScript(typeof(Page), "mensagem", "<script>alert('Sua sessão expirou! Fa\x00e7a o login novamente.')</script>", false);
                //base.Response.Redirect("../../Login.aspx");
            }
        }
    }

    private void Print()
    {
        if ((this.m_streams != null) && (this.m_streams.Count != 0))
        {
            PrintDocument document = new PrintDocument();
            if (!document.PrinterSettings.IsValid)
            {
                string.Format("Não foi possivel encontrar a impressora \"{0}\".", "Microsoft XPS Document Writer");
            }
            else
            {
                document.PrintPage += new PrintPageEventHandler(this.PrintPage);
                document.Print();
            }
        }
    }

    private void PrintPage(object sender, PrintPageEventArgs ev)
    {
        Metafile image = new Metafile(this.m_streams[this.m_currentPageIndex]);
        ev.Graphics.DrawImage(image, 0, 0);
        this.m_currentPageIndex++;
        ev.HasMorePages = this.m_currentPageIndex < this.m_streams.Count;
    }




}