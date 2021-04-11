using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITSolutionsCompanyV1.Models
{
    public class Demo
    {
        public Guid Id { get; set; }
        [MaxLength(200)]
        public string Name { get; set; }
        public DateTime DateCreated { get; set; } //TODO: cannot be < present date (date when insert was made) if not provided then today()
        public byte[] Video { get; set; }
        public byte[] Exe { get; set; }
        public Demo(Guid id, string name, DateTime dateCreated, byte[] video, byte[] exe)
        {
            Id = id;
            Name = name;
            DateCreated = dateCreated;
            Video = video;
            Exe = exe;
        }
    }
}
