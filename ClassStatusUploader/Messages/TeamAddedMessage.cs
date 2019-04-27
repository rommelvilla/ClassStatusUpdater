using System;
using System.Linq;

namespace ClassStatusUploader.Messages
{
    public class TeamAddedMessage
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
    }
    public class TeamStatusChange
    {
        public Guid Id { get; set; }
    }
}
