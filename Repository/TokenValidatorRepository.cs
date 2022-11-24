using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenValidator.Models;
using TokenValidator.Services;

namespace TokenValidator.Repository
{
    public class TokenValidatorRepository : ITokenValidatorRepository
    {
        private readonly ICardConsumer _cardConsumer;

        public TokenValidatorRepository(ICardConsumer cardConsumer)
        {
            _cardConsumer = cardConsumer;
        }
        public async Task<TokenOutput> ValidateToken(TokenInput input)
        {
            var validation = await TokenValidator(input);

            var result = new TokenOutput() { Validated = validation };
            return result;
        }

        private async Task<bool> TokenValidator(TokenInput input)
        {
            var cardRegister = await _cardConsumer.GetCardRegister(input.CardId);

            if (cardRegister.RegistrationDate > cardRegister.RegistrationDate.AddMinutes(30))
                return false;

            var card = await _cardConsumer.GetCard(input.CardId);

            if(input.CustomerId != card.CustomerId)
                return false;

            var compareToken = GenerateToken(card.CVV, card.CardNumber);

            if (compareToken != cardRegister.Token)
                return false;

            return true;
        }

        private static int MathMod(int a, int b)
        {
            int c = ((a % b) + b) % b;
            return c;
        }
        private static IEnumerable<T> ShiftRight<T>(IList<T> values, int shift)
        {
            for (int index = 0; index < values.Count; index++)
            {
                yield return values[MathMod(index - shift, values.Count)];
            }
        }

        private static long GenerateToken(int cvv, long cardNumber)
        {
            var lastFourDigitsCardNumber = cardNumber.ToString()[Math.Max(0, cardNumber.ToString().Length - 4)..];

            var intList = lastFourDigitsCardNumber.Select(x => Convert.ToInt32(x.ToString())).ToList();

            var convert = ShiftRight(intList, cvv);

            var result = int.Parse(string.Join(",", convert).Replace(",", ""));

            return Convert.ToInt64(result);
        }
    }
}
