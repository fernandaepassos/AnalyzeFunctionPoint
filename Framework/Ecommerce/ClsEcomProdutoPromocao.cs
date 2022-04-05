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
    public class ClsEcomProdutoPromocao : Rotina
    {
        // Fields
        private string _DataFinal;
        private string _DataInicial;
        private string _DescUltimoUsuario;
        private string _FlagAtivo;
        private int _IdProduto;
        private int _IdProdutoPromocao;
        private int _IdUltimoUsuario;
        private string _Nome;
        private double _PrecoPromocao;
        private string _UltimaAtualizacao;

        // Methods
        public ClsEcomProdutoPromocao BuscarProdutoPromocao(ClsEcomProdutoPromocao objClasse, int id)
        {
            ClsEcomProdutoPromocao promocao;
            try
            {
                if (id <= 0)
                {
                    return null;
                }
                DataSet set = AcessoBD.ObterDataSet(" select                 IdProdutoPromocao                ,IdProduto                ,PrecoPromocao                , Nome                , convert(varchar, DataInicial, 103) as DataInicial                , CONVERT(varchar,DataFinal, 103) as DataFinal                ,FlagAtivo                 ,EcomProdutoPromocao.IdUltimoUsuario                , SigeUsuario.Login as DescUltimoUsuario                , CONVERT(varchar, EcomProdutoPromocao.UltimaAtualizacao, 103) as UltimaAtualizacao                from EcomProdutoPromocao                LEFT OUTER JOIN SigeUsuario ON SigeUsuario.IdUsuario = EcomProdutoPromocao.IdUltimoUsuario                where IdProdutoPromocao = " + id.ToString() + " ");
                if (set.Tables[0].Rows.Count > 0)
                {
                    DataRow row = set.Tables[0].Rows[0];
                    objClasse.IdProdutoPromocao = base.FieldInt(row["IdProdutoPromocao"].ToString());
                    objClasse.IdProduto = base.FieldInt(row["IdProduto"].ToString());
                    objClasse.PrecoPromocao = (double) row["PrecoPromocao"];
                    objClasse.DataInicial = base.FieldString(row["DataInicial"].ToString());
                    objClasse.DataFinal = base.FieldString(row["DataFinal"].ToString());
                    objClasse.FlagAtivo = base.FieldString(row["FlagAtivo"].ToString());
                    objClasse.IdUltimoUsuario = base.FieldInt(row["IdUltimoUsuario"].ToString());
                    objClasse.UltimaAtualizacao = base.FieldString(row["UltimaAtualizacao"].ToString());
                    objClasse.DescUltimoUsuario = base.FieldString(row["DescUltimoUsuario"].ToString());
                    objClasse.Nome = base.FieldString(row["Nome"].ToString());
                    set.Dispose();
                }
                promocao = objClasse;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return promocao;
        }

        public void ExcluirProdutoPromocao(ClsEcomProdutoPromocao objClasse, int id)
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

        public DataSet ListaProdutoPromocao(string strIdProduto)
        {
            DataSet set2;
            try
            {
                if (((strIdProduto == null) || (strIdProduto == "")) || (strIdProduto.Trim() == "0"))
                {
                    return null;
                }
                set2 = AcessoBD.ObterDataSet(" select                 IdProdutoPromocao                ,IdProduto                ,PrecoPromocao                , Nome                , convert(varchar, DataInicial, 103) as DataInicial                , CONVERT(varchar,DataFinal, 103) as DataFinal                ,(case when FlagAtivo = 1 then 'Ativo' else case when FlagAtivo = 0 then 'Inativo' end end) as FlagAtivo                ,EcomProdutoPromocao.IdUltimoUsuario                , SigeUsuario.Login as DescUltimoUsuario                , CONVERT(varchar, EcomProdutoPromocao.UltimaAtualizacao, 103) as UltimaAtualizacao                from EcomProdutoPromocao                LEFT OUTER JOIN SigeUsuario ON SigeUsuario.IdUsuario = EcomProdutoPromocao.IdUltimoUsuario                where IdProduto = " + strIdProduto.Trim() + " ");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set2;
        }

        public int SalvarProdutoPromocao(ClsEcomProdutoPromocao objEcomProdutoPromocao, int id)
        {
            int num2;
            try
            {
                num2 = AcessoBD.InsertUpdateRegistro(objEcomProdutoPromocao, id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string DataFinal
        {
            get
            {
                return this._DataFinal;
            }
            set
            {
                this._DataFinal = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string DataInicial
        {
            get
            {
                return this._DataInicial;
            }
            set
            {
                this._DataInicial = value;
            }
        }

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
        public string FlagAtivo
        {
            get
            {
                return this._FlagAtivo;
            }
            set
            {
                this._FlagAtivo = value;
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
        public int IdProdutoPromocao
        {
            get
            {
                return this._IdProdutoPromocao;
            }
            set
            {
                this._IdProdutoPromocao = value;
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
        public double PrecoPromocao
        {
            get
            {
                return this._PrecoPromocao;
            }
            set
            {
                this._PrecoPromocao = value;
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
    }
}
