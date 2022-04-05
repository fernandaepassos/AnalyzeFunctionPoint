using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database;

namespace Framework.Util
{
    class Cls_WebDropDown
    {
        /// <summary>
        /// Inicilizador da classe
        /// </summary>
        public Cls_WebDropDown()
        {
        }

        //#region metodo geraDropDownList
        ///// <summary>
        ///// Gera um novo DropDownList de acordo com a coleção de atributos.
        ///// </summary>
        ///// <param name="objDropDownList">DropDownList</param>
        //public static bool geraDropDownList(
        //    Infragistics.Web.UI.ListControls.WebDropDown objDropDownList, 
        //    string strSql = "", 
        //    string strItemPadraoNome = "", 
        //    string strItemPadraoValor = "", 
        //    string strNomeDoDataTextField = "", 
        //    string strNomeDoValueField = "")
        //{
        //    try
        //    {
        //        //Seleciona os registros no banco de dados
        //        if (!string.IsNullOrEmpty(strNomeDoDataTextField) && !string.IsNullOrEmpty(strNomeDoValueField))
        //        {
        //            using (Conexao cn = new Conexao())
        //            {
        //                System.Data.IDataReader objDataReader = cn.RetornaDataReader(strSql);
                       

        //                //Verifica se o select retornou informação.

        //                //Limpa o objeto
        //                objDropDownList.Items.Clear();

        //                objDropDownList.DataSource = objDataReader;
        //                objDropDownList.TextField = strNomeDoDataTextField;
        //                objDropDownList.ValueField = strNomeDoValueField;
        //                objDropDownList.DataBind();
        //            }
        //        }

        //        //Adiciona o item padrão: Sómente se o valor e texto for informado por parâmetro
        //        if (!string.IsNullOrEmpty(strItemPadraoNome) && !string.IsNullOrEmpty(strItemPadraoValor))
        //        {
        //            Infragistics.Web.UI.ListControls.DropDownItem objDropDownItem = new Infragistics.Web.UI.ListControls.DropDownItem(strItemPadraoNome, strItemPadraoValor);
        //            objDropDownList.Items.Add(objDropDownItem);
        //        }

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //#endregion

    }
}
