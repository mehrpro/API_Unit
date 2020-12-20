using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Unit.Models
{
    public class TagRegistered
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RowID { get; set; }
        [Required]
        public int  TagID_FK { get; set; }
        public Tags Tags { get; set; }
        [Required]
        public DateTime RegisterdDateTime { get; set; }
        [Required]
        public bool ViewRegistered { get; set; }
        [Required]
        public bool Enabled { get; set; }
        [Required]
        public int ReporterID_FK { get; set; }
        public ReporterStation ReporterStation { get; set; }
    }
}