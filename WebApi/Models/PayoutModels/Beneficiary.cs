using System;
namespace WebApi.Models.PayoutModels
{
    public class Beneficiary
    {
        public Additionalnfo additional_info;
        public Address address;
        public BankDetails bank_details;

        public string company_name;
        public string date_of_birth;
        public string entity_type;
        public string first_name;
        public string last_name;



        public Beneficiary()
        {
        }
    }
}
