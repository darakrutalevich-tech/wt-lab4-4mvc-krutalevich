using System.ComponentModel.DataAnnotations;
namespace wt_lab4_4mvc_krutalevich.Models
{
    public class Flight
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите номер рейса")]
        [Display(Name = "Номер рейса")]
        [StringLength(10)]
        public string FlightNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите город вылета")]
        [Display(Name = "Город вылета")]
        public string Departure { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажите город прилёта")]
        [Display(Name = "Город прилёта")]
        public string Arrival { get; set; } = string.Empty;

        [Range(1, 100000, ErrorMessage = "Цена должна быть положительной")]
        [Display(Name = "Цена, руб.")]
        public decimal Price { get; set; }

        [Display(Name = "Доступен для продажи")]
        public bool IsAvailable { get; set; }
    }
}
