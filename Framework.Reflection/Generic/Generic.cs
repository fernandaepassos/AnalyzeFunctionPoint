using System;
using Framework.Reflection;
using System.Reflection;
using System.Data;
using Framework.Reflection.Tool;

namespace Framework.Reflection.Generic
{
    public abstract class Generic
    {
        // Fields
        private AcessoDBConfig _acessoDBConfig;
        private string _nomeTela = "";
        private Tools _tools;
        public bool GravarLog = false;

        // Methods
        protected Generic()
        {
                    }

        protected bool atribuirObjeto(object obj, DataRow dr)
        {
            this.buscaNomeValorPropriedades(obj, dr);
            this.buscaNomeValorFields(obj, dr);
            dr.Table.Dispose();
            return true;
        }

        private void buscaNomeValorFields(object obj, DataRow dr)
        {
            FieldInfo[] fields = obj.GetType().GetFields(BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            DataTable table = dr.Table;
            foreach (FieldInfo info in fields)
            {
                if (table.Columns.Contains(info.Name))
                {
                    if (info.FieldType != typeof(string))
                    {
                        if ((info.FieldType != typeof(int)) && !(info.FieldType == typeof(int)))
                        {
                            if (info.FieldType != typeof(short))
                            {
                                if (info.FieldType != typeof(byte))
                                {
                                    if (info.FieldType != typeof(double))
                                    {
                                        if (info.FieldType != typeof(long))
                                        {
                                            if (info.FieldType != typeof(float))
                                            {
                                                throw new Exception("Campo não identificado: buscaNomeValorFields - " + obj.GetType().ToString() + " - " + info.Name);
                                            }
                                            info.SetValue(obj, this.Tools.FieldFloat(dr[info.Name]));
                                        }
                                        else
                                        {
                                            info.SetValue(obj, this.Tools.FieldInt64(dr[info.Name]));
                                        }
                                    }
                                    else
                                    {
                                        info.SetValue(obj, this.Tools.FieldDouble(dr[info.Name]));
                                    }
                                }
                                else
                                {
                                    info.SetValue(obj, this.Tools.FieldByte(dr[info.Name]));
                                }
                            }
                            else
                            {
                                info.SetValue(obj, this.Tools.FieldShort(dr[info.Name]));
                            }
                        }
                        else
                        {
                            info.SetValue(obj, this.Tools.FieldInt(dr[info.Name]));
                        }
                    }
                    else
                    {
                        info.SetValue(obj, this.Tools.FieldString(dr[info.Name]));
                    }
                }
            }
        }

        private void buscaNomeValorPropriedades(object obj, DataRow dr)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            DataTable table = dr.Table;
            foreach (PropertyInfo info in properties)
            {
                if (table.Columns.Contains(info.Name) && info.CanWrite)
                {
                    if (info.PropertyType != typeof(string))
                    {
                        if ((info.PropertyType != typeof(int)) && !(info.PropertyType == typeof(int)))
                        {
                            if (info.PropertyType != typeof(short))
                            {
                                if (info.PropertyType != typeof(byte))
                                {
                                    if (info.PropertyType != typeof(double))
                                    {
                                        if (info.PropertyType != typeof(long))
                                        {
                                            if (info.PropertyType != typeof(float))
                                            {
                                                if (info.PropertyType != typeof(char))
                                                {
                                                    throw new Exception("Campo não identificado: buscaNomeValorPropriedades - " + obj.GetType().ToString() + " - " + info.Name);
                                                }
                                                char ch = (dr[info.Name] == DBNull.Value) ? '0' : Convert.ToChar(dr[info.Name]);
                                                info.SetValue(obj, ch, null);
                                            }
                                            else
                                            {
                                                info.SetValue(obj, this.Tools.FieldFloat(dr[info.Name]), null);
                                            }
                                        }
                                        else
                                        {
                                            info.SetValue(obj, this.Tools.FieldInt64(dr[info.Name]), null);
                                        }
                                    }
                                    else
                                    {
                                        info.SetValue(obj, this.Tools.FieldDouble(dr[info.Name]), null);
                                    }
                                }
                                else
                                {
                                    info.SetValue(obj, this.Tools.FieldByte(dr[info.Name]), null);
                                }
                            }
                            else
                            {
                                info.SetValue(obj, this.Tools.FieldShort(dr[info.Name]), null);
                            }
                        }
                        else
                        {
                            info.SetValue(obj, this.Tools.FieldInt(dr[info.Name]), null);
                        }
                    }
                    else
                    {
                        info.SetValue(obj, this.Tools.FieldString(dr[info.Name]), null);
                    }
                }
            }
        }

        public virtual void IncluirAcessoDBConfig(AcessoDBConfig pAcessoDBConfig)
        {
            this._AcessoDBConfig = pAcessoDBConfig;
        }

        public virtual void RetirarAcessoDBConfig()
        {
            this._acessoDBConfig = null;
        }

        // Properties
        protected AcessoDBConfig _AcessoDBConfig
        {
            get
            {
                if (this._acessoDBConfig == null)
                {
                    this._acessoDBConfig = new AcessoDBConfig();
                }
                return this._acessoDBConfig;
            }
            set
            {
                this._acessoDBConfig = value;
            }
        }

        public string NomeTela
        {
            get
            {
                return this._nomeTela;
            }
            set
            {
                this._nomeTela = value;
            }
        }

        public Tools Tools
        {
            get
            {
                if (this._tools == null)
                {
                    this._tools = new Tools();
                }
                return this._tools;
            }
        }
    }
}