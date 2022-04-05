using System;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Reflection.Generic
{

    //public abstract class ClassGeneric : SckDatabase.Generic.Generic, InterfaceGeneric
    public abstract class ClassGeneric : Framework.Reflection.Generic.Generic, InterfaceGeneric
    {
        // Fields
        protected string _comandoSQL = "";
        [AtributoBancoDados(AtributoBD=true)]
        public int IdUltimoUsuario;
        public bool IgnorarValidacoes = false;
        [AtributoBancoDados(AtributoBD=true)]
        public string UltimaAtualizacao;

        // Methods
        protected ClassGeneric()
        {
        }

        private string buscarAcaoSobreCampo(eTipoComandoBuscaValor _eTipoComandoBuscaValor, string _campoNaTabela)
        {
            if (string.IsNullOrEmpty(_campoNaTabela))
            {
                throw new Exception("Deve ser informado o campo na tabela no ClassGeneric.buscarAcaoSobreCampo");
            }
            switch (_eTipoComandoBuscaValor)
            {
                case eTipoComandoBuscaValor.Max:
                    return (" Max(" + _campoNaTabela + ") ");

                case eTipoComandoBuscaValor.Min:
                    return (" Min(" + _campoNaTabela + ") ");

                case eTipoComandoBuscaValor.Count:
                    return (" Count(" + _campoNaTabela + ") ");

                case eTipoComandoBuscaValor.Avg:
                    return (" Avg(" + _campoNaTabela + ") ");

                case eTipoComandoBuscaValor.Sum:
                    return (" Sum(" + _campoNaTabela + ") ");
            }
            throw new Exception("eTipoComandoBuscaValor informado não implementado no ClassGeneric.BuscarValor: " + _eTipoComandoBuscaValor.ToString());
        }

        protected bool buscarObjeto()
        {
            DataSet set;
            if (string.IsNullOrEmpty(this._comandoSQL))
            {
                return false;
            }
            if (!base._AcessoDBConfig.TransacaoAtiva)
            {
                set = AcessoBD.ObterDataSet(this._comandoSQL);
            }
            else
            {
                set = AcessoBD.ObterDataSetTransacao(this._comandoSQL, base._AcessoDBConfig.TransacaoBD);
            }
            if (set.Tables.Count == 0)
            {
                return false;
            }
            if (set.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            DataRow dr = set.Tables[0].Rows[0];
            bool flag = base.atribuirObjeto(this, dr);
            set.Dispose();
            return flag;
        }

        public long BuscarProximoCodigo(string campoNaTabela)
        {
            object obj2 = this.BuscarValor(eTipoComandoBuscaValor.Max, campoNaTabela);
            if (obj2 == DBNull.Value)
            {
                return 1L;
            }
            return (Convert.ToInt64(obj2) + 1L);
        }

        public object BuscarValor(eTipoComandoBuscaValor _eTipoComandoBuscaValor, string campoNaTabela)
        {
            return this.BuscarValor(_eTipoComandoBuscaValor, campoNaTabela, " 1 = 1");
        }

        public object BuscarValor(eTipoComandoBuscaValor _eTipoComandoBuscaValor, string campoNaTabela, string condicaoWhere)
        {
            object obj2;
            try
            {
                string str = this.buscarAcaoSobreCampo(_eTipoComandoBuscaValor, campoNaTabela);
                string str2 = this.validarCondicaoWhere(condicaoWhere);
                string sqlComand = "Select " + str + " From " + this.nomeTabela + " " + str2;
                if (!base._AcessoDBConfig.TransacaoAtiva)
                {
                    return AcessoBD.ExecutarComandoSqlEscalar(sqlComand);
                }
                obj2 = AcessoBD.ExecutarComandoSqlEscalarTransacao(sqlComand, base._AcessoDBConfig.TransacaoBD);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return obj2;
        }

        protected void criarException(string mensagem)
        {
            throw new Exception(mensagem);
        }

        public virtual bool Excluir()
        {
            bool flag;
            try
            {
                if (this.Id == 0)
                {
                    return true;
                }
                this.UltimaAtualizacao = DateTime.Now.ToString();
                if (!base._AcessoDBConfig.TransacaoAtiva)
                {
                    AcessoBD.DeleteRegistro(this, this.Id, base.NomeTela);
                }
                else
                {
                    AcessoBD.DeleteRegistroTransacao(this, this.Id, base._AcessoDBConfig.TransacaoBD, base.NomeTela);
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return flag;
        }

        public virtual bool GetBy(string condicaoWhere)
        {
            bool flag;
            try
            {
                if (string.IsNullOrEmpty(condicaoWhere.Trim()))
                {
                    throw new Exception("Informe a condição da clausula Where na chamada do método ClassGeneric.GetBy");
                }
                if (condicaoWhere.ToUpper().IndexOf("WHERE") < 0)
                {
                    condicaoWhere = " Where " + condicaoWhere;
                }
                this._comandoSQL = "Select * From " + this.nomeTabela + " " + condicaoWhere;
                flag = this.buscarObjeto();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return flag;
        }

        public virtual bool GetById(int id)
        {
            bool flag;
            try
            {
                this.Id = id;
                this._comandoSQL = "Select * From " + this.nomeTabela + " Where " + this.GetNomeDoCampoId(this.nomeTabela.Trim()) + " = " + this.Id.ToString();
                flag = this.buscarObjeto();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return flag;
        }

        protected object getLista(Type tipoObjetoDaLista, Type tipoDaLista, object objetoLista, DataSet dsDeObjetos)
        {
            if (objetoLista == null)
            {
                objetoLista = tipoDaLista.GetConstructor(new Type[0]).Invoke(null);
            }
            ((ListGeneric) objetoLista).IncluirAcessoDBConfig(base._AcessoDBConfig);
            ((ListGeneric) objetoLista).PreencherLista(tipoObjetoDaLista, dsDeObjetos);
            return objetoLista;
        }

        protected object getLista(Type tipoObjetoDaLista, Type tipoDaLista, object objetoLista, string sqlDeObjetos)
        {
            if (objetoLista == null)
            {
                objetoLista = tipoDaLista.GetConstructor(new Type[0]).Invoke(null);
            }
            ((ListGeneric) objetoLista).NomeTela = base.NomeTela;
            ((ListGeneric) objetoLista).IncluirAcessoDBConfig(base._AcessoDBConfig);
            ((ListGeneric) objetoLista).PreencherLista(tipoObjetoDaLista, sqlDeObjetos);
            return objetoLista;
        }

        private string GetNomeDoCampoId(string strNomeTabela)
        {
            if ((((strNomeTabela.Trim().Substring(0, 4).ToLower().Trim() == "sige") || (strNomeTabela.Trim().Substring(0, 4).ToLower().Trim() == "sdsk")) || (strNomeTabela.Trim().Substring(0, 4).ToLower().Trim() == "vist")) || (strNomeTabela.Trim().Substring(0, 4).ToLower().Trim() == "ecom"))
            {
                return ("Id" + strNomeTabela.Trim().Substring(4, strNomeTabela.Trim().Length - 4));
            }
            return ("Id" + strNomeTabela);
        }

        private string GetNomeTabela(string strNomeClasse)
        {
            return strNomeClasse.Trim().Substring(3, strNomeClasse.Trim().Length - 3);
        }

        protected object getObject(Type tipoObjeto, object objeto, int idObjeto)
        {
            if (objeto == null)
            {
                objeto = tipoObjeto.GetConstructor(new Type[0]).Invoke(null);
                ((ClassGeneric) objeto).GetById(idObjeto);
            }
            else if (((ClassGeneric) objeto).Id != idObjeto)
            {
                ((ClassGeneric) objeto).GetById(idObjeto);
            }
            if (!string.IsNullOrEmpty(base.NomeTela))
            {
                ((ClassGeneric) objeto).NomeTela = base.NomeTela;
            }
            if (base._AcessoDBConfig.TransacaoAtiva)
            {
                ((ClassGeneric) objeto).IncluirAcessoDBConfig(base._AcessoDBConfig);
            }
            return objeto;
        }

        protected PropertyInfo getPropertyId()
        {
            string name = "";
            if (this.nomeTabela.Trim().Substring(0, 3).Trim().ToLower() == "cls")
            {
                name = this.GetNomeDoCampoId(this.nomeTabela.Trim());
            }
            else
            {
                name = this.GetNomeDoCampoId(this.nomeTabela.Trim());
            }
            PropertyInfo property = base.GetType().GetProperty(name);
            if (property == null)
            {
                name = "id" + this.nomeTabela;
                property = base.GetType().GetProperty(name);
                if (property == null)
                {
                    throw new Exception("Implemente uma property pública com o nome Id" + this.nomeTabela + " na classe " + this.nomeTabela);
                }
            }
            if (!(property.PropertyType == typeof(int)))
            {
                throw new Exception("A property Id" + this.nomeTabela + " na classe " + this.nomeTabela + " deve ser do tipo int");
            }
            if (!property.CanRead)
            {
                throw new Exception("A property Id" + this.nomeTabela + " na classe " + this.nomeTabela + " deve ter um get");
            }
            return property;
        }

        private int getValorId()
        {
            PropertyInfo info = this.getPropertyId();
            if (info == null)
            {
                return 0;
            }
            return (int) info.GetValue(this, null);
        }

        public void ImportarDadosLogAuditoria(ClassGeneric objClassGeneric)
        {
            this.IdUltimoUsuario = objClassGeneric.IdUltimoUsuario;
            base.NomeTela = objClassGeneric.NomeTela;
        }

        public virtual bool Salvar()
        {
            bool flag;
            try
            {
                //this.UltimaAtualizacao = DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss");
                this.UltimaAtualizacao = "01/01/1982 12:00";
                
                if (!this.IgnorarValidacoes)
                {
                    this.Validar();
                }
                this.SalvarAncestral();
                if (!base._AcessoDBConfig.TransacaoAtiva)
                {
                    if (base.GravarLog)
                    {
                        this.Id = AcessoBD.InsertUpdateRegistro(this, this.Id, base.NomeTela);
                    }
                    else
                    {
                        this.Id = AcessoBD.InsertUpdateRegistroSemLog(this, this.Id);
                    }
                }
                else if (base.GravarLog)
                {
                    this.Id = AcessoBD.InsertUpdateRegistroTransacao(this, this.Id, base._AcessoDBConfig.TransacaoBD, base.NomeTela);
                }
                else
                {
                    this.Id = AcessoBD.InsertUpdateRegistroTransacaoSemLog(this, this.Id, base._AcessoDBConfig.TransacaoBD);
                }
                flag = this.Id > 0;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return flag;
        }

        private void SalvarAncestral()
        {
            object[] customAttributes = base.GetType().GetCustomAttributes(typeof(AtributoAncestralTabelaPropria), true);
            if (customAttributes.Length != 0)
            {
                AtributoAncestralTabelaPropria propria = (AtributoAncestralTabelaPropria) customAttributes.GetValue(0);
                if (propria.TabelaPropria)
                {
                    Type baseType = base.GetType().BaseType;
                    ConstructorInfo constructor = baseType.GetConstructor(new Type[0]);
                    if (constructor != null)
                    {
                        object obj2 = constructor.Invoke(null);
                        PropertyInfo info2 = null;
                        PropertyInfo[] properties = baseType.GetProperties();
                        foreach (PropertyInfo info3 in properties)
                        {
                            info2 = base.GetType().GetProperty(info3.Name);
                            if (((info2 != null) && (info3.Name.ToUpper() != "ID")) && info2.CanRead)
                            {
                                object obj3 = info2.GetValue(this, null);
                                if ((obj3 != null) && info3.CanWrite)
                                {
                                    info3.SetValue(obj2, obj3, null);
                                }
                            }
                        }
                        if (obj2 is ClassGeneric)
                        {
                            ((ClassGeneric) obj2).IgnorarValidacoes = this.IgnorarValidacoes;
                            ((ClassGeneric) obj2).IncluirAcessoDBConfig(base._AcessoDBConfig);
                            ((ClassGeneric) obj2).Salvar();
                        }
                        PropertyInfo property = base.GetType().GetProperty("Id" + ((ClassGeneric) obj2).nomeTabela);
                        PropertyInfo info5 = obj2.GetType().GetProperty("Id" + ((ClassGeneric) obj2).nomeTabela);
                        if (((property != null) && (info5 != null)) && property.CanWrite)
                        {
                            object obj4 = info5.GetValue((ClassGeneric) obj2, null);
                            if (obj4 != null)
                            {
                                property.SetValue(this, obj4, null);
                            }
                        }
                    }
                }
            }
        }

        protected object setObject(object valueProperty, ref int idObjeto)
        {
            if (valueProperty == null)
            {
                idObjeto = 0;
                return new object();
            }
            if (!string.IsNullOrEmpty(base.NomeTela))
            {
                ((ClassGeneric) valueProperty).NomeTela = base.NomeTela;
            }
            if (base._AcessoDBConfig.TransacaoAtiva)
            {
                ((ClassGeneric) valueProperty).IncluirAcessoDBConfig(base._AcessoDBConfig);
            }
            idObjeto = ((ClassGeneric) valueProperty).Id;
            return valueProperty;
        }

        private void setValorId(int valorId)
        {
            PropertyInfo info = this.getPropertyId();
            if (info != null)
            {
                info.SetValue(this, valorId, null);
            }
        }

        public virtual void Validar()
        {
        }

        private string validarCondicaoWhere(string condicaoWhere)
        {
            if (string.IsNullOrEmpty(condicaoWhere.Trim()))
            {
                throw new Exception("Informe a condição da clausula Where na chamada do método ClassGeneric.validarCondicaoWhere");
            }
            if (condicaoWhere.ToUpper().IndexOf("WHERE") < 0)
            {
                return (" Where " + condicaoWhere);
            }
            return condicaoWhere;
        }

        // Properties
        public bool ConsiderarNomeTabelaAncestral { get; set; }

        public int Id
        {
            get
            {
                return this.getValorId();
            }
            set
            {
                this.setValorId(value);
            }
        }

        protected string nomeTabela
        {
            get
            {
                if (this.ConsiderarNomeTabelaAncestral)
                {
                    this.ConsiderarNomeTabelaAncestral = false;
                    if (base.GetType().BaseType.Name.ToString().Trim().Substring(0, 3).Trim().ToLower() == "cls")
                    {
                        return this.GetNomeTabela(base.GetType().BaseType.Name.ToString());
                    }
                    return base.GetType().BaseType.Name.ToString();
                }
                if (base.GetType().Name.ToString().Trim().Substring(0, 3).Trim().ToLower() == "cls")
                {
                    return this.GetNomeTabela(base.GetType().Name.ToString());
                }
                return base.GetType().Name.ToString();
            }
        }
    }
}
