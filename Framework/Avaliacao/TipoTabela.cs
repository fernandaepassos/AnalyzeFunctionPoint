
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class TipoTabela : ClassGenericAvaliacao
    {
        // Methods
        public DataSet ListaTipoPorTabelaCampo(string strTabela, string strCampo)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                if (strTabela == null)
                {
                    return null;
                }
                if (strTabela.Trim() == "")
                {
                    return null;
                }
                if (strCampo == null)
                {
                    return null;
                }
                if (strCampo.Trim() == "")
                {
                    return null;
                }
                string str2 = (" select Tipo.IdTipo " + " , Tipo.DescTipo ") + " from TipoTabela  " + " Left Join Tipo on Tipo.IdTipo = TipoTabela.IdTipo  ";
                set = AcessoBD.ObterDataSet(str2 + " where Tabela = '" + strTabela + "' and Campo = '" + strCampo + "' ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdTipo", typeof(int));
                    table.Columns.Add("DescTipo", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdTipo"].ToString().Trim()), set.Tables[0].Rows[i]["DescTipo"].ToString().Trim() });
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
    }
}
 
