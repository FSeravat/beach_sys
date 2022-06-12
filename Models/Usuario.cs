using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace beach_sys.Models
{
    public class Usuario
    {
        //Propriedades
        [Key]
        public int UsuarioId { get; set; }
        [Required(ErrorMessage ="Email obrigatório.")]
        public String Email { get; set; }
        [Required(ErrorMessage ="CPF obrigatório.")]
        public String Cpf { get; set; }
        [Required(ErrorMessage ="Nome obrigatório.")]
        public String Nome { get; set; }
        
        //Relações
        [ForeignKey("Compartimento")]
        public int CompartimentoId { get; set; }
        public virtual Compartimento Compartimento { get; set; }
    }
}