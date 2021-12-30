using ICar.Infrastructure.Database;
using ICar.Infrastructure.Models;
using ICar.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ICarContext _dbContext;

        public ContactRepository(ICarContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Contact> GetContactAsync(string userId)
        {
            return await _dbContext.Contacts.FindAsync(userId);
        }
    }
}
