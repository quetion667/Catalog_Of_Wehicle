using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogOfWehicle.Models
{
    //  класс с нужными полями
    public class Wehicle
    {
        public int ID { get; set; }//обязателен для привязки к БД 
        [Display(Name = "Регистрационный номер")]
        public string RegistrationNumber { get; set; }
        [Display(Name = "Марка")]
        public string ModelWehicle{ get; set; }
        [Display(Name = "Цвет")]
        public string Color { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата производства")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Пробег")]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal KilometrAge { get; set; }

    }
}
