using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.AcessoBancoDados;
using System.Data;

namespace Framework.Ecommerce
{
    public class ClsSigePessoa
    {
        // Fields
        private string _Admissao;
        private string _Bairro;
        private string _Celular;
        private string _Cep;
        private string _CnpjCpf;
        private string _Complemento;
        private string _DataInclusao;
        private string _Demissao;
        private string _DescMissao;
        private string _DescSAC;
        private string _DescValores;
        private string _DescVisao;
        private string _Email;
        private string _Endereco;
        private string _Facebook;
        private string _FlagPadraoSistema;
        private int _IdCidade;
        private int _IdEmpresa;
        private string _Identidade;
        private string _IdentidadeUF;
        private int _IdFuncao;
        private int _IdInclusorUsuario;
        private int _IdPais;
        private int _IdPerfl;
        private int _IdPessoa;
        private int _IdTipo;
        private int _IdTipoContato;
        private int _IdUltimoUsuario;
        private int _IdUsuario;
        private string _InscEstadual;
        private string _InscMunicipal;
        private string _Linkedin;
        private string _Login;
        private string _Mae;
        private string _Nascimento;
        private string _NomeDoResponsalvel;
        private string _NomeFantasia;
        private string _NomePessoa;
        private string _Numero;
        private string _Pai;
        private int _QtdDependentes;
        private string _QuemSomos;
        private string _RazaoSocial;
        private int _ReceberNewsLatter;
        private string _Senha;
        private string _Sexo;
        private string _SiglaUf;
        private string _Site;
        private string _StatusAtivoInativo;
        private string _Telefone;
        private string _TipoPfPj;
        private string _Twitter;
        private string _UltimaAtualizacao;
        private string _Youtube;

        // Methods
        public ClsSigePessoa BuscarPessoa(ClsSigePessoa objClasse, int id)
        {
            ClsSigePessoa pessoa;
            try
            {
                string str = " SELECT * , SigeUsuario.IdUsuario, SigeUsuario.Login, SigeUsuario.Senha,SigeUsuario.IdPerfl, SigeUsuario.StatusAtivoInativo ";
                object obj2 = str + " FROM SigePessoa left join SigeUsuario on SigeUsuario.IdPessoa = SigePessoa.IdPessoa ";
                DataSet set = AcessoBD.ObterDataSet(string.Concat(new object[] { obj2, " WHERE SigePessoa.IdPessoa = ", id, " " }));
                if (set.Tables[0].Rows.Count > 0)
                {
                    DataRow row = set.Tables[0].Rows[0];
                    objClasse.IdTipoContato = (row["IdTipoContato"].ToString().Trim() != "") ? Convert.ToInt32(row["IdTipoContato"].ToString().Trim()) : 0;
                    objClasse.Sexo = row["Sexo"].ToString().Trim();
                    objClasse.IdPessoa = (row["IdPessoa"].ToString().Trim() != "") ? Convert.ToInt32(row["IdPessoa"].ToString()) : 0;
                    objClasse.IdEmpresa = (row["IdEmpresa"].ToString().Trim() != "") ? Convert.ToInt32(row["IdEmpresa"].ToString()) : 0;
                    objClasse.NomePessoa = row["NomePessoa"].ToString().Trim();
                    objClasse.IdTipo = (row["IdTipo"].ToString().Trim() != "") ? Convert.ToInt32(row["IdTipo"].ToString()) : 0;
                    objClasse.IdFuncao = (row["IdFuncao"].ToString().Trim() != "") ? Convert.ToInt32(row["IdFuncao"].ToString()) : 0;
                    objClasse.TipoPfPj = row["TipoPfPj"].ToString().Trim();
                    objClasse.FlagPadraoSistema = row["FlagPadraoSistema"].ToString().Trim();
                    objClasse.IdUltimoUsuario = (row["IdUltimoUsuario"].ToString().Trim() != "") ? Convert.ToInt32(row["IdUltimoUsuario"].ToString()) : 0;
                    objClasse.IdInclusorUsuario = (row["IdInclusorUsuario"].ToString().Trim() != "") ? Convert.ToInt32(row["IdInclusorUsuario"].ToString()) : 0;
                    objClasse.UltimaAtualizacao = row["UltimaAtualizacao"].ToString().Trim();
                    objClasse.DataInclusao = row["DataInclusao"].ToString().Trim();
                    objClasse.CnpjCpf = row["CnpjCpf"].ToString().Trim();
                    objClasse.Identidade = row["Identidade"].ToString().Trim();
                    objClasse.IdentidadeUF = row["IdentidadeUF"].ToString().Trim();
                    objClasse.RazaoSocial = row["RazaoSocial"].ToString().Trim();
                    objClasse.InscEstadual = row["InscEstadual"].ToString().Trim();
                    objClasse.InscMunicipal = row["InscMunicipal"].ToString().Trim();
                    objClasse.Cep = row["Cep"].ToString().Trim();
                    objClasse.Endereco = row["Endereco"].ToString().Trim();
                    objClasse.Numero = row["Numero"].ToString().Trim();
                    objClasse.Bairro = row["Bairro"].ToString().Trim();
                    objClasse.IdPais = (row["IdPais"].ToString().Trim() != "") ? Convert.ToInt32(row["IdPais"].ToString()) : 0;
                    objClasse.IdCidade = (row["IdCidade"].ToString().Trim() != "") ? Convert.ToInt32(row["IdCidade"].ToString()) : 0;
                    objClasse.Complemento = row["Complemento"].ToString().Trim();
                    objClasse.Admissao = row["Admissao"].ToString().Trim();
                    objClasse.Demissao = row["Demissao"].ToString().Trim();
                    objClasse.Nascimento = row["Nascimento"].ToString().Trim();
                    objClasse.Mae = row["Mae"].ToString().Trim();
                    objClasse.Pai = row["Pai"].ToString().Trim();
                    objClasse.QtdDependentes = (row["QtdDependentes"].ToString().Trim() != "") ? Convert.ToInt32(row["QtdDependentes"].ToString()) : 0;
                    objClasse.Telefone = row["Telefone"].ToString().Trim();
                    objClasse.Celular = row["Celular"].ToString().Trim();
                    objClasse.Email = row["Email"].ToString().Trim();
                    objClasse.NomeFantasia = row["NomeFantasia"].ToString().Trim();
                    objClasse.NomeDoResponsalvel = row["NomeDoResponsalvel"].ToString().Trim();
                    row["ReceberNewsLatter"] = obj2 = 1;
                    objClasse.ReceberNewsLatter = (int) obj2;
                    objClasse.SiglaUf = row["SiglaUf"].ToString().Trim();
                    objClasse.IdUsuario = (row["IdUsuario"].ToString().Trim() != "") ? Convert.ToInt32(row["IdUsuario"].ToString().Trim()) : 0;
                    objClasse.Login = row["Login"].ToString().Trim();
                    objClasse.IdPerfl = (row["IdPerfl"].ToString().Trim() != "") ? Convert.ToInt32(row["IdPerfl"].ToString().Trim()) : 0;
                    objClasse.Senha = row["Senha"].ToString().Trim();
                    objClasse.StatusAtivoInativo = row["StatusAtivoInativo"].ToString().Trim();
                    objClasse.Site = row["Site"].ToString().Trim();
                    objClasse.Facebook = row["Facebook"].ToString().Trim();
                    objClasse.Twitter = row["Twitter"].ToString().Trim();
                    objClasse.Youtube = row["Youtube"].ToString().Trim();
                    objClasse.Linkedin = row["Linkedin"].ToString().Trim();
                    objClasse.DescMissao = row["DescMissao"].ToString().Trim();
                    objClasse.DescVisao = row["DescVisao"].ToString().Trim();
                    objClasse.DescValores = row["DescValores"].ToString().Trim();
                    objClasse.QuemSomos = row["QuemSomos"].ToString().Trim();
                    objClasse.DescSAC = row["DescSAC"].ToString().Trim();
                    set.Dispose();
                }
                pessoa = objClasse;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return pessoa;
        }

        public ClsSigePessoa BuscarPessoaCliente(ClsSigePessoa objClasse, int id)
        {
            ClsSigePessoa pessoa;
            try
            {
                object obj2 = (" SELECT * , SigeUsuario.IdUsuario, SigeUsuario.Login, SigeUsuario.Senha,SigeUsuario.IdPerfl, SigeUsuario.StatusAtivoInativo " + " FROM SigePessoa ") + " Left join SigeUsuario on SigeUsuario.IdPessoa = SigePessoa.IdPessoa  " + " Left Join SigeCliente on SigeCliente.IdPessoa = SigePessoa.IdPessoa ";
                DataSet set = AcessoBD.ObterDataSet(string.Concat(new object[] { obj2, " WHERE SigePessoa.IdPessoa = ", id, " " }));
                if (set.Tables[0].Rows.Count > 0)
                {
                    DataRow row = set.Tables[0].Rows[0];
                    objClasse.IdTipoContato = (row["IdTipoContato"].ToString().Trim() != "") ? Convert.ToInt32(row["IdTipoContato"].ToString().Trim()) : 0;
                    objClasse.Sexo = row["Sexo"].ToString().Trim();
                    objClasse.IdPessoa = (row["IdPessoa"].ToString().Trim() != "") ? Convert.ToInt32(row["IdPessoa"].ToString()) : 0;
                    objClasse.IdEmpresa = (row["IdEmpresa"].ToString().Trim() != "") ? Convert.ToInt32(row["IdEmpresa"].ToString()) : 0;
                    objClasse.NomePessoa = row["NomePessoa"].ToString().Trim();
                    objClasse.IdTipo = (row["IdTipo"].ToString().Trim() != "") ? Convert.ToInt32(row["IdTipo"].ToString()) : 0;
                    objClasse.IdFuncao = (row["IdFuncao"].ToString().Trim() != "") ? Convert.ToInt32(row["IdFuncao"].ToString()) : 0;
                    objClasse.TipoPfPj = row["TipoPfPj"].ToString().Trim();
                    objClasse.FlagPadraoSistema = row["FlagPadraoSistema"].ToString().Trim();
                    objClasse.IdUltimoUsuario = (row["IdUltimoUsuario"].ToString().Trim() != "") ? Convert.ToInt32(row["IdUltimoUsuario"].ToString()) : 0;
                    objClasse.IdInclusorUsuario = (row["IdInclusorUsuario"].ToString().Trim() != "") ? Convert.ToInt32(row["IdInclusorUsuario"].ToString()) : 0;
                    objClasse.UltimaAtualizacao = row["UltimaAtualizacao"].ToString().Trim();
                    objClasse.DataInclusao = row["DataInclusao"].ToString().Trim();
                    objClasse.CnpjCpf = row["CnpjCpf"].ToString().Trim();
                    objClasse.Identidade = row["Identidade"].ToString().Trim();
                    objClasse.IdentidadeUF = row["IdentidadeUF"].ToString().Trim();
                    objClasse.RazaoSocial = row["RazaoSocial"].ToString().Trim();
                    objClasse.InscEstadual = row["InscEstadual"].ToString().Trim();
                    objClasse.InscMunicipal = row["InscMunicipal"].ToString().Trim();
                    objClasse.Cep = row["Cep"].ToString().Trim();
                    objClasse.Endereco = row["Endereco"].ToString().Trim();
                    objClasse.Numero = row["Numero"].ToString().Trim();
                    objClasse.Bairro = row["Bairro"].ToString().Trim();
                    objClasse.IdPais = (row["IdPais"].ToString().Trim() != "") ? Convert.ToInt32(row["IdPais"].ToString()) : 0;
                    objClasse.IdCidade = (row["IdCidade"].ToString().Trim() != "") ? Convert.ToInt32(row["IdCidade"].ToString()) : 0;
                    objClasse.Complemento = row["Complemento"].ToString().Trim();
                    objClasse.Admissao = row["Admissao"].ToString().Trim();
                    objClasse.Demissao = row["Demissao"].ToString().Trim();
                    objClasse.Nascimento = row["Nascimento"].ToString().Trim();
                    objClasse.Mae = row["Mae"].ToString().Trim();
                    objClasse.Pai = row["Pai"].ToString().Trim();
                    objClasse.QtdDependentes = (row["QtdDependentes"].ToString().Trim() != "") ? Convert.ToInt32(row["QtdDependentes"].ToString()) : 0;
                    objClasse.Telefone = row["Telefone"].ToString().Trim();
                    objClasse.Celular = row["Celular"].ToString().Trim();
                    objClasse.Email = row["Email"].ToString().Trim();
                    objClasse.NomeFantasia = row["NomeFantasia"].ToString().Trim();
                    objClasse.NomeDoResponsalvel = row["NomeDoResponsalvel"].ToString().Trim();
                    row["ReceberNewsLatter"] = obj2 = 1;
                    objClasse.ReceberNewsLatter = (int) obj2;
                    objClasse.SiglaUf = row["SiglaUf"].ToString().Trim();
                    objClasse.IdUsuario = (row["IdUsuario"].ToString().Trim() != "") ? Convert.ToInt32(row["IdUsuario"].ToString().Trim()) : 0;
                    objClasse.Login = row["Login"].ToString().Trim();
                    objClasse.IdPerfl = (row["IdPerfl"].ToString().Trim() != "") ? Convert.ToInt32(row["IdPerfl"].ToString().Trim()) : 0;
                    objClasse.Senha = row["Senha"].ToString().Trim();
                    objClasse.StatusAtivoInativo = row["StatusAtivoInativo"].ToString().Trim();
                    objClasse.Site = row["Site"].ToString().Trim();
                    objClasse.Facebook = row["Facebook"].ToString().Trim();
                    objClasse.Twitter = row["Twitter"].ToString().Trim();
                    objClasse.Youtube = row["Youtube"].ToString().Trim();
                    objClasse.Linkedin = row["Linkedin"].ToString().Trim();
                    objClasse.DescMissao = row["DescMissao"].ToString().Trim();
                    objClasse.DescVisao = row["DescVisao"].ToString().Trim();
                    objClasse.DescValores = row["DescValores"].ToString().Trim();
                    objClasse.QuemSomos = row["QuemSomos"].ToString().Trim();
                    objClasse.DescSAC = row["DescSAC"].ToString().Trim();
                    set.Dispose();
                }
                pessoa = objClasse;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return pessoa;
        }

        public void Excluir(ClsSigePessoa objSigePessoa, int id)
        {
            try
            {
                if (id > 0)
                {
                    AcessoBD.DeleteRegistro(objSigePessoa, id);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public DataSet GetPessoaComprador(string strIdPessoa)
        {
            DataSet set;
            try
            {
                set = AcessoBD.ObterDataSet("   select sigepessoa.IdPessoa            , SigePessoa.IdEmpresa            , 'BRA' as Pais            , SiglaUf as Estado            , SigeCidade.DescMunicipio as Cidade            , Bairro            , Cep            , Endereco            , Numero            , Complemento            , Email            , Sexo            , Site            , case when TipoPfPj = 'pf' then 'CPF' else 'CNPJ' end as TipoDocumento            , case when TipoPfPj = 'pf' then NomePessoa else RazaoSocial end as Nome            , REPLACE(REPLACE(replace(CnpjCpf,'/',''),'.',''),',','') as Documento            , (SUBSTRING(rtrim(ltrim(Telefone)),2,2)) as DDD            , (SUBSTRING(((Telefone)),5,len(((Telefone))))) as Telefone            from sigepessoa             left join SigeCidade on SigeCidade.IdCidade = SigePessoa.IdCidade            where 1=1 " + " and IdPessoa = " + strIdPessoa + "  ");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }

        public int Salvar(ClsSigePessoa objSigePessoa, int id, string strNomeTela = "")
        {
            int num2;
            try
            {
                num2 = AcessoBD.InsertUpdateRegistro(objSigePessoa, id, strNomeTela);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string Admissao
        {
            get
            {
                return this._Admissao;
            }
            set
            {
                this._Admissao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Bairro
        {
            get
            {
                return this._Bairro;
            }
            set
            {
                this._Bairro = value;
            }
        }

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
        public string Cep
        {
            get
            {
                return this._Cep;
            }
            set
            {
                this._Cep = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string CnpjCpf
        {
            get
            {
                return this._CnpjCpf;
            }
            set
            {
                this._CnpjCpf = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Complemento
        {
            get
            {
                return this._Complemento;
            }
            set
            {
                this._Complemento = value;
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
        public string Demissao
        {
            get
            {
                return this._Demissao;
            }
            set
            {
                this._Demissao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string DescMissao
        {
            get
            {
                return this._DescMissao;
            }
            set
            {
                this._DescMissao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string DescSAC
        {
            get
            {
                return this._DescSAC;
            }
            set
            {
                this._DescSAC = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string DescValores
        {
            get
            {
                return this._DescValores;
            }
            set
            {
                this._DescValores = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string DescVisao
        {
            get
            {
                return this._DescVisao;
            }
            set
            {
                this._DescVisao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Endereco
        {
            get
            {
                return this._Endereco;
            }
            set
            {
                this._Endereco = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Facebook
        {
            get
            {
                return this._Facebook;
            }
            set
            {
                this._Facebook = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string FlagPadraoSistema
        {
            get
            {
                return this._FlagPadraoSistema;
            }
            set
            {
                this._FlagPadraoSistema = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdCidade
        {
            get
            {
                return this._IdCidade;
            }
            set
            {
                this._IdCidade = value;
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

        [AtributoBancoDados(AtributoBD=true)]
        public string Identidade
        {
            get
            {
                return this._Identidade;
            }
            set
            {
                this._Identidade = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string IdentidadeUF
        {
            get
            {
                return this._IdentidadeUF;
            }
            set
            {
                this._IdentidadeUF = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdFuncao
        {
            get
            {
                return this._IdFuncao;
            }
            set
            {
                this._IdFuncao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdInclusorUsuario
        {
            get
            {
                return this._IdInclusorUsuario;
            }
            set
            {
                this._IdInclusorUsuario = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdPais
        {
            get
            {
                return this._IdPais;
            }
            set
            {
                this._IdPais = value;
            }
        }

        public int IdPerfl
        {
            get
            {
                return this._IdPerfl;
            }
            set
            {
                this._IdPerfl = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdPessoa
        {
            get
            {
                return this._IdPessoa;
            }
            set
            {
                this._IdPessoa = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdTipo
        {
            get
            {
                return this._IdTipo;
            }
            set
            {
                this._IdTipo = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdTipoContato
        {
            get
            {
                return this._IdTipoContato;
            }
            set
            {
                this._IdTipoContato = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
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

        public int IdUsuario
        {
            get
            {
                return this._IdUsuario;
            }
            set
            {
                this._IdUsuario = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string InscEstadual
        {
            get
            {
                return this._InscEstadual;
            }
            set
            {
                this._InscEstadual = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string InscMunicipal
        {
            get
            {
                return this._InscMunicipal;
            }
            set
            {
                this._InscMunicipal = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Linkedin
        {
            get
            {
                return this._Linkedin;
            }
            set
            {
                this._Linkedin = value;
            }
        }

        public string Login
        {
            get
            {
                return this._Login;
            }
            set
            {
                this._Login = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Mae
        {
            get
            {
                return this._Mae;
            }
            set
            {
                this._Mae = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Nascimento
        {
            get
            {
                return this._Nascimento;
            }
            set
            {
                this._Nascimento = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string NomeDoResponsalvel
        {
            get
            {
                return this._NomeDoResponsalvel;
            }
            set
            {
                this._NomeDoResponsalvel = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string NomeFantasia
        {
            get
            {
                return this._NomeFantasia;
            }
            set
            {
                this._NomeFantasia = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string NomePessoa
        {
            get
            {
                return this._NomePessoa;
            }
            set
            {
                this._NomePessoa = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Numero
        {
            get
            {
                return this._Numero;
            }
            set
            {
                this._Numero = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Pai
        {
            get
            {
                return this._Pai;
            }
            set
            {
                this._Pai = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int QtdDependentes
        {
            get
            {
                return this._QtdDependentes;
            }
            set
            {
                this._QtdDependentes = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string QuemSomos
        {
            get
            {
                return this._QuemSomos;
            }
            set
            {
                this._QuemSomos = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string RazaoSocial
        {
            get
            {
                return this._RazaoSocial;
            }
            set
            {
                this._RazaoSocial = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int ReceberNewsLatter
        {
            get
            {
                return this._ReceberNewsLatter;
            }
            set
            {
                this._ReceberNewsLatter = value;
            }
        }

        public string Senha
        {
            get
            {
                return this._Senha;
            }
            set
            {
                this._Senha = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Sexo
        {
            get
            {
                return this._Sexo;
            }
            set
            {
                this._Sexo = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string SiglaUf
        {
            get
            {
                return this._SiglaUf;
            }
            set
            {
                this._SiglaUf = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Site
        {
            get
            {
                return this._Site;
            }
            set
            {
                this._Site = value;
            }
        }

        public string StatusAtivoInativo
        {
            get
            {
                return this._StatusAtivoInativo;
            }
            set
            {
                this._StatusAtivoInativo = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
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
        public string TipoPfPj
        {
            get
            {
                return this._TipoPfPj;
            }
            set
            {
                this._TipoPfPj = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Twitter
        {
            get
            {
                return this._Twitter;
            }
            set
            {
                this._Twitter = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
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
        public string Youtube
        {
            get
            {
                return this._Youtube;
            }
            set
            {
                this._Youtube = value;
            }
        }
    }


 

}
