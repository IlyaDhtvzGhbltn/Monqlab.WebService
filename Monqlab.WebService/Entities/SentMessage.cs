﻿using Monqlab.WebService.DTO;
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
        /// <summary>
        /// Primary key. Generated by Database
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Max Length 1000
        /// </summary>
        [MaxLength(1000)]
        public string Subject { get; set; }

        /// <summary>
        /// Required Field
        /// </summary>
        [Required]
        public string Body { get; set; }

        /// <summary>
        /// Date in UTC
        /// </summary>
        public DateTime CreationDateUtc { get; set; }

        /// <summary>
        /// Max length 10. Could be Ok or Failed only
        /// </summary>
        [MaxLength(10)]
        public string Result { get; set; }

        /// <summary>
        /// Exception when trying to send a message or NULL
        /// </summary>
        public string FailedMessage { get; set; }

        /// <summary>
        /// Max length 128. DataType - EmailAddress
        /// </summary>
        [MaxLength(128)]
        [DataType(DataType.EmailAddress)]
        public string Recipient { get; set; }
    }
}
