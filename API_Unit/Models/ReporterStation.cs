using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Unit.Models
{
    public class ReporterStation
    {

        public ReporterStation()
        {
            TagRegistereds=new HashSet<TagRegistered>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReporterID { get; set; }
        [Required]
        [MaxLength(250)]
        public string ReporterTitel { get; set; }
        [MaxLength(350)]
        public string Description { get; set; }


        [ForeignKey("ReporterID_FK")]
        public virtual ICollection<TagRegistered> TagRegistereds { get; set; }
    }
}