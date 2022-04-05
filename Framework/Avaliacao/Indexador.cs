using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class Indexador : ClassGenericAvaliacao
    {
        // Fields
        private string _DescIndexador;
        private int _IdFilial;
        private int _IdIndexador;
        private int _IdUltimoUsuario;
        private string _UltimaAtualizacao;
        private string _UrlIndexador;

        // Methods
        public DataSet ListaIndexador(int intIdFilial)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (intIdFilial <= 0)
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet("select  Indexador.IdIndexador                , Indexador.IdFilial                , Indexador.DescIndexador                , Indexador.UrlIndexador                , convert(Varchar,Indexador.UltimaAtualizacao,103)+' '+convert(Varchar,Indexador.UltimaAtualizacao,108) as UltimaAtualizacao                , Usuario.Login as DescUltimoUsuario                , Filial.RazaoSocial as Filial                from Indexador                left join Usuario on Usuario.IdUsuario = Indexador.IdUltimoUsuario                left join Filial on Filial.IdFilial = Indexador.IdFilial                where Indexador.IdFilial = " + intIdFilial + " ");
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
        public string DescIndexador
        {
            get
            {
                return this._DescIndexador;
            }
            set
            {
                this._DescIndexador = value;
            }
        }

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
        public int IdIndexador
        {
            get
            {
                return this._IdIndexador;
            }
            set
            {
                this._IdIndexador = value;
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
        public string UrlIndexador
        {
            get
            {
                return this._UrlIndexador;
            }
            set
            {
                this._UrlIndexador = value;
            }
        }
    }
}
