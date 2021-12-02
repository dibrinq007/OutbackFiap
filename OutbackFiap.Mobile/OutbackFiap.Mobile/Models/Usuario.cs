using System.ComponentModel;
using SQLite;

namespace OutbackFiap.Mobile.Models
{
    public enum TipoUsuario
    {
        [Description("Funcionario")]
        Funcionario,

        [Description("Cliente")]
        Cliente
    }

    public class Usuario
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
