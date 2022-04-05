using System;
using Database;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.Rotinas;


namespace Framework.Sige
{
    public class ClsSigeEmpresa : Rotina
    {
        // Fields
        private string strCelular_1;
        private string strCelular_2;
        private string strCep;
        private string strCNPJ;
        private string strDataInclusao;
        private string strDescEndereco;
        private string strDescMissao;
        private string strDescSAC;
        private string strDescValores;
        private string strDescVisao;
        private string strEmail;
        private string strFacabook;
        private string strIdArquivoLogo;
        private string strIdContato;
        private string strIdEmpresa;
        private string strIdEmpresaContratante;
        private string strIdEmpresaSup;
        private string strIdEndereco;
        private string strIdInclusorUsuario;
        private string strIdTipo;
        private string strIdTipoContato;
        private string strIdUf;
        private string strIdUltimoUsuario;
        private string strInscMunicipal;
        private string strInsEstadual;
        private string strLinkedin;
        private string strNomeBairro;
        private string strNomeCidade;
        private string strNomeFantazia;
        private string strNumero;
        private string strObservacao;
        private string strQuemSomos;
        private string strRazaoSocial;
        private string strSite;
        private string strStatusAtivoInativo;
        private string strTalk;
        private string strTel_fixo1;
        private string strTel_fixo2;
        private string strTwitter;
        private string strUltimaAtualizacao;
        private string strYoutube;

        // Methods
        public bool Excluir(out string strMsgRetorno, string strCodigoRegistro)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdEmpresa", this.strIdEmpresa);
                    conexao.CriarPedido("STP_SigeEmpresa_Exc", false);
                    string str2 = conexao.GetValor("RESPOSTA", 0, 0);
                    if (str2 == null)
                    {
                        goto Label_0074;
                    }
                    if (!(str2 == "1"))
                    {
                        if (str2 == "2")
                        {
                            goto Label_006B;
                        }
                        goto Label_0074;
                    }
                    strMsgRetorno = "Registro excluído com sucesso.";
                    goto Label_007D;
                Label_006B:
                    strMsgRetorno = "Não foi possível excluir o registro.";
                    goto Label_007D;
                Label_0074:
                    strMsgRetorno = "Não foi possível incluir ou alterar o registro.";
                Label_007D:
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        public static DataSet GetClientes(string strIdEmpresaContratante)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (strIdEmpresaContratante.Trim() == "")
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet("  SELECT SigeEmpresa.IdEmpresa                , IdEmpresaContratante                , RazaoSocial                 , NomeFantazia                , CNPJ                , (CASE WHEN StatusAtivoInativo = 'A' THEN 'Ativo' ELSE CASE WHEN StatusAtivoInativo = 'I' THEN 'Inativo' END END) AS StatusAtivoInativo                 , (SELECT NomeEstado FROM SigeUf WHERE IdUf = SigeEndereco.IdUf) as Estado                , sigeEndereco.NomeCidade as Cidade                , SigeEndereco.NomeBairro as Bairro                , SigeContato.Celular_1 +'  '+ SigeContato.Celular_2 +'  '+ SigeContato.Tel_fixo1 +'  '+ SigeContato.Tel_fixo2 AS Telefone                , SigeContato.Email as Email                , (SELECT COUNT(*) FROM EcomVenda WHERE IdEmpresaCliente  = SIGEEMPRESA.IdEmpresa) as TotVendaPCliente                , (SELECT COUNT(*) FROM EcomCarrinho WHERE IdEmpresaCliente = SIGEEMPRESA.IdEmpresa) as TotCarrinhoPCliente                FROM SIGEEMPRESA                LEFT OUTER JOIN sigeEndereco ON sigeEndereco.IdEmpresa = SIGEEMPRESA.IdEmpresa                LEFT OUTER JOIN SigeContato ON SigeContato.IdEmpresa = SigeEmpresa.IdEmpresa                WHERE IdEmpresaContratante = " + strIdEmpresaContratante + " ");
                set2 = set;
            }
            catch (Exception exception)
            {
                throw exception;
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

        public static DataSet GetEmpresa(TipoDeEmpresas strTipoDaEmpresa)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string sQL = " SELECT SigeEmpresa.IdEmpresa, RazaoSocial";
                sQL = (sQL + " FROM SigeEmpresa, SigeTipo") + " WHERE  SigeEmpresa.IdTipo = sigeTipo.IdTipo" + " AND SigeEmpresa.StatusAtivoInativo = 'A'";
                if (!string.IsNullOrEmpty(strTipoDaEmpresa.ToString()))
                {
                    object obj2 = sQL;
                    sQL = string.Concat(new object[] { obj2, " AND SigeTipo.IdTipo IN (4, ", GetIdTypeCompan(strTipoDaEmpresa.ToString()), ")" });
                }
                sQL = sQL + " ORDER BY RazaoSocial";
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

        public static DataSet GetEmpresa(string strIdEmpresaContratante, string strStatusAtivoInativo, string strIdEmpresa = "")
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string sQL = " SELECT IdEmpresa, RazaoSocial";
                sQL = sQL + " FROM SigeEmpresa " + " WHERE  1=1 ";
                if (!string.IsNullOrEmpty(strIdEmpresaContratante.Trim()))
                {
                    string str2 = sQL;
                    sQL = str2 + " AND (IdEmpresaContratante = " + strIdEmpresaContratante + " OR IdEmpresa = " + strIdEmpresaContratante + ")   ";
                }
                if (!string.IsNullOrEmpty(strIdEmpresa.Trim()))
                {
                    sQL = sQL + " AND IdEmpresa = " + strIdEmpresa + " ";
                }
                if (!string.IsNullOrEmpty(strStatusAtivoInativo.Trim()))
                {
                    sQL = sQL + " AND SigeEmpresa.StatusAtivoInativo = '" + strStatusAtivoInativo.Trim() + "' ";
                }
                sQL = sQL + " ORDER BY RazaoSocial";
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

        public static DataSet GetEmpresa(string strIdEmpresa = "", string strIdEmpresaContratante = "", bool bolExibirAsFilhasDaEmpresaDoParametro = false, string strRazaoSocial = "", string strNomeFantasia = "", string strCnpj = "", string strIdTipo = "", string strIdStatus = "")
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string sQL = " select * from vwSigeEmpresaPesq where 1=1 ";
                if (!string.IsNullOrEmpty(strIdEmpresaContratante.Trim()))
                {
                    sQL = sQL + " AND IdEmpresaContratante = " + strIdEmpresaContratante.Trim() + " ";
                }
                if (!string.IsNullOrEmpty(strIdEmpresa.Trim()))
                {
                    string str2 = sQL;
                    sQL = str2 + "AND (IdEmpresa = " + strIdEmpresa + " or IdEmpresaContratante = " + strIdEmpresa + " )";
                }
                if (!string.IsNullOrEmpty(strRazaoSocial.Trim()))
                {
                    sQL = sQL + " AND RAZAOSOCIAL LIKE '%" + strRazaoSocial.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(strNomeFantasia.Trim()))
                {
                    sQL = sQL + " AND nomefantazia like '%" + strNomeFantasia.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(strCnpj.Trim()))
                {
                    sQL = sQL + " AND CNPJ like '%" + strCnpj.Trim().Replace(".", "").Replace("/", "").Replace("-", "").Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(strIdTipo.Trim()))
                {
                    sQL = sQL + " AND IdTipo = " + strIdTipo.Trim();
                }
                if (!string.IsNullOrEmpty(strIdStatus.Trim()))
                {
                    sQL = sQL + " AND lower(StatusAtivoInativo) = '" + strIdStatus.Trim().ToLower() + "'";
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

        public static DataSet GetEmpresaDetalhe(string strIdEmpresa)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string sQL = " select * from vwSigeEmpresaPesqDetalhe where 1=1 ";
                if (!string.IsNullOrEmpty(strIdEmpresa.Trim()))
                {
                    sQL = sQL + " AND IDEMPRESA = " + strIdEmpresa.Trim() + " ";
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

        public static DataSet GetEmpresaPorTipoEContratante(string strIdEmpresa, string strIdTipo)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string sQL = " select IdEmpresa, (CASE WHEN RazaoSocial IS NULL THEN NomeFantazia ELSE RazaoSocial END ) as Nome from SigeEmpresa where 1=1 ";
                if (strIdTipo.Trim() != "")
                {
                    sQL = sQL + " AND IdTipo = " + strIdTipo + " ";
                }
                if (strIdEmpresa.Trim() != "")
                {
                    sQL = sQL + " AND IdEmpresaContratante = " + strIdEmpresa + " ";
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

        private static int GetIdTypeCompan(string strTipoDaEmpresa)
        {
            int num;
            try
            {
                switch (strTipoDaEmpresa)
                {
                    case "Cliente1":
                        return 1;

                    case "Fornecedor2":
                        return 2;

                    case "Parceiro3":
                        return 3;

                    case "Proprietária4":
                        return 4;

                    case "Todas":
                        return 0;
                }
                num = 1;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }

        public static string GetNomeEmpresa(string strIdEmpresa)
        {
            string str;
            DataSet set = new DataSet();
            try
            {
                if (strIdEmpresa == null)
                {
                    return "";
                }
                if (strIdEmpresa.Trim() == "")
                {
                    return "";
                }
                set = AcessoBD.ObterDataSet("select case when RazaoSocial is null then NomeFantazia else RazaoSocial end as NomeEmpresa from SigeEmpresa where idempresa = " + strIdEmpresa);
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    return set.Tables[0].Rows[0]["NomeEmpresa"].ToString().Trim();
                }
                str = "";
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
            }
            return str;
        }

        public int GetTotCarrinhoPorCliente(string strIdEmpresa)
        {
            int num;
            DataSet set = new DataSet();
            try
            {
                set = AcessoBD.ObterDataSet("SELECT COUNT(*) as TotCarrinhoPCliente FROM EcomCarrinho WHERE IdEmpresaCliente = " + strIdEmpresa.Trim());
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    return Convert.ToInt32(set.Tables[0].Rows[0]["TotCarrinhoPCliente"].ToString().Trim());
                }
                num = 0;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
            }
            return num;
        }

        public int GetTotVendasPorCliente(string strIdEmpresa)
        {
            int num;
            DataSet set = new DataSet();
            try
            {
                set = AcessoBD.ObterDataSet("SELECT COUNT(*) as TotVendaPCliente FROM EcomVenda WHERE IdEmpresaCliente = " + strIdEmpresa.Trim());
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    return Convert.ToInt32(set.Tables[0].Rows[0]["TotVendaPCliente"].ToString().Trim());
                }
                num = 0;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
            }
            return num;
        }

        public string GetUrlLogo(string strIdEmpresa)
        {
            string str;
            DataSet set = new DataSet();
            try
            {
                if (strIdEmpresa.Trim() == "")
                {
                    return "";
                }
                set = AcessoBD.ObterDataSet("SELECT Arquivo FROM SigeArquivo WHERE IdArquivo IN (SELECT IdArquivo FROM SigeArquivoVinculo WHERE NomeTabela = 'SigeEmpresa' AND IdRegistroTabela = " + strIdEmpresa.Trim() + " )");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    return set.Tables[0].Rows[0][0].ToString().Trim();
                }
                str = "~/Files/SckEcommerce/logomarcas/LogoPendente.png";
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
            }
            return str;
        }

        public bool Gravar(out string strMsgRetorno, out string strIdEmpresaNew, out string strIdInternalEnderecoNew, out string strIdInternalContatoNew)
        {
            bool flag;
            strMsgRetorno = "";
            strIdEmpresaNew = "";
            strIdInternalEnderecoNew = "";
            strIdInternalContatoNew = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdEmpresa", this.strIdEmpresa);
                    conexao.AddParametros("IdEmpresaSup", this.strIdEmpresaSup);
                    conexao.AddParametros("IdEmpresaContratante", this.strIdEmpresaContratante);
                    conexao.AddParametros("RazaoSocial", this.strRazaoSocial);
                    conexao.AddParametros("NomeFantazia", this.strNomeFantazia);
                    conexao.AddParametros("CNPJ", this.strCNPJ);
                    conexao.AddParametros("InscMunicipal", this.strInscMunicipal);
                    conexao.AddParametros("InsEstadual", this.strInsEstadual);
                    conexao.AddParametros("IdUltimoUsuario", this.strIdUltimoUsuario);
                    conexao.AddParametros("IdInclusorUsuario", this.strIdInclusorUsuario);
                    conexao.AddParametros("UltimaAtualizacao", this.strUltimaAtualizacao);
                    conexao.AddParametros("DataInclusao", this.strDataInclusao);
                    conexao.AddParametros("IdTipo", this.strIdTipo);
                    conexao.AddParametros("StatusAtivoInativo", this.strStatusAtivoInativo);
                    conexao.AddParametros("DescMissao", this.strDescMissao);
                    conexao.AddParametros("DescVisao", this.strDescVisao);
                    conexao.AddParametros("DescValores", this.strDescValores);
                    conexao.AddParametros("Observacao", this.strObservacao);
                    conexao.AddParametros("IdArquivoLogo", this.strIdArquivoLogo);
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
                    conexao.AddParametros("QuemSomos", this.strQuemSomos);
                    conexao.AddParametros("DescSAC", this.strDescSAC);
                    conexao.AddParametros("Youtube", this.strYoutube);
                    conexao.AddParametros("Linkedin", this.strLinkedin);
                    conexao.CriarPedido("STP_SigeEmpresa_IncAlt", false);
                    string str = "";
                    string str2 = "";
                    string str3 = "";
                    str = conexao.GetValor("RespostaEmpresa", 0, 0);
                    str2 = conexao.GetValor("CnpjExistePraOutraEmpresa", 0, 0);
                    if (!(!(str2.Trim() != "") || str2.Trim().Contains("{")))
                    {
                        strMsgRetorno = "O Cnpj " + this.CNPJ + " já encontra-se cadastrado <br/> para a empresa " + str2 + ". <br/> ";
                        return false;
                    }
                    str3 = conexao.GetValor("RazaoSocialExistePraOutraEmpresa", 0, 0);
                    if (!(!(str3.Trim() != "") || str3.Trim().Contains("{")))
                    {
                        strMsgRetorno = "O sistema identificou que a Razão Social " + str3 + " já existe cadastrada no sistema. ";
                        return false;
                    }
                    string str4 = str;
                    if (str4 == null)
                    {
                        goto Label_051E;
                    }
                    if (!(str4 == "I"))
                    {
                        if (str4 == "A")
                        {
                            goto Label_04B3;
                        }
                        goto Label_051E;
                    }
                    strMsgRetorno = "Registro incluído com sucesso.";
                    strIdEmpresaNew = conexao.GetValor("IdEmpresa", 0, 0);
                    if (conexao.GetValor("RespostaEndereco", 0, 0) == "I")
                    {
                        strIdInternalEnderecoNew = conexao.GetValor("IdEndereco", 0, 0);
                    }
                    if (conexao.GetValor("RespostaContato", 0, 0) == "I")
                    {
                        strIdInternalContatoNew = conexao.GetValor("IdContato", 0, 0);
                    }
                    return true;
                Label_04B3:
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
                Label_051E:
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

        public DataSet ListaEmpresa(string strIdEmpresaContratante)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                string str = " SELECT IdEmpresa, RazaoSocial";
                str = str + " FROM SigeEmpresa " + " WHERE  1=1 ";
                if (!string.IsNullOrEmpty(strIdEmpresaContratante.Trim()))
                {
                    string str2 = str;
                    str = str2 + " AND (IdEmpresaContratante = " + strIdEmpresaContratante + " OR IdEmpresa = " + strIdEmpresaContratante + ")   ";
                }
                set = AcessoBD.ObterDataSet(str + " ORDER BY RazaoSocial");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdEmpresa", typeof(int));
                    table.Columns.Add("RazaoSocial", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdEmpresa"].ToString().Trim()), set.Tables[0].Rows[i]["RazaoSocial"].ToString().Trim() });
                    }
                    set2.Tables.Add(table);
                    return set2;
                }
                set3 = null;
            }
            catch (Exception exception)
            {
                throw exception;
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

        public DataSet ListaEmpresaConceitoPessoaEmpresa(string strIdEmpresa)
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
                set = AcessoBD.ObterDataSet(" Select SigePessoa.IdPessoa                , TipoPfPj                , SigePessoa.IdUltimoUsuario                , SigeUsuarioUltimoUsuario.Login as DescUltimoUsuario                , SigeUsuario.Login as DescInclusorUsuario                , CONVERT(varchar,SigePessoa.UltimaAtualizacao,103)+' '+ CONVERT(varchar,SigePessoa.UltimaAtualizacao,108) as UltimaAtualizacao                , CONVERT(varchar,SigePessoa.DataInclusao,103)+' '+ CONVERT(varchar,SigePessoa.DataInclusao,108) as DataInclusao                , CnpjCpf                , RazaoSocial                , NomeFantasia                , NomeDoResponsalvel                , SigePessoa.IdPais                , SigePais.Nome as DescPais                , SigePessoa.IdCidade                , SigeCidade.DescMunicipio                , Bairro                , Telefone                , Celular                , Email                , SiglaUf                From SigePessoa                Left Join SigeUsuario on SigeUsuario.IdUsuario = SigePessoa.IdInclusorUsuario                Left Join SigeUsuario as SigeUsuarioUltimoUsuario on SigeUsuarioUltimoUsuario.IdUsuario = SigePessoa.IdUltimoUsuario                Left Join SigePais on SigePais.IdPais = SigePessoa.IdPais                Left Join SigeCidade on SigeCidade.IdCidade = SigePessoa.IdCidade                Where SigePessoa.IdPessoa = (select IdPessoa from SigeEmpresa where IdEmpresa = " + strIdEmpresa + " )");
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

        public bool Pesquisar(out string strMsgRetorno, string strCodigoRegistro)
        {
            bool flag;
            strMsgRetorno = "";
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdEmpresa", this.strIdEmpresa);
                    conexao.CriarPedido("STP_SigeEmpresa_Pes", false);
                    this.IdEmpresa = conexao.GetValor("IdEmpresa", 0, 0);
                    this.IdEmpresaSup = conexao.GetValor("IdEmpresaSup", 0, 0);
                    this.IdEmpresaContratante = conexao.GetValor("IdEmpresaContratante", 0, 0);
                    this.RazaoSocial = conexao.GetValor("RazaoSocial", 0, 0);
                    this.NomeFantazia = conexao.GetValor("NomeFantazia", 0, 0);
                    this.CNPJ = conexao.GetValor("CNPJ", 0, 0);
                    this.InscMunicipal = conexao.GetValor("InscMunicipal", 0, 0);
                    this.InsEstadual = conexao.GetValor("InsEstadual", 0, 0);
                    this.IdContato = conexao.GetValor("IdContato", 0, 0);
                    this.IdEndereco = conexao.GetValor("IdEndereco", 0, 0);
                    this.IdUltimoUsuario = conexao.GetValor("IdUltimoUsuario", 0, 0);
                    this.IdInclusorUsuario = conexao.GetValor("IdInclusorUsuario", 0, 0);
                    this.UltimaAtualizacao = conexao.GetValor("UltimaAtualizacao", 0, 0);
                    this.DataInclusao = conexao.GetValor("DataInclusao", 0, 0);
                    this.IdTipo = conexao.GetValor("IdTipo", 0, 0);
                    this.StatusAtivoInativo = conexao.GetValor("StatusAtivoInativo", 0, 0);
                    this.DescMissao = conexao.GetValor("DescMissao", 0, 0);
                    this.DescVisao = conexao.GetValor("DescVisao", 0, 0);
                    this.DescValores = conexao.GetValor("DescValores", 0, 0);
                    this.Observacao = conexao.GetValor("Observacao", 0, 0);
                    this.IdArquivoLogo = conexao.GetValor("IdArquivoLogo", 0, 0);
                    strMsgRetorno = "Pesquisa realizada com sucesso.";
                    flag = true;
                }
            }
            catch (Exception exception)
            {
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

        public string CNPJ
        {
            get
            {
                return this.strCNPJ;
            }
            set
            {
                this.strCNPJ = value;
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

        public string DescMissao
        {
            get
            {
                return this.strDescMissao;
            }
            set
            {
                this.strDescMissao = value;
            }
        }

        public string DescSAC
        {
            get
            {
                return this.strDescSAC;
            }
            set
            {
                this.strDescSAC = value;
            }
        }

        public string DescValores
        {
            get
            {
                return this.strDescValores;
            }
            set
            {
                this.strDescValores = value;
            }
        }

        public string DescVisao
        {
            get
            {
                return this.strDescVisao;
            }
            set
            {
                this.strDescVisao = value;
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

        public string IdArquivoLogo
        {
            get
            {
                return this.strIdArquivoLogo;
            }
            set
            {
                this.strIdArquivoLogo = value;
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

        public string IdEmpresaContratante
        {
            get
            {
                return this.strIdEmpresaContratante;
            }
            set
            {
                this.strIdEmpresaContratante = value;
            }
        }

        public string IdEmpresaSup
        {
            get
            {
                return this.strIdEmpresaSup;
            }
            set
            {
                this.strIdEmpresaSup = value;
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

        public string InscMunicipal
        {
            get
            {
                return this.strInscMunicipal;
            }
            set
            {
                this.strInscMunicipal = value;
            }
        }

        public string InsEstadual
        {
            get
            {
                return this.strInsEstadual;
            }
            set
            {
                this.strInsEstadual = value;
            }
        }

        public string Linkedin
        {
            get
            {
                return this.strLinkedin;
            }
            set
            {
                this.strLinkedin = value;
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

        public string NomeFantazia
        {
            get
            {
                return this.strNomeFantazia;
            }
            set
            {
                this.strNomeFantazia = value;
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

        public string Observacao
        {
            get
            {
                return this.strObservacao;
            }
            set
            {
                this.strObservacao = value;
            }
        }

        public string QuemSomos
        {
            get
            {
                return this.strQuemSomos;
            }
            set
            {
                this.strQuemSomos = value;
            }
        }

        public string RazaoSocial
        {
            get
            {
                return this.strRazaoSocial;
            }
            set
            {
                this.strRazaoSocial = value;
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

        public string StatusAtivoInativo
        {
            get
            {
                return this.strStatusAtivoInativo;
            }
            set
            {
                this.strStatusAtivoInativo = value;
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

        public string Youtube
        {
            get
            {
                return this.strYoutube;
            }
            set
            {
                this.strYoutube = value;
            }
        }

        // Nested Types
        public enum TipoDeEmpresas
        {
            Cliente1,
            Fornecedor2,
            Parceiro3,
            Proprietária4,
            Todas
        }
    }
}
