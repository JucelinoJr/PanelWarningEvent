﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepPanel.Application.DTOs
{
    public class WarningDTO
    {
        public string? Id { get; set; }

        [Required(ErrorMessage="A descrição do aviso é necessária")]
        [MinLength(10)]
        [MaxLength(500)]
        [DisplayName("Descrição")]
        public string Description { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
