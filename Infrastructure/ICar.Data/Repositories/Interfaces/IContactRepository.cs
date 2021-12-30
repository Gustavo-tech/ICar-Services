using ICar.Infrastructure.Models;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface IContactRepository
    {
        public Task<Contact> GetContactAsync(string userId);
    }
}
