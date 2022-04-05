using System;
using System.Data;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Sige
{
    public class ClsSigeStatus
    {
        // Methods
        public static DataSet GetStatus(string strNomeTabela)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                string str = " SELECT SigeStatus.IdStatus, NomeStatus";
                str = str + " FROM SigeStatus, SigeStatusTabela" + " WHERE SigeStatus.IdStatus = SigeStatusTabela.IdStatus";
                if (!string.IsNullOrEmpty(strNomeTabela))
                {
                    str = str + " AND SigeStatusTabela.NomeTabela = '" + strNomeTabela.Trim() + "'";
                }
                set = AcessoBD.ObterDataSet(str + " ORDER BY SigeStatus.IdStatus");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdStatus", typeof(int));
                    table.Columns.Add("NomeStatus", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdStatus"].ToString().Trim()), set.Tables[0].Rows[i]["NomeStatus"].ToString().Trim() });
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

        public static DataSet GetStatus(string strNomeTabela, string strCampo)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if ((strNomeTabela.Trim() == "") || (strCampo.Trim() == ""))
                {
                    return null;
                }
                string str = " Select IdStatus, DescStatus ";
                string str2 = str + " from Status ";
                set = AcessoBD.ObterDataSet(str2 + " where IdStatus in (select IdStatus from StatusTabela where Tabela = '" + strNomeTabela + "' and Campo = '" + strCampo + "') ");
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

        // Properties
        public DateTime DataInclusao { get; set; }

        public string FlagPadraoSistema { get; set; }

        public int IdInclusorUsuario { get; set; }

        public int IdStatus { get; set; }

        public int IdUltimoUsuario { get; set; }

        public string NomeStatus { get; set; }

        public DateTime UltimaAtualizacao { get; set; }

        // Nested Types
        public enum TipoDeStatus
        {
            PrjProjeto,
            SigeSistema,
            VistOrdemServico
        }
    }

}
