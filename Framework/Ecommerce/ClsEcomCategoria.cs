using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Framework.Reflection.Rotinas;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;


namespace Framework.Ecommerce
{
    public class ClsEcomCategoria : ClassGenericEcommerce
    {
        // Fields
        private string _AtivoInativo;
        private string _Chave;
        private int _IdCategoria;
        private int _IdCategoriaSup;
        private int _IdEmpresa;
        private int _IdUltimoUsuario;
        private string _Nome;
        private string _Ordem;
        private string _UltimaAtualizacao;

        // Methods
        private DataSet GetSubCategorias(string strIdCategoria)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (string.IsNullOrEmpty(strIdCategoria))
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(((("SELECT IdCategoria " + " , IdCategoriaSup " + " , Chave ") + " , Nome  " + " FROM EcomCategoria  ") + " WHERE IdCategoriaSup = " + strIdCategoria + "  ") + " and AtivoInativo = 'A'  " + " order by IdCategoria");
                set2 = set;
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
            return set2;
        }

        public DataSet ListaCategoria(string strIdEmpresa)
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                if (strIdEmpresa == null)
                {
                    return null;
                }
                if (strIdEmpresa.Trim() == "")
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" select ECOMCATEGORIA.idcategoria                , (CASE WHEN ECOMCATEGORIA.IdCategoriaSup IS NULL THEN ECOMCATEGORIA.Nome ELSE EcomCategoriaSup.Nome + ' >> '+ ECOMCATEGORIA.Nome END)as Nome                 , ECOMCATEGORIA.chave                 FROM ECOMCATEGORIA                 Left Join EcomCategoria as EcomCategoriaSup on EcomCategoriaSup.IdCategoria = EcomCategoria.IdCategoriaSup                where ECOMCATEGORIA.IdEmpresa = " + strIdEmpresa + " order by ECOMCATEGORIA.Chave  ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("idcategoria", typeof(int));
                    table.Columns.Add("Nome", typeof(string));
                    table.Columns.Add("chave", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "", "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["idcategoria"].ToString().Trim()), set.Tables[0].Rows[i]["Nome"].ToString().Trim(), set.Tables[0].Rows[i]["Chave"].ToString().Trim() });
                    }
                    set2.Tables.Add(table);
                    return set2;
                }
                set3 = null;
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
                if (table != null)
                {
                    table.Dispose();
                }
            }
            return set3;
        }

        public DataSet ListaCategoriaFilha(string strIdEmpresa, string strIdCategoriaSup)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                set = AcessoBD.ObterDataSet(" SELECT IdCategoria, IdCategoriaSup, Chave, Nome FROM EcomCategoria WHERE IdCategoriaSup = " + strIdCategoriaSup + " AND IdEmpresa = " + strIdEmpresa + " and idsistema = 3 AND AtivoInativo = 'A' ORDER BY Ordem ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    return set;
                }
                set2 = null;
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

        public DataSet ListaCategoriaSup(string strIdEmpresa)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                set = AcessoBD.ObterDataSet(" SELECT IdCategoria, IdCategoriaSup, Chave, Nome FROM EcomCategoria WHERE IdCategoriaSup IS NULL AND IdEmpresa = " + strIdEmpresa + " and idsistema = 3 AND AtivoInativo = 'A' ORDER BY Ordem ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    return set;
                }
                set2 = null;
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

        public Menu PreencheCategoria(string strIdEmpresa, string strIdSistema, bool bolRetornaSubMenu, Menu objMenu)
        {
            Menu menu;
            DataSet set = new DataSet();
            DataSet subCategorias = new DataSet();
            try
            {
                if (((strIdEmpresa.Trim() == "") || (strIdSistema.Trim() == "")) || (objMenu == null))
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(((((("SELECT IdCategoria " + " , IdCategoriaSup " + " , Chave ") + " , Nome  " + " FROM EcomCategoria  ") + " WHERE IdEmpresa = " + strIdEmpresa + "  ") + " and IdSistema = " + strIdSistema + "  ") + " and AtivoInativo = 'A'  ") + " and IdCategoriaSup is null " + " order by IdCategoria");
                MenuItem child = new MenuItem();
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        child = new MenuItem {
                            Text = set.Tables[0].Rows[i]["Nome"].ToString().Trim() + "   |   ",
                            Value = set.Tables[0].Rows[i]["IdCategoria"].ToString().Trim()
                        };
                        objMenu.Items.AddAt(i, child);
                        subCategorias = this.GetSubCategorias(set.Tables[0].Rows[i]["IdCategoria"].ToString().Trim());
                        if (((subCategorias != null) && (subCategorias.Tables.Count > 0)) && (subCategorias.Tables[0].Rows.Count > 0))
                        {
                            for (int j = 0; j < subCategorias.Tables[0].Rows.Count; j++)
                            {
                                child = new MenuItem {
                                    Text = subCategorias.Tables[0].Rows[i]["Nome"].ToString().Trim(),
                                    Value = subCategorias.Tables[0].Rows[i]["IdCategoria"].ToString().Trim()
                                };
                                objMenu.Items[i].ChildItems.AddAt(j, child);
                            }
                        }
                    }
                }
                menu = objMenu;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                objMenu = null;
                if (set != null)
                {
                    set.Dispose();
                }
                if (subCategorias != null)
                {
                    subCategorias.Dispose();
                }
            }
            return menu;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string AtivoInativo
        {
            get
            {
                return this._AtivoInativo;
            }
            set
            {
                this._AtivoInativo = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Chave
        {
            get
            {
                return this._Chave;
            }
            set
            {
                this._Chave = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdCategoria
        {
            get
            {
                return this._IdCategoria;
            }
            set
            {
                this._IdCategoria = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdCategoriaSup
        {
            get
            {
                return this._IdCategoriaSup;
            }
            set
            {
                this._IdCategoriaSup = value;
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

        [AtributoBancoDados(AtributoBD=true)]
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

        [AtributoBancoDados(AtributoBD=true)]
        public string Ordem
        {
            get
            {
                return this._Ordem;
            }
            set
            {
                this._Ordem = value;
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

