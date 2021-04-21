using ICar.Data.Models;
using ICar.Data.Models.System;
using System.Collections.Generic;

namespace ICar.Data.Validations {
    public static class NewsValidator {
        private static bool ValidateTitle(string title) {
            return !string.IsNullOrWhiteSpace(title) && title.Length >= 7;
        }

        private static bool ValidateBody(string title) {
            return !string.IsNullOrWhiteSpace(title) && title.Length >= 20;
        }

        public static List<InvalidReason> GetInvalidReasons(News news) {
            List<InvalidReason> invalidReasons = new List<InvalidReason>();

            if (!ValidateTitle(news.Title))
                invalidReasons.Add(new InvalidReason("Title is invalid", "Title should contains seven or more characters"));

            if (!ValidateBody(news.Text))
                invalidReasons.Add(new InvalidReason("Body is invalid", "Body should contains 20 or more characters"));

            if (invalidReasons.Count == 0)
                return null;
            else
                return invalidReasons;
        }
    }
}
