namespace TvShows.Api.Models
{
    public class EpisodeResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Season { get; set; }
        public int Number { get; set; }
        public int? Runtime { get; set; }
    }

    public class ShowResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Language { get; set; }
        public List<string> Genres { get; set; } = new();
        public double? Rating { get; set; }
        public string? ImageUrl { get; set; }
    }
}
