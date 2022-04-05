using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.AcessoBancoDados;
using System;
using System.Data;

namespace Framework.PontoFuncao
{
    public class ProjetoContagem : ClassGenericPontoFuncao
    {
        private int _IdProjetoContagem;

        [AtributoBancoDados(AtributoBD = true)]
        public int IdProjetoContagem
        {
            get
            {
                return this._IdProjetoContagem;
            }
            set
            {
                this._IdProjetoContagem = value;
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

        private int _ComunicacaoDados;

        [AtributoBancoDados(AtributoBD = true)]
        public int ComunicacaoDados
        {
            get
            {
                return this._ComunicacaoDados;
            }
            set
            {
                this._ComunicacaoDados = value;
            }
        }

        private int _ProcessamentoDistribuido;

        [AtributoBancoDados(AtributoBD = true)]
        public int ProcessamentoDistribuido
        {
            get
            {
                return this._ProcessamentoDistribuido;
            }
            set
            {
                this._ProcessamentoDistribuido = value;
            }
        }

        private int _Performance;

        [AtributoBancoDados(AtributoBD = true)]
        public int Performance
        {
            get
            {
                return this._Performance;
            }
            set
            {
                this._Performance = value;
            }
        }

        private int _ConfigIintensaUsada;

        [AtributoBancoDados(AtributoBD = true)]
        public int ConfigIntensaUsada
        {
            get
            {
                return this._ConfigIintensaUsada;
            }
            set
            {
                this._ConfigIintensaUsada = value;
            }
        }

        private int _VolumeTransacao;

        [AtributoBancoDados(AtributoBD = true)]
        public int VolumeTransacao
        {
            get
            {
                return this._VolumeTransacao;
            }
            set
            {
                this._VolumeTransacao = value;
            }
        }

        private int _EntradaDadosOnline;
        

        [AtributoBancoDados(AtributoBD = true)]
        public int EntradaDadosOnline
        {
            get
            {
                return this._EntradaDadosOnline;
            }
            set
            {
                this._EntradaDadosOnline = value;
            }
        }

        private int _EficienciaUsuarioFinal;

        [AtributoBancoDados(AtributoBD = true)]
        public int EficienciaUsuarioFinal
        {
            get
            {
                return this._EficienciaUsuarioFinal;
            }
            set
            {
                this._EficienciaUsuarioFinal = value;
            }
        }

        private int _AtualizacaoOnline;

        [AtributoBancoDados(AtributoBD = true)]
        public int AtualizacaoOnline
        {
            get
            {
                return this._AtualizacaoOnline;
            }
            set
            {
                this._AtualizacaoOnline = value;
            }
        }

        private int _ProcessamentoComplexo;

        [AtributoBancoDados(AtributoBD = true)]
        public int ProcessamentoComplexo
        {
            get
            {
                return this._ProcessamentoComplexo;
            }
            set
            {
                this._ProcessamentoComplexo = value;
            }
        }

        private int _Reusabilidade;

        [AtributoBancoDados(AtributoBD = true)]
        public int Reusabilidade
        {
            get
            {
                return this._Reusabilidade;
            }
            set
            {
                this._Reusabilidade = value;
            }
        }

        private int _FacilidadeInstalacao;

        [AtributoBancoDados(AtributoBD = true)]
        public int FacilidadeInstalacao
        {
            get
            {
                return this._FacilidadeInstalacao;
            }
            set
            {
                this._FacilidadeInstalacao = value;
            }
        }

        private int _FacilidadeOperacao;

        [AtributoBancoDados(AtributoBD = true)]
        public int FacilidadeOperacao
        {
            get
            {
                return this._FacilidadeOperacao;
            }
            set
            {
                this._FacilidadeOperacao = value;
            }
        }

        private int _MultiplosLocais;

        [AtributoBancoDados(AtributoBD = true)]
        public int MultiplosLocais
        {
            get
            {
                return this._MultiplosLocais;
            }
            set
            {
                this._MultiplosLocais = value;
            }
        }

        private int _FacilidadeMudancao;

        [AtributoBancoDados(AtributoBD = true)]
        public int FacilidadeMudancao
        {
            get
            {
                return this._FacilidadeMudancao;
            }
            set
            {
                this._FacilidadeMudancao = value;
            }
        }

        private double _Soma;

        [AtributoBancoDados(AtributoBD = true)]
        public double Soma
        {
            get
            {
                return this._Soma;
            }
            set
            {
                this._Soma = value;
            }
        }

        private double _Vaf;

        [AtributoBancoDados(AtributoBD = true)]
        public double Vaf
        {
            get
            {
                return this._Vaf;
            }
            set
            {
                this._Vaf = value;
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
                strSql += " where pessoa.NUMREGISTRO = " + strNumRegistro + " ";
                strSql += " and PESSOA.IDPESSOA <> " + intIdPessoa + "";

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
