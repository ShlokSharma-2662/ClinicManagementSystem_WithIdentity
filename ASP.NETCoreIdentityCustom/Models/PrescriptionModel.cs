using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP.NETCoreIdentityCustom.Models
{
    public class PrescriptionModel
    {

        [Key]
        public int pres_id { get; set; }


        [ForeignKey("PatientModel")]
        public int PID { get; set; }
        [Required]
        public string? CreatedAt { get; set; }
        [Required]
        public string? P_FName { get; set; }
        [Required]
        public string? P_LName { get; set; }
        [Required]
        public string? medicine_name { get; set; }
        [Required]
        public int? quantity { get; set; }

    }
}
