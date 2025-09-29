using System.ComponentModel.DataAnnotations;

namespace BLL.BusinessObjects
{
    public class CreateTestDriveAppointment
    {
        [Required(ErrorMessage = "Vui lòng chọn khách hàng.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn phiên bản xe.")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn phiên bản xe hợp lệ.")]
        public int CarVersionId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn màu xe.")]
        [Range(1, int.MaxValue, ErrorMessage = "Vui lòng chọn màu xe hợp lệ.")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn ngày giờ.")]
        public DateTime DateTime { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Scheduled";

        [StringLength(500, ErrorMessage = "Ghi chú tối đa 500 ký tự.")]
        public string? Feedback { get; set; }
    }
}
