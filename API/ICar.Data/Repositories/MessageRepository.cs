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
    public class MessageRepository : IMessageRepository
    {
        private readonly ICarContext _context;

        public MessageRepository(ICarContext context)
        {
            _context = context;
        }

        public async Task<Message> GetLastMessageWith(string person, string anotherPerson)
        {
            return await _context.Messages
                .Where(x => (x.FromUser.Email == person && x.ToUser.Email == anotherPerson) || (x.FromUser.Email == anotherPerson && x.ToUser.Email == person))
                .OrderBy(x => x.SendAt)
                .Take(1)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Message>> GetMessagesByEmail(string email)
        {
            return await _context.Messages
                .Where(x => x.ToUser.Email == email || x.FromUser.Email == email)
                .Include(x => x.FromUser)
                .Include(x => x.ToUser)
                .OrderBy(x => x.SendAt)
                .ToListAsync();
        }
    }
}
