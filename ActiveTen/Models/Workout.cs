namespace ActiveTen.Models
{
    public class Workout
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Duration { get; set; }
        public required string ImageUrl { get; set; }
        public required string VideoUrl { get; set; }
    }
}
