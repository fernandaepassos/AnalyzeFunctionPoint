using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.AcessoBancoDados;
using System;
using System.Data;

namespace Framework.PontoFuncao
{
    public class Projeto : ClassGenericPontoFuncao
    {
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

        private int _IdEquipe;

        [AtributoBancoDados(AtributoBD = true)]
        public int IdEquipe
        {
            get
            {
                return this._IdEquipe;
            }
            set
            {
                this._IdEquipe = value;
            }
        }

        private int _TamanhoFuncional;

        [AtributoBancoDados(AtributoBD = true)]
        public int TamanhoFuncional
        {
            get
            {
                return this._TamanhoFuncional;
            }
            set
            {
                this._TamanhoFuncional = value;
            }
        }

        private int _TamanhoFuncionalAjustado;

        [AtributoBancoDados(AtributoBD = true)]
        public int TamanhoFuncionalAjustado
        {
            get
            {
                return this._TamanhoFuncionalAjustado;
            }
            set
            {
                this._TamanhoFuncionalAjustado = value;
            }
        }

        private int _TempoHomemHora;

        [AtributoBancoDados(AtributoBD = true)]
        public int TempoHomemHora
        {
            get
            {
                return this._TempoHomemHora;
            }
            set
            {
                this._TempoHomemHora = value;
            }
        }

        private double _ValorProjeto;

        [AtributoBancoDados(AtributoBD = true)]
        public double ValorProjeto
        {
            get
            {
                return this._ValorProjeto;
            }
            set
            {
                this._ValorProjeto = value;
            }
        }


        public DataSet ListaProjeto()
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string strSql = "SELECT PROJETO.* ";
                strSql += " , EQUIPE.NOME AS DESCEQUIPE ";
                strSql += " FROM PROJETO ";
                strSql += " LEFT JOIN EQUIPE ON EQUIPE.IDEQUIPE = PROJETO.IDEQUIPE";

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
