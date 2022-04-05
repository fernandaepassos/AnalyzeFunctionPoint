using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;


namespace Framework.Ecommerce
{
    public class ClsEcomCorreios
    {
        // Fields
        private double _AlturaCm;
        private string _AvisoDeRecebimento;
        private int _CepDestino;
        private int _CepOrigem;
        private double _ComprimentoCm;
        private double _LarguraCm;
        private string _MaoPropria;
        private double _PesoGrama;
        private string _TipoDeFrete;
        private string _Token;

        // Methods
        public DataSet GetDadosFrete(ClsEcomCorreios objEcomCorreios, out string strMensagem)
        {
            DataSet set2;
            strMensagem = "";
            DataSet set = new DataSet();
            try
            {
                if (!this.Validacao(out strMensagem, objEcomCorreios))
                {
                    return null;
                }
                string s = "&lt;?xml version='1.0' encoding='UTF-8'?><request><header><userId>*GUEST</userId><password>guest</password></header><body><command>searchJobs</command><parms><parm>100</parm><parm>Open</parm><parm></parm><parm></parm><parm></parm><parm></parm><parm></parm><parm></parm></parms></body></request>";
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(string.Concat(new object[] { "http://webservice.kinghost.net/web_frete.php?auth=", objEcomCorreios.Token, "&tipo=", objEcomCorreios.TipoDeFrete, "&formato=xml&cep_origem=", this.CepOrigem, "&cep_destino=", this.CepDestino, "&cm_altura=", this.AlturaCm, "&cm_largura=", this.LarguraCm, "&cm_comprimento=", this.ComprimentoCm, "&peso=", this.PesoGrama }));
                byte[] bytes = Encoding.ASCII.GetBytes(s);
                request.Method = "POST";
                request.ContentType = "text/xml;charset=utf-8";
                request.ContentLength = bytes.Length;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.Default);
                string str3 = reader.ReadToEnd();
                MemoryStream stream = new MemoryStream(Encoding.ASCII.GetBytes(str3));
                set.ReadXml(stream);
                stream.Close();
                reader.Close();
                response.Close();
                stream.Close();
                if ((set.Tables.Count > 0) && (set.Tables[0].Rows.Count > 0))
                {
                    return set;
                }
                set2 = null;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                set.Dispose();
            }
            return set2;
        }

        private bool Validacao(out string strMensagem, ClsEcomCorreios objEcomCorreios)
        {
            bool flag;
            strMensagem = "";
            try
            {
                double pesoGrama = objEcomCorreios.PesoGrama;
                if (objEcomCorreios.PesoGrama < 0.0)
                {
                    objEcomCorreios.PesoGrama = 0.0;
                }
                double comprimentoCm = objEcomCorreios.ComprimentoCm;
                if (objEcomCorreios.ComprimentoCm < 0.0)
                {
                    objEcomCorreios.ComprimentoCm = 0.0;
                }
                double larguraCm = objEcomCorreios.LarguraCm;
                if (objEcomCorreios.LarguraCm < 0.0)
                {
                    objEcomCorreios.LarguraCm = 0.0;
                }
                double alturaCm = objEcomCorreios.AlturaCm;
                if (objEcomCorreios.AlturaCm < 0.0)
                {
                    objEcomCorreios.AlturaCm = 0.0;
                }
                if ((objEcomCorreios.TipoDeFrete == null) || (objEcomCorreios.TipoDeFrete.Trim() == ""))
                {
                    strMensagem = "Informe o tipo de frete.";
                    return false;
                }
                if ((objEcomCorreios.Token == null) || (objEcomCorreios.Token.Trim() == ""))
                {
                    strMensagem = "Informe o toke de pesquisa.";
                    return false;
                }
                int cepOrigem = objEcomCorreios.CepOrigem;
                if (objEcomCorreios.CepOrigem <= 0)
                {
                    strMensagem = "Informe o CEP de origem.";
                    return false;
                }
                int cepDestino = objEcomCorreios.CepDestino;
                if (objEcomCorreios.CepDestino <= 0)
                {
                    strMensagem = "Informe o CEP de destino.";
                    return false;
                }
                if ((objEcomCorreios.MaoPropria == null) || (objEcomCorreios.MaoPropria.Trim() == ""))
                {
                    objEcomCorreios.MaoPropria = "1";
                }
                if ((objEcomCorreios.AvisoDeRecebimento == null) || (objEcomCorreios.AvisoDeRecebimento.Trim() == ""))
                {
                    objEcomCorreios.AvisoDeRecebimento = "1";
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return flag;
        }

        // Properties
        public double AlturaCm
        {
            get
            {
                return this._AlturaCm;
            }
            set
            {
                this._AlturaCm = value;
            }
        }

        public string AvisoDeRecebimento
        {
            get
            {
                return this._AvisoDeRecebimento;
            }
            set
            {
                this._AvisoDeRecebimento = value;
            }
        }

        public int CepDestino
        {
            get
            {
                return this._CepDestino;
            }
            set
            {
                this._CepDestino = value;
            }
        }

        public int CepOrigem
        {
            get
            {
                return this._CepOrigem;
            }
            set
            {
                this._CepOrigem = value;
            }
        }

        public double ComprimentoCm
        {
            get
            {
                return this._ComprimentoCm;
            }
            set
            {
                this._ComprimentoCm = value;
            }
        }

        public double LarguraCm
        {
            get
            {
                return this._LarguraCm;
            }
            set
            {
                this._LarguraCm = value;
            }
        }

        public string MaoPropria
        {
            get
            {
                return this._MaoPropria;
            }
            set
            {
                this._MaoPropria = value;
            }
        }

        public double PesoGrama
        {
            get
            {
                return this._PesoGrama;
            }
            set
            {
                this._PesoGrama = value;
            }
        }

        public string TipoDeFrete
        {
            get
            {
                return this._TipoDeFrete;
            }
            set
            {
                this._TipoDeFrete = value;
            }
        }

        public string Token
        {
            get
            {
                return this._Token;
            }
            set
            {
                this._Token = value;
            }
        }
    }
}
