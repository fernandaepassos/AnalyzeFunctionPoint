using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class AvaliaAcessorio : ClassGenericAvaliacao
    {
        // Fields
        private int _IdAcessorio;
        private int _IdAvalia;
        private int _IdAvaliaAcessorio;
        private int _IdUltimoUsuario;
        private string _SiglaClassifica;
        private string _UltimaAtualizacao;

        // Methods
        public void AssociaVarios(string strpnlGrupoDeItem_1, string strpnlGrupoDeItem_2, string strpnlGrupoDeItem_3, int intIdAvalia)
        {
            try
            {
                if (intIdAvalia <= 0)
                {
                    return;
                }
                AcessoBD.ExecutarComandoSql("delete AvaliaAcessorio where IdAvalia = " + intIdAvalia + " ");
                if (!string.IsNullOrEmpty(strpnlGrupoDeItem_1) && (strpnlGrupoDeItem_1.Trim().Split(new char[] { ',' }).Length <= 0))
                {
                    goto Label_016C;
                }
                int index = 0;
                goto Label_0147;
            Label_0067: ;
                if (strpnlGrupoDeItem_1.Trim().Split(new char[] { ',' })[index].Split(new char[] { '_' })[0].Trim() != "")
                {
                    this.IdAvaliaAcessorio = 0;
                    this.IdAvalia = intIdAvalia;
                    this.IdAcessorio = Convert.ToInt32(strpnlGrupoDeItem_1.Trim().Split(new char[] { ',' })[index].Split(new char[] { '_' })[0]);
                    this.SiglaClassifica = strpnlGrupoDeItem_1.Trim().Split(new char[] { ',' })[index].Split(new char[] { '_' })[1].ToString().Trim();
                    this.Salvar();
                }
                index++;
            Label_0147: ;
                if (index < strpnlGrupoDeItem_1.Trim().Split(new char[] { ',' }).Length)
                {
                    goto Label_0067;
                }
            Label_016C:
                if (!string.IsNullOrEmpty(strpnlGrupoDeItem_2) && (strpnlGrupoDeItem_2.Trim().Split(new char[] { ',' }).Length <= 0))
                {
                    goto Label_02AC;
                }
                index = 0;
                goto Label_0287;
            Label_01A7: ;
                if (strpnlGrupoDeItem_2.Trim().Split(new char[] { ',' })[index].Split(new char[] { '_' })[0].Trim() != "")
                {
                    this.IdAvaliaAcessorio = 0;
                    this.IdAvalia = intIdAvalia;
                    this.IdAcessorio = Convert.ToInt32(strpnlGrupoDeItem_2.Trim().Split(new char[] { ',' })[index].Split(new char[] { '_' })[0]);
                    this.SiglaClassifica = strpnlGrupoDeItem_2.Trim().Split(new char[] { ',' })[index].Split(new char[] { '_' })[1].ToString().Trim();
                    this.Salvar();
                }
                index++;
            Label_0287: ;
                if (index < strpnlGrupoDeItem_2.Trim().Split(new char[] { ',' }).Length)
                {
                    goto Label_01A7;
                }
            Label_02AC:
                if (!string.IsNullOrEmpty(strpnlGrupoDeItem_3) && (strpnlGrupoDeItem_3.Trim().Split(new char[] { ',' }).Length <= 0))
                {
                    return;
                }
                index = 0;
                goto Label_03FC;
            Label_02E7: ;
                if (strpnlGrupoDeItem_3.Trim().Split(new char[] { ',' })[index].Trim().Contains("S") && (strpnlGrupoDeItem_3.Trim().Split(new char[] { ',' })[index].Split(new char[] { '_' })[0].Trim() != ""))
                {
                    this.IdAvaliaAcessorio = 0;
                    this.IdAvalia = intIdAvalia;
                    this.IdAcessorio = Convert.ToInt32(strpnlGrupoDeItem_3.Trim().Split(new char[] { ',' })[index].Split(new char[] { '_' })[0]);
                    this.SiglaClassifica = strpnlGrupoDeItem_3.Trim().Split(new char[] { ',' })[index].Split(new char[] { '_' })[1].ToString().Trim();
                    this.Salvar();
                }
                index++;
            Label_03FC: ;
                if (index < strpnlGrupoDeItem_3.Trim().Split(new char[] { ',' }).Length)
                {
                    goto Label_02E7;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public DataSet GetAcessorioAssociado(int intIdAvalia)
        {
            try
            {
                if (intIdAvalia <= 0)
                {
                    return null;
                }
                return AcessoBD.ObterDataSet("select IdAcessorio, SiglaClassifica from AvaliaAcessorio where IdAvalia = " + intIdAvalia);
            }
            catch
            {
                return null;
            }
        }

        // Properties
        [AtributoBancoDados(AtributoBD = true)]
        public int IdAcessorio
        {
            get
            {
                return this._IdAcessorio;
            }
            set
            {
                this._IdAcessorio = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
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

        [AtributoBancoDados(AtributoBD = true)]
        public int IdAvaliaAcessorio
        {
            get
            {
                return this._IdAvaliaAcessorio;
            }
            set
            {
                this._IdAvaliaAcessorio = value;
            }
        }

        [AtributoBancoDados(AtributoBD = false)]
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

        [AtributoBancoDados(AtributoBD = true)]
        public string SiglaClassifica
        {
            get
            {
                return this._SiglaClassifica;
            }
            set
            {
                this._SiglaClassifica = value;
            }
        }

        [AtributoBancoDados(AtributoBD = false)]
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

