using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class Parceiro : ClassGenericAvaliacao
    {
        // Fields
        private int _IdParceiro;
        private int _IdPessoa;
        private int _IdUltimoUsuario;
        private string _UltimaAtualizacao;

        // Methods
        public int GetIdParceiro(int intIdPessoa)
        {
            int num;
            DataSet set = new DataSet();
            try
            {
                set = AcessoBD.ObterDataSet("select IdParceiro from Parceiro where IdPessoa = " + intIdPessoa);
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    return Convert.ToInt32(set.Tables[0].Rows[0][0].ToString().Trim());
                }
                num = 0;
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
            return num;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public int IdParceiro
        {
            get
            {
                return this._IdParceiro;
            }
            set
            {
                this._IdParceiro = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
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

        [AtributoBancoDados(AtributoBD=false)]
        public int IdUltimoUsuario
        {
            get
            {
                return this._IdUltimoUsuario;
            }
            set
            {
                this._IdUltimoUsuario = value;
            }
        }

        [AtributoBancoDados(AtributoBD=false)]
        public string UltimaAtualizacao
        {
            get
            {
                return this._UltimaAtualizacao;
            }
            set
            {
                this._UltimaAtualizacao = value;
            }
        }
    }
}
 
