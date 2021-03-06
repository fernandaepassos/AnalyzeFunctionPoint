using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;
using Framework.Seguranca;

namespace Framework.PontoFuncao
{
    public class Usuario
    {
        // Methods
        public Usuario Buscar(Usuario objClasse, int id)
        {
            Usuario usuario;
            try
            {
                DataSet set = AcessoBD.ObterDataSet(" select * from usuario where idusuario = " + id + " ");
                if (set.Tables[0].Rows.Count > 0)
                {
                    DataRow row = set.Tables[0].Rows[0];
                    objClasse.IdUsuario = Convert.ToInt32(row["IdUsuario"].ToString());
                    objClasse.Login = row["Login"].ToString().Trim();
                    objClasse.IdUltimoUsuario = (row["IdUltimoUsuario"].ToString().Trim() != "") ? Convert.ToInt32(row["IdUltimoUsuario"].ToString()) : 0;
                    objClasse.UltimaAtualizacao = row["UltimaAtualizacao"].ToString().Trim();
                    objClasse.Senha = row["Senha"].ToString().Trim();
                    objClasse.FlagInativo = row["FlagInativo"].ToString().Trim();
                    objClasse.FlagAcessoTotalNaFilial = (row["FlagAcessoTotalNaFilial"].ToString().Trim() != "") ? Convert.ToInt32(row["FlagAcessoTotalNaFilial"].ToString().Trim()) : 0;
                    objClasse.FlagHorarioAcessoLivre = (row["FlagHorarioAcessoLivre"].ToString().Trim() != "") ? Convert.ToInt32(row["FlagHorarioAcessoLivre"].ToString().Trim()) : 0;
                    objClasse.FlagAdministradoGeral = (row["FlagAdministradoGeral"].ToString().Trim() != "") ? Convert.ToInt32(row["FlagAdministradoGeral"].ToString().Trim()) : 0;
                    objClasse.IdPessoa = (row["IdPessoa"].ToString().Trim() != "") ? Convert.ToInt32(row["IdPessoa"].ToString()) : 0;
                    set.Dispose();
                }
                usuario = objClasse;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return usuario;
        }

        private string GetDiaDaSemana()
        {
            string str;
            try
            {
                switch (DateTime.Now.DayOfWeek.ToString().Trim())
                {
                    case "Monday":
                        return "segunda-feira";

                    case "Tuesday":
                        return "terça-feira";

                    case "Wednesday":
                        return "quarta-feira";

                    case "Thursday":
                        return "quinta-feira";

                    case "Friday":
                        return "sexta-feira";

                    case "Saturday":
                        return "sábado";

                    case "Sunday":
                        return "domingo";
                }
                str = "";
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        public static DataSet GetHrAcesso(string strIdUsuario)
        {
            DataSet set2;
            DataSet set = new DataSet();
            try
            {
                if (strIdUsuario == null)
                {
                    return null;
                }
                if (strIdUsuario.Trim() == "")
                {
                    return null;
                }
                set = AcessoBD.ObterDataSet(" select IdHorarioAcesso, IdUsuario,DiaSemana, HoraInicio, HoraFim from HorarioAcesso where IdUsuario = " + strIdUsuario + " ");
                set2 = set;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return set2;
        }

        public int GetIdUsuario(int intIdPessoa)
        {
            int num;
            try
            {
                DataSet set = new DataSet();
                set = AcessoBD.ObterDataSet("select IdUsuario from Usuario where idpessoa = " + intIdPessoa);
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    return Convert.ToInt32(set.Tables[0].Rows[0][0].ToString().Trim());
                }
                num = 0;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num;
        }

        public int Salvar(Usuario objUsuario, int id)
        {
            int num2;
            try
            {
                num2 = AcessoBD.InsertUpdateRegistro(objUsuario, id);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        private bool ValidaAcessoParaDiaIntervHoraAtual(out string strMensagem, string strIdUsuario)
        {
            bool flag2;
            strMensagem = "";
            bool flag = true;
            DataSet set = new DataSet();
            try
            {
                if (strIdUsuario.Trim() == "")
                {
                    return false;
                }
                DataSet set2 = AcessoBD.ObterDataSet("select FlagHorarioAcessoLivre from Usuario where IdUsuario = " + strIdUsuario);
                if ((((set2 != null) && (set2.Tables.Count > 0)) && (set2.Tables[0].Rows.Count > 0)) && (set2.Tables[0].Rows[0][0].ToString().Trim() == "1"))
                {
                    strMensagem = "Usuário com horário de acesso livre.";
                    return true;
                }
                set = AcessoBD.ObterDataSet(((((" SELECT COUNT(*) AcessoAutorizado " + " FROM HorarioAcesso ") + " WHERE IdUsuario = " + strIdUsuario + " ") + "  AND DiaSemana IN ('" + this.GetDiaDaSemana() + "')") + " AND '" + DateTime.Now.ToString("HH:mm") + "' >= HoraInicio  ") + " AND '" + DateTime.Now.ToString("HH:mm") + "' <= HoraFim ");
                if (((set.Tables.Count > 0) && (set.Tables[0].Rows.Count > 0)) && (set.Tables[0].Rows[0][0].ToString().Trim() == "0"))
                {
                    strMensagem = "Seu login/senha estão corretos, porém não existe configuração para<br/> o usuário acessar nesta data/hora.";
                    flag = false;
                }
                flag2 = flag;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                set.Dispose();
            }
            return flag2;
        }

        public bool ValidaAcessoUsuario(out string strMensagem)
        {
            bool flag;
            strMensagem = "";
            DataSet set = new DataSet();
            try
            {
                if (this.ValidaDadosUsuario(out strMensagem))
                {
                    string strSql = "SELECT Usuario.IdUsuario, ";
                    strSql += " Pessoa.IdPessoa ";
                    strSql += " , Usuario.Login ";
                    strSql += " , Usuario.Senha ";                
                    strSql += " , Pessoa.Nome ";
                    strSql += " , Usuario.IDUSUARIO ";
                    strSql += " FROM Usuario ";
                    strSql += " LEFT JOIN Pessoa ON Pessoa.IdPessoa = Usuario.IdPessoa ";
                    strSql += " WHERE Login = '"+ Login +"' and Senha = '"+ Senha +"' ";

                    set = AcessoBD.ObterDataSet(strSql);

                    if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                    {
                        this.IdUsuario = Convert.ToInt32(set.Tables[0].Rows[0]["IdUsuario"].ToString());
                        this.IdPessoa = Convert.ToInt32(set.Tables[0].Rows[0]["IdPessoa"].ToString());
                        this.Login = set.Tables[0].Rows[0]["Login"].ToString();
                        this.Senha = set.Tables[0].Rows[0]["Senha"].ToString();
                        this.Nome = set.Tables[0].Rows[0]["Nome"].ToString();
                        return true;
                    }
                    else
                    {
                        strMensagem = "Login e/ou senha inválido.";
                        return false;
                    }
                }

                return false;
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
        }

        private bool ValidaDadosUsuario(out string strMensagem)
        {
            bool flag;
            strMensagem = "";
            try
            {
                if (string.IsNullOrEmpty(this.Login.Trim()))
                {
                    strMensagem = "Por favor, informe o usuário";
                    return false;
                }
                if (string.IsNullOrEmpty(this.Senha))
                {
                    strMensagem = "Por favor, informe a senha.";
                    return false;
                }

                flag = true;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return flag;
        }

        public bool VerificaSeLoginJaExiste(string strLogin)
        {
            bool flag;
            try
            {
                DataSet set = new DataSet();
                set = AcessoBD.ObterDataSet("select COUNT(*) as qtd from Usuario where login = '" + strLogin + "'");
                if (((set != null) && (set.Tables.Count > 0)) && (set.Tables[0].Rows.Count > 0))
                {
                    if (set.Tables[0].Rows[0][0].ToString().Trim() == "0")
                    {
                        return false;
                    }
                    if (set.Tables[0].Rows[0][0].ToString().Trim() == "1")
                    {
                        return true;
                    }
                }
                flag = false;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return flag;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=false)]
        public string Empresa { get; set; }

        [AtributoBancoDados(AtributoBD=false)]
        public string Filial { get; set; }

        [AtributoBancoDados(AtributoBD=true)]
        public int FlagAcessoTotalNaFilial { get; set; }

        [AtributoBancoDados(AtributoBD=true)]
        public int FlagAdministradoGeral { get; set; }

        [AtributoBancoDados(AtributoBD=true)]
        public int FlagHorarioAcessoLivre { get; set; }

        [AtributoBancoDados(AtributoBD=true)]
        public string FlagInativo { get; set; }

        [AtributoBancoDados(AtributoBD=false)]
        public int IdEmpresa { get; set; }

        [AtributoBancoDados(AtributoBD=false)]
        public int IdFilial { get; set; }

        [AtributoBancoDados(AtributoBD=false)]
        public string IdFuncao { get; set; }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdPessoa { get; set; }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdUltimoUsuario { get; set; }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdUsuario { get; set; }

        [AtributoBancoDados(AtributoBD=true)]
        public string Login { get; set; }

        [AtributoBancoDados(AtributoBD=false)]
        public string Nome { get; set; }

        [AtributoBancoDados(AtributoBD=true)]
        public string Senha { get; set; }

        [AtributoBancoDados(AtributoBD=true)]
        public string UltimaAtualizacao { get; set; }
    }
}
