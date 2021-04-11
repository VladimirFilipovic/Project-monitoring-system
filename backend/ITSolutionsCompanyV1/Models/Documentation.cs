using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models
{
    public class Documentation
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public int Version { get; set; }
        public DateTime DateCreated { get; set; } //TODO: cannot be < present date (date when insert was made)
        public DateTime? DateModified { get; set; } //TODO: cannot be < date created 
        public byte[] Pdf { get; set; }
        public bool Accepted { get; set; }
        public Documentation(Guid id, string name, int version, DateTime dateCreated, DateTime? dateModified, byte[] pdf, bool accepted)
        {
            Id = id;
            Name = name;
            Version = version;
            DateCreated = dateCreated;
            DateModified = dateModified;
            Pdf = pdf;
            Accepted = accepted;
        }
    }
}
