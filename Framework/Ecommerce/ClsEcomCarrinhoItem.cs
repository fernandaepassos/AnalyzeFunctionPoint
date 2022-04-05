using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;

using Framework.Reflection.InsertUpdateDelete;


namespace Framework.Ecommerce
{
    public class ClsEcomCarrinhoItem
    {
        // Fields
        private string _DataUltimaAlteracao;
        private int _IdCarrinho;
        private int _IdCarrinhoItem;
        private int _IdEmpresa;
        private int _IdProduto;
        private int _IdSistema;

        // Methods
        public int Salvar(ClsEcomCarrinhoItem objEcomCarrinhoItem, int id)
        {
            int num2;
            try
            {
                if (objEcomCarrinhoItem.IdCarrinho <= 0)
                {
                    object obj2 = AcessoBD.ExecutarComandoSqlEscalar(string.Concat(new object[] { "INSERT INTO EcomCarrinho VALUES (", objEcomCarrinhoItem.IdEmpresa, ",", objEcomCarrinhoItem.IdSistema, ",GETDATE())" }));
                    if ((obj2 != null) && (Convert.ToInt32(obj2) > 0))
                    {
                        objEcomCarrinhoItem.IdCarrinho = Convert.ToInt32(obj2);
                    }
                }
                num2 = AcessoBD.InsertUpdateRegistro(objEcomCarrinhoItem, id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string DataUltimaAlteracao
        {
            get
            {
                return this._DataUltimaAlteracao;
            }
            set
            {
                this._DataUltimaAlteracao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdCarrinho
        {
            get
            {
                return this._IdCarrinho;
            }
            set
            {
                this._IdCarrinho = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdCarrinhoItem
        {
            get
            {
                return this._IdCarrinhoItem;
            }
            set
            {
                this._IdCarrinhoItem = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdEmpresa
        {
            get
            {
                return this._IdEmpresa;
            }
            set
            {
                this._IdEmpresa = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdProduto
        {
            get
            {
                return this._IdProduto;
            }
            set
            {
                this._IdProduto = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdSistema
        {
            get
            {
                return this._IdSistema;
            }
            set
            {
                this._IdSistema = value;
            }
        }
    }
}
