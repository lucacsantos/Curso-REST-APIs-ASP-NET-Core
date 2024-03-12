namespace AwesomeDevEvents.API.Entities
{
    public class DevEvent
    {
        public DevEvent()
        {
            Speakers = new List<DevEventSpeak>();
            IsDelete = false;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<DevEventSpeak> Speakers { get; set; }
        public bool IsDelete { get; set; }

        public void Update(string title, string description, DateTime startDate, DateTime endDate)
        {
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Delete()
        {
            IsDelete = true;

        }
    }
}
