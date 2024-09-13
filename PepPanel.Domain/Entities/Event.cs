using PepPanel.Domain.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepPanel.Domain.Entities
{
    [Table("PP_EVENT")]
    public sealed class Event
    {
        [Column("EV_ID")]
        public int Id { get; private set; }

        [Column("EV_EVENTDATETIME")]
        public DateTime? EventDateTime { get; private set; }

        [Column("EV_DESCRIPTION")]
        public string Description { get; private set; }

        [Column("EV_RESPONSIBLE")]
        public string Responsible { get; private set; }

        [Column("EV_CREATEDATE")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Column("EV_UPDATEDATE")]
        public DateTime? UpdateDate { get; set; } = DateTime.Now;
    
        public Event(DateTime? eventDateTime, string description, string responsible)
        {
            ValidateDomain(eventDateTime, description, responsible);
        }

        public Event(int id, DateTime? eventDateTime, string description, string responsible) 
        {
            DomainExceptionValidation.When(id < 0, "Id inválido/inexistente");
            Id = id;
            ValidateDomain(eventDateTime, description, responsible);
        }

        private void ValidateDomain(DateTime? eventdatetime, string description, string responsible)
        {
            DomainExceptionValidation.When(!eventdatetime.HasValue, "Data do evento não especificada. Data do evento é necessária");
            DomainExceptionValidation.When(description.Length < 10, "Evento inválido. Mínimo 10 caracteres");
            DomainExceptionValidation.When(responsible.Length < 3, "Evento inválido. Mínimo 3 caracteres");

            Description = description;
            EventDateTime = eventdatetime;
            Responsible = responsible;
        }
    }
}
