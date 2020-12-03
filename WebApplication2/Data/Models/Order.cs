using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace batuaShop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Введите имя")]
        [StringLength(maximumLength: 30, MinimumLength = 2)]
        [Required(ErrorMessage ="Длина имени не менее 2 символов")]
        public string name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(maximumLength:30, MinimumLength = 3)]
        [Required(ErrorMessage = "Длина фамилии не менее 3 символов")]
        public string surname { get; set; }

        [Display(Name = "Введите адресс")]
        [StringLength(maximumLength: 30, MinimumLength = 5)]
        [Required(ErrorMessage = "Длина адресса не менее 5 символов")]
        public string adress { get; set; }

        [Display(Name = "Введите номер телефона")]
        [StringLength(maximumLength: 30, MinimumLength = 10)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина номера телефона не менее 10 символов")]
        public string phone { get; set; }
        
        [StringLength(maximumLength: 30, MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Длина почты не менее 3 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime dateTime { get; set; }
        [BindNever]
        public List<OrderDetail> orderDetails { get; set; } 
    }
}
