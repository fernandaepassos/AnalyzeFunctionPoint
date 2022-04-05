using System.Data;
using System;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;
using Framework.Reflection.Generic;
using Framework.Sige;

namespace Framework.Servicedesk
{
    public class ClassSQLServicedesk : ClassSQLGeneric
    {
        // Methods
        public DataSet GetChamados()
        {
            DataSet set;
            try
            {
                string comandoSQL = " SELECT " + base.Tools.MaxLinhaInicial() + " SdskChamado.IdChamado                , SdskChamado.Descricao                , SdskChamado.IdStatus                , SigeStatus.NomeStatus                , SdskChamado.IdTipo                , SigeTipo.NomeTipo                , SigeEmpresa.RazaoSocial as DescEmpresaSolicitante                , SdskChamado.IdEmpresaSolicitante                , SdskChamado.IdOrigem                , SdskOrigem.Nome AS DescNome                , SdskChamado.IdPessoaProprietario                , SigePessoaProprietario.NomePessoa AS DescPessoaProprietario                , SdskChamado.IdPessoaAtendente                , SigePessoaPessoaAtendente.NomePessoa AS DescPessoaAtendente                , EnviarNotificacao                , CONVERT(varchar, DataFinalizacao,103)+' '+ CONVERT(varchar,DataFinalizacao,108) as DataFinalizacao                , TempoSlaInicio                , TempoSlaTermino                , SdskChamado.IdUltimoUsuario                , SigePessoa.NomePessoa as DescUsuarioAlteracao                , CONVERT(varchar,SdskChamado.UltimaAtualizacao,103)+' '+ CONVERT(varchar,SdskChamado.UltimaAtualizacao,108) as DataUltimaAlteracao                , CONVERT(varchar,SdskChamado.DataInclusao,103)+' '+ CONVERT(varchar,SdskChamado.DataInclusao,108) as DataInclusao                --IdPessoaFinalizado                , Vip                , TempoVida                , TempoAtendimento                , SolucionadoPrimeiroContato                , SigeSistema.IdSistema                , SigeSistema.NomeSistema                , SdskImpacto.Descricao                , SdskChamado.IdImpacto                , SdskPrioridade.Descricao as DescricaoPrioridade                , SdskChamado.IdPrioridade                , SdskUrgencia.Descricao                , SdskChamado.IdUrgencia                , IdPessoaSolicitante                , SigePessoaSolicitante.NomePessoa as DescPessoaSolicitante                FROM SdskChamado                LEFT JOIN SdskUrgencia ON SdskUrgencia.IdUrgencia = SdskChamado.IdUrgencia                LEFT JOIN SdskPrioridade ON SdskPrioridade.IdPrioridade = SdskChamado.IdPrioridade                LEFT JOIN SdskImpacto ON SdskImpacto.IdImpacto = SdskChamado.IdImpacto                LEFT JOIN SigeStatus ON SigeStatus.IdStatus = SdskChamado.IdStatus                LEFT JOIN SigeTipo ON SigeTipo.IdTipo = SdskChamado.IdTipo                LEFT JOIN SigeEmpresa on SigeEmpresa.IdEmpresa = SdskChamado.IdEmpresaSolicitante                LEFT JOIN SigeSistema ON SigeSistema.IdSistema = SdskChamado.IdSistema                LEFT JOIN SdskOrigem ON SdskOrigem.IdOrigem = SdskChamado.IdOrigem                LEFT JOIN SigeUsuario ON SigeUsuario.IdUsuario = SdskChamado.IdUltimoUsuario                LEFT JOIN SigePessoa ON SigePessoa.IdPessoa = SigeUsuario.IdPessoa                LEFT JOIN SigePessoa AS SigePessoaProprietario ON SigePessoaProprietario.IdPessoa = SdskChamado.IdPessoaProprietario                LEFT JOIN SigePessoa AS SigePessoaPessoaAtendente ON SigePessoaPessoaAtendente.IdPessoa = SdskChamado.IdPessoaAtendente                LEFT JOIN SigePessoa AS SigePessoaSolicitante ON SigePessoaSolicitante.IdPessoa = SdskChamado.IdPessoaSolicitante                WHERE 1 = 1  ";
                set = base.ObterDataSet(comandoSQL);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set;
        }

        public DataSet GetChamadosCliente(string strIdEmpresa)
        {
            DataSet set;
            try
            {
                if (strIdEmpresa == null)
                {
                    return null;
                }
                if (strIdEmpresa.Trim() == "")
                {
                    return null;
                }
                string comandoSQL = " SELECT " + base.Tools.MaxLinhaInicial() + " SdskChamado.IdChamado                , SdskChamado.Descricao                , SdskChamado.IdStatus                , SigeStatus.NomeStatus                , SdskChamado.IdTipo                , SigeTipo.NomeTipo                , SigeEmpresa.RazaoSocial as DescEmpresaSolicitante                , SdskChamado.IdEmpresaSolicitante                , SdskChamado.IdOrigem                , SdskOrigem.Nome AS DescNome                , SdskChamado.IdPessoaProprietario                , SigePessoaProprietario.NomePessoa AS DescPessoaProprietario                , SdskChamado.IdPessoaAtendente                , SigePessoaPessoaAtendente.NomePessoa AS DescPessoaAtendente                , EnviarNotificacao                , CONVERT(varchar, DataFinalizacao,103)+' '+ CONVERT(varchar,DataFinalizacao,108) as DataFinalizacao                , TempoSlaInicio                , TempoSlaTermino                , SdskChamado.IdUltimoUsuario                , SigePessoa.NomePessoa as DescUsuarioAlteracao                , CONVERT(varchar,SdskChamado.UltimaAtualizacao,103)+' '+ CONVERT(varchar,SdskChamado.UltimaAtualizacao,108) as DataUltimaAlteracao                , CONVERT(varchar,SdskChamado.DataInclusao,103)+' '+ CONVERT(varchar,SdskChamado.DataInclusao,108) as DataInclusao                --IdPessoaFinalizado                , Vip                , TempoVida                , TempoAtendimento                , SolucionadoPrimeiroContato                , SigeSistema.IdSistema                , SigeSistema.NomeSistema                , SdskImpacto.Descricao                , SdskChamado.IdImpacto                , SdskPrioridade.Descricao as DescricaoPrioridade                , SdskChamado.IdPrioridade                , SdskUrgencia.Descricao                , SdskChamado.IdUrgencia                , IdPessoaSolicitante                , SigePessoaSolicitante.NomePessoa as DescPessoaSolicitante                FROM SdskChamado                LEFT JOIN SdskUrgencia ON SdskUrgencia.IdUrgencia = SdskChamado.IdUrgencia                LEFT JOIN SdskPrioridade ON SdskPrioridade.IdPrioridade = SdskChamado.IdPrioridade                LEFT JOIN SdskImpacto ON SdskImpacto.IdImpacto = SdskChamado.IdImpacto                LEFT JOIN SigeStatus ON SigeStatus.IdStatus = SdskChamado.IdStatus                LEFT JOIN SigeTipo ON SigeTipo.IdTipo = SdskChamado.IdTipo                LEFT JOIN SigeEmpresa on SigeEmpresa.IdEmpresa = SdskChamado.IdEmpresaSolicitante                LEFT JOIN SigeSistema ON SigeSistema.IdSistema = SdskChamado.IdSistema                LEFT JOIN SdskOrigem ON SdskOrigem.IdOrigem = SdskChamado.IdOrigem                LEFT JOIN SigeUsuario ON SigeUsuario.IdUsuario = SdskChamado.IdUltimoUsuario                LEFT JOIN SigePessoa ON SigePessoa.IdPessoa = SigeUsuario.IdPessoa                LEFT JOIN SigePessoa AS SigePessoaProprietario ON SigePessoaProprietario.IdPessoa = SdskChamado.IdPessoaProprietario                LEFT JOIN SigePessoa AS SigePessoaPessoaAtendente ON SigePessoaPessoaAtendente.IdPessoa = SdskChamado.IdPessoaAtendente                LEFT JOIN SigePessoa AS SigePessoaSolicitante ON SigePessoaSolicitante.IdPessoa = SdskChamado.IdPessoaSolicitante                WHERE 1 = 1 and SdskChamado.IdEmpresaSolicitante = " + strIdEmpresa + "  ";
                set = base.ObterDataSet(comandoSQL);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return set;
        }

        public DataSet GetPrioridade()
        {
            DataSet set3;
            DataSet set = new DataSet();
            DataTable table = new DataTable();
            DataSet set2 = new DataSet();
            try
            {
                string sqlComand = " select idprioridade, Descricao from SdskPrioridade order by IdPrioridade ";
                set = AcessoBD.ObterDataSet(sqlComand);
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    table.Columns.Add("idprioridade", typeof(int));
                    table.Columns.Add("Descricao", typeof(string));
                    table.Rows.Add(new object[] { Convert.ToInt32("0"), "" });
                    for (int i = 0; i < set.Tables[0].Rows.Count; i++)
                    {
                        table.Rows.Add(new object[] { Convert.ToInt32(set.Tables[0].Rows[i]["idprioridade"].ToString().Trim()), set.Tables[0].Rows[i]["Descricao"].ToString().Trim() });
                    }
                    set2.Tables.Add(table);
                    return set2;
                }
                set3 = null;
            }
            catch (Exception exception)
            {
                throw exception;
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
                if (set2 != null)
                {
                    set2.Dispose();
                }
            }
            return set3;
        }
    }
}
