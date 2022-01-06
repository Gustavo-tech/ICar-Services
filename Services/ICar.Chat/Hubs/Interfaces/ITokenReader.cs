namespace ICar.Chat.Hubs.Interfaces
{
    public interface ITokenReader
    {
        public string ReadClaimValue(string token, string type);
    }
}
