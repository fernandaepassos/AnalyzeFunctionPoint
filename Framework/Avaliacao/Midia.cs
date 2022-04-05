using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class Midia : ClassGenericAvaliacao
    {
        // Fields
        private string _DescMidia;
        private int _IdFilial;
        private int _IdMidia;
        private int _IdUltimoUsuario;
        private string _UltimaAtualizacao;

        // Methods
        public DataSet ListaMidia(int intIdFilial)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                if (intIdFilial <= 0)
                {
                    return null;
                }

                string strSql = " select  Midia.IdMidia, Midia.IdFilial, Midia.DescMidia, ";
                strSql += " convert(Varchar,Midia.UltimaAtualizacao,103)+' '+convert(Varchar,Midia.UltimaAtualizacao,108) as UltimaAtualizacao, ";
                strSql += " Usuario.Login as DescUltimoUsuario, Filial.RazaoSocial as Filial ";
                strSql += " from Midia left join Usuario on Usuario.IdUsuario = Midia.IdUltimoUsuario ";
                strSql += " left join filial on Filial.IdFilial = Midia.IdFilial ";
                strSql += " where Midia.IdFilial = " + intIdFilial + "  ";

                set = AcessoBD.ObterDataSet(strSql);

                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdMidia", typeof(int));
                    table.Columns.Add("DescMidia", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdMidia"].ToString().Trim()), set.Tables[0].Rows[i]["DescMidia"].ToString().Trim() });
                    }
                    set2.Tables.Add(table);
                    return set2;
                }
                set3 = set;
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
            }
            return set3;
        }

        public DataSet ListagemMidia(int intIdFilial)
        {
            try
            {
                if (intIdFilial <= 0) return null;

                string strSql = " select  Midia.IdMidia, Midia.IdFilial, Midia.DescMidia, ";
                strSql += " convert(Varchar,Midia.UltimaAtualizacao,103)+' '+convert(Varchar,Midia.UltimaAtualizacao,108) as UltimaAtualizacao, ";
                strSql += " Usuario.Login as DescUltimoUsuario, Filial.RazaoSocial as Filial ";
                strSql += " from Midia left join Usuario on Usuario.IdUsuario = Midia.IdUltimoUsuario ";
                strSql += " left join filial on Filial.IdFilial = Midia.IdFilial ";
                strSql += " where Midia.IdFilial = " + intIdFilial + "  ";

                 return  AcessoBD.ObterDataSet(strSql);

            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string DescMidia
        {
            get
            {
                return this._DescMidia;
            }
            set
            {
                this._DescMidia = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdFilial
        {
            get
            {
                return this._IdFilial;
            }
            set
            {
                this._IdFilial = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdMidia
        {
            get
            {
                return this._IdMidia;
            }
            set
            {
                this._IdMidia = value;
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
    }
}
