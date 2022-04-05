using System;
using Framework.Reflection.AcessoBancoDados;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using Database;

namespace Framework.Sige
{
    public class ClsSigeArquivo
    {
        // Fields
        private static int intIdArquivo = 0;

        // Methods
        public bool Excluir(out string strMensagem, string strPathFile = "")
        {
            bool flag2;
            strMensagem = "";
            bool flag = true;
            try
            {
                if ((intIdArquivo <= 0) || (intIdArquivo <= 0))
                {
                    strMensagem = "Selecionar o arquivo para exclusão.";
                    return false;
                }
                try
                {
                    if (!string.IsNullOrEmpty(strPathFile) && File.Exists(strPathFile))
                    {
                        File.Delete(strPathFile);
                    }
                }
                catch
                {
                }
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdArquivo", intIdArquivo.ToString());
                    conexao.CriarPedido("STP_SigeArquivo_Exc", false);
                    string str2 = conexao.GetValor("RESPOSTA", 0, 0);
                    if (str2 == null)
                    {
                        goto Label_00E8;
                    }
                    if (!(str2 == "1"))
                    {
                        if (str2 == "2")
                        {
                            goto Label_00DD;
                        }
                        goto Label_00E8;
                    }
                    strMensagem = "Registro excluído com sucesso.";
                    this.IdArquivo = 0;
                    this.IdArquivoVinculo = 0;
                    flag = true;
                    goto Label_00F3;
                Label_00DD:
                    strMensagem = "Não foi possível excluir o registro.";
                    flag = false;
                    goto Label_00F3;
                Label_00E8:
                    strMensagem = "Não foi possível excluir o registro.";
                    flag = false;
                Label_00F3:
                    flag2 = true;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }

        public static DataSet GetArquivo(string strNomeDaTabela, int intIdIdentificadorRegistro)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if ((intIdIdentificadorRegistro <= 0) || (strNomeDaTabela.Trim() == ""))
                {
                    return null;
                }
                string sQL = " SELECT * FROM vwSigeArquivoPesq ";
                if ((strNomeDaTabela.Trim() != "") && (intIdIdentificadorRegistro > 0))
                {
                    object obj2 = ((sQL + " WHERE      ") + "IdArquivo IN   " + "(") + "SELECT     IdArquivo  " + "FROM          SigeArquivoVinculo  ";
                    sQL = (string.Concat(new object[] { obj2, "WHERE      IdRegistroTabela = ", intIdIdentificadorRegistro, "  " }) + "AND NomeTabela = '" + strNomeDaTabela + "' ") + ") ";
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

        public static DataSet GetArquivo_(string strNomeDaTabela, int intIdIdentificadorRegistro)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if ((intIdIdentificadorRegistro <= 0) || (strNomeDaTabela.Trim() == ""))
                {
                    return null;
                }
                string sqlComand = " SELECT * FROM vwSigeArquivoPesq ";
                if ((strNomeDaTabela.Trim() != "") && (intIdIdentificadorRegistro > 0))
                {
                    object obj2 = ((sqlComand + " WHERE      ") + "IdArquivo IN   " + "(") + "SELECT     IdArquivo  " + "FROM          SigeArquivoVinculo  ";
                    sqlComand = (string.Concat(new object[] { obj2, "WHERE      IdRegistroTabela = ", intIdIdentificadorRegistro, "  " }) + "AND NomeTabela = '" + strNomeDaTabela + "' ") + ") ";
                }
                set = AcessoBD.ObterDataSet(sqlComand);
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

        public static DataSet GetArquivoDeProjetoPorEmpresa(string strIdEmpresa)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (string.IsNullOrEmpty(strIdEmpresa))
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet("  select idprojeto  , titulo                 , SigeStatus.NomeStatus                 , SigeEmpresa.RazaoSocial                 , SigeSistema.NomeSistema                  , SigeArquivo.NomeArquivo                , SigeArquivo.Arquivo                 , SigeArquivo.IdArquivo                , SigeArquivo.IdTipoArquivoProjeto                 , PrjProjeto.IdEmpresa                , PrjProjeto.IdSistema                 , SigeTipo.NomeTipo                 , SigeTipo.IdTipo                , CONVERT(varchar,SigeArquivo.DataInclusao, 103)+' '+ CONVERT(varchar,SigeArquivo.DataInclusao, 108) as DataInclusao                from PrjProjeto                 left join sigestatus on SigeStatus.IdStatus = PrjProjeto.IdStatus                left join SigeEmpresa on SigeEmpresa.IdEmpresa = PrjProjeto.IdEmpresa                left join SigeSistema on SigeSistema.IdSistema = PrjProjeto.IdSistema                left outer join SigeArquivoVinculo on SigeArquivoVinculo.IdEmpresa = PrjProjeto.IdEmpresa and SigeArquivoVinculo.IdRegistroTabela = PrjProjeto.IdProjeto and SigeArquivoVinculo.NomeTabela = 'PrjProjeto'                left outer join SigeArquivo on SigeArquivo.IdArquivo = SigeArquivoVinculo.IdArquivo                left outer join SigeTipo on SigeTipo.IdTipo = SigeArquivo.IdTipoArquivoProjeto                where PrjProjeto.idempresa = " + strIdEmpresa + "  ");
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

        public static string GetArquivosParaExibicao(string strExibirSouN, string strIDREGISTROTABELA, string strNOMETABELA)
        {
            string str3;
            DataSet set = new DataSet();
            try
            {
                string sQL = "SELECT Arquivo, idtipo ";
                sQL = ((((((sQL + " FROM SIGEARQUIVO  ") + " WHERE ExibirImpresso = '" + strExibirSouN + "' ") + " AND IdArquivo " + " IN (") + " SELECT IDARQUIVO " + " FROM SigeArquivoVinculo ") + " WHERE NOMETABELA = '" + strNOMETABELA + "' ") + " AND IDREGISTROTABELA = " + strIDREGISTROTABELA) + " ) ";
                string str2 = "";
                using (Conexao conexao = new Conexao())
                {
                    set = conexao.ExecSQL(sQL);
                    if (((set != null) & (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                    {
                        for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                        {
                            string str4 = str2;
                            str2 = str4 + set.Tables[0].Rows[i]["Arquivo"].ToString().Trim() + "-" + set.Tables[0].Rows[i]["idtipo"].ToString().Trim() + ",";
                        }
                        return str2.Substring(0, str2.Length - 1);
                    }
                    str3 = "";
                }
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
            return str3;
        }

        public bool InsereArquivo(out string strMensagem)
        {
            bool flag2;
            bool flag = true;
            try
            {
                if (!this.Validacao(out strMensagem))
                {
                    return false;
                }
                using (Conexao conexao = new Conexao())
                {
                    conexao.AddParametros("IdArquivo", "0");
                    conexao.AddParametros("NomeArquivo", this.NomeArquivo);
                    conexao.AddParametros("Arquivo", this.Arquivo);
                    conexao.AddParametros("IdEmpresa", this.IdEmpresa.ToString());
                    conexao.AddParametros("NomeTipoArquivo", this.NomeTipoArquivo);
                    conexao.AddParametros("LenMbArquivo", this.LenMbArquivo);
                    conexao.AddParametros("DataInclusao", "");
                    conexao.AddParametros("UltimaAtualizacao", "");
                    conexao.AddParametros("IdInclusorUsuario", this.IdInclusorUsuario.ToString());
                    conexao.AddParametros("IdUltimoUsuario", this.IdInclusorUsuario.ToString());
                    conexao.AddParametros("NomeTabela", this.NomeTabela);
                    conexao.AddParametros("IdRegistroTabela", this.IdRegistroTabela.ToString());
                    conexao.AddParametros("IdTipo", this.IdTipo);
                    conexao.CriarPedido("STP_SigeArquivo_IncAlt", false);
                    string str2 = conexao.GetValor("RESPOSTA", 0, 0);
                    if (str2 == null)
                    {
                        goto Label_0181;
                    }
                    if (!(str2 == "I"))
                    {
                        if (str2 == "A")
                        {
                            goto Label_0176;
                        }
                        goto Label_0181;
                    }
                    strMensagem = "Registro incluído com sucesso.";
                    flag = true;
                    goto Label_01A1;
                Label_0176:
                    strMensagem = "Registro alterado com sucesso. ";
                    flag = true;
                    goto Label_01A1;
                Label_0181:
                    strMensagem = "Não foi possível incluir ou alterar o registro.";
                    flag = false;
                }
            Label_01A1:
                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }

        public void SetExibirArquivoEmImpressos(string strIdArquivo, string strSorN)
        {
            try
            {
                if (!string.IsNullOrEmpty(strIdArquivo) && !string.IsNullOrEmpty(strSorN))
                {
                    using (Conexao conexao = new Conexao())
                    {
                        conexao.ExecSQL("UPDATE SigeArquivo SET ExibirImpresso = '" + strSorN + "' WHERE IdArquivo = " + strIdArquivo);
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private int SetMaxId()
        {
            int num;
            DataSet set = new DataSet();
            try
            {
                using (Conexao conexao = new Conexao())
                {
                    set = conexao.ExecSQL("SELECT MAX(IdArquivo) AS IDMAX FROM SigeArquivo");
                }
                if ((set.Tables != null) && (set.Tables[0].Rows.Count > 0))
                {
                    this.IdArquivo = Convert.ToInt32(set.Tables[0].Rows[0][0].ToString());
                    return Convert.ToInt32(set.Tables[0].Rows[0][0].ToString());
                }
                num = 0;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return num;
        }

        private bool Validacao(out string strMensagem)
        {
            bool flag2;
            strMensagem = "";
            bool flag = true;
            try
            {
                if (string.IsNullOrEmpty(this.NomeTabela))
                {
                    strMensagem = "Informe o nome tabela onde esse arquivo se associa.";
                    flag = false;
                }
                if (this.IdRegistroTabela <= 0)
                {
                    strMensagem = "Informe o código identificador do registro da tabela.";
                    flag = false;
                }
                if (string.IsNullOrEmpty(this.NomeArquivo.Trim()))
                {
                    strMensagem = "Informe o nome do arquivo.";
                    flag = false;
                }
                if (string.IsNullOrEmpty(this.Arquivo.Trim()))
                {
                    strMensagem = "Selecione o arquivo.";
                    flag = false;
                }
                if (this.IdEmpresa <= 0)
                {
                    strMensagem = "Informe o código da empresa.";
                    flag = false;
                }
                if (string.IsNullOrEmpty(this.NomeTipoArquivo.Trim()))
                {
                    strMensagem = "Informe o tipo do arquivo (Ex: xls | docx | pdf ...). ";
                    flag = false;
                }
                try
                {
                    if (string.IsNullOrEmpty(this.LenMbArquivo.Trim()))
                    {
                        strMensagem = "Informe o tamanho do arquivo. ";
                        flag = false;
                    }
                    else if (Convert.ToInt32(this.LenMbArquivo.Trim()) > 0x989680)
                    {
                        strMensagem = "O tamanho do arquivo excede 10MB.";
                        flag = false;
                    }
                }
                catch
                {
                }
                if (this.IdInclusorUsuario <= 0)
                {
                    this.IdInclusorUsuario = 12;
                }
                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag2;
        }

        // Properties
        public string Arquivo { get; set; }

        public DateTime DataInclusao { get; set; }

        public int IdArquivo
        {
            get
            {
                return intIdArquivo;
            }
            set
            {
                intIdArquivo = value;
            }
        }

        public int IdArquivoVinculo { get; set; }

        public int IdEmpresa { get; set; }

        public int IdInclusorUsuario { get; set; }

        public int IdRegistroTabela { get; set; }

        public string IdTipo { get; set; }

        public int IdUltimoUsuario { get; set; }

        public string LenMbArquivo { get; set; }

        public string NomeArquivo { get; set; }

        public string NomeTabela { get; set; }

        public string NomeTipoArquivo { get; set; }

        public DateTime UltimaAtualizacao { get; set; }
    }
}
