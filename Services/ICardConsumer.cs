using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TokenValidator.Models;

namespace TokenValidator.Services
{
    public interface ICardConsumer
    {
        Task<CardApiResponse> GetCard(int cardId);
        Task<CardRegisterApiResponse> GetCardRegister(int cardId);
    }
}
