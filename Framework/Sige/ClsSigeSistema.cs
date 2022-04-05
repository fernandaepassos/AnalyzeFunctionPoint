using System;
using Framework.Reflection.AcessoBancoDados;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection;

using Database;


namespace Framework.Sige
{
    public class ClsSigeSistema
    {
        // Methods
        public static string GetNomeSistema(string strIdEmpresa)
        {
            string str2;
            DataSet set = new DataSet();
            try
            {
                if (string.IsNullOrEmpty(strIdEmpresa))
                {
                    return "";
                }
                set = AcessoBD.ObterDataSet(" select NomeSistema from SigeSistema where idsistema = " + strIdEmpresa + " ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    return set.Tables[0].Rows[0]["NomeSistema"].ToString().Trim();
                }
                str2 = "";
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return str2;
        }

        public static DataSet GetSistema(int intIdCliente = 0)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                string sqlComand = " SELECT IdSistema, NomeSistema +' ['+ SigeStatus.NomeStatus + ']' as NomeSistema";
                sqlComand = sqlComand + " FROM SigeSistema, SigeStatus " + " WHERE SigeSistema.IdStatus = SigeStatus.IdStatus ";
                if (intIdCliente != 0)
                {
                    object obj2 = sqlComand;
                    sqlComand = string.Concat(new object[] { obj2, " AND IdSistema IN (SELECT IdSistema FROM SigeSistemaEmpresa WHERE IdEmpresa = ", intIdCliente, ") " });
                }
                set = AcessoBD.ObterDataSet(sqlComand);
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdSistema", typeof(int));
                    table.Columns.Add("NomeSistema", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdSistema"].ToString().Trim()), set.Tables[0].Rows[i]["NomeSistema"].ToString().Trim() });
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

        public static DataSet GetSistemaPorEmpresa(string strIdEmpresa)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (string.IsNullOrEmpty(strIdEmpresa))
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" select SigeSistema.IdSistema                , SigeSistema.NomeSistema                from SigeSistemaEmpresa                left join SigeSistema on SigeSistema.IdSistema = SigeSistemaEmpresa.IdSistema                where SigeSistemaEmpresa.IdEmpresa  = " + strIdEmpresa + " ");
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

        public static DataSet GetSistemaPorUsuario(int idUsuario)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (idUsuario <= 0)
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" select IdSistema, NomeSistema from SigeSistema where IdSistema in (select IdSistema from SigeUsuarioSistema where IdUsuario = " + idUsuario + ") ");
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

        public static DataSet GetSistemPraTree()
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string sQL = " SELECT IdSistema,  NomeSistema  FROM SigeSistema  ";
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

        // Properties
        public DateTime DataInclusao { get; set; }

        public string FlagPadroSistema { get; set; }

        public int IdInclusorUsuario { get; set; }

        public int IdSistema { get; set; }

        public int IdSistemaSup { get; set; }

        public int IdStatus { get; set; }

        public int IdUltimoUsuario { get; set; }

        public string NomeSistema { get; set; }

        public DateTime UltimaAtualizacao { get; set; }
    }
}
