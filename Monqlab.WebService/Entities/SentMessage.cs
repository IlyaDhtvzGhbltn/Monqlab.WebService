using Monqlab.WebService.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Entities
{
    public class SentMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [MaxLength(1000)]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        public DateTime CreationDateUtc { get; set; }

        [MaxLength(10)]
        public string Result { get; set; }

        public string FailedMessage { get; set; }

        [MaxLength(128)]
        [DataType(DataType.EmailAddress)]
        public string Recipient { get; set; }
    }
}
