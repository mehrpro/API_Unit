using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_Unit.Models
{
    public class Tags
    {
        public Tags()
        {
            TagRegistereds=new HashSet<TagRegistered>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TagID { get; set; }
        [Required]
        [MaxLength(250)]
        public string TagTitel { get; set; }



        [ForeignKey("TagID_FK")]
        public virtual ICollection<TagRegistered> TagRegistereds { get; set; }

    }
}