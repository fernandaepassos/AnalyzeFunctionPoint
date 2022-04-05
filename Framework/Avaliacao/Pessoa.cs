using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.AcessoBancoDados;
using System;
using System.Data;

namespace Framework.Avaliacao
{
    public class Pessoa : ClassGenericAvaliacao
    {
        // Fields
        private string _Admissao;
        private string _Bairro;
        private string _Celular;
        private string _Cep;
        private string _Cidade;
        private string _CnpjCpf;
        private string _Complemento;
        private string _Demissao;
        private string _Email;
        private string _Endereco;
        private string _FlagReceberNotificacao;
        private int _IdDepartamento;
        private string _Identidade;
        private string _IdentidadeUF;
        private int _IdEstado;
        private int _IdFilial;
        private int _IdFuncao;
        private int _IdPessoa;
        private int _IdUltimoUsuario;
        private string _InscEstadual;
        private string _InscMunicipal;
        private string _Mae;
        private string _Nascimento;
        private string _Nome;
        private string _Numero;
        private string _Pai;
        private string _PfPj;
        private string _QtdDependentes;
        private string _RazaoSocial;
        private string _Telefone;
        private string _UltimaAtualizacao;

        // Methods
        public string GetDadoCampoPessoa(int intIdPessoa, string strCampo)
        {
            try
            {
                return AcessoBD.ExecutarComandoSqlEscalar(string.Concat(new object[] { "select ", strCampo, " from pessoa where idpessoa = ", intIdPessoa })).ToString().Trim();
            }
            catch
            {
                return "";
            }
        }

        public string GetEmailFuncionarioPorFuncao(string strParaGrupoDe, string strIdFilial)
        {
            string str3;
            DataSet set = new DataSet();
            try
            {
                if (strParaGrupoDe.Trim().ToLower() == "precistas".ToLower())
                {
                    set = AcessoBD.ObterDataSet("select email from Pessoa where idfuncao in ( 2, 5, 9) and lower(Pessoa.FlagReceberNotificacao) = 's' and IdFilial = " + strIdFilial + " and IdPessoa in (select IdPessoa from Funcionario)");
                }
                else if (strParaGrupoDe.Trim().ToLower() == "avaliadores".ToLower())
                {
                    set = AcessoBD.ObterDataSet("select email from Pessoa where idfuncao in (1,2 ,8, 9) and lower(Pessoa.FlagReceberNotificacao) = 's'  and IdFilial = " + strIdFilial + " and IdPessoa in (select IdPessoa from Funcionario)");
                }
                else if (strParaGrupoDe.Trim().ToLower() == "vendedor".ToLower())
                {
                    set = AcessoBD.ObterDataSet("select email from Pessoa where idfuncao in (7, 8 , 9) and lower(Pessoa.FlagReceberNotificacao) = 's'  and IdFilial = " + strIdFilial + " and IdPessoa in (select IdPessoa from Funcionario)");
                }
                else if (strParaGrupoDe.Trim().ToLower() == "gerenteloja".ToLower())
                {
                    set = AcessoBD.ObterDataSet("select email from Pessoa where idfuncao in (4)  and lower(Pessoa.FlagReceberNotificacao) = 's' and IdFilial = " + strIdFilial + " and IdPessoa in (select IdPessoa from Funcionario)");
                }
                else if (strParaGrupoDe.Trim().ToLower() == "admgeral".ToLower())
                {
                    set = AcessoBD.ObterDataSet("select Pessoa.Email from Pessoa                    left join Usuario on Usuario.IdPessoa = Pessoa.IdPessoa                     Left Join Filial on Filial.IdFilial = Pessoa.IdFilial                    Left Join Empresa on Empresa.IdEmpresa = Filial.IdEmpresa                    where Usuario.FlagAdministradoGeral = 1 and lower(Pessoa.FlagReceberNotificacao) = 's'                    and Filial.IdFilial = " + strIdFilial + " ");
                }
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    string str2 = "";
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        str2 = str2 + set.Tables[0].Rows[i][0].ToString().Trim() + ",";
                    }
                    if (str2.Trim() != "")
                    {
                        str2 = str2.Trim().Substring(0, str2.Trim().Length - 1);
                    }
                    return str2;
                }
                str3 = "";
            }
            catch
            {
                str3 = "";
            }
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
            }
            return str3;
        }

        public string GetPessoaNome(int intIdUsuario)
        {
            try
            {
                return AcessoBD.ExecutarComandoSqlEscalar("select Pessoa.Nome from Usuario  left join Pessoa on Pessoa.IdPessoa = Usuario.IdPessoa where Usuario.IdUsuario  = " + intIdUsuario + " ").ToString().Trim();
            }
            catch
            {
                return "";
            }
        }

        public string GetPessoaNomePorIdPessoa(int intIdPessoa)
        {
            try
            {
                return AcessoBD.ExecutarComandoSqlEscalar("select Nome from pessoa where idpessoa = " + intIdPessoa).ToString().Trim();
            }
            catch
            {
                return "";
            }
        }

        public DataSet ListaFuncionario(int intIdFilial)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (intIdFilial <= 0)
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet("SELECT  Pessoa.IdFilial                , Usuario.Login as DescUltimoUsuario                , convert(varchar,Pessoa.UltimaAtualizacao, 103)+' '+ convert(varchar,Pessoa.UltimaAtualizacao, 108) as UltimaAtualizacao                 , CnpjCpf                , Nome                , Celular                , Pessoa.Telefone                , Pessoa.Email                , Pessoa.PfPj                , Filial.RazaoSocial as Filial                , Departamento.DescDepartamento                , Funcao.DescFuncao                , Filial.IdFilial                , Departamento.IdDepartamento                , Funcao.IdFuncao                , Pessoa.IdPessoa                FROM Pessoa                Left Join Usuario on Usuario.IdUsuario = Pessoa.IdUltimoUsuario                Left Join Filial on Filial.IdFilial = Pessoa.IdFilial                Left Join Departamento on Departamento.IdDepartamento = Pessoa.IdDepartamento                Left Join Funcao on Funcao.IdFuncao = Pessoa.idFuncao                WHERE Pessoa.IdPessoa in (select IdPessoa from Funcionario) and Pessoa.IdFilial = " + intIdFilial + " ");
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

        public DataSet ListaParceiro(int intIdFilial)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (intIdFilial <= 0)
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet("SELECT  Pessoa.IdFilial                , Usuario.Login as DescUltimoUsuario                , convert(varchar,Pessoa.UltimaAtualizacao, 103)+' '+ convert(varchar,Pessoa.UltimaAtualizacao, 108) as UltimaAtualizacao                 , CnpjCpf                , Nome                , Celular                , Pessoa.Telefone                , Pessoa.Email                , Pessoa.PfPj                , Filial.RazaoSocial as Filial                , Filial.IdFilial                , Pessoa.IdPessoa                FROM Pessoa                Left Join Usuario on Usuario.IdUsuario = Pessoa.IdUltimoUsuario                Left Join Filial on Filial.IdFilial = Pessoa.IdFilial                WHERE Pessoa.IdPessoa in (select IdPessoa from Parceiro) and Pessoa.IdFilial = " + intIdFilial + " ");
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

        public DataSet ListaPessoa(int intIdFilial)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (intIdFilial <= 0)
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet("SELECT  Pessoa.IdFilial                , Usuario.Login as DescUltimoUsuario                , convert(varchar,Pessoa.UltimaAtualizacao, 103)+' '+ convert(varchar,Pessoa.UltimaAtualizacao, 108) as UltimaAtualizacao                 , CnpjCpf                , Nome                , Celular                , Pessoa.Telefone                , Pessoa.Email                , Pessoa.PfPj                , Filial.RazaoSocial as Filial                , Departamento.DescDepartamento                , Funcao.DescFuncao                , Filial.IdFilial                , Departamento.IdDepartamento                , Funcao.IdFuncao                , Pessoa.IdPessoa                FROM Pessoa                Left Join Usuario on Usuario.IdUsuario = Pessoa.IdUltimoUsuario                Left Join Filial on Filial.IdFilial = Pessoa.IdFilial                Left Join Departamento on Departamento.IdDepartamento = Pessoa.IdDepartamento                Left Join Funcao on Funcao.IdFuncao = Pessoa.idFuncao                WHERE Pessoa.IdFilial = " + intIdFilial + " ");
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

        public DataSet ListaPessoaVendedor(string strIdFilial)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
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
                set = AcessoBD.ObterDataSet(" select IdPessoa                , nome                from Pessoa                 where 1 = 1                and IdFuncao in (7,8,9)                and IdFilial = " + strIdFilial + " ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdPessoa", typeof(int));
                    table.Columns.Add("nome", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdPessoa"].ToString().Trim()), set.Tables[0].Rows[i]["nome"].ToString().Trim() });
                    }
                    set2.Tables.Add(table);
                    return set2;
                }
                set3 = null;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set3;
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
        public string Cidade
        {
            get
            {
                return this._Cidade;
            }
            set
            {
                this._Cidade = value;
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
        public string FlagReceberNotificacao
        {
            get
            {
                return this._FlagReceberNotificacao;
            }
            set
            {
                this._FlagReceberNotificacao = value;
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
        public int IdEstado
        {
            get
            {
                return this._IdEstado;
            }
            set
            {
                this._IdEstado = value;
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
        public string PfPj
        {
            get
            {
                return this._PfPj;
            }
            set
            {
                this._PfPj = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string QtdDependentes
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

 
