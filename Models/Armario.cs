using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace beach_sys.Models
{
    public class Armario
    {
        //Propriedades
        [Key]
        public int ArmarioId { get; set; }
        [Required(ErrorMessage ="Nome obrigatório.")]
        public String Nome { get; set; }
        [Required(ErrorMessage ="Latitude obrigatória.")]
        public double Latitude { get; set; }
        [Required(ErrorMessage ="Longitude obrigatório.")]
        public double Longitude { get; set; }
        
        //Relações
        public virtual ICollection<Compartimento> Compartimentos { get; set; }
        
        public int qtdCompartimentos(){
            return Compartimentos.Count;
        }
    }
}