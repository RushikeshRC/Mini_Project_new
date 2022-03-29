using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet_MiniProject.Models
{
    class StudentAccount
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        [ForeignKey("StudentClassID")]
        public int StudentClassID { get; set; }
        public virtual Student Student { get; set; }
    }
}
