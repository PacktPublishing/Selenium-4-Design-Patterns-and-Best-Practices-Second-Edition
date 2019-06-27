using TestDataPreparationDemos.Configuration;

namespace TestDataPreparationDemos.Facades.Second
{
    public class PurchaseInfo
    {
        public string FirstName { get; set; } = ConfigurationService.Instance.GetBillingInfoDefaultValues().FirstName;
        public string LastName { get; set; } = ConfigurationService.Instance.GetBillingInfoDefaultValues().LastName;
        public string Company { get; set; } = ConfigurationService.Instance.GetBillingInfoDefaultValues().Company;
        public string Country { get; set; } = ConfigurationService.Instance.GetBillingInfoDefaultValues().Country;
        public string Address1 { get; set; } = ConfigurationService.Instance.GetBillingInfoDefaultValues().Address1;
        public string Address2 { get; set; } = ConfigurationService.Instance.GetBillingInfoDefaultValues().Address2;
        public string City { get; set; } = ConfigurationService.Instance.GetBillingInfoDefaultValues().City;
        public string Zip { get; set; } = ConfigurationService.Instance.GetBillingInfoDefaultValues().Zip;
        public string Phone { get; set; } = ConfigurationService.Instance.GetBillingInfoDefaultValues().Phone;
        public string Email { get; set; } = ConfigurationService.Instance.GetBillingInfoDefaultValues().Email;
        public bool ShouldCreateAccount { get; set; }
        public bool ShouldCheckPayment { get; set; }
        public string Note { get; set; }
    }
}
