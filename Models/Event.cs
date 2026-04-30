namespace ZealandZoo.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Location { get; set; }
        public int MaxParticipants { get; set; }


        public Event(string title, string description, DateTime startDateTime,
            DateTime endDateTime, string location, int maxParticipants)
        {

            Title = title;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Location = location;
            MaxParticipants = maxParticipants;

        }

        public Event()
        {

        }

        public override string ToString()
        {
            return $"Event: {Title} at {Location} from {StartDateTime} to {EndDateTime}. Max Participants: {MaxParticipants}";
        }

    }
}
