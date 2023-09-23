using System.ComponentModel.DataAnnotations;

namespace FirstProject.Models
{
    public class Student
    {
        [Display(Name ="Mã số Sinh viên")]
        [RegularExpression(@"\d{2}.01.10[34].\d{3}", ErrorMessage ="Sai định dạng mã sinh viên")]
        public string StudentId { get; set; }

        [MaxLength(150, ErrorMessage ="Tối đa 150 kí tự")]
        [Required(ErrorMessage ="Phải nhập họ tên")]
        public string FullName { get; set; }

        [EmailAddress]
        [RegularExpression(@"\w+@student.hcmue.edu.vn")]
        public string Email { get; set; }

        [Range(18, 60, ErrorMessage ="Tuổi 18 - 60")]
        public int Age { get; set; }
    }
}
