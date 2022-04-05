using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using System.Web;
using Framework.Reflection.InsertUpdateDelete;
using System.Data;
using Framework.Reflection.Generic;


namespace Framework.Robo
{
    public class ClsUsuario : ClassGenericRobo
    {
        // Fields
        private int _IdUsuario;
        private string _Senha;
        private string _UltimaAtualizacao;
        private int _IdUltimoUsuario;
        private string _AtivoInativo;
        private string _Email;
        private string _Nome;

        #region [ Métodos  ]

        #region [   Autenticacao    ]
        /// <summary>
        /// [   Autenticacao    ]
        /// </summary>
        /// <param name="strMensagem"></param>
        /// <returns></returns>
        public bool Autenticacao(out string strMensagem)
        {
            DataSet objDataSet = new DataSet();
            strMensagem = "";
            try
            {
                string strSql = "select IdUsuario , AtivoInativo, Nome, Email ";
                strSql  += " from usuario  ";
                strSql += " where email = '"+ Email.Trim()  +"' ";
                strSql  += " and Senha = '"+ Senha.Trim() +"' ";

                objDataSet = AcessoBD.ObterDataSet(strSql);

                if (objDataSet != null && objDataSet.Tables.Count > 0 && objDataSet.Tables[0].Rows.Count > 0)
                {
                    if (objDataSet.Tables[0].Rows[0]["AtivoInativo"].ToString().Trim().ToUpper() == "I")
                    {
                        strMensagem = "Dados de acesso desativados.";
                        return false;
                    }
                    else
                    {
                        IdUsuario = Convert.ToInt32(objDataSet.Tables[0].Rows[0]["IdUsuario"].ToString().Trim().ToUpper());
                        AtivoInativo = objDataSet.Tables[0].Rows[0]["AtivoInativo"].ToString().Trim().ToUpper();
                        Nome = objDataSet.Tables[0].Rows[0]["Nome"].ToString().Trim().ToUpper();
                        Email = objDataSet.Tables[0].Rows[0]["Email"].ToString().Trim().ToUpper();
                        return true;
                    }
                }
                else
                {
                    strMensagem = "O e-mail e/ou senha não existem no sistema.";
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [   ListaUsuarios   ]
        /// <summary>
        /// [   ListaUsuarios   ]
        /// </summary>
        /// <returns></returns>
        public DataSet ListaUsuarios()
        {
            try
            {
                string strSql = "select Usuario.IdUsuario ";
                strSql += " , Usuario.Senha ";
                strSql += " , (CONVERT(varchar,Usuario.UltimaAtualizacao,103)+' '+ CONVERT(varchar,Usuario.UltimaAtualizacao,108) ) as UltimaAtualizacao ";
                strSql += " , Usuario.IdUltimoUsuario ";
                strSql += " , UsuarioAtualizador.Nome as DescUltimoUsuario ";
                strSql += " , (case when Usuario.AtivoInativo = 'i' then 'Inativo' else case when Usuario.AtivoInativo = 'a' then 'Ativo' else 'Indefinido' end end) as AtivoInativo ";
                strSql += " , Usuario.Email ";
                strSql += " , Usuario.Nome ";
                strSql += " from Usuario ";
                strSql += " left join Usuario as UsuarioAtualizador on UsuarioAtualizador.IdUsuario = Usuario.IdUltimoUsuario ";

                return AcessoBD.ObterDataSet(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public int IdUsuario
        {
            get
            {
                return this._IdUsuario;
            }
            set
            {
                this._IdUsuario = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Senha
        {
            get
            {
                return this._Senha;
            }
            set
            {
                this._Senha = value;
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

        [AtributoBancoDados(AtributoBD = true)]
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

        [AtributoBancoDados(AtributoBD = true)]
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
        
        #endregion
    }
}
 
