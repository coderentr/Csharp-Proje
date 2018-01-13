using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PublicUI.Models
{
    public class Calisan
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        [DisplayName("Adı")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        [DisplayName("Soyadı")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Bu Alan Boş Geçilemez")]
        [DisplayName("Telefon Numarası")]
        [DataType(DataType.PhoneNumber)]
        public string Telefon { get; set; }
        public int? DepartmanID { get; set; }
        public int? YoneticiID { get; set; }

        [ForeignKey("DepartmanID")]
        public virtual Departman Departman { get; set; }

        [ForeignKey("YoneticiID")]
        public virtual Yonetici Yonetici { get; set; }
    }
}