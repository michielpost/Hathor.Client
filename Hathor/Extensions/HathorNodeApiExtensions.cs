using Hathor.Models.Node.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hathor.Extensions
{
    public static class HathorNodeApiExtensions
    {
        public static async Task<BalanceForAddressResponse> CalculateBalanceForAddress(this IHathorNodeApi hathorNodeApi, string address)
        {
            var transactions = await hathorNodeApi.GetAddressHistory(address);
            if (!transactions.Success)
                throw new Exception(transactions.Message);

            BalanceForAddressResponse result = new BalanceForAddressResponse();
            result.TotalTransactions = transactions.History.Count();

            var tokenDataResult = new Dictionary<string, TokenData>();

            foreach (var transaction in transactions.History.Where(x => !x.IsVoided))
            {
                var validInputs = transaction.Inputs
                   .Where(x => x.Decoded?.Address?.Equals(address, StringComparison.InvariantCultureIgnoreCase) ?? false)
                   .ToList();

                var validOutputs = transaction.Outputs
                   .Where(x => x.Decoded?.Address?.Equals(address, StringComparison.InvariantCultureIgnoreCase) ?? false)
                   .ToList();

                Dictionary<string, TokenData> inputs = ToTokenDataDictionary(validInputs);
                Dictionary<string, TokenData> ouputs = ToTokenDataDictionary(validOutputs);

                foreach (var input in inputs)
                {
                    var key = input.Key;
                    if (key == null)
                        continue;
                    var tokenData = tokenDataResult.ContainsKey(key) ? tokenDataResult[key] : new TokenData();

                    tokenData.Spent += input.Value.Spent;

                    tokenDataResult[key] = tokenData;
                }


                foreach (var output in ouputs)
                {
                    var key = output.Key;
                    if (key == null)
                        continue;
                    var tokenData = tokenDataResult.ContainsKey(key) ? tokenDataResult[key] : new TokenData();

                    tokenData.Received += output.Value.Received;

                    tokenDataResult[key] = tokenData;
                }

            }

            result.TokensData = tokenDataResult;

            return result;
        }

        private static Dictionary<string, TokenData> ToTokenDataDictionary(List<Input> inputs)
        {
            Dictionary<string, TokenData> result = new Dictionary<string, TokenData>();
            foreach (var input in inputs)
            {
                var key = input.Token;
                if (key == null)
                    continue;

                var tokenData = result.ContainsKey(key) ? result[key] : new TokenData();
                tokenData.Spent += input.Value;

                result[key] = tokenData;
            }

            return result;
        }

        private static Dictionary<string, TokenData> ToTokenDataDictionary(List<Output> outputs)
        {
            Dictionary<string, TokenData> result = new Dictionary<string, TokenData>();
            foreach (var output in outputs)
            {
                var key = output.Token;
                if (key == null)
                    continue;

                var tokenData = result.ContainsKey(key) ? result[key] : new TokenData();
                tokenData.Received += output.Value;

                result[key] = tokenData;
            }

            return result;
        }
    }
}
