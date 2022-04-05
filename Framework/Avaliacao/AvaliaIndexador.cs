using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class AvaliaIndexador : ClassGenericAvaliacao
    {
        // Fields
        private string _FlagSelecionado;
        private int _IdAvalia;
        private int _IdAvaliaIndexador;
        private int _IdIndexador;
        private double _Valor;

        // Methods
        public void SalvaAvaliaIndexador(string strValores, string strIdAvalia)
        {
            try
            {
                if ((((strValores == null) || (strValores.Trim() == "")) || ((strIdAvalia == null) || (strIdAvalia.Trim() == ""))) || (strValores.Trim().Split(new char[] { ',' }).Length <= 0))
                {
                    return;
                }
                AcessoBD.ExecutarComandoSql("delete AvaliaIndexador where IdAvalia = " + strIdAvalia);
                int index = 0;
                goto Label_017C;
            Label_0098:
                this.IdAvaliaIndexador = 0;
                this.IdIndexador = Convert.ToInt32(strValores.Trim().Split(new char[] { '|' })[index].Split(new char[] { '_' })[0]);
                this.IdAvalia = Convert.ToInt32(strIdAvalia);
                this.Valor = Convert.ToDouble(strValores.Trim().Split(new char[] { '|' })[index].Split(new char[] { '_' })[1].Replace(",", "."));
                this.FlagSelecionado = strValores.Trim().Split(new char[] { '|' })[index].Split(new char[] { '_' })[2].ToString().Trim();
                this.Salvar();
                index++;
            Label_017C:;
                if (index < strValores.Trim().Split(new char[] { '|' }).Length)
                {
                    goto Label_0098;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string FlagSelecionado
        {
            get
            {
                return this._FlagSelecionado;
            }
            set
            {
                this._FlagSelecionado = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdAvalia
        {
            get
            {
                return this._IdAvalia;
            }
            set
            {
                this._IdAvalia = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdAvaliaIndexador
        {
            get
            {
                return this._IdAvaliaIndexador;
            }
            set
            {
                this._IdAvaliaIndexador = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdIndexador
        {
            get
            {
                return this._IdIndexador;
            }
            set
            {
                this._IdIndexador = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public double Valor
        {
            get
            {
                return this._Valor;
            }
            set
            {
                this._Valor = value;
            }
        }
    }
}

