using System;
using System.Data;
using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.AcessoBancoDados;

namespace Framework.Sige
{
    public class ClsSigeSistemaPadraoHora : ClassGenericSige
    {
        // Fields
        private int _IdSistema;
        private int _IdSistemaPadraoHora;
        private int _IdTipoPadraoHora;
        private double _ValorHora;

        // Methods
        public static DataSet GetPadraoHora(string strIdSistema)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                if (strIdSistema == null)
                {
                    return null;
                }
                if (strIdSistema.Trim() == "")
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" select IdSistemaPadraoHora, SigeTipo.NomeTipo + ' - Vlr. HH: '+ convert(varchar,ValorHora) as Valor                from SigeSistemaPadraoHora                 Left Join SigeTipo on SigeTipo.IdTipo = SigeSistemaPadraoHora.IdTipoPadraoHora Where SigeSistemaPadraoHora.IdSistema = " + strIdSistema + " ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdSistemaPadraoHora", typeof(int));
                    table.Columns.Add("Valor", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdSistemaPadraoHora"].ToString().Trim()), set.Tables[0].Rows[i]["Valor"].ToString().Trim() });
                    }
                    set2.Tables.Add(table);
                    return set2;
                }
                table.Columns.Add("IdSistemaPadraoHora", typeof(int));
                table.Columns.Add("Valor", typeof(string));
                table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                set2.Tables.Add(table);
                set3 = set2;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
                if (table != null)
                {
                    table.Dispose();
                }
            }
            return set3;
        }

        // Properties
        [AtributoBancoDados(AtributoBD = true)]
        public int IdSistema
        {
            get
            {
                return this._IdSistema;
            }
            set
            {
                this._IdSistema = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdSistemaPadraoHora
        {
            get
            {
                return this._IdSistemaPadraoHora;
            }
            set
            {
                this._IdSistemaPadraoHora = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdTipoPadraoHora
        {
            get
            {
                return this._IdTipoPadraoHora;
            }
            set
            {
                this._IdTipoPadraoHora = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public double ValorHora
        {
            get
            {
                return this._ValorHora;
            }
            set
            {
                this._ValorHora = value;
            }
        }
    }
}
