namespace EvenueApi
{
    public static class EvenueStatusCode
    {
        public static string CustomerDontExist { get => "601"; }
        public static string IncorrectPassword { get => "602"; }
        public static string CustomerAlreadyExist { get => "603"; }
        public static string ErrorWhileCreatingCustomer { get => "604"; }
        public static string OrganizerDontExist { get => "605"; }
    }
}
