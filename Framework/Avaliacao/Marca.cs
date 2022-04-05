using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class Marca : ClassGenericAvaliacao
    {
        // Fields
        private string _DescMarca;
        private int _IdFilial;
        private int _IdMarca;
        private int _IdUltimoUsuario;
        private string _UltimaAtualizacao;

        // Methods
        public DataSet ListaMarca(int intIdFilial)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (intIdFilial <= 0)
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet("select Marca.IdMarca                , Marca.DescMarca                , Marca.IdFilial                , convert(Varchar,Marca.UltimaAtualizacao,103)+' '+convert(Varchar,Marca.UltimaAtualizacao,108) as UltimaAtualizacao                , Usuario.Login as DescUltimoUsuario                , Filial.RazaoSocial as Filial                from Marca                left join Usuario on Usuario.IdUsuario = Marca.IdUltimoUsuario                left join Filial on Filial.IdFilial = Marca.IdFilial                where Marca.IdFilial = " + intIdFilial + " ");
                set2 = set;
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
            return set2;
        }

        public DataSet ListaMarcaDropDown()
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                set = AcessoBD.ObterDataSet("select IdMarca, DescMarca from Marca order by DescMarca");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdMarca", typeof(int));
                    table.Columns.Add("DescMarca", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdMarca"].ToString().Trim()), set.Tables[0].Rows[i]["DescMarca"].ToString().Trim() });
                    }
                    set2.Tables.Add(table);
                    return set2;
                }
                set3 = null;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set3;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string DescMarca
        {
            get
            {
                return this._DescMarca;
            }
            set
            {
                this._DescMarca = value;
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
        public int IdMarca
        {
            get
            {
                return this._IdMarca;
            }
            set
            {
                this._IdMarca = value;
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
