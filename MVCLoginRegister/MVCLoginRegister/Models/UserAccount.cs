using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLoginRegister.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }

        [Required(ErrorMessage ="İsim bilginizi girmeniz gerekmektedir.")]
        public string Ad { get; set; }
        [Required(ErrorMessage ="Soyisim bilginizi girmeniz gerekmektedir.")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "E-Mail bilginizi girmeniz gerekmektedir.")]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3]\.)|(([\w-]+\.)+))([a-zA-Z{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Lütfen geçerili bir e posta adresi giriniz.")]
        public string E_Mail  { get; set; }
        [Required(ErrorMessage ="Kulanıcı adınızı girmelisiniz.")]
        public string  KullaniciAdi { get; set; }
        [Required(ErrorMessage ="Sifrenizi girmelisiniz.")]
        [DataType(DataType.Password)]
        public string  Sifre { get; set; }
        [Compare("Sifre",ErrorMessage ="Lütfen şifreyi tekrar giriniz.")]
        [DataType(DataType.Password)]
        public string SifreTekrar { get; set; }
    }
}