using Microsoft.AspNetCore.Mvc;
using TvShows.Api.Models;
using TvShows.Api.Repositories;

namespace TvShows.Api.Controllers
{
    public class ShowsController : ControllerBase
    {
        private readonly TvMazeRepository r_Repository;

        public ShowsController(TvMazeRepository repository)
        {
            r_Repository = repository;
        }

        [HttpGet("api/shows/search")]
        public Task<List<ShowResponse>> Search([FromQuery] string query)
        {
            return r_Repository.SearchShowsAsync(query);
        }

        [HttpGet("api/shows/{id}/episodes")]
        public Task<List<EpisodeResponse>> GetEpisodes(int id)
        {
            return r_Repository.GetEpisodesAsync(id);
        }
    }
}
