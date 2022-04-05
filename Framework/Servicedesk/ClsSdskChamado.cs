using System.Data;
using System;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.Generic;
using Framework.Sige;

namespace Framework.Servicedesk
{
    public class ClsSdskChamado : ClassGenericServicedesk
    {
        // Fields
        private string _DataFinalizacao;
        private string _DataInclusao;
        private string _Descricao;
        private string _EnviarNotificacao;
        private int _IdChamado;
        private int _IdEmpresaSolicitante;
        private int _IdImpacto;
        private int _IdOrigem;
        private int _IdPessoaAtendente;
        private int _IdPessoaFinalizado;
        private int _IdPessoaProprietario;
        private int _IdPessoaSolicitante;
        private int _IdPrioridade;
        private int _IdSistema;
        private int _IdStatus;
        private int _IdTipo;
        private int _IdUltimoUsuario;
        private int _IdUrgencia;
        private string _SolucionadoPrimeiroContato;
        private int _TempoAtendimento;
        private int _TempoSlaInicio;
        private int _TempoSlaTermino;
        private int _TempoVida;
        private string _UltimaAtualizacao;
        private string _Vip;

        // Methods
        public ClsSdskChamado BuscarChamado(ClsSdskChamado objClasse, int id)
        {
            ClsSdskChamado chamado;
            try
            {
                DataSet set = AcessoBD.ObterDataSet(" SELECT * FROM SVDCHAMADO WHERE IDCHAMADO = " + id + " ");
                if (set.Tables[0].Rows.Count > 0)
                {
                    DataRow row = set.Tables[0].Rows[0];
                    objClasse.IdChamado = Convert.ToInt32(row["IdChamado"].ToString());
                    objClasse.Descricao = row["Descricao"].ToString();
                    objClasse.IdOrigem = Convert.ToInt32(row["IdOrigem"].ToString());
                    objClasse.IdStatus = Convert.ToInt32(row["IdStatus"].ToString());
                    objClasse.IdTipo = Convert.ToInt32(row["IdTipo"].ToString());
                    objClasse.IdEmpresaSolicitante = Convert.ToInt32(row["IdEmpresaSolicitante"].ToString());
                    objClasse.IdPessoaProprietario = Convert.ToInt32(row["IdPessoaProprietario"].ToString());
                    objClasse.IdPessoaAtendente = Convert.ToInt32(row["IdPessoaAtendente"].ToString());
                    objClasse.EnviarNotificacao = row["EnviarNotificacao"].ToString().Trim();
                    objClasse.DataFinalizacao = row["DataFinalizacao"].ToString();
                    objClasse.IdPessoaFinalizado = Convert.ToInt32(row["IdPessoaFinalizado"].ToString());
                    objClasse.TempoSlaInicio = Convert.ToInt32(row["TempoSlaInicio"].ToString());
                    objClasse.TempoSlaTermino = Convert.ToInt32(row["TempoSlaTermino"].ToString());
                    objClasse.DataInclusao = row["DataInclusao"].ToString();
                    objClasse.IdUltimoUsuario = Convert.ToInt32(row["IdUltimoUsuario"].ToString());
                    objClasse.UltimaAtualizacao = row["UltimaAtualizacao"].ToString();
                    set.Dispose();
                }
                chamado = objClasse;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return chamado;
        }

        public void ExcluirChamado(ClsSdskChamado objClasse, int id)
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

        public DataSet GetPessoaSolicitante()
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                string sqlComand = " select  SigeUsuario.IdPessoa, SigePessoa.NomePessoa +' [ '+ SigePessoaEmpresa.NomePessoa +' ] ' as NomePessoa from SigeUsuario                left join SigePessoa on SigePessoa.IdPessoa = SigeUsuario.IdPessoa                left join SigeEmpresa on SigeEmpresa.IdEmpresa = SigeUsuario.IdEmpresa                 left join SigePessoa as SigePessoaEmpresa  on SigePessoaEmpresa.IdPessoa = SigeEmpresa.IdPessoa ";
                set = AcessoBD.ObterDataSet(sqlComand);
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("IdPessoa", typeof(int));
                    table.Columns.Add("NomePessoa", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["IdPessoa"].ToString().Trim()), set.Tables[0].Rows[i]["NomePessoa"].ToString().Trim() });
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
            finally
            {
                if (set != null)
                {
                    set.Dispose();
                }
                if (table != null)
                {
                    table.Dispose();
                }
            }
            return set3;
        }

        public DataSet ListaChamado(string strIdEmpresa)
        {
            DataSet set2;
            try
            {
                string sqlComand = "select  IdChamado                , IdEmpresaSolicitante                , Descricao                , SdskOrigem.Nome                , SigeStatus.NomeStatus                , SigeTipo.NomeTipo                , SigeEmpresa.RazaoSocial                , case when EnviarNotificacao = 'N' then 'Não' else case when EnviarNotificacao = 'S' then 'Sim' else 'Não' end end as ReceberNotificacaoAndamento                , CONVERT(varchar,DataFinalizacao,103) +' '+CONVERT(varchar,DataFinalizacao,108) as DataFinalizacao                , CONVERT(varchar,SdskChamado.UltimaAtualizacao,103) +' '+CONVERT(varchar,SdskChamado.UltimaAtualizacao,108) as DataUltimaAlteracao                 , CONVERT(varchar,SdskChamado.DataInclusao,103) +' '+CONVERT(varchar,SdskChamado.DataInclusao,108) as DataInclusao                 from  SdskChamado                left join SdskOrigem on SdskOrigem.IdOrigem = SdskChamado.IdOrigem                left join SigeStatus on SigeStatus.IdStatus = SdskChamado.IdStatus                left join SigeTipo on SigeTipo.IdTipo = SdskChamado.IdTipo                left join SigeEmpresa on SigeEmpresa.Idempresa = SdskChamado.IdEmpresaSolicitante                where 1 = 1 ";
                if ((strIdEmpresa != null) && (strIdEmpresa.Trim() != ""))
                {
                    sqlComand = sqlComand + " SdskChamado.IdEmpresaSolicitante = " + strIdEmpresa + "  ";
                }
                set2 = AcessoBD.ObterDataSet(sqlComand);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set2;
        }

        public int SalvarChamado(ClsSdskChamado objChamado, int id)
        {
            int num2;
            try
            {
                if (objChamado.Descricao.Trim() == "")
                {
                    throw new Exception("Informe a descrição.");
                }
                if (objChamado.IdOrigem <= 0)
                {
                    throw new Exception("Informe a origem do chamado.");
                }
                if (objChamado.IdStatus <= 0)
                {
                    throw new Exception("Informe o status do chamado.");
                }
                if (objChamado.IdTipo <= 0)
                {
                    throw new Exception("Informe o tipo do chamado.");
                }
                if (objChamado.IdEmpresaSolicitante <= 0)
                {
                    throw new Exception("Informe a empresa do chamado.");
                }
                if (objChamado.EnviarNotificacao == null)
                {
                    throw new Exception("Informe se deseja ou não receber notificações do andamento.");
                }
                if (objChamado.DataInclusao.Trim() == "")
                {
                    throw new Exception("Contacte o administrador do sistema. Data de inclusão não informada.");
                }
                num2 = AcessoBD.InsertUpdateRegistro(objChamado, id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        public bool ValidaExclusao()
        {
            bool flag;
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
        [AtributoBancoDados(AtributoBD = true)]
        public string DataFinalizacao
        {
            get
            {
                return this._DataFinalizacao;
            }
            set
            {
                this._DataFinalizacao = value.Trim();
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public string DataInclusao
        {
            get
            {
                return this._DataInclusao;
            }
            set
            {
                this._DataInclusao = value.Trim();
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
        public string EnviarNotificacao
        {
            get
            {
                return this._EnviarNotificacao;
            }
            set
            {
                this._EnviarNotificacao = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdChamado
        {
            get
            {
                return this._IdChamado;
            }
            set
            {
                this._IdChamado = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdEmpresaSolicitante
        {
            get
            {
                return this._IdEmpresaSolicitante;
            }
            set
            {
                this._IdEmpresaSolicitante = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdImpacto
        {
            get
            {
                return this._IdImpacto;
            }
            set
            {
                this._IdImpacto = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdOrigem
        {
            get
            {
                return this._IdOrigem;
            }
            set
            {
                this._IdOrigem = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdPessoaAtendente
        {
            get
            {
                return this._IdPessoaAtendente;
            }
            set
            {
                this._IdPessoaAtendente = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdPessoaFinalizado
        {
            get
            {
                return this._IdPessoaFinalizado;
            }
            set
            {
                this._IdPessoaFinalizado = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdPessoaProprietario
        {
            get
            {
                return this._IdPessoaProprietario;
            }
            set
            {
                this._IdPessoaProprietario = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdPessoaSolicitante
        {
            get
            {
                return this._IdPessoaSolicitante;
            }
            set
            {
                this._IdPessoaSolicitante = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdPrioridade
        {
            get
            {
                return this._IdPrioridade;
            }
            set
            {
                this._IdPrioridade = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
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

        [AtributoBancoDados(AtributoBD = true)]
        public int IdStatus
        {
            get
            {
                return this._IdStatus;
            }
            set
            {
                this._IdStatus = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int IdTipo
        {
            get
            {
                return this._IdTipo;
            }
            set
            {
                this._IdTipo = value;
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
        public int IdUrgencia
        {
            get
            {
                return this._IdUrgencia;
            }
            set
            {
                this._IdUrgencia = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public string SolucionadoPrimeiroContato
        {
            get
            {
                return this._SolucionadoPrimeiroContato;
            }
            set
            {
                this._SolucionadoPrimeiroContato = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int TempoAtendimento
        {
            get
            {
                return this._TempoAtendimento;
            }
            set
            {
                this._TempoAtendimento = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int TempoSlaInicio
        {
            get
            {
                return this._TempoSlaInicio;
            }
            set
            {
                this._TempoSlaInicio = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int TempoSlaTermino
        {
            get
            {
                return this._TempoSlaTermino;
            }
            set
            {
                this._TempoSlaTermino = value;
            }
        }

        [AtributoBancoDados(AtributoBD = true)]
        public int TempoVida
        {
            get
            {
                return this._TempoVida;
            }
            set
            {
                this._TempoVida = value;
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

        [AtributoBancoDados(AtributoBD = true)]
        public string Vip
        {
            get
            {
                return this._Vip;
            }
            set
            {
                this._Vip = value;
            }
        }
    }
}