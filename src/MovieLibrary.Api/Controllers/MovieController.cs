using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieLibrary.Core;
using MovieLibrary.Core.Features.Commands;
using MovieLibrary.Core.Features.Queries;
using MovieLibrary.Core.Filters;
using MovieLibrary.Core.ViewModels;
using MovieLibrary.Data.Entities;
using MovieLibrary.Data.Filters;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary.Api.Controllers
{
    [Route("/v1/MovieManagement")]
    [ApiController]
    public class MovieController : Controller
    {
        private readonly IMediator _mediator;

        public MovieController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get list of movies.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<Movie>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllMovies()
        {
            return Ok(await _mediator.Send(new GetAllMoviesQuery()));
        }

        /// <summary>
        /// Get movie by id.
        /// </summary>
        [Route("{movieId}")]
        [HttpGet]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetMovieByIdAsync([FromRoute] int movieId)
        {
            return Ok(await _mediator.Send(new GetMovieByIdQuery(movieId)));
        }

        /// <summary>
        /// Add movie.
        /// </summary>
        [Route("")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AddMovieAsync([FromBody] AddMovieCommand request)
        {
            await _mediator.Send(request);

            return Created(string.Empty, null);
        }

        /// <summary>
        /// Update movie.
        /// </summary>
        [Route("")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UpdateMovieAsync([FromBody] UpdateMovieCommand request)
        {
            await _mediator.Send(request);

            return Ok();
        }

        /// <summary>
        /// Remove movie.
        /// </summary>
        [Route("{movieId}")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RemoveMovieAsync([FromRoute] int movieId)
        {
            await _mediator.Send(new RemoveMovieCommand(movieId));

            return NoContent();
        }

        /// <summary>
        /// Filter movies
        /// </summary>
        [Route("~/v1/Movie/Filter")]
        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<MovieViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> FilterAsync([FromQuery] MovieParameters movieParameters)
        {
            var(response, metadata) = await _mediator.Send(new FilterMoviesQuery(movieParameters));

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }
    }
}