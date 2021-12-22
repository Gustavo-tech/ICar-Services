using System;

namespace ICar.Infrastructure.ViewModels.Output.Login
{
    public class LoginOutputViewModel
    {
        public string Id { get; private set; }
        public DateTime Time { get; private set; }
        public bool Success { get; private set; }

        public LoginOutputViewModel(string id, DateTime time, bool success)
        {
            Id = id;
            Time = time;
            Success = success;
        }
    }
}
