using System;
using System.Data;
using System.Globalization;


namespace Framework.Reflection.InsertUpdateDelete
{

    public class ItensPersistenciaOracle
    {
        // Fields
        private string _nome;
        private object _valor;

        // Methods
        public ItensPersistenciaOracle(string nome, object valor)
        {
            this._valor = valor;
            this._nome = nome;
        }

        public string FormatValueForSqlSyntax()
        {
            if (this._valor == null)
            {
                return "null";
            }
            if ((this._valor.GetType() == typeof(string)) || (this._valor.GetType() == typeof(DateTime)))
            {
                if (this._valor.GetType() == typeof(DateTime))
                {
                    if (this._valor.ToString() == "")
                    {
                        return "null";
                    }
                    return ("to_date('" + this._valor + "','DD/MM/YYYY HH24:MI:SS')");
                }
                if (this._valor.ToString() == "")
                {
                    return "null";
                }
                if (this._valor.ToString().Length >= 8)
                {
                    try
                    {
                        return ("to_date('" + Convert.ToDateTime(this._valor).ToString("dd/MM/yyyy HH:mm:ss") + "','DD/MM/YYYY HH24:MI:SS')");
                    }
                    catch
                    {
                        return ("'" + this._valor.ToString().Replace("'", "''") + "'");
                    }
                }
                return ("'" + this._valor.ToString().Replace("'", "''") + "'");
            }
            if (this._valor.GetType() == typeof(int))
            {
                if (Convert.ToInt32(this._valor) == 0)
                {
                    return "null";
                }
                return Convert.ToString(this._valor);
            }
            if (((this._valor.GetType() == typeof(float)) || (this._valor.GetType() == typeof(double))) || (this._valor.GetType() == typeof(decimal)))
            {
                return Convert.ToString(this._valor, new NumberFormatInfo());
            }
            return Convert.ToString("'" + this._valor + "'");
        }

        public string GetColumnValueExpression()
        {
            return string.Format("{0}={1}", this._nome, this.FormatValueForSqlSyntax());
        }

        // Properties
        public string Nome
        {
            get
            {
                return this._nome;
            }
        }

        public object Valor
        {
            get
            {
                return this._valor;
            }
        }
    }
}
 
