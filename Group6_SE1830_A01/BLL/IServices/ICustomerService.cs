using BLL.BusinessObjects;

namespace BLL.IServices
{
    public interface ICustomerService 
    {
        Task<int> GetTotalCustomers();
        Task<ICollection<ViewCustomer>> GetAllCustomers();
        Task CreateCustomer(ViewCustomerCreate customer);
        Task EditCustomer(ViewCustomerEdit customer);
        Task<bool> DeleteCustomer(int id);
    }
}
