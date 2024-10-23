using PepPanel.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepPanel.Domain.Entities
{
    [Table("PP_WARNING")]
    public sealed class Warning
    {
        [Column("WR_ID")]
        public string Id { get; private set; }

        [Column("WR_DESCRIPTION")]
        public string Description {  get; private set; }

        [Column("WR_CREATEDATE")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Column("WR_UPDATEDATE")]
        public DateTime? UpdateDate { get; set; }

        public Warning(string description)
        {
            ValidateDomain(description);
        }

        public Warning(string id, string description)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(id), "Id inválido/inexistente");
            Id = id;
            ValidateDomain(description);
        }

        private void ValidateDomain(string description)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(description),"Aviso inválido. O aviso é necessário");
            DomainExceptionValidation.When(description.Length < 10, "Aviso inválido. Mínimo 10 caracteres");

            Description = description;
        }
    }
}
