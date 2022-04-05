using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class Filial : ClassGenericAvaliacao
    {
        // Fields
        private string _Bairro;
        private string _CEP;
        private string _Cidade;
        private string _Cnpj;
        private string _Complemento;
        private string _Email;
        private string _Endereco;
        private int _FlagMatriz;
        private int _IdEmpresa;
        private int _IdFilial;
        private string _InscEstadual;
        private string _InscMunicipal;
        private string _NomeFantasia;
        private string _Numero;
        private string _RazaoSocial;
        private string _Responsavel;
        private string _Telefone;

        // Methods
        public string GetDadoCampoFilial(int intFilial, string strCampo)
        {
            try
            {
                return AcessoBD.ExecutarComandoSqlEscalar(string.Concat(new object[] { "select ", strCampo, " from Filial where IdFilial = ", intFilial })).ToString().Trim();
            }
            catch
            {
                return "";
            }
        }

        public DataSet ListaFilial(int intIdEmpresa)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (intIdEmpresa <= 0)
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" SELECT IdFilial                 , Filial.IdEmpresa                , RazaoSocial                , NomeFantasia                , Cnpj                , FlagMatriz                , Filial.IdUltimoUsuario                , Usuario.Login AS DescUltimoUsuario                , CONVERT(VARCHAR,Filial.UltimaAtualizacao,103) +' '+ CONVERT(VARCHAR,Filial.UltimaAtualizacao,108) AS UltimaAtualizacao                , Empresa.DescEmpresa                FROM FILIAL                LEFT JOIN Empresa ON Filial.IdEmpresa = Empresa.IdEmpresa                LEFT JOIN Usuario ON Usuario.IdUsuario = Filial.IdUltimoUsuario                where 1 = 1 and Filial.IdEmpresa = " + intIdEmpresa + " ");
                set2 = set;
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

        public DataSet ListaFilialForDropDown(string strIdEmpresa)
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
                if (strIdEmpresa == "")
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet("select IdFilial, RazaoSocial from Filial where IdEmpresa = " + strIdEmpresa + " ");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdFilial", typeof(int));
                    table.Columns.Add("RazaoSocial", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdFilial"].ToString().Trim()), set.Tables[0].Rows[i]["RazaoSocial"].ToString().Trim() });
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
            return set3;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string Bairro
        {
            get
            {
                return this._Bairro;
            }
            set
            {
                this._Bairro = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string CEP
        {
            get
            {
                return this._CEP;
            }
            set
            {
                this._CEP = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Cidade
        {
            get
            {
                return this._Cidade;
            }
            set
            {
                this._Cidade = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Cnpj
        {
            get
            {
                return this._Cnpj;
            }
            set
            {
                this._Cnpj = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Complemento
        {
            get
            {
                return this._Complemento;
            }
            set
            {
                this._Complemento = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Email
        {
            get
            {
                return this._Email;
            }
            set
            {
                this._Email = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Endereco
        {
            get
            {
                return this._Endereco;
            }
            set
            {
                this._Endereco = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int FlagMatriz
        {
            get
            {
                return this._FlagMatriz;
            }
            set
            {
                this._FlagMatriz = value;
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
        public int IdFilial
        {
            get
            {
                return this._IdFilial;
            }
            set
            {
                this._IdFilial = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string InscEstadual
        {
            get
            {
                return this._InscEstadual;
            }
            set
            {
                this._InscEstadual = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string InscMunicipal
        {
            get
            {
                return this._InscMunicipal;
            }
            set
            {
                this._InscMunicipal = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string NomeFantasia
        {
            get
            {
                return this._NomeFantasia;
            }
            set
            {
                this._NomeFantasia = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Numero
        {
            get
            {
                return this._Numero;
            }
            set
            {
                this._Numero = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string RazaoSocial
        {
            get
            {
                return this._RazaoSocial;
            }
            set
            {
                this._RazaoSocial = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Responsavel
        {
            get
            {
                return this._Responsavel;
            }
            set
            {
                this._Responsavel = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Telefone
        {
            get
            {
                return this._Telefone;
            }
            set
            {
                this._Telefone = value;
            }
        }
    }
}
