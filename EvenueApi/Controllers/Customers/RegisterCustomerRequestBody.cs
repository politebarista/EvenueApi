namespace EvenueApi.Controllers.Customers
{
    public class RegisterCustomerRequestBody
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
