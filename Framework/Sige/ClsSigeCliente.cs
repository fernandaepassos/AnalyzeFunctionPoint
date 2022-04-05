using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Sige
{
    public class ClsSigeCliente
    {
        // Fields
        private int _FlagInativo;
        private int _IdCliente;
        private int _IdPessoa;
        private int _IdTipo;
        private int _IdUltimoUsuario;
        private string _UltimaAtualizacao;

        // Methods
        public void Excluir(ClsSigeCliente objClasse, int id)
        {
            try
            {
                if (id > 0)
                {
                    AcessoBD.DeleteRegistro(objClasse, id);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public int GetIdCliente(int intIdPessoa)
        {
            int num;
            DataSet set = new DataSet();
            try
            {
                set = AcessoBD.ObterDataSet("select IdCliente from SigeCliente where idpessoa = " + intIdPessoa);
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    return Convert.ToInt32(set.Tables[0].Rows[0][0].ToString().Trim());
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

        public int Salvar(ClsSigeCliente objSigeCliente, int id)
        {
            int num2;
            try
            {
                num2 = AcessoBD.InsertUpdateRegistro(objSigeCliente, id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public int FlagInativo
        {
            get
            {
                return this._FlagInativo;
            }
            set
            {
                this._FlagInativo = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdCliente
        {
            get
            {
                return this._IdCliente;
            }
            set
            {
                this._IdCliente = value;
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

        [AtributoBancoDados(AtributoBD=true)]
        public int IdTipo
        {
            get
            {
                return this._IdTipo;
            }
            set
            {
                this._IdTipo = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
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

        [AtributoBancoDados(AtributoBD=true)]
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
