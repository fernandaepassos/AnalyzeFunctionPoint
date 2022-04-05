using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Sige
{
    public class ClsSigeParametroValor : ClassGenericSige
    {
        // Fields
        private int _IdEmpresa;
        private int _IdParametro;
        private int _IdParametroValor;
        private int _IdUltimoUsuario;
        private string _UltimaAtualizacao;
        private string _Valor;

        // Methods
        public void Excluir(ClsSigeParametroValor objClasse, int id)
        {
            try
            {
                if (id > 0)
                {
                    AcessoBD.DeleteRegistro(objClasse, id);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public DataSet ListaParametroEcommerce(string strIdEmpresa)
        {
            DataSet set;
            try
            {
                if (strIdEmpresa == null)
                {
                    return null;
                }
                if (strIdEmpresa.Trim() == "")
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" Select SigeParametroValor.IdParametroValor                , SigeParametroValor.IdParametro                , SigeParametroValor.IdEmpresa                , SigeParametro.NomeParametro                , SigeParametro.DescParametro                , SigeParametroValor.Valor                , SigeUsuario.Login as DescUltimoUsuario                , CONVERT(varchar,SigeParametroValor.UltimaAtualizacao,103)+ ' '+ CONVERT(varchar,SigeParametroValor.UltimaAtualizacao,108) as UltimaAtualizacao                From SigeParametroValor                Left Join SigeParametro on SigeParametro.IdParametro = SigeParametroValor.IdParametro                Left Join SigeUsuario on SigeUsuario.IdUsuario = SigeParametroValor.IdUltimoUsuario                where SigeParametro.IdSistema = 3 and SigeParametroValor.IdEmpresa = " + strIdEmpresa + " ");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

        public int Salvar(ClsSigeParametroValor objSigeParametroValor, int id)
        {
            int num2;
            try
            {
                num2 = AcessoBD.InsertUpdateRegistro(objSigeParametroValor, id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
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
