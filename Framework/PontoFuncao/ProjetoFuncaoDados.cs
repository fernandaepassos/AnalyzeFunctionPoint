using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.AcessoBancoDados;
using System;
using System.Data;

namespace Framework.PontoFuncao
{
    public class ProjetoFuncaoDados : ClassGenericPontoFuncao
    {
        private int _IdProjetoFuncaoDados;

        [AtributoBancoDados(AtributoBD = true)]
        public int IdProjetoFuncaoDados
        {
            get
            {
                return this._IdProjetoFuncaoDados;
            }
            set
            {
                this._IdProjetoFuncaoDados = value;
            }
        }

        private int _IdProjeto;

        [AtributoBancoDados(AtributoBD = true)]
        public int IdProjeto
        {
            get
            {
                return this._IdProjeto;
            }
            set
            {
                this._IdProjeto = value;
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

        private int _IdTipo;

        [AtributoBancoDados(AtributoBD = true)]
        public int IdTipo
        {
            get
            {
                return this._IdTipo;
            }
            set
            {
                this._IdTipo = value;
            }
        }

        private int _NumTr;

        [AtributoBancoDados(AtributoBD = true)]
        public int NumTr
        {
            get
            {
                return this._NumTr;
            }
            set
            {
                this._NumTr = value;
            }
        }

        private int _NumTd;

        [AtributoBancoDados(AtributoBD = true)]
        public int NumTd
        {
            get
            {
                return this._NumTd;
            }
            set
            {
                this._NumTd = value;
            }
        }

        private int _Prioridade;

        [AtributoBancoDados(AtributoBD = true)]
        public int Prioridade
        {
            get
            {
                return this._Prioridade;
            }
            set
            {
                this._Prioridade = value;
            }
        }

        private int _QtdPontoFuncao;
        

        [AtributoBancoDados(AtributoBD = true)]
        public int QtdPontoFuncao
        {
            get
            {
                return this._QtdPontoFuncao;
            }
            set
            {
                this._QtdPontoFuncao = value;
            }
        }

        public DataSet ListaFuncaoDados(string strIdProjeto)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (string.IsNullOrEmpty(strIdProjeto)) return null;

                string strSql = " SELECT IDPROJETOFUNCAODADOS ";
                strSql += " , IDPROJETO ";
                strSql += " , NOME ";
                strSql += " , IDTIPO ";
                strSql += " , (SELECT NOME FROM TIPO WHERE IDTIPO = PROJETOFUNCAODADOS.IDTIPO) DSTIPO ";
                strSql += " , NUMTR ";
                strSql += " , NUMTD ";
                strSql += " , PRIORIDADE ";
                strSql += " , (SELECT NOME FROM TIPO WHERE IDTIPO = ProjetoFuncaoDados.PRIORIDADE AND IDTIPO IN (SELECT IDTIPO FROM TIPOTABELA WHERE TABELA = 'ProjetoFuncaoDados' AND CAMPO = 'PRIORIDADE')) DSPRIORIDADE  ";
                strSql += " , QTDPONTOFUNCAO ";
                strSql += " FROM PROJETOFUNCAODADOS ";
                strSql += " WHERE IDPROJETO = " + strIdProjeto + " ";

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
    }
}
