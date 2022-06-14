using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace beach_sys.Models
{
    public class Compartimento
    {
        //Propriedades
        [Key]
        public int CompartimentoId { get; set; }
        [Required(ErrorMessage ="Número obrigatório.")]
        public int Numero { get; set; }
        [Required(ErrorMessage ="Tamanho obrigatório.")]
        public String Tamanho { get; set; }
        public bool Disponivel { get; set; }
        public bool Aberto { get; set; }

        //Relações
        [ForeignKey("Armario")]
        public int ArmarioId { get; set; }
        public virtual Armario Armario { get; set; }
    }
}