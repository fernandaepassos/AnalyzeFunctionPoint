using System;
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
    public class ClsHistorico : ClassGenericRobo
    {
        #region [   Métodos ]

        #region [   ListaHistorico  ]
        /// <summary>
        /// [   ListaHistorico  ]
        /// </summary>
        /// <returns></returns>
        public DataSet ListaHistorico()
        {
            try
            {
                string strSql = "SELECT IdHistorico ";
                strSql += " , Historico.IdTarefa ";
                strSql += " , Tarefa.Nome as TarefaNome ";
                strSql += " , Tarefa.Descricao as TerafaDescricao ";
                strSql += " , (convert(varchar, DataHora, 103) +' '+ convert(varchar,DataHora,108)) as  DataHora ";
                strSql += " , Historico.Descricao as DescricaoEvento ";
                strSql += " , Tipo ";
                strSql += " , (CONVERT(varchar,Historico.UltimaAtualizacao,103)+' '+ CONVERT(varchar,Historico.UltimaAtualizacao,108)) as UltimaAtualizacao ";
                strSql += " , Historico.IdUltimoUsuario ";
                strSql += " , Usuario.Nome as DescUltimoUsuario ";
                strSql += " FROM Historico ";
                strSql += " left join Tarefa on Tarefa.IdTarefa = Historico.IdTarefa ";
                strSql += " Left Join Usuario on Usuario.IdUsuario = Historico.IdUltimoUsuario  ";

                return AcessoBD.ObterDataSet(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region [   ListaHistorico  ]
        /// <summary>
        /// [   ListaHistorico  ]
        /// </summary>
        /// <returns></returns>
        public DataSet ListaHistorico(string strIdHistorico)
        {
            try
            {
                if (strIdHistorico == null || strIdHistorico.Trim() == "") return null;

                string strSql = "SELECT IdHistorico ";
                strSql += " , Historico.IdTarefa ";
                strSql += " , Tarefa.Nome as TarefaNome ";
                strSql += " , Tarefa.Descricao as TerafaDescricao ";
                strSql += " , (convert(varchar, DataHora, 103) +' '+ convert(varchar,DataHora,108)) as  DataHora ";
                strSql += " , Historico.Descricao as DescricaoEvento ";
                strSql += " , Tipo ";
                strSql += " , (CONVERT(varchar,Historico.UltimaAtualizacao,103)+' '+ CONVERT(varchar,Historico.UltimaAtualizacao,108)) as UltimaAtualizacao ";
                strSql += " , Historico.IdUltimoUsuario ";
                strSql += " , Usuario.Nome as DescUltimoUsuario ";
                strSql += " FROM Historico ";
                strSql += " left join Tarefa on Tarefa.IdTarefa = Historico.IdTarefa ";
                strSql += " Left Join Usuario on Usuario.IdUsuario = Historico.IdUltimoUsuario where idhistorico = "+ strIdHistorico +" ";

                return AcessoBD.ObterDataSet(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region [   Propriedades    ]

        private int _IdHistorico;
        private int _IdTarefa;
        private string _DataHora;
        private string _Descricao;
        private string _Tipo;
        private string _UltimaAtualizacao;
        private int _IdUltimoUsuario;


        [AtributoBancoDados(AtributoBD=true)]
        public int IdHistorico
        {
            get
            {
                return this._IdHistorico;
            }
            set
            {
                this._IdHistorico = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdTarefa
        {
            get
            {
                return this._IdTarefa;
            }
            set
            {
                this._IdTarefa = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string DataHora
        {
            get
            {
                return this._DataHora;
            }
            set
            {
                this._DataHora = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
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

        [AtributoBancoDados(AtributoBD = true)]
        public string Tipo
        {
            get
            {
                return this._Tipo;
            }
            set
            {
                this._Tipo = value;
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

        #endregion
    }
}
 
