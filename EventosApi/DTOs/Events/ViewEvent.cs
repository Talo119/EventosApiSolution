namespace EventosApi.DTOs.Events
{
    public class ViewEvent
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime? Eventdate { get; set; }

        public string? User { get; set; }
    }
}
