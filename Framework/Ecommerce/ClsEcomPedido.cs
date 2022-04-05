using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
//using UOL.PagSeguro;

namespace Framework.Ecommerce
{
    public class ClsEcomPedido
    {
        // Fields
        private static ClsEcomPedido _instancia;

        // Methods
        private ClsEcomPedido()
        {
        }

        public string GravarPedido(ClsEcomCarrinho carrinho)
        {
            return Convert.ToString(new Random().Next());
        }

        // Properties
        public static ClsEcomPedido Instancia
        {
            get
            {
                if (_instancia == null)
                {
                    _instancia = new ClsEcomPedido();
                }
                return _instancia;
            }
        }
    }


}
