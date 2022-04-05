using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class Recepcao : ClassGenericAvaliacao
    {
        // Fields
        private string _Celular;
        private string _DataInclusao;
        private string _FlagVendedorPreferencia;
        private int _IdFilial;
        private int _IdMidia;
        private int _IdPessoaVendedor;
        private int _IdRecepcao;
        private int _IdTipoMotivoVisita;
        private string _Nome;
        private string _Placa;
        private string _Telefone;
        private string _VeiculoDeInteresse;

        // Methods
        public DataSet ListaRecepcao(int intIdFilial)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (intIdFilial <= 0)
                {
                    return null;
                }

                
                string strSql = "select IdRecepcao, Recepcao.Nome ";
                strSql += " , (CONVERT(varchar,Recepcao.DataInclusao,103)) as DataInclusao ";
                strSql += " , Recepcao.Telefone, Recepcao.Celular, IdTipoMotivoVisita ";
                strSql += " , Tipo.DescTipo as DescTipoMotivoVisita, FlagVendedorPreferencia ";
                strSql += " , Placa, VeiculoDeInteresse, Recepcao.IdMidia, Midia.DescMidia ";
                strSql += " , Recepcao.IdFilial, IdPessoaVendedor, (Pessoa.Nome) as DescPessoaVendedor ";
                strSql += " , (Usuario.Login) as DescUltimoUsuario ";
                strSql += " , (CONVERT(varchar,Recepcao.UltimaAtualizacao,103)) as UltimaAtualizacao ";
                strSql += " , Recepcao.IdFilial, Filial.RazaoSocial ";
                strSql += " from Recepcao Left Join Tipo on Tipo.IdTipo = Recepcao.IdTipoMotivoVisita ";
                strSql += " Left join Usuario on Usuario.IdUsuario = Recepcao.IdUltimoUsuario ";
                strSql += " Left Join Midia on Midia.IdMidia = Recepcao.IdMidia  ";
                strSql += " Left Join Pessoa on Pessoa.IdPessoa = Recepcao.IdPessoaVendedor  ";
                strSql += " Left Join Filial on Filial.IdFilial = Recepcao.IdFilial ";
                strSql += " where Recepcao.IdFilial = " + intIdFilial + " ";

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

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string Celular
        {
            get
            {
                return this._Celular;
            }
            set
            {
                this._Celular = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string DataInclusao
        {
            get
            {
                return this._DataInclusao;
            }
            set
            {
                this._DataInclusao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string FlagVendedorPreferencia
        {
            get
            {
                return this._FlagVendedorPreferencia;
            }
            set
            {
                this._FlagVendedorPreferencia = value;
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
        public int IdMidia
        {
            get
            {
                return this._IdMidia;
            }
            set
            {
                this._IdMidia = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdPessoaVendedor
        {
            get
            {
                return this._IdPessoaVendedor;
            }
            set
            {
                this._IdPessoaVendedor = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdRecepcao
        {
            get
            {
                return this._IdRecepcao;
            }
            set
            {
                this._IdRecepcao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdTipoMotivoVisita
        {
            get
            {
                return this._IdTipoMotivoVisita;
            }
            set
            {
                this._IdTipoMotivoVisita = value;
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

        [AtributoBancoDados(AtributoBD=true)]
        public string Placa
        {
            get
            {
                return this._Placa;
            }
            set
            {
                this._Placa = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public string Telefone
        {
            get
            {
                return this._Telefone;
            }
            set
            {
                this._Telefone = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string VeiculoDeInteresse
        {
            get
            {
                return this._VeiculoDeInteresse;
            }
            set
            {
                this._VeiculoDeInteresse = value;
            }
        }
    }
}
 
