using System;
using WebApi.Models.PayoutModels;
using RestSharp;
using System.Text.Json;
using WebApi.Models;
using Newtonsoft.Json;

namespace WebApi
{
    public class Payouts
    {
        public Payouts()
        {
        }

        public BeneficiaryResponse GetBeneficiaryByID(string bearer, string id)
        {
            var client = new RestClient();
            client.BaseUrl = new Uri(Config.BaseURL);

            /*
            The following code is working.

            var request = new RestRequest("/api/v1/beneficiaries/{beneficiary_id}", Method.GET);
            request.AddUrlSegment("beneficiary_id", id);
            request.AddHeader("Authorization", bearer);
            */

            string queryEndpoint = "/{beneficiary_id}";
            var request = new RestRequest(Config.Beneficiaries + queryEndpoint, Method.GET);
            request.AddUrlSegment("beneficiary_id", id);
            request.AddHeader("Authorization", bearer);

            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);

            BeneficiaryResponse beneficiaryResponse = JsonConvert.DeserializeObject<BeneficiaryResponse>(response.Content);

            return beneficiaryResponse;
        }

        public BeneficiaryResponse CreateBeneficiary(string bearer)
        {

            //create Beneficiary request object
            Additionalnfo additionalnfo = new Additionalnfo();

            Address address = new Address();

            Console.WriteLine("Please input your city:");
            address.city = Console.ReadLine();
            Console.WriteLine("Please input the Country Code:");
            address.country_code = Console.ReadLine().ToUpper();
            Console.WriteLine("Please input your post code:");
            address.postcode = Console.ReadLine();
            Console.WriteLine("Please input your state:");
            address.state = Console.ReadLine();
            Console.WriteLine("Please input your address:");
            address.street_address = Console.ReadLine();

            BankDetails bankDetails = new BankDetails();

            Console.WriteLine("Please input account currency:");
            bankDetails.account_currency = Console.ReadLine().ToUpper();
            Console.WriteLine("Please input your Account Name:");
            bankDetails.account_name = Console.ReadLine();
            Console.WriteLine("Please input your Bank Number");
            bankDetails.account_number = Console.ReadLine();
            Console.WriteLine("Please input the Routing code type;");
            bankDetails.account_routing_type1 = Console.ReadLine();
            Console.WriteLine("Please input the Routing code number");
            bankDetails.account_routing_value1 = Console.ReadLine();
            Console.WriteLine("Please input your Bank Country Code:");
            bankDetails.bank_country_code = Console.ReadLine().ToUpper();
            Console.WriteLine("Please input your Bank Name:");
            bankDetails.bank_name = Console.ReadLine();

            Beneficiary beneficiary = new Beneficiary();

            beneficiary.additional_info = additionalnfo;
            beneficiary.address = address;
            beneficiary.bank_details = bankDetails;
            Console.WriteLine("Please input your Company name:");
            beneficiary.company_name = Console.ReadLine();
            Console.WriteLine("Please input your First Name:");
            beneficiary.first_name = Console.ReadLine();
            Console.WriteLine("Please input your Last Name:");
            beneficiary.last_name = Console.ReadLine();
            Console.WriteLine("Please input your Entity Type:");
            beneficiary.entity_type = Console.ReadLine().ToUpper();

            BeneficiaryRequest beneficiaryRequest = new BeneficiaryRequest
            {
                beneficiary = beneficiary
            };

            Console.WriteLine("Please select your Payment method: Local or Swift");
            string paymentMethod = Console.ReadLine().ToUpper();
            beneficiaryRequest.payment_methods = new string[1];
            beneficiaryRequest.payment_methods[0] = paymentMethod;

            // create json string for http request
            string json = JsonConvert.SerializeObject(beneficiaryRequest);

            Console.WriteLine("The generated beneficiary info: " + json);

            var client = new RestClient();
            client.BaseUrl = new Uri(Config.BaseURL);
            string queryEndpoint = "/create";
            var request = new RestRequest(Config.Beneficiaries + queryEndpoint, Method.POST);
            request.AddHeader("Authorization", bearer);
            request.AddParameter("application / json", json, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);

            if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                Console.WriteLine("Got BadRequest:  " + response.Content);
                return null;
            }
            else
            {
                BeneficiaryResponse beneficiaryResponse = JsonConvert.DeserializeObject<BeneficiaryResponse>(response.Content);

                return beneficiaryResponse;
            }



        }
    }
}
