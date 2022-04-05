using System;
using System.Data;
using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.AcessoBancoDados;

namespace Framework.Sige
{
    public class ClsSigeProspect
    {
        // Fields
        private int _IdPessoa;
        private int _IdProspect;
        private int _IdStatusProspect;
        private int _IdUltimoUsuario;
        private string _UltimaAtualizacao;

        // Methods
        public void Excluir(ClsSigeProspect objClasse, int id)
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

        public int GetIdProspect(int intIdPessoa)
        {
            int num;
            DataSet set = new DataSet();
            try
            {
                set = AcessoBD.ObterDataSet("select IdProspect from SigeProspect where idpessoa = " + intIdPessoa);
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

        public int Salvar(ClsSigeProspect objSigeProspect, int id)
        {
            int num2;
            try
            {
                num2 = AcessoBD.InsertUpdateRegistro(objSigeProspect, id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        // Properties
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

        [AtributoBancoDados(AtributoBD = true)]
        public int IdProspect
        {
            get
            {
                return this._IdProspect;
            }
            set
            {
                this._IdProspect = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdStatusProspect
        {
            get
            {
                return this._IdStatusProspect;
            }
            set
            {
                this._IdStatusProspect = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
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

        [AtributoBancoDados(AtributoBD = true)]
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