using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class AvaliaClassificaItem : ClassGenericAvaliacao
    {
        // Fields
        private int _IdAvalia;
        private int _IdAvaliaClassificaItem;
        private int _IdClassificaItem;
        private int _IdItemVeiculo;
        private int _IdUltimoUsuario;
        private string _UltimaAtualizacao;

        // Methods
        public bool ItemClassificouVeiculo(string strIdAvalia, string strIdItemVeiculo, string strIdClassificaItem)
        {
            try
            {
                if (!string.IsNullOrEmpty(strIdAvalia))
                {
                    if (string.IsNullOrEmpty(strIdItemVeiculo))
                    {
                        return false;
                    }
                    if (string.IsNullOrEmpty(strIdClassificaItem))
                    {
                        return false;
                    }
                    object obj2 = AcessoBD.ExecutarComandoSqlEscalar("select COUNT(*) Visible from AvaliaClassificaItem where IdAvalia = " + strIdAvalia + " and IdItemVeiculo  = " + strIdItemVeiculo + " and IdClassificaItem = " + strIdClassificaItem);
                    if (obj2 != null)
                    {
                        return ((Convert.ToInt32(obj2) != 0) && (Convert.ToInt32(obj2) > 0));
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public int IdAvalia
        {
            get
            {
                return this._IdAvalia;
            }
            set
            {
                this._IdAvalia = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdAvaliaClassificaItem
        {
            get
            {
                return this._IdAvaliaClassificaItem;
            }
            set
            {
                this._IdAvaliaClassificaItem = value;
            }
        }

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
        public int IdItemVeiculo
        {
            get
            {
                return this._IdItemVeiculo;
            }
            set
            {
                this._IdItemVeiculo = value;
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
