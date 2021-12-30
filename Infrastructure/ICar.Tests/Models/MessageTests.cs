using ICar.Infrastructure.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ICar.Infrastructure.Tests.Models
{
    class MessageTests
    {
        private Message _message;

        [SetUp]
        public void SetUp()
        {
            _message = new("ggg", "hhh", "Hello");
        }
    }
}
