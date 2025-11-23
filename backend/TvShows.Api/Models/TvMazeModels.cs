namespace TvShows.Api.Models
{
    public class TvMazeSearchResult
    {
        public TvMazeShow Show { get; set; } = null!;
    }

    public class TvMazeShow
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Language { get; set; }
        public List<string>? Genres { get; set; }
        public TvMazeRating? Rating { get; set; }
        public TvMazeImage? Image { get; set; }
    }

    public class TvMazeRating
    {
        public double? Average { get; set; }
    }

    public class TvMazeImage
    {
        public string? Medium { get; set; }
    }

    public class TvMazeEpisode
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Season { get; set; }
        public int Number { get; set; }
        public int? Runtime { get; set; }
    }
}
