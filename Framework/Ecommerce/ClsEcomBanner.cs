using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using System.Web;
using Framework.Reflection.InsertUpdateDelete;
using System.Data;
using Framework.Reflection.Generic;


namespace Framework.Ecommerce
{
    public class ClsEcomBanner : ClassGenericEcommerce
    {
        // Fields
        private string _AtivoInativo;
        private string _DataExpiracao;
        private string _Descricao;
        private int _IdBanner;
        private int _IdEmpresa;
        private int _IdUltimoUsuario;
        private int _OrdemExibicao;
        private string _Titulo;
        private string _UltimaAtualizacao;

        // Methods
        public DataSet ListaBanner(string strIdEmpresa)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (strIdEmpresa.Trim() == "")
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" SELECT IdBanner, Titulo                 , Descricao                ,  OrdemExibicao                , SigeUsuario.Login as DescUltimoUsuario                , (CONVERT(varchar,DataExpiracao,103)) as DataExpiracao                , (CONVERT(varchar,EcomBanner.UltimaAtualizacao,103)+ ' '+ CONVERT(varchar, EcomBanner.UltimaAtualizacao,108)) as UltimaAtualizacao                , 'http://www.sisclick.com.br/ecommerce/Files/Anexos/'+ substring(SigeArquivo.Arquivo,CHARINDEX('anexos',Arquivo)+7,len(Arquivo)) as Arquivo                FROM EcomBanner                 Left Join SigeArquivo on SigeArquivo.IdArquivo in (select IdArquivo From SigeArquivoVinculo Where NomeTabela = 'EcomBanner' and IdRegistroTabela = EcomBanner.IdBanner )                 Left Join SigeUsuario on SigeUsuario.IdUsuario = EcomBanner.IdUltimoUsuario                WHERE EcomBanner.IdEmpresa = " + strIdEmpresa + " ");
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
        public string DataExpiracao
        {
            get
            {
                return this._DataExpiracao;
            }
            set
            {
                this._DataExpiracao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Descricao
        {
            get
            {
                return this._Descricao;
            }
            set
            {
                this._Descricao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdBanner
        {
            get
            {
                return this._IdBanner;
            }
            set
            {
                this._IdBanner = value;
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
        public int OrdemExibicao
        {
            get
            {
                return this._OrdemExibicao;
            }
            set
            {
                this._OrdemExibicao = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Titulo
        {
            get
            {
                return this._Titulo;
            }
            set
            {
                this._Titulo = value;
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
 
