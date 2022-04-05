using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class Especie : ClassGenericAvaliacao
    {
        // Fields
        private string _DescEspecie;
        private int _IdEspecie;
        private int _IdFilial;
        private int _IdUltimoUsuario;
        private string _UltimaAtualizacao;

        // Methods
        public DataSet ListaEspecie(int intIdFilial)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (intIdFilial <= 0)
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet("select                 Especie.IdEspecie                , Especie.IdFilial                , Especie.DescEspecie                , convert(Varchar,Especie.UltimaAtualizacao,103)+' '+convert(Varchar,Especie.UltimaAtualizacao,108) as UltimaAtualizacao                , Usuario.Login as DescUltimoUsuario                , Filial.RazaoSocial as Filial                from Especie                left join Usuario on Usuario.IdUsuario = Especie.IdUltimoUsuario                left join Filial on Filial.IdFilial = Especie.IdFilial                where Especie.IdFilial = " + intIdFilial + " ");
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
        public string DescEspecie
        {
            get
            {
                return this._DescEspecie;
            }
            set
            {
                this._DescEspecie = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdEspecie
        {
            get
            {
                return this._IdEspecie;
            }
            set
            {
                this._IdEspecie = value;
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
