using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class Empresa : ClassGenericAvaliacao
    {
        // Fields
        private string _DescEmpresa;
        private int _IdEmpresa;
        private int _IdUltimoUsuario;
        private string _UltimaAtualizacao;

        // Methods
        public DataSet ListaEmpresa(int intIdEmpresa)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (intIdEmpresa <= 0)
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" Select                 Empresa.IdEmpresa                , Empresa.DescEmpresa                , Usuario.Login                , CONVERT(VARCHAR,Empresa.UltimaAtualizacao,103) +' '+ CONVERT(VARCHAR, Empresa.UltimaAtualizacao, 108) AS UltimaAtualizacao                from Empresa                LEFT JOIN Usuario ON Usuario.IdUsuario = Empresa.IdUltimoUsuario                WHERE IdEmpresa = " + intIdEmpresa + " ");
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

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string DescEmpresa
        {
            get
            {
                return this._DescEmpresa;
            }
            set
            {
                this._DescEmpresa = value;
            }
        }

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
