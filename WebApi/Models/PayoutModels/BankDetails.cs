using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.PayoutModels
{
    public class BankDetails
    {
        [Required()]
        public string account_currency;

        [Required()]
        public string account_name;

        [Required()]
        public string account_number;

        [Required(ErrorMessage = "Please input the routing code type")]
        public string account_routing_type1;

        [Required()]
        public string account_routing_type2;
        public string account_routing_value1;
        public string account_routting_value2;
        public string bank_branch;

        [Required()]
        public string bank_country_code;

        [Required()]
        public string bank_name;
        public string bank_street_address;
        public string binding_mobile_number;
        public string iban;
        public string local_clearing_system;
        public string swift_code;
        public string transaction_reference;


        public BankDetails()
        {
        }
    }
}
