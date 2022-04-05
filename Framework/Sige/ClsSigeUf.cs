using System;
using System.Data;
using Database;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;

namespace Framework.Sige
{
    public class ClsSigeUf
    {
        // Methods
        public static DataSet GetEstados(string strIdEmpresa = "")
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string sQL = " SELECT IdUf, NomeEstado FROM SigeUf ";
                if (!string.IsNullOrEmpty(strIdEmpresa))
                {
                    sQL = sQL + " WHERE IDEMPRESA = " + strIdEmpresa + " ";
                }
                sQL = sQL + " ORDER BY NomeEstado ";
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

        public DataSet GetEstadosAtivosPraVenda(string strIdEmpresa, string strIdSistema)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                if (string.IsNullOrEmpty(strIdEmpresa) || string.IsNullOrEmpty(strIdSistema))
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet((((" Select SigeUf.IdUf,  SigePais.IdPais, SigeUf.IdEmpresa, SigeUf.IdSistema, SigeUf.NomeEstado, SigeUf.Sigla " + " From SigeUf " + " left join SigePais on SigePais.IdEmpresa = SigeUf.IdEmpresa and SigePais.IdSistema = SigeUf.IdSistema ") + " where SigeUf.IdEmpresa = " + strIdEmpresa + " ") + " and SigeUf.IdSistema = " + strIdSistema + " ") + " and SigeUf.AtivoPraVenda = 1 " + " and SigePais.ativopravenda = 1 ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("Sigla", typeof(string));
                    table.Columns.Add("NomeEstado", typeof(string));
                    table.Rows.Add(new object[] { "0", "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { set.Tables[0].Rows[i]["Sigla"].ToString().Trim(), set.Tables[0].Rows[i]["NomeEstado"].ToString().Trim() });
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
                if (set2 != null)
                {
                    set2.Dispose();
                }
            }
            return set3;
        }
    }
}
