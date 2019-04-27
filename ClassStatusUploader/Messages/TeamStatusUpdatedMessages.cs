using System;

namespace ClassStatusUploader.Messages
{
    public class TeamStatusUpdatedMessages
    {
        public Guid Id { get; set; }
        public bool NeedHelp { get; set; }
        public bool Complete { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? HelpTime { get; set; }
    }
}
