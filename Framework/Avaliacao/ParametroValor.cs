using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class ParametroValor : ClassGenericAvaliacao
    {
        // Fields
        private int _IdFilial;
        private int _IdParametro;
        private int _IdParametroValor;
        private int _IdUltimoUsuario;
        private string _UltimaAtualizacao;
        private string _Valor;

        // Methods
        public string GetParamentro(string strIdFilial, string strIdParametro)
        {
            try
            {
                if (strIdFilial == null)
                {
                    return "";
                }
                if (strIdFilial.Trim() == "")
                {
                    return "";
                }
                if (strIdParametro == null)
                {
                    return "";
                }
                if (strIdParametro.Trim() == "")
                {
                    return "";
                }
                return AcessoBD.ExecutarComandoSqlEscalar("select Valor from ParametroValor where IdFilial = " + strIdFilial + " and IdParametro = " + strIdParametro + " ").ToString().Trim();
            }
            catch
            {
                return "";
            }
        }

        public DataSet ListaParametro(string strIdFilial)
        {
            DataSet set;
            try
            {
                if (strIdFilial == null)
                {
                    return null;
                }
                if (strIdFilial.Trim() == "")
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" Select ParametroValor.IdParametroValor                , ParametroValor.IdParametro                , ParametroValor.IdFilial                , Parametro.Nome                , Parametro.Descricao                , ParametroValor.Valor                , Usuario.Login as DescUltimoUsuario                , CONVERT(varchar,ParametroValor.UltimaAtualizacao,103)+ ' '+ CONVERT(varchar,ParametroValor.UltimaAtualizacao,108) as UltimaAtualizacao                From ParametroValor                Left Join Parametro on Parametro.IdParametro = ParametroValor.IdParametro                Left Join Usuario on Usuario.IdUsuario = ParametroValor.IdUltimoUsuario                where ParametroValor.IdFilial = " + strIdFilial + " ");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

        // Properties
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
        public int IdParametro
        {
            get
            {
                return this._IdParametro;
            }
            set
            {
                this._IdParametro = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdParametroValor
        {
            get
            {
                return this._IdParametroValor;
            }
            set
            {
                this._IdParametroValor = value;
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

        [AtributoBancoDados(AtributoBD=true)]
        public string Valor
        {
            get
            {
                return this._Valor;
            }
            set
            {
                this._Valor = value;
            }
        }
    }
}
