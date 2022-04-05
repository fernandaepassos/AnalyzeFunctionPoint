using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Reflection;
using Framework.Reflection.AcessoBancoDados;

namespace Framework.Reflection.Generic
{
    public abstract class ListGeneric : Framework.Reflection.Generic.Generic
    {
        // Fields
        protected ArrayList _arrayListInterno = new ArrayList();
        private int _idx = 0;
        private bool _listaInternaJaPreenchida = false;
        private bool _listaProcessoLeitura = false;
        private string _sqlDeObjetos;
        private Type _tipoObjetoDaLista;

        // Methods
        public void Add(object objetoInserirLista)
        {
            this._arrayListInterno.Add(objetoInserirLista);
        }

        public void Clear()
        {
            this._arrayListInterno.Clear();
        }

        public int Count()
        {
            return this._arrayListInterno.Count;
        }

        ~ListGeneric()
        {
            this._arrayListInterno.Clear();
        }

        public void First()
        {
            this._idx = 0;
        }

        public bool IsLast()
        {
            return ((this._arrayListInterno.Count - 1) < this._idx);
        }

        public void Next()
        {
            this._idx++;
        }

        public void PreencherLista(Type tipoObjetoDaLista, DataSet dsDeObjetos)
        {
            if (dsDeObjetos == null)
            {
                throw new Exception("Informe o dataset para preencher a lista");
            }
            this.preencherListaInterna(tipoObjetoDaLista, dsDeObjetos, null);
        }

        public void PreencherLista(Type tipoObjetoDaLista, string sqlDeObjetos)
        {
            if (string.IsNullOrEmpty(sqlDeObjetos))
            {
                throw new Exception("Informe o comando SQL para preencher a lista");
            }
            this.preencherListaInterna(tipoObjetoDaLista, null, sqlDeObjetos);
        }

        private void preencherListaInterna(Type tipoObjetoDaLista, DataSet dsDeObjetos, string sqlDeObjetos)
        {
            if (!this._listaInternaJaPreenchida)
            {
                DataSet set;
                if (dsDeObjetos == null)
                {
                    if (!((base._AcessoDBConfig.TransacaoBD != null) && base._AcessoDBConfig.TransacaoBD.TransacaoAtiva()))
                    {
                        set = AcessoBD.ObterDataSet(sqlDeObjetos);
                    }
                    else
                    {
                        set = AcessoBD.ObterDataSetTransacao(sqlDeObjetos, base._AcessoDBConfig.TransacaoBD);
                    }
                    this._sqlDeObjetos = sqlDeObjetos;
                    this._tipoObjetoDaLista = tipoObjetoDaLista;
                }
                else
                {
                    set = dsDeObjetos;
                    this._sqlDeObjetos = "";
                }
                if ((set.Tables.Count >= 1) && (set.Tables[0].Rows.Count >= 1))
                {
                    this.Clear();
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        object obj2 = tipoObjetoDaLista.GetConstructor(new Type[0]).Invoke(null);
                        DataRow dr = set.Tables[0].Rows[i];
                        base.atribuirObjeto(obj2, dr);
                        ((ClassGeneric) obj2).IncluirAcessoDBConfig(base._AcessoDBConfig);
                        this.Add(obj2);
                    }
                    set.Tables[0].Rows.Clear();
                    set.Tables.Clear();
                    set.Dispose();
                    this._listaInternaJaPreenchida = true;
                }
            }
        }

        public bool Read()
        {
            if (!this._listaProcessoLeitura)
            {
                if (this.Count() == 0)
                {
                    this._listaProcessoLeitura = false;
                    return false;
                }
                this.First();
                this._listaProcessoLeitura = true;
                return true;
            }
            this.Next();
            if (this.IsLast())
            {
                this._listaProcessoLeitura = false;
                return false;
            }
            this._listaProcessoLeitura = true;
            return true;
        }

        public void Refresh()
        {
            if (!string.IsNullOrEmpty(this._sqlDeObjetos))
            {
                this._listaInternaJaPreenchida = false;
                this.preencherListaInterna(this._tipoObjetoDaLista, null, this._sqlDeObjetos);
            }
        }

        // Properties
        protected object CurrentObject
        {
            get
            {
                if (this._arrayListInterno.Count > 0)
                {
                    object obj2 = this._arrayListInterno[this._idx];
                    if (obj2 is ClassGeneric)
                    {
                        ((ClassGeneric) obj2).NomeTela = base.NomeTela;
                        ((ClassGeneric) obj2).IncluirAcessoDBConfig(base._AcessoDBConfig);
                    }
                    return obj2;
                }
                return null;
            }
        }
    }
}
