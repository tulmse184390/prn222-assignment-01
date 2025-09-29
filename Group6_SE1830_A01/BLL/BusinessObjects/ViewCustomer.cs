using DAL.Entities;

namespace BLL.BusinessObjects
{
    public class ViewCustomer
    {
        public int CustomerId { get; set; }

        public string FullName { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Address { get; set; }

        public string? Idnumber { get; set; }

        public DateOnly? Dob { get; set; }

        public string? Note { get; set; }

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
