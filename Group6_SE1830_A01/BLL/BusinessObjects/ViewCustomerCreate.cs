using System.ComponentModel.DataAnnotations;

namespace BLL.BusinessObjects
{
    public class ViewCustomerCreate
    {
        [Required(ErrorMessage = "Tên khách hàng là bắt buộc")]
        [StringLength(100, ErrorMessage = "Tên không vượt quá 100 ký tự")]
        [Display(Name = "Họ và tên")]
        public string FullName { get; set; } = null!;

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(11, ErrorMessage ="Số điện thoại không vượt quá 11 ký tự")]
        [Display(Name = "Số điện thoại")]
        public string? Phone { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [StringLength(100, ErrorMessage = "Email không vượt quá 100 ký tự")]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [StringLength(200, ErrorMessage = "Địa chỉ không vượt quá 200 ký tự")]
        [Display(Name = "Địa chỉ")]
        public string? Address { get; set; }

        [StringLength(20, ErrorMessage = "CMND/CCCD không vượt quá 20 ký tự")]
        [Display(Name = "CMND/CCCD")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CMND/CCCD")]
        public string? Idnumber { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public DateOnly? Dob { get; set; }

        [StringLength(300, ErrorMessage = "Ghi chú không vượt quá 300 ký tự")]
        [Display(Name = "Ghi chú")]
        public string? Note { get; set; }
    }
}
