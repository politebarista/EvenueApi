namespace EvenueApi
{
    public static class EvenueStatusCode
    {
        // GENERAL ERRORS - 600
        public static string IncorrectPassword { get => "602"; } // TODO: change to 601

        // CUSTOMER ERRORS - 610
        public static string CustomerDontExist { get => "601"; } // TODO: change to 611
        public static string CustomerAlreadyExist { get => "603"; } // TODO: change to 612
        public static string ErrorWhileCreatingCustomer { get => "604"; } // TODO: change to 613

        // ORGANIZER ERRORS - 620
        public static string OrganizerDontExist { get => "605"; } // TODO: change to 621

        // TICKET ERROR CODES - 630
        public static string NoAwaitingPaymentTicket { get => "631"; }
        public static string IncorrectConfirmationPurchaseCode { get => "632"; }
        public static string NoTicketsLeftForEvent { get => "633"; }
    }
}
