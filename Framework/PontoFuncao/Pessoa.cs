using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.AcessoBancoDados;
using System;
using System.Data;

namespace Framework.PontoFuncao
{
    public class Pessoa : ClassGenericPontoFuncao
    {
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

        private string _Nome;

        [AtributoBancoDados(AtributoBD = true)]
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

        private string _NumRegistro;
        
        [AtributoBancoDados(AtributoBD = true)]
        public string NumRegistro
        {
            get
            {
                return this._NumRegistro;
            }
            set
            {
                this._NumRegistro = value;
            }
        }

        public DataSet ListaFuncionario()
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string strSql = "SELECT ";
                strSql += " PESSOA.IDPESSOA ";
                strSql += " , PESSOA.NOME ";
                strSql += " , PESSOA.NUMREGISTRO ";
                strSql += " FROM PESSOA ";
                strSql += " WHERE IDPESSOA IN (SELECT IDPESSOA FROM FUNCIONARIO) ";

                set = AcessoBD.ObterDataSet(strSql);
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

        public bool ValidaNumRegistro(int intIdPessoa, string strNumRegistro)
        {
            try
            {
                string strSql = "select nome ";
                strSql += " from pessoa ";
                strSql += " where pessoa.NUMREGISTRO = " + strNumRegistro  + " ";
                strSql += " and PESSOA.IDPESSOA <> " + intIdPessoa  + "";

                object objPessoa = AcessoBD.ExecutarComandoSqlEscalar(strSql);

                if (objPessoa != null && !string.IsNullOrEmpty(objPessoa.ToString().Trim()))
                    return false;
                else return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
