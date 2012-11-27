using System;

namespace DemoCode.Controllers
{
    public class BigEvent
    {
        public string Name { get; set; }

        public DateTimeOffset Date { get; set; }

        public BigEvent(string name)
        {
            Name = name;
            Date = DateTimeOffset.Now;
        }
    }
}