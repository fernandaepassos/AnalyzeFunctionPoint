using System;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;
using Framework.Reflection.Rotinas;


namespace Framework.Sige
{
    public class ClsSigePessoa : Rotina
    {
        // Fields
        private string strCelular_1;
        private string strCelular_2;
        private string strCep;
        private string strDataInclusao;
        private string strDescEndereco;
        private string strEmail;
        private string strFacabook;
        private string strFlagPadraoSistema;
        private string strIdContato;
        private string strIdEmpresa;
        private string strIdEndereco;
        private string strIdFuncao;
        private string strIdInclusorUsuario;
        private string strIdPessoa;
        private string strIdTipo;
        private string strIdTipoContato;
        private string strIdUf;
        private string strIdUltimoUsuario;
        private string strNomeBairro;
        private string strNomeCidade;
        private string strNomePessoa;
        private string strNumero;
        private string strSite;
        private string strTalk;
        private string strTel_fixo1;
        private string strTel_fixo2;
        private string strTipoPfPj;
        private string strTwitter;
        private string strUltimaAtualizacao;

        // Methods
        public bool Excluir(out string strMsgRetorno, string strCodigoRegistro)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    if ((this.strIdPessoa != null) && (this.strIdPessoa.Trim() != ""))
                    {
                        conexao.AddParametros("IdPessoa", this.strIdPessoa);
                    }
                    else if ((strCodigoRegistro != null) && (strCodigoRegistro.Trim() != ""))
                    {
                        conexao.AddParametros("IdPessoa", strCodigoRegistro);
                    }
                    conexao.CriarPedido("STP_SigePessoa_Exc", false);
                    string str2 = conexao.GetValor("RESPOSTA", 0, 0);
                    if (str2 == null)
                    {
                        goto Label_00CD;
                    }
                    if (!(str2 == "1"))
                    {
                        if (str2 == "2")
                        {
                            goto Label_00C4;
                        }
                        goto Label_00CD;
                    }
                    strMsgRetorno = "Registro excluído com sucesso.";
                    goto Label_00D6;
                Label_00C4:
                    strMsgRetorno = "Não foi possível excluir o registro.";
                    goto Label_00D6;
                Label_00CD:
                    strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                Label_00D6:
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                strMsgRetorno = exception.Message;
                throw exception;
            }
            return flag;
        }

        public bool ExcluirFuncionarioEcommerce(string strIdPessoa, out string strMensagem)
        {
            bool flag;
            strMensagem = "";
            try
            {
                if (strIdPessoa == null)
                {
                    return false;
                }
                if (strIdPessoa.Trim() == "")
                {
                    return false;
                }
                ClsSigeUsuario usuario = new ClsSigeUsuario();
                if (usuario.ValidaExclusao(usuario.GetIdUsuario(Convert.ToInt32(strIdPessoa))))
                {
                    AcessoBD.ExecutarComandoSql("select * from sigefuncionario where idpessoa = " + strIdPessoa);
                    AcessoBD.ExecutarComandoSql("select * from SigePessoa where IdPessoa = " + strIdPessoa + " ");
                    AcessoBD.ExecutarComandoSql("select * from SigeUsuario where IdPessoa = " + strIdPessoa + " ");
                    AcessoBD.ExecutarComandoSql("select * from SigeUsuarioSistema where IdSistema = 3 and IdUsuario in (select IdUsuario from SigeUsuario where IdPessoa = " + strIdPessoa + ") ");
                    AcessoBD.ExecutarComandoSql("select * from SigeUsuarioHrAcesso where IdUsuario in (select IdUsuario from SigeUsuario where IdPessoa = " + strIdPessoa + ") ");
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public DataSet GetClienteEProspects()
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string sqlComand = "  Select IdPessoa                , NomePessoa                from SigePessoa                where IdPessoa in (select IdPessoa from SigeCliente)                or IdPessoa in (select IdPessoa from SigeProspect) ";
                set = AcessoBD.ObterDataSet(sqlComand);
                set2 = set;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return set2;
        }

        public DataSet GetColaboradores(string strIdEmpresa)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (string.IsNullOrEmpty(strIdEmpresa))
                {
                    return null;
                }
                set2 = AcessoBD.ObterDataSet("                select SigePessoa.IdPessoa                , NomePessoa                , (SELECT NomePerfil FROM SigePerfil WHERE IdPerfil = SigeUsuario.IdPerfl) as Perfil                , SigeUsuario.Login as Login                , (SigeContato.Tel_fixo1 +'   '+ SigeContato.Tel_fixo2 +'   '+ SigeContato.Celular_1 +'   '+ SigeContato.Celular_2) as Telefones                , SigeContato.Email as Email                , SigeEndereco.NomeCidade                , SigeEndereco.NomeBairro                , CONVERT(VARCHAR,SigePessoa.DataInclusao, 103) as DataCadastro                from SigePessoa                 LEFT OUTER JOIN SIGEUSUARIO ON SigePessoa.IdPessoa = SigeUsuario.IdUsuario                LEFT OUTER JOIN SigeContato ON SigeContato.IdPessoa = SigePessoa.IdPessoa                LEFT OUTER JOIN SigeEndereco ON SigeEndereco.IdPessoa = SigePessoa.IdPessoa                WHERE SigePessoa.IdEmpresa = " + strIdEmpresa.Trim() + " ");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set2;
        }

        public string GetIdPessoa(string strIdUsuario)
        {
            string str;
            try
            {
                if (strIdUsuario == null)
                {
                    return "";
                }
                if (strIdUsuario.Trim() == "")
                {
                    return "";
                }
                DataSet set = AcessoBD.ObterDataSet("select IdPessoa from SigeUsuario where IdUsuario = " + strIdUsuario + " ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    return set.Tables[0].Rows[0]["IdPessoa"].ToString().Trim();
                }
                str = "";
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public static DataSet GetPessoa(int intIdPessoa = 0, string strIdEmpresa = "")
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string str = " SELECT IdPessoa, NomePessoa";
                str = str + " FROM SigePessoa " + " WHERE 1=1 ";
                if (!string.IsNullOrEmpty(strIdEmpresa.Trim()))
                {
                    str = str + " AND IdEmpresa = " + strIdEmpresa + " ";
                }
                if (intIdPessoa != 0)
                {
                    object obj2 = str;
                    str = string.Concat(new object[] { obj2, " AND IdPessoa = ", intIdPessoa, " " });
                }
                set = AcessoBD.ObterDataSet(str + " ORDER BY NomePessoa ASC ");
                set2 = set;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return set2;
        }

        public static DataSet GetPessoa(string strIdPessoa, string strIdEmpresa)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string sQL = " SELECT * FROM vwSigePessoaPesqDetalhe WHERE 1=1 ";
                if (!string.IsNullOrEmpty(strIdPessoa.Trim()))
                {
                    sQL = sQL + " AND IDPESSOA = " + strIdPessoa + " ";
                }
                if (!string.IsNullOrEmpty(strIdEmpresa.Trim()))
                {
                    sQL = sQL + " AND IDEMPRESA = " + strIdEmpresa + " ";
                }
                using (Conexao conexao = new Conexao())
                {
                    set = conexao.ExecSQL(sQL);
                }
                set2 = set;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return set2;
        }

        public static DataSet GetPessoa(string strIdEmpresa, string strIDEstado, string strTipoPessoa, string strIdTipo, string strCidade, string strNome)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string sQL = " SELECT *  FROM vwSigePessoaPesq WHERE 1=1 ";
                if (!string.IsNullOrEmpty(strIdEmpresa))
                {
                    sQL = sQL + " AND IDEMPRESA = " + strIdEmpresa.Trim() + " ";
                }
                if (!string.IsNullOrEmpty(strIDEstado.Trim()))
                {
                    sQL = sQL + " AND IdUf = " + strIDEstado.Trim() + " ";
                }
                if (!string.IsNullOrEmpty(strTipoPessoa.Trim()))
                {
                    sQL = sQL + " and IdTipo = " + strTipoPessoa + " ";
                }
                if (!string.IsNullOrEmpty(strIdTipo.Trim()))
                {
                    sQL = sQL + " and lower(TipoPfPj) = '" + strIdTipo.Trim().ToLower() + "' ";
                }
                if (!string.IsNullOrEmpty(strCidade.Trim()))
                {
                    sQL = sQL + " AND CIDADE LIKE '%" + strCidade + "%' ";
                }
                if (!string.IsNullOrEmpty(strNome.Trim()))
                {
                    sQL = sQL + " AND NOMEPESSOA LIKE '%" + strNome.Trim() + "%' ";
                }
                using (Conexao conexao = new Conexao())
                {
                    set = conexao.ExecSQL(sQL);
                }
                set2 = set;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return set2;
        }

        public bool Gravar(out string strMsgRetorno, out string strIdPessoaNew, out string strIdInternalEnderecoNew, out string strIdInternalContatoNew)
        {
            bool flag;
            strMsgRetorno = "";
            strIdPessoaNew = "";
            strIdInternalEnderecoNew = "";
            strIdInternalContatoNew = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdPessoa", this.strIdPessoa);
                    conexao.AddParametros("IdTipo", this.strIdTipo);
                    conexao.AddParametros("IdEmpresa", this.strIdEmpresa);
                    conexao.AddParametros("NomePessoa", this.strNomePessoa);
                    conexao.AddParametros("IdFuncao", this.strIdFuncao);
                    conexao.AddParametros("TipoPfPj", this.strTipoPfPj);
                    conexao.AddParametros("FlagPadraoSistema", this.strFlagPadraoSistema);
                    conexao.AddParametros("IdUltimoUsuario", this.strIdUltimoUsuario);
                    conexao.AddParametros("IdInclusorUsuario", this.strIdInclusorUsuario);
                    conexao.AddParametros("UltimaAtualizacao", "");
                    conexao.AddParametros("DataInclusao", "");
                    conexao.AddParametros("IdEndereco", this.strIdEndereco);
                    conexao.AddParametros("IdUf", this.strIdUf);
                    conexao.AddParametros("DescEndereco", this.strDescEndereco);
                    conexao.AddParametros("Numero", this.strNumero);
                    conexao.AddParametros("Cep", this.strCep);
                    conexao.AddParametros("NomeCidade", this.strNomeCidade);
                    conexao.AddParametros("NomeBairro", this.strNomeBairro);
                    conexao.AddParametros("IdContato", this.strIdContato);
                    conexao.AddParametros("IdTipoContato", this.strIdTipoContato);
                    conexao.AddParametros("Tel_fixo1", this.strTel_fixo1);
                    conexao.AddParametros("Email", this.strEmail);
                    conexao.AddParametros("Celular_1", this.strCelular_1);
                    conexao.AddParametros("Tel_fixo2", this.strTel_fixo2);
                    conexao.AddParametros("Celular_2", this.strCelular_2);
                    conexao.AddParametros("Site", this.strSite);
                    conexao.AddParametros("Facabook", this.strFacabook);
                    conexao.AddParametros("Twitter", this.strTwitter);
                    conexao.AddParametros("Talk", this.strTalk);
                    conexao.CriarPedido("STP_SigePessoa_IncAlt", false);
                    string str2 = conexao.GetValor("RespostaPessoa", 0, 0);
                    if (str2 == null)
                    {
                        goto Label_035D;
                    }
                    if (!(str2 == "I"))
                    {
                        if (str2 == "A")
                        {
                            goto Label_02F3;
                        }
                        goto Label_035D;
                    }
                    strMsgRetorno = "Registro incluído com sucesso.";
                    strIdPessoaNew = conexao.GetValor("IdPessoa", 0, 0);
                    if (conexao.GetValor("RespostaEndereco", 0, 0) == "I")
                    {
                        strIdInternalEnderecoNew = conexao.GetValor("IdEndereco", 0, 0);
                    }
                    if (conexao.GetValor("RespostaContato", 0, 0) == "I")
                    {
                        strIdInternalContatoNew = conexao.GetValor("IdContato", 0, 0);
                    }
                    return true;
                Label_02F3:
                    strMsgRetorno = "Registro alterado com sucesso.";
                    if (conexao.GetValor("RespostaEndereco", 0, 0) == "I")
                    {
                        strIdInternalEnderecoNew = conexao.GetValor("IdEndereco", 0, 0);
                    }
                    if (conexao.GetValor("RespostaContato", 0, 0) == "I")
                    {
                        strIdInternalContatoNew = conexao.GetValor("IdContato", 0, 0);
                    }
                    return true;
                Label_035D:
                    strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                    flag = false;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public DataSet ListaFuncionario(string strIdEmpresa)
        {
            DataSet set2;
            DataSet set = new DataSet();
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
                set = AcessoBD.ObterDataSet("  Select SigePessoa.IdPessoa , TipoPfPj                , SigePessoa.IdUltimoUsuario                , SigeUsuarioUltimoUsuario.Login as DescUltimoUsuario                , SigeUsuario.Login as DescInclusorUsuario                , CONVERT(varchar,SigePessoa.UltimaAtualizacao,103)+' '+ CONVERT(varchar,SigePessoa.UltimaAtualizacao,108) as UltimaAtualizacao                , CONVERT(varchar,SigePessoa.DataInclusao,103)+' '+ CONVERT(varchar,SigePessoa.DataInclusao,108) as DataInclusao                , CnpjCpf                , NomePessoa                , SigePessoa.IdPais                , SigePais.Nome as DescPais                , SigePessoa.IdCidade                , SigeCidade.DescMunicipio                , Bairro                , Telefone                , Celular                , Email                , SiglaUf                From SigePessoa                Left Join SigeUsuario on SigeUsuario.IdUsuario = SigePessoa.IdInclusorUsuario                Left Join SigeUsuario as SigeUsuarioUltimoUsuario on SigeUsuarioUltimoUsuario.IdUsuario = SigePessoa.IdUltimoUsuario                Left Join SigePais on SigePais.IdPais = SigePessoa.IdPais                Left Join SigeCidade on SigeCidade.IdCidade = SigePessoa.IdCidade                Where SigePessoa.IdEmpresa = " + strIdEmpresa + " and SigePessoa.IdPessoa in (select idpessoa from SigeFuncionario where IdEmpresa = " + strIdEmpresa + "  )");
                set2 = set;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return set2;
        }

        public DataSet ListaPessoasDaEmpresa()
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                string sqlComand = " select SigePessoa.IdPessoa, SigePessoa.NomePessoa from SigePessoa where IdEmpresa = 1";
                set = AcessoBD.ObterDataSet(sqlComand);
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdPessoa", typeof(int));
                    table.Columns.Add("NomePessoa", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdPessoa"].ToString().Trim()), set.Tables[0].Rows[i]["NomePessoa"].ToString().Trim() });
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
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
                if (table != null)
                {
                    table.Dispose();
                }
            }
            return set3;
        }

        public bool Pesquisar(out string strMsgRetorno, string strCodigoRegistro)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdPessoa", this.strIdPessoa);
                    conexao.CriarPedido("STP_SigePessoa_Pes", false);
                    this.IdPessoa = conexao.GetValor("IdPessoa", 0, 0);
                    this.IdTipo = conexao.GetValor("IdTipo", 0, 0);
                    this.IdEmpresa = conexao.GetValor("IdEmpresa", 0, 0);
                    this.NomePessoa = conexao.GetValor("NomePessoa", 0, 0);
                    this.IdFuncao = conexao.GetValor("IdFuncao", 0, 0);
                    this.TipoPfPj = conexao.GetValor("TipoPfPj", 0, 0);
                    this.FlagPadraoSistema = conexao.GetValor("FlagPadraoSistema", 0, 0);
                    this.IdUltimoUsuario = conexao.GetValor("IdUltimoUsuario", 0, 0);
                    this.IdInclusorUsuario = conexao.GetValor("IdInclusorUsuario", 0, 0);
                    this.UltimaAtualizacao = conexao.GetValor("UltimaAtualizacao", 0, 0);
                    this.DataInclusao = conexao.GetValor("DataInclusao", 0, 0);
                    strMsgRetorno = "Pesquisa realizada com sucesso.";
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                strMsgRetorno = exception.Message;
                throw exception;
            }
            return flag;
        }

        // Properties
        public string Celular_1
        {
            get
            {
                return this.strCelular_1;
            }
            set
            {
                this.strCelular_1 = value;
            }
        }

        public string Celular_2
        {
            get
            {
                return this.strCelular_2;
            }
            set
            {
                this.strCelular_2 = value;
            }
        }

        public string Cep
        {
            get
            {
                return this.strCep;
            }
            set
            {
                this.strCep = value;
            }
        }

        public string DataInclusao
        {
            get
            {
                return this.strDataInclusao;
            }
            set
            {
                this.strDataInclusao = value;
            }
        }

        public string DescEndereco
        {
            get
            {
                return this.strDescEndereco;
            }
            set
            {
                this.strDescEndereco = value;
            }
        }

        public string Email
        {
            get
            {
                return this.strEmail;
            }
            set
            {
                this.strEmail = value;
            }
        }

        public string Facabook
        {
            get
            {
                return this.strFacabook;
            }
            set
            {
                this.strFacabook = value;
            }
        }

        public string FlagPadraoSistema
        {
            get
            {
                return this.strFlagPadraoSistema;
            }
            set
            {
                this.strFlagPadraoSistema = value;
            }
        }

        public string IdContato
        {
            get
            {
                return this.strIdContato;
            }
            set
            {
                this.strIdContato = value;
            }
        }

        public string IdEmpresa
        {
            get
            {
                return this.strIdEmpresa;
            }
            set
            {
                this.strIdEmpresa = value;
            }
        }

        public string IdEndereco
        {
            get
            {
                return this.strIdEndereco;
            }
            set
            {
                this.strIdEndereco = value;
            }
        }

        public string IdFuncao
        {
            get
            {
                return this.strIdFuncao;
            }
            set
            {
                this.strIdFuncao = value;
            }
        }

        public string IdInclusorUsuario
        {
            get
            {
                return this.strIdInclusorUsuario;
            }
            set
            {
                this.strIdInclusorUsuario = value;
            }
        }

        public string IdPessoa
        {
            get
            {
                return this.strIdPessoa;
            }
            set
            {
                this.strIdPessoa = value;
            }
        }

        public string IdTipo
        {
            get
            {
                return this.strIdTipo;
            }
            set
            {
                this.strIdTipo = value;
            }
        }

        public string IdTipoContato
        {
            get
            {
                return this.strIdTipoContato;
            }
            set
            {
                this.strIdTipoContato = value;
            }
        }

        public string IdUf
        {
            get
            {
                return this.strIdUf;
            }
            set
            {
                this.strIdUf = value;
            }
        }

        public string IdUltimoUsuario
        {
            get
            {
                return this.strIdUltimoUsuario;
            }
            set
            {
                this.strIdUltimoUsuario = value;
            }
        }

        public string NomeBairro
        {
            get
            {
                return this.strNomeBairro;
            }
            set
            {
                this.strNomeBairro = value;
            }
        }

        public string NomeCidade
        {
            get
            {
                return this.strNomeCidade;
            }
            set
            {
                this.strNomeCidade = value;
            }
        }

        public string NomePessoa
        {
            get
            {
                return this.strNomePessoa;
            }
            set
            {
                this.strNomePessoa = value;
            }
        }

        public string Numero
        {
            get
            {
                return this.strNumero;
            }
            set
            {
                this.strNumero = value;
            }
        }

        public string Site
        {
            get
            {
                return this.strSite;
            }
            set
            {
                this.strSite = value;
            }
        }

        public string Talk
        {
            get
            {
                return this.strTalk;
            }
            set
            {
                this.strTalk = value;
            }
        }

        public string Tel_fixo1
        {
            get
            {
                return this.strTel_fixo1;
            }
            set
            {
                this.strTel_fixo1 = value;
            }
        }

        public string Tel_fixo2
        {
            get
            {
                return this.strTel_fixo2;
            }
            set
            {
                this.strTel_fixo2 = value;
            }
        }

        public string TipoPfPj
        {
            get
            {
                return this.strTipoPfPj;
            }
            set
            {
                this.strTipoPfPj = value;
            }
        }

        public string Twitter
        {
            get
            {
                return this.strTwitter;
            }
            set
            {
                this.strTwitter = value;
            }
        }

        public string UltimaAtualizacao
        {
            get
            {
                return this.strUltimaAtualizacao;
            }
            set
            {
                this.strUltimaAtualizacao = value;
            }
        }
    }
}
