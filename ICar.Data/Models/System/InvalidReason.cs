namespace ICar.Data.Models.System {
    public class InvalidReason {
        public string Title { get; set; }
        public string Message { get; set; }

        public InvalidReason(string title, string message) {
            Title = title;
            Message = message;
        }
    }
}
