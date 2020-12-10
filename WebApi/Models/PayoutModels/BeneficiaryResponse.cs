using System;
namespace WebApi.Models.PayoutModels
{
    public class BeneficiaryResponse
    {
        public Beneficiary beneficiary;
        public string beneficiary_id;
        public string nickname;
        public string payer_entity_type;
        public string[] payment_methods;

    }
}
