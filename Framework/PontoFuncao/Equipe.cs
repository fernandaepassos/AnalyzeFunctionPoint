using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.AcessoBancoDados;
using System;
using System.Data;

namespace Framework.PontoFuncao
{
    public class Equipe : ClassGenericPontoFuncao
    {

        private int _IdEquipe;
        
        [AtributoBancoDados(AtributoBD = true)]
        public int IdEquipe
        {
            get
            {
                return this._IdEquipe;
            }
            set
            {
                this._IdEquipe = value;
            }
        }

        private string _Nome;

        [AtributoBancoDados(AtributoBD = true)]
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

        private int _HoraPorPontoFuncao;

        [AtributoBancoDados(AtributoBD = true)]
        public int HoraPorPontoFuncao
        {
            get
            {
                return this._HoraPorPontoFuncao;
            }
            set
            {
                this._HoraPorPontoFuncao = value;
            }
        }

        private double _ValorPontoFuncao;

        [AtributoBancoDados(AtributoBD = true)]
        public double ValorPontoFuncao
        {
            get
            {
                return this._ValorPontoFuncao;
            }
            set
            {
                this._ValorPontoFuncao = value;
            }
        }

        public DataSet ListaEquipe()
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string strSql = "SELECT EQUIPE.* ";
                strSql += " , (SELECT COUNT(*) FROM EQUIPEPESSOA WHERE IDEQUIPE = EQUIPE.IDEQUIPE) AS QTDPESSOA ";
                strSql += " FROM EQUIPE ";

                set = AcessoBD.ObterDataSet(strSql);
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

        public DataSet ListaEquipeParaListagem()
        {
            DataSet set2 = new DataSet();
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            try
            {
                string strSql = "SELECT IDEQUIPE , NOME FROM EQUIPE ";

                set = AcessoBD.ObterDataSet(strSql);

                if (set != null && set.Tables.Count > 0 && set.Tables[0].Rows.Count > 0)
                {
                    table.Columns.Add("IDEQUIPE", typeof(int));
                    table.Columns.Add("NOME", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IDEQUIPE"].ToString().Trim()), set.Tables[0].Rows[i]["NOME"].ToString().Trim() });
                    }
                    set2.Tables.Add(table);
                    return set2;
                } return null;
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

        }
    }
}
