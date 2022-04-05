using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Reflection.AcessoBancoDados;
using Framework.Reflection.InsertUpdateDelete;

namespace Framework.Avaliacao
{
    public class HorarioAcesso
    {
        // Fields
        private string _DiaSemana;
        private string _HoraFim;
        private string _HoraInicio;
        private int _IdHorarioAcesso;
        private int _IdUltimoUsuario;
        private int _IdUsuario;
        private string _UltimaAtualizacao;

        // Methods
        public bool Excluir(HorarioAcesso objClasse, int id)
        {
            bool flag;
            try
            {
                if (id > 0)
                {
                    AcessoBD.DeleteRegistro(objClasse, id);
                    return true;
                }
                flag = false;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return flag;
        }

        public int Salvar(HorarioAcesso objHorarioAcesso, int id, string strNomeTela = "")
        {
            int num2;
            try
            {
                num2 = AcessoBD.InsertUpdateRegistro(objHorarioAcesso, id, strNomeTela);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            return num2;
        }

        // Properties
        [AtributoBancoDados(AtributoBD=true)]
        public string DiaSemana
        {
            get
            {
                return this._DiaSemana;
            }
            set
            {
                this._DiaSemana = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string HoraFim
        {
            get
            {
                return this._HoraFim;
            }
            set
            {
                this._HoraFim = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public string HoraInicio
        {
            get
            {
                return this._HoraInicio;
            }
            set
            {
                this._HoraInicio = value;
            }
        }

        [AtributoBancoDados(AtributoBD=true)]
        public int IdHorarioAcesso
        {
            get
            {
                return this._IdHorarioAcesso;
            }
            set
            {
                this._IdHorarioAcesso = value;
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