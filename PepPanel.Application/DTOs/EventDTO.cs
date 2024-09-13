using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepPanel.Application.DTOs
{
    public class EventDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A data do evento é obrigatória")]
        [DisplayName("Data do Evento")]
        public DateTime EventDateTime { get; set; }

        [Required(ErrorMessage = "A descrição do evento é obrigatória")]
        [MinLength(10)]
        [MaxLength(1000)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O Responsável do evento é obrigatório")]
        [MinLength(3)]
        [MaxLength(255)]
        [DisplayName("Responsável")]
        public string Responsible { get; set; }
    }
}
