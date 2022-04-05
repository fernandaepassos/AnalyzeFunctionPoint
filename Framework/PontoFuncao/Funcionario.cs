using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.AcessoBancoDados;
using System;
using System.Data;

namespace Framework.PontoFuncao
{
    public class Funcionario : ClassGenericPontoFuncao
    {
        private int _IdFuncionario;

        [AtributoBancoDados(AtributoBD = true)]
        public int IdFuncionario
        {
            get
            {
                return this._IdFuncionario;
            }
            set
            {
                this._IdFuncionario = value;
            }
        }

        private int _IdPessoa;

        [AtributoBancoDados(AtributoBD = true)]
        public int IdPessoa
        {
            get
            {
                return this._IdPessoa;
            }
            set
            {
                this._IdPessoa = value;
            }
        }

        public DataSet ListaFuncionario()
        {
            DataSet set2 = new DataSet ();
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            try
            {
                string strSql = "SELECT ";
                strSql += " PESSOA.IDPESSOA ";
                strSql += " , PESSOA.NOME ";
                strSql += " , PESSOA.NUMREGISTRO ";
                strSql += " FROM PESSOA ";
                strSql += " where IDPESSOA in (select IDPESSOA from FUNCIONARIO)";

                set = AcessoBD.ObterDataSet(strSql);
              
      
                if (set != null && set.Tables.Count > 0 && set.Tables[0].Rows.Count > 0)
                {
                    table.Columns.Add("IDPESSOA", typeof(int));
                    table.Columns.Add("NOME", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IDPESSOA"].ToString().Trim()), set.Tables[0].Rows[i]["NOME"].ToString().Trim() });
                    }
                    set2.Tables.Add(table);
                    return set2;
                } return null;
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
            
        }


    }
}
