using ICar.Infrastructure.Database;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories
{
    public class InteractionRepository : IInteractionRepository
    {
        private readonly ICarContext _dbContext;

        public InteractionRepository(ICarContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Interaction> GetInteractionWithAsync(string userId, string withUserId, string subject)
        {
            return await _dbContext.Interactions
                .Where(x => x.UserId == userId 
                && x.WithUserId == withUserId 
                && x.SubjectId == subject)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Interaction>> GetUserInteractionsAsync(string userId)
        {
            return await _dbContext.Interactions
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }
    }
}
