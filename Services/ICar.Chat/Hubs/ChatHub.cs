using ICar.Chat.Hubs.Interfaces;
using ICar.Infrastructure.Database.Repositories.Interfaces;
using ICar.Infrastructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICar.Chat.Hubs
{
    public class ChatHub : Hub<IChatHub>
    {
        private readonly string _userIdClaimType = "oid";
        private readonly ITokenReader _tokenReader;
        private readonly IDictionary<string, List<string>> _connections;
        private readonly IBaseRepository _baseRepository;

        public ChatHub(ITokenReader tokenReader, IDictionary<string, List<string>> dictionary,
            IBaseRepository baseRepository)
        {
            _tokenReader = tokenReader;
            _connections = dictionary;
            _baseRepository = baseRepository;
        }

        public async Task SendMessage(string token, string toUserId, string subjectId, string text)
        {
            try
            {
                string userObjectId = _tokenReader.ReadClaimValue(token, _userIdClaimType);

                if (userObjectId != toUserId)
                {
                    Message message = new(userObjectId, toUserId, subjectId, text);
                    await _baseRepository.AddAsync(message);

                    if (!_connections.ContainsKey(userObjectId))
                    {
                        Connect(token);
                    }

                    await Clients.Clients(_connections[userObjectId]).MessageSent(message);
                    await Clients.Clients(_connections[toUserId]).ReceiveMessage(message);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Connect(string token)
        {

            try
            {
                string userId = _tokenReader.ReadClaimValue(token, _userIdClaimType);

                if (_connections.ContainsKey(userId))
                {
                    if (!UserIsConnected(userId))
                    {
                        _connections[userId].Add(Context.ConnectionId);
                    }
                }

                else
                {
                    _connections.Add(userId, new List<string> { Context.ConnectionId });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine(exception);

            try
            {
                foreach (KeyValuePair<string, List<string>> kvp in _connections)
                {
                    foreach (string value in kvp.Value)
                    {
                        if (value == Context.ConnectionId)
                        {
                            _connections.Remove(kvp.Key);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return Task.CompletedTask;
        }

        private bool UserIsConnected(string userId)
        {
            List<string> userConnections = _connections[userId];

            foreach (string connectionId in userConnections)
            {
                if (Context.ConnectionId == connectionId)
                    return true;
            }

            return false;
        }
    }
}
