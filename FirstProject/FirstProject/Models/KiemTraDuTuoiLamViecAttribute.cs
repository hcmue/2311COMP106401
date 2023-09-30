using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models
{
    public class KiemTraDuTuoiLamViecAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) return ValidationResult.Success;

            var ngaySinh = (DateTime)value;
            var tuoi = DateTime.Now.Year - ngaySinh.Year;
            if (tuoi < 18)
            {
                return new ValidationResult("Chưa đủ tuổi làm việc");
            }
            if (tuoi > 60)
            {
                return new ValidationResult("Quá tuổi làm việc");
            }
            return ValidationResult.Success;
        }
    }
}