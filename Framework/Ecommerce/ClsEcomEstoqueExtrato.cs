using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Framework.Reflection.Rotinas;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Ecommerce
{
    public class ClsEcomEstoqueExtrato : Rotina
    {
        // Fields
        private string _DescUltimoUsuario;
        private string _E_S;
        private int _IdEmpresa;
        private int _IdEstoqueExtrato;
        private int _IdPedido;
        private int _IdProduto;
        private int _IdSistema;
        private int _IdUltimoUsuario;
        private int _NumDocumento;
        private string _Produto;
        private int _QtdAtualProduto;
        private string _QtdMovimento;
        private string _UltimaAtualizacao;
        private double _ValorCusto;

        // Methods
        public ClsEcomEstoqueExtrato Buscar(ClsEcomEstoqueExtrato objClasse, int id)
        {
            ClsEcomEstoqueExtrato extrato;
            try
            {
                DataSet set = AcessoBD.ObterDataSet((((((((((" select " + " IdEstoqueExtrato ") + " , EcomEstoqueExtrato.IdEmpresa " + " , IdProduto ") + ", (SELECT NOME FROM EcomProduto WHERE IdProduto = EcomEstoqueExtrato.IdProduto) as Produto " + " , E_S ") + " , QtdMovimento " + " , ValorCusto ") + " , NumDocumento " + " , IdPedido ") + " , QtdAtualProduto " + " , IdSistema ") + " , EcomEstoqueExtrato.IdUltimoUsuario " + " , CONVERT(VARCHAR,EcomEstoqueExtrato.UltimaAtualizacao,103)+' '+CONVERT(VARCHAR,EcomEstoqueExtrato.UltimaAtualizacao,108) UltimaAtualizacao ") + " , SigeUsuario.Login AS DescUltimoUsuario " + "  from EcomEstoqueExtrato ") + "  LEFT OUTER JOIN SigeUsuario ON SigeUsuario.IdUsuario = EcomEstoqueExtrato.IdUltimoUsuario " + " where 1=1 ") + " AND EcomEstoqueExtrato.IdEstoqueExtrato  = " + id.ToString() + "  ");
                if (set.Tables[0].Rows.Count > 0)
                {
                    DataRow row = set.Tables[0].Rows[0];
                    objClasse.IdEstoqueExtrato = base.FieldInt(row["IdEstoqueExtrato"].ToString());
                    objClasse.IdEmpresa = base.FieldInt(row["IdEmpresa"].ToString());
                    objClasse.IdProduto = base.FieldInt(row["IdProduto"].ToString());
                    objClasse.Produto = base.FieldString(row["Produto"].ToString());
                    objClasse.E_S = base.FieldString(row["E_S"].ToString().Trim());
                    objClasse.QtdMovimento = base.FieldString(row["QtdMovimento"].ToString().Trim());
                    objClasse.ValorCusto = Convert.ToDouble(row["ValorCusto"].ToString().Trim());
                    objClasse.NumDocumento = base.FieldInt(row["NumDocumento"].ToString().Trim());
                    objClasse.IdPedido = base.FieldInt(row["IdPedido"].ToString());
                    objClasse.QtdAtualProduto = base.FieldInt(row["QtdAtualProduto"].ToString().Trim());
                    objClasse.IdSistema = base.FieldInt(row["IdSistema"].ToString());
                    objClasse.DescUltimoUsuario = base.FieldString(row["DescUltimoUsuario"].ToString().Trim());
                    objClasse.IdUltimoUsuario = base.FieldInt(row["IdUltimoUsuario"].ToString().Trim());
                    objClasse.UltimaAtualizacao = base.FieldString(row["UltimaAtualizacao"].ToString().Trim());
                    set.Dispose();
                }
                extrato = objClasse;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return extrato;
        }

        public void Excluir(ClsEcomEstoqueExtrato objClasse, int id)
        {
            try
            {
                if (id > 0)
                {
                    AcessoBD.DeleteRegistro(objClasse, id);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public DataSet Lista(string strIdEmpresa)
        {
            DataSet set2;
            try
            {
                if ((strIdEmpresa == null) || (strIdEmpresa.Trim() == ""))
                {
                    return null;
                }
                set2 = AcessoBD.ObterDataSet(((((((((((" select " + " IdEstoqueExtrato ") + " , EcomEstoqueExtrato.IdEmpresa " + " , IdProduto ") + ", (SELECT NOME FROM EcomProduto WHERE IdProduto = EcomEstoqueExtrato.IdProduto) as Produto " + " ,(CASE WHEN E_S = 'E' THEN 'Entrada' ELSE 'SAÍDA' END)as E_S ") + " , QtdMovimento " + " , ValorCusto ") + " , NumDocumento " + " , IdPedido ") + " , QtdAtualProduto " + " , IdSistema ") + " , EcomEstoqueExtrato.IdUltimoUsuario " + " , CONVERT(VARCHAR,EcomEstoqueExtrato.UltimaAtualizacao,103)+' '+CONVERT(VARCHAR,EcomEstoqueExtrato.UltimaAtualizacao,108) UltimaAtualizacao ") + " , SigeUsuario.Login AS DescUltimoUsuario " + "  from EcomEstoqueExtrato ") + "  LEFT OUTER JOIN SigeUsuario ON SigeUsuario.IdUsuario = EcomEstoqueExtrato.IdUltimoUsuario " + " where 1=1 ") + " AND EcomEstoqueExtrato.IDEMPRESA  = " + strIdEmpresa + "  ") + " ORDER BY IdProduto, UltimaAtualizacao DESC ");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set2;
        }

        public DataSet ListaEstoquePorProduto(string strIdProduto)
        {
            DataSet set2;
            try
            {
                if ((strIdProduto == null) || (strIdProduto.Trim() == ""))
                {
                    return null;
                }
                set2 = AcessoBD.ObterDataSet(((((((((((" select " + " IdEstoqueExtrato ") + " , EcomEstoqueExtrato.IdEmpresa " + " , IdProduto ") + ", (SELECT NOME FROM EcomProduto WHERE IdProduto = EcomEstoqueExtrato.IdProduto) as Produto " + " ,(CASE WHEN E_S = 'E' THEN 'Entrada' ELSE 'SAÍDA' END)as E_S ") + " , QtdMovimento " + " , ValorCusto ") + " , NumDocumento " + " , IdPedido ") + " , QtdAtualProduto " + " , IdSistema ") + " , EcomEstoqueExtrato.IdUltimoUsuario " + " , CONVERT(VARCHAR,EcomEstoqueExtrato.UltimaAtualizacao,103)+' '+CONVERT(VARCHAR,EcomEstoqueExtrato.UltimaAtualizacao,108) UltimaAtualizacao ") + " , SigeUsuario.Login AS DescUltimoUsuario " + "  from EcomEstoqueExtrato ") + "  LEFT OUTER JOIN SigeUsuario ON SigeUsuario.IdUsuario = EcomEstoqueExtrato.IdUltimoUsuario " + " where 1=1 ") + " AND IdProduto  = " + strIdProduto + "  ") + " ORDER BY IdProduto, UltimaAtualizacao DESC ");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set2;
        }

        public int Salvar(ClsEcomEstoqueExtrato objEcomEstoqueExtrato, int id)
        {
            int num2;
            try
            {
                num2 = AcessoBD.InsertUpdateRegistro(objEcomEstoqueExtrato, id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        public bool ValidaExclusao(out string strMensagem)
        {
            bool flag;
            strMensagem = "";
            try
            {
                flag = true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return flag;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=false)]
        public string DescUltimoUsuario
        {
            get
            {
                return this._DescUltimoUsuario;
            }
            set
            {
                this._DescUltimoUsuario = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string E_S
        {
            get
            {
                return this._E_S;
            }
            set
            {
                this._E_S = value;
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

        [AtributoBancoDados(AtributoBD=true)]
        public int IdEstoqueExtrato
        {
            get
            {
                return this._IdEstoqueExtrato;
            }
            set
            {
                this._IdEstoqueExtrato = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdPedido
        {
            get
            {
                return this._IdPedido;
            }
            set
            {
                this._IdPedido = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdProduto
        {
            get
            {
                return this._IdProduto;
            }
            set
            {
                this._IdProduto = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdSistema
        {
            get
            {
                return this._IdSistema;
            }
            set
            {
                this._IdSistema = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
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
        public int NumDocumento
        {
            get
            {
                return this._NumDocumento;
            }
            set
            {
                this._NumDocumento = value;
            }
        }

        [AtributoBancoDados(AtributoBD=false)]
        public string Produto
        {
            get
            {
                return this._Produto;
            }
            set
            {
                this._Produto = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int QtdAtualProduto
        {
            get
            {
                return this._QtdAtualProduto;
            }
            set
            {
                this._QtdAtualProduto = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string QtdMovimento
        {
            get
            {
                return this._QtdMovimento;
            }
            set
            {
                this._QtdMovimento = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
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

        [AtributoBancoDados(AtributoBD=true)]
        public double ValorCusto
        {
            get
            {
                return this._ValorCusto;
            }
            set
            {
                this._ValorCusto = value;
            }
        }
    }

}

