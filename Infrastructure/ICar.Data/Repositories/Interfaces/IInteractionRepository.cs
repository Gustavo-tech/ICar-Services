using ICar.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface IInteractionRepository
    {
        public Task<List<Interaction>> GetUserInteractionsAsync(string userId);
    }
}
