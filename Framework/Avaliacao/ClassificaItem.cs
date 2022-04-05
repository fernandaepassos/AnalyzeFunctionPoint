using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;


namespace Framework.Avaliacao
{
    public class ClassificaItem : ClassGenericAvaliacao
    {
        // Fields
        private int _IdClassificaItem;
        private int _IdTipoVeiculo;
        private int _IdUltimoUsuario;
        private string _Letra;
        private string _Nome;
        private string _UltimaAtualizacao;

        // Methods
        public DataSet ListaItem(string strIdTipoVeiculo)
        {
            DataSet set;
            try
            {
                if (strIdTipoVeiculo == null)
                {
                    return null;
                }
                if (strIdTipoVeiculo.Trim() == "")
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" select IdClassificaItem , nome +'['+ letra +']' as nome from ClassificaItem where idtipoveiculo = " + strIdTipoVeiculo + " ");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public int IdClassificaItem
        {
            get
            {
                return this._IdClassificaItem;
            }
            set
            {
                this._IdClassificaItem = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdTipoVeiculo
        {
            get
            {
                return this._IdTipoVeiculo;
            }
            set
            {
                this._IdTipoVeiculo = value;
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

        [AtributoBancoDados(AtributoBD=true)]
        public string Letra
        {
            get
            {
                return this._Letra;
            }
            set
            {
                this._Letra = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
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

 
