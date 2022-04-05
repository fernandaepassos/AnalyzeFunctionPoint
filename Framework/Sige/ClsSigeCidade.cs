using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using System.Data;

using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Sige
{
    public class ClsSigeCidade
    {
        // Methods
        public DataSet GetCidadesAtivosPraVenda(string strUF = "", string strIdEmpresa = "", string strIdSistema = "")
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                if (string.IsNullOrEmpty(strUF) || (strUF.Trim() == "0"))
                {
                    return null;
                }
                if ((strIdSistema == null) || (strIdSistema.Trim() == ""))
                {
                    return null;
                }
                if ((strIdEmpresa == null) || (strIdEmpresa.Trim() == ""))
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(((((" Select SigeCidade.IdCidade, SigeCidade.DescMunicipio, EcomCidadeVende.IdEmpresa, EcomCidadeVende.IdSistema " + " from SigeCidade " + " left join EcomCidadeVende on EcomCidadeVende.IdCidade = SigeCidade.IdCidade  ") + " where UF = '" + strUF + "' ") + " and EcomCidadeVende.IdEmpresa = " + strIdEmpresa + " ") + " and EcomCidadeVende.IdSistema = " + strIdSistema + " ") + " order by SigeCidade.DescMunicipio asc ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdCidade", typeof(string));
                    table.Columns.Add("DescMunicipio", typeof(string));
                    table.Rows.Add(new object[] { "0", "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { set.Tables[0].Rows[i]["IdCidade"].ToString().Trim(), set.Tables[0].Rows[i]["DescMunicipio"].ToString().Trim() });
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
            }
            return set3;
        }

        public DataSet GetCidadesPorEstado(string strUF = "")
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (string.IsNullOrEmpty(strUF))
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(((" Select SigeCidade.IdCidade, SigeCidade.DescMunicipio" + " from SigeCidade ") + " where UF = '" + strUF + "' ") + " order by SigeCidade.DescMunicipio asc ");
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
    }
}