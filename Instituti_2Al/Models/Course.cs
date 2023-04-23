using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace Instituti_2Al.Models
{
    public class Course : BaseClass
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Content { get; set; }
        public string Image { get; set; } = String.Empty;

        [NotMapped]
        [DataType(DataType.Upload)]
        [Display(Name = "Upload Image")]
        [Required]
        public IFormFile? ImageFile { get; set; }

        public bool Featured { get; set; }
        public bool Deleted { get; set; }

    }
}
