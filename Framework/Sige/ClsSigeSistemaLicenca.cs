using System.Data;
using System;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;


namespace Framework.Sige
{
    public class ClsSigeSistemaLicenca : ClassGenericSige
    {
        // Fields
        private string _Beneficios;
        private int _IdSistema;
        private int _IdSistemaLicenca;
        private int _IdUltimoUsuario;
        private string _Nome;
        private string _UltimaAtualizacao;
        private double _ValorMensal;

        // Methods
        public static DataSet GetLicenca(string strIdSistema)
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
                set = AcessoBD.ObterDataSet(" select IdSistemaLicenca, SigeSistemaLicenca.Nome + ' - Vlr. a.m: '+ convert(varchar,ValorMensal) as Valor                from SigeSistemaLicenca                 Where SigeSistemaLicenca.IdSistema = " + strIdSistema + " ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdSistemaLicenca", typeof(int));
                    table.Columns.Add("Valor", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdSistemaLicenca"].ToString().Trim()), set.Tables[0].Rows[i]["Valor"].ToString().Trim() });
                    }
                    set2.Tables.Add(table);
                    return set2;
                }
                table.Columns.Add("IdSistemaLicenca", typeof(int));
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
        [AtributoBancoDados(AtributoBD=true)]
        public string Beneficios
        {
            get
            {
                return this._Beneficios;
            }
            set
            {
                this._Beneficios = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
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

        [AtributoBancoDados(AtributoBD=true)]
        public int IdSistemaLicenca
        {
            get
            {
                return this._IdSistemaLicenca;
            }
            set
            {
                this._IdSistemaLicenca = value;
            }
        }

        [AtributoBancoDados(AtributoBD=false)]
        public int IdUltimoUsuario
        {
            get
            {
                return this._IdUltimoUsuario;
            }
            set
            {
                this._IdUltimoUsuario = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Nome
        {
            get
            {
                return this._Nome;
            }
            set
            {
                this._Nome = value;
            }
        }

        [AtributoBancoDados(AtributoBD=false)]
        public string UltimaAtualizacao
        {
            get
            {
                return this._UltimaAtualizacao;
            }
            set
            {
                this._UltimaAtualizacao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public double ValorMensal
        {
            get
            {
                return this._ValorMensal;
            }
            set
            {
                this._ValorMensal = value;
            }
        }
    }
}
