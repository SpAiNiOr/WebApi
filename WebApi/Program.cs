using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Models.PayoutModels;

namespace WebApi
{
    class Program
    {

        static async void Main(string[] args)
        {

            GetToken getToken = new GetToken();
            var token = getToken.GetWebToken();

            Console.WriteLine(token);

            String bearer = "Bearer " + token;

            Payouts payouts = new Payouts();

            /*
            //Get Beneficiary by ID
            Console.WriteLine("Please input a Beneficiar ID:");
            string id = Console.ReadLine();

            BeneficiaryResponse beneficiaryResponse = payouts.GetBeneficiaryByID(bearer, id);

            Console.WriteLine("The Beneficiary searched by ID:");
            Console.WriteLine(beneficiaryResponse.beneficiary_id);
            Console.Read();
            */

            //Create a new Beneficiary
            Console.WriteLine("Try create a new Beneficiary");
            BeneficiaryResponse newBeneficiary = await payouts.CreateBeneficiary(bearer);

            if (newBeneficiary == null)
            {
                Console.WriteLine("Create a new Beneficiary failed!");
            }

            else
            {
                Console.WriteLine(newBeneficiary.beneficiary_id);
            }

            Console.Read();



        }



    }
}
