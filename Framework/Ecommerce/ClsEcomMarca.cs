using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Framework.Reflection.Rotinas;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;


namespace Framework.Ecommerce
{
    public class ClsEcomMarca : ClassGenericEcommerce
    {
        // Fields
        private int _IdEmpresa;
        private int _IdMarca;
        private int _IdUltimoUsuario;
        private string _Marca;
        private string _UltimaAtualizacao;

        // Methods
        public DataSet ListaMarca(string strIdEmpresa)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (strIdEmpresa.Trim() == "")
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" SELECT IDMARCA , MARCA                 , 'http://www.sisclick.com.br/ecommerce/Files/Anexos/'+ substring(SigeArquivo.Arquivo,CHARINDEX('anexos',Arquivo)+7,len(Arquivo)) as Arquivo                FROM ECOMMARCA                 Left Join SigeArquivo on SigeArquivo.IdArquivo in (select IdArquivo From SigeArquivoVinculo Where NomeTabela = 'ECOMMARCA' and IdRegistroTabela = ECOMMARCA.IDMARCA )                 WHERE ECOMMARCA.IdEmpresa = " + strIdEmpresa + " ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
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
                if (set != null)
                {
                    set.Dispose();
                }
            }
            return set2;
        }

        public DataSet ListagemDeMarca(string strIdEmpresa)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                if (strIdEmpresa == null) return null;
                if(strIdEmpresa == "") return null;

                string str = " select IdMarca, Marca From EcomMarca where IdEmpresa = "+ strIdEmpresa +" order by Marca asc ";
                
                set = AcessoBD.ObterDataSet(str);
                
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdMarca", typeof(int));
                    table.Columns.Add("Marca", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdMarca"].ToString().Trim()), set.Tables[0].Rows[i]["Marca"].ToString().Trim() });
                    }
                    set2.Tables.Add(table);
                    return set2;
                }
                set3 = null;
            }
            catch (Exception exception)
            {
                throw exception;
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
        public int IdEmpresa
        {
            get
            {
                return this._IdEmpresa;
            }
            set
            {
                this._IdEmpresa = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
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

        [AtributoBancoDados(AtributoBD = false)]
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

        [AtributoBancoDados(AtributoBD = true)]
        public string Marca
        {
            get
            {
                return this._Marca;
            }
            set
            {
                this._Marca = value;
            }
        }

        [AtributoBancoDados(AtributoBD = false)]
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
