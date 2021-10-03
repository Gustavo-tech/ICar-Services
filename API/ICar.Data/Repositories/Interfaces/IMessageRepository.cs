﻿using ICar.Infrastructure.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICar.Infrastructure.Repositories.Interfaces
{
    public interface IMessageRepository
    {
        Task<List<Message>> GetMessagesByEmail(string email);
        Task<Message> GetLastMessageWith(string person, string anotherPerson);
    }
}