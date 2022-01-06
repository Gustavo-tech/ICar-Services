using ICar.Chat.Hubs.Interfaces;
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
        private readonly ITokenReader _tokenReader;
        private readonly string _userIdClaimType = "oid";
        private readonly IDictionary<string, List<string>> _connections;

        public ChatHub(ITokenReader tokenReader, IDictionary<string, List<string>> dictionary)
        {
            _tokenReader = tokenReader;
            _connections = dictionary;
        }

        public async Task SendMessage(string token, string toUserId, string subjectId, string message)
        {
            string userObjectId = _tokenReader.ReadClaimValue(token, _userIdClaimType);

            if (!_connections.ContainsKey(userObjectId))
            {
                Connect(token);
            }

            await Clients.Clients(_connections[toUserId]).ReceiveMessage(userObjectId, subjectId, message);
        }

        public void Connect(string token)
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
