using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using System.Web;
using Framework.Reflection.InsertUpdateDelete;


namespace Framework.Ecommerce
{
    public class ClsEcomCarrinho
    {
        // Methods
        private ClsEcomCarrinho()
        {
            this.ListaDeItens = new Dictionary<int, int>();
        }

        public void Adicionar(int IdProduto, int quantidade)
        {
            try
            {
                if (this.ListaDeItens.ContainsKey(IdProduto))
                {
                    Dictionary<int, int> dictionary;
                    int num;
                    (dictionary = this.ListaDeItens)[num = IdProduto] = dictionary[num] + quantidade;
                }
                else
                {
                    this.ListaDeItens.Add(IdProduto, quantidade);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void DefinirQtdAtualDoProduto(int IdProduto, int QtdAtualDoProduto)
        {
            try
            {
                if (this.ListaDeItens.ContainsKey(IdProduto))
                {
                    this.ListaDeItens[IdProduto] = QtdAtualDoProduto;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Limpar()
        {
            try
            {
                this.ListaDeItens.Clear();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int ObterQuantidadeDoItem(int IdProduto)
        {
            int num;
            try
            {
                num = this.ListaDeItens[IdProduto];
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }

        public void Remover(int IdProduto)
        {
            try
            {
                if (this.ListaDeItens.ContainsKey(IdProduto))
                {
                    this.ListaDeItens.Remove(IdProduto);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // Properties
        public string CodigoDosItensString
        {
            get
            {
                string str = "";
                int[] numArray = this.ListaDeItens.Keys.ToArray<int>();
                for (int i = 0; i < numArray.Length; i++)
                {
                    if (str.Trim() == "")
                    {
                        str = numArray[i].ToString();
                    }
                    else
                    {
                        str = str + "," + numArray[i].ToString();
                    }
                }
                return str;
            }
        }

        public int[] CodigosDosItens
        {
            get
            {
                return this.ListaDeItens.Keys.ToArray<int>();
            }
        }

        public static ClsEcomCarrinho Instancia
        {
            get
            {
                if (HttpContext.Current.Session["carrinho"] == null)
                {
                    HttpContext.Current.Session["carrinho"] = new ClsEcomCarrinho();
                }
                return (ClsEcomCarrinho) HttpContext.Current.Session["carrinho"];
            }
        }

        private Dictionary<int, int> ListaDeItens { get; set; }

        public int QuantidadeTotal
        {
            get
            {
                int num = 0;
                foreach (int num2 in this.ListaDeItens.Keys)
                {
                    num += this.ListaDeItens[num2];
                }
                return num;
            }
        }

        public bool TemItens
        {
            get
            {
                return (this.ListaDeItens.Count > 0);
            }
        }
    }

}
