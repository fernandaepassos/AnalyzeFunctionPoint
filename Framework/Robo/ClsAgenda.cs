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
    public class ClsAgenda : ClassGenericRobo
    {

        #region [   Methods ]

        #region [   ListaAgenda ]
        /// <summary>
        /// [   ListaAgenda ]
        /// </summary>
        /// <returns></returns>
        public DataSet ListaAgenda()
        {
            try
            {
                string strSql = "select IdAgenda ";
                strSql += " , Semana ";
                strSql += " , (case when Semana = 2 then 'Segunda-feira' else ";
                strSql += " case when Semana = 3 then 'Terça-feira' else ";
                strSql += " case when Semana = 4 then 'Quarta-feira' else ";
                strSql += " case when Semana = 5 then 'Quinta-feira' else ";
                strSql += " case when Semana = 6 then 'Sexta-feira' else ";
                strSql += " case when Semana = 7 then 'Sábado' else ";
                strSql += " case when Semana = 8 then 'Domingo' end end end end end end end ) as DescSemana ";
                strSql += " , Hora  ";
                strSql += " , (convert(varchar,Agenda.UltimaAtualizacao,103)+' '+ CONVERT(varchar,Agenda.UltimaAtualizacao,108)) as UltimaAtualizacao ";
                strSql += " , Agenda.IdUltimoUsuario ";
                strSql += " , Usuario.Nome as DescUltimoUsuario ";
                strSql += " from Agenda ";
                strSql += " left join Usuario on Usuario.IdUsuario = Agenda.IdUltimoUsuario ";
                strSql += " order by Semana, Hora ";

                return AcessoBD.ObterDataSet(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region [   ExisteAgendaProDiaHora  ]
        /// <summary>
        /// [   ExisteAgendaProDiaHora  ]
        /// </summary>
        /// <param name="strHora"></param>
        /// <param name="strSemana"></param>
        /// <returns></returns>
        public bool ExisteAgendaProDiaHora(string strHora, string strSemana)
        {
            try
            {
                object var = AcessoBD.ExecutarComandoSqlEscalar("select IdAgenda from agenda where Semana = "+ strSemana +" and  Hora = "+ strHora +"");
                
                if(var != null && var.ToString().Trim() != "" && Convert.ToInt32(var.ToString().Trim()) > 0)
                {
                    return true;
                }
                else 
                    return false ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #endregion

        #region [   Properties  ]

        // Fields
        private int _IdAgenda;
        private int _Semana;
        private string _Hora;
        private string _UltimaAtualizacao;
        private int _IdUltimoUsuario;

        [AtributoBancoDados(AtributoBD=true)]
        public int IdAgenda
        {
            get
            {
                return this._IdAgenda;
            }
            set
            {
                this._IdAgenda = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int Semana
        {
            get
            {
                return this._Semana;
            }
            set
            {
                this._Semana = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string Hora
        {
            get
            {
                return this._Hora;
            }
            set
            {
                this._Hora = value;
            }
        }

        #endregion
    }
}
 
