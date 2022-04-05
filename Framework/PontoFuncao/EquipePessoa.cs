using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.AcessoBancoDados;
using System;
using System.Data;

namespace Framework.PontoFuncao
{
    public class EquipePessoa : ClassGenericPontoFuncao
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

        private int _IdEquipePessoa;

        [AtributoBancoDados(AtributoBD = true)]
        public int IdEquipePessoa
        {
            get
            {
                return this._IdEquipePessoa;
            }
            set
            {
                this._IdEquipePessoa = value;
            }
        }

        private int _IdPessoa;

        [AtributoBancoDados(AtributoBD = true)]
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

        public DataSet ListaEquipePessoa(int intIdEquipe)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                string strSql = "SELECT IDEQUIPEPESSOA ";
                strSql += " , IDPESSOA ";
                strSql += " , IDEQUIPE ";
                strSql += " , (select nome from EQUIPE where IDEQUIPE = EQUIPEPESSOA.IDEQUIPE) AS NomeEquipe ";
                strSql += " , (select nome from PESSOA where IDPESSOA = EQUIPEPESSOA.IDPESSOA) as NomePessoa ";
                strSql += " FROM EQUIPEPESSOA ";
                strSql += " WHERE IDEQUIPE = " + intIdEquipe + " ";

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
    }
}
