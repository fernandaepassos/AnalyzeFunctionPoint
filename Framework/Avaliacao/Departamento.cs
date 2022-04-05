using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class Departamento : ClassGenericAvaliacao
    {
        // Fields
        private string _DescDepartamento;
        private int _IdDepartamento;
        private int _IdFilial;
        private int _IdUltimoUsuario;
        private string _UltimaAtualizacao;

        // Methods
        public DataSet ListaDepartamento(int intIdFilial)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (intIdFilial <= 0)
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet("select                 Departamento.IdDepartamento                , Departamento.DescDepartamento                , Departamento.IdFilial                , convert(Varchar,Departamento.UltimaAtualizacao,103)+' '+convert(Varchar,Departamento.UltimaAtualizacao,108) as UltimaAtualizacao                , Usuario.Login as DescUltimoUsuario                , Filial.RazaoSocial as Filial                from Departamento                left join Usuario on Usuario.IdUsuario = Departamento.IdUltimoUsuario                LEFT JOIN Filial ON Filial.IdFilial = Departamento.IdFilial                where Departamento.IdFilial = " + intIdFilial + "  ");
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
        public string DescDepartamento
        {
            get
            {
                return this._DescDepartamento;
            }
            set
            {
                this._DescDepartamento = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdDepartamento
        {
            get
            {
                return this._IdDepartamento;
            }
            set
            {
                this._IdDepartamento = value;
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
