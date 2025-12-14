using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HealthSystemApp.Data
{
    public class HealthRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        [Required]
        public DateTime Date { get; set; } = DateTime.Today;

        public double? Weight { get; set; } // вес в кг
        public int? SystolicPressure { get; set; } // верхнее давление
        public int? DiastolicPressure { get; set; } // нижнее давление
        public int? HeartRate { get; set; } // пульс

        public string? Notes { get; set; } // заметки
    }
}
