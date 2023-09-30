using System.ComponentModel.DataAnnotations;
using System.Net;

namespace FirstProject.Models
{
    public class Employee
    {
        public Guid? Id { get; set; }

        [Required(ErrorMessage ="Phải nhập mã nhân viên")]
        [RegularExpression(@"NV\d{5}", ErrorMessage ="Mã NV dạng NVxxxxx")]
        public string EmployeeNo { get; set; }

        [StringLength(150, MinimumLength = 5, ErrorMessage ="Từ 5 đến 150 kí tự")]
        public string FullName { get; set; }

        [RegularExpression(@"[a-z]+(.[a-z]+)*@hcmue.edu.vn")]
        public string Email { get; set; }

        [Url]
        public string Website { get; set; }


        [KiemTraDuTuoiLamViec]
        public DateTime? BirthDate { get; set; }

        public bool Gender { get; set; } = true;
        public double Salary { get; set; }
        public bool IsPartTime { get; set; } = false;
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CreditCard { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}
