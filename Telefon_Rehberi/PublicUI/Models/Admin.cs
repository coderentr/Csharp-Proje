using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicUI.Models
{
    public class Admin
    {
        public Admin()
        {
            KullaniciAdi = "Eren";
            Sifre = "Eren123";
        }
        [Key]
        [Required(ErrorMessage = "Boş Geçmeyiniz")]
        [DisplayName("Kullanıcı Adı")]
        public string KullaniciAdi { get; set; }
        [Required(ErrorMessage = "Boş Geçmeyiniz")]
        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        public string Sifre { get; set; }
    }
}