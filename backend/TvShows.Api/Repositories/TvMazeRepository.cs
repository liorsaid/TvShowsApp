using TvShows.Api.Models;

namespace TvShows.Api.Repositories
{
    public class TvMazeRepository
    {
        private readonly HttpClient r_Client;

        public TvMazeRepository(IHttpClientFactory httpClientFactory)
        {
            r_Client = httpClientFactory.CreateClient();
            r_Client.BaseAddress = new Uri("https://api.tvmaze.com/");
        }

        public async Task<List<ShowResponse>> SearchShowsAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return new List<ShowResponse>();
            }

            var rawData = await r_Client.GetFromJsonAsync<List<TvMazeSearchResult>>(
                $"search/shows?q={Uri.EscapeDataString(query)}");

            if (rawData == null)
            {
                return new List<ShowResponse>();
            }

            List<ShowResponse> shows = new List<ShowResponse>();

            foreach (var item in rawData)
            {
                var show = item.Show;

                shows.Add(new ShowResponse
                {
                    Id = show.Id,
                    Name = show.Name,
                    Language = show.Language,
                    Genres = show.Genres ?? new List<string>(),
                    Rating = show.Rating?.Average,
                    ImageUrl = show.Image?.Medium
                });
            }

            return shows;
        }

        public async Task<List<EpisodeResponse>> GetEpisodesAsync(int showId)
        {
            var rawData = await r_Client.GetFromJsonAsync<List<TvMazeEpisode>>(
                $"shows/{showId}/episodes");

            if (rawData == null)
            {
                return new List<EpisodeResponse>();
            }

            List<EpisodeResponse> episodes = new List<EpisodeResponse>();

            foreach (var episode in rawData)
            {
                episodes.Add(new EpisodeResponse
                {
                    Id = episode.Id,
                    Name = episode.Name,
                    Season = episode.Season,
                    Number = episode.Number,
                    Runtime = episode.Runtime
                });
            }

            return episodes;
        }
    }
}
