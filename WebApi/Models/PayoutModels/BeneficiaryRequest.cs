using System;
namespace WebApi.Models.PayoutModels
{
    public class BeneficiaryRequest
    {
        public Beneficiary beneficiary;
        public string nickname;
        public string payer_entity_type;
        public string[] payment_methods;
        public string payment_reason;

        public BeneficiaryRequest()
        {
        }
    }
}
