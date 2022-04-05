using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Framework.Avaliacao
{
    public class Permissao
    {
        // Fields
        private int _IdFilial;
        private int _IdFuncionalidade;
        private int _IdPermissao;
        private int _IdUltimoUsuario;
        private int _IdUsuario;
        private string _strIdFuncionalidades;
        private string _UltimaAtualizacao;

        // Methods
        public bool Excluir(Permissao objClasse, int id)
        {
            bool flag;
            try
            {
                if (id > 0)
                {
                    AcessoBD.DeleteRegistro(objClasse, id);
                    return true;
                }
                flag = false;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return flag;
        }

        public void MarcaGrid(GridView objGridView, string strIdUsuario, string strIdFilial)
        {
            try
            {
                int count = objGridView.Rows.Count;
                if (count > 0)
                {
                    CheckBox box = null;
                    Label label = null;
                    for (int i = 0; count > i; i++)
                    {
                        GridViewRow row = objGridView.Rows[i];
                        box = (CheckBox) row.FindControl("chkselect");
                        label = (Label) row.FindControl("lblIdFuncionalidade");
                        box.Checked = this.VerificaSePermitido(strIdUsuario, strIdFilial, label.Text.Trim());
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int Salvar(Permissao objPermissao, int id, string strNomeTela = "")
        {
            int num2;
            try
            {
                num2 = AcessoBD.InsertUpdateRegistro(objPermissao, id, strNomeTela);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        public bool SalvarVarias(Permissao objPermissao)
        {
            bool flag;
            try
            {
                if ((objPermissao.strIdFuncionalidades == null) || (objPermissao.strIdFuncionalidades.Trim() == ""))
                {
                    return false;
                }
                AcessoBD.ExecutarComandoSql(string.Concat(new object[] { "delete Permissao where IdUsuario = ", objPermissao.IdUsuario, " and IdFilial = ", objPermissao.IdFilial }));
                int index = 0;
                goto Label_00C6;
            Label_007A:;
                this.IdFuncionalidade = Convert.ToInt32(objPermissao.strIdFuncionalidades.Trim().Split(new char[] { ',' })[index].ToString().Trim());
                this.Salvar(objPermissao, 0, "");
                index++;
            Label_00C6:;
                if (index < objPermissao.strIdFuncionalidades.Trim().Split(new char[] { ',' }).Length)
                {
                    goto Label_007A;
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        private bool VerificaSePermitido(string strIdUsuario, string strIdFilial, string strIdFuncionalidade)
        {
            bool flag;
            try
            {
                object obj2 = AcessoBD.ExecutarComandoSqlEscalar("select count(IdFuncionalidade) from Permissao where IdUsuario = " + strIdUsuario + " and IdFilial = " + strIdFilial + " and IdFuncionalidade = " + strIdFuncionalidade);
                if (obj2 != null)
                {
                    return (Convert.ToInt32(obj2) > 0);
                }
                flag = false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return flag;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public int IdFilial
        {
            get
            {
                return this._IdFilial;
            }
            set
            {
                this._IdFilial = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdFuncionalidade
        {
            get
            {
                return this._IdFuncionalidade;
            }
            set
            {
                this._IdFuncionalidade = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdPermissao
        {
            get
            {
                return this._IdPermissao;
            }
            set
            {
                this._IdPermissao = value;
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
        public int IdUsuario
        {
            get
            {
                return this._IdUsuario;
            }
            set
            {
                this._IdUsuario = value;
            }
        }

        [AtributoBancoDados(AtributoBD=false)]
        public string strIdFuncionalidades
        {
            get
            {
                return this._strIdFuncionalidades;
            }
            set
            {
                this._strIdFuncionalidades = value;
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

 
