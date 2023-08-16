using Microsoft.AspNetCore.Mvc;
using MoviesApp.Web.DTOs;
using MoviesApp.Web.Mappers.Extensions;
using MoviesApp.Web.Models;
using MoviesApp.Web.Models.Enums;

namespace MoviesApp.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet] //https://localhost:7118/api/Movies
        public IActionResult GetAllMovies()
        {
            try
            {
                var moviesDb = StaticDb.Movies;
                var movieDtos = moviesDb.Select(x => x.MapToMovieDto()).ToList();

                return Ok(movieDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Yikes, that's not good! :(");
            }
        }

        [HttpGet("{id}")] //https://localhost:7118/api/Movies/3
        public IActionResult GetMovieByIdRoute([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("The id must not be negative!");
                }

                var movieDb = StaticDb.Movies.FirstOrDefault(x => x.Id == id);

                if (movieDb is null)
                {
                    return NotFound($"Movie with id: {id} does not exist!");
                }

                var movieDto = movieDb.MapToMovieDto();
                return Ok(movieDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Yikes, that's not good! :(");
            }
        }

        [HttpGet("findById")] //https://localhost:7118/api/Movies/findById?id=2
        public IActionResult GetMovieByIdQuery([FromQuery] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("The id must not be negative!");
                }

                var movieDb = StaticDb.Movies.FirstOrDefault(x => x.Id == id);

                if (movieDb is null)
                {
                    return NotFound($"Movie with id: {id} does not exist!");
                }

                var movieDto = movieDb.MapToMovieDto();
                return Ok(movieDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Yikes, that's not good! :(");
            }
        }

        [HttpGet("filter")] //https://localhost:7118/api/Movies/filter?genre=2&year=2021
        public IActionResult FilterMovies([FromQuery] Genre? genre, [FromQuery] int? year)
        {
            try
            {
                var filteredMovies = StaticDb.Movies;

                if (genre.HasValue)
                {
                    filteredMovies = filteredMovies.Where(x => x.Genre == genre.Value).ToList();
                }

                if (year.HasValue)
                {
                    filteredMovies = filteredMovies.Where(x => x.Year == year.Value).ToList();
                }

                if (!genre.HasValue && !year.HasValue)
                {
                    return BadRequest("At least one filter parameter (genre or year) must be provided.");
                }

                var movieDtos = filteredMovies.Select(x => x.MapToMovieDto()).ToList();

                if (movieDtos.Count == 0)
                {
                    return NotFound("No movies match the specified filters :(");
                }

                return Ok(movieDtos);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Yikes, that's not good! :(");
            }
        }

        [HttpPost] //https://localhost:7118/api/Movies
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(movie.Title) || movie.Year <= 0 || !Enum.IsDefined(typeof(Genre), movie.Genre))
                {
                    return BadRequest("Title, Year, and Genre are required fields!");
                }

                if (!string.IsNullOrEmpty(movie.Description) && movie.Description.Length > 250)
                {
                    return BadRequest("Description length should be a maximum of 250 characters!");
                }

                StaticDb.Movies.Add(movie);

                return StatusCode(StatusCodes.Status201Created,$"Movie created!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Yikes, that's not good! :(");
            }
        }

        [HttpDelete] //https://localhost:7118/api/Movies
        public IActionResult DeleteMovieBody([FromBody] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("The id must not be negative!");
                }

                var movie = StaticDb.Movies.FirstOrDefault(x => x.Id == id);

                if (movie is null)
                {
                    return NotFound($"Movie with id: {id} does not exist!");
                }

                StaticDb.Movies.Remove(movie);
                return Ok("Movie deleted!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Yikes, that's not good! :(");
            }
        }

        [HttpDelete("{id}")] //https://localhost:7118/api/Movies/1
        public IActionResult DeleteMovieRoute([FromRoute] int id)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("The id must not be negative!");
                }

                var movie = StaticDb.Movies.FirstOrDefault(x => x.Id == id);

                if (movie is null)
                {
                    return NotFound($"Movie with id: {id} does not exist!");
                }

                StaticDb.Movies.Remove(movie);
                return Ok("Movie deleted!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Yikes, that's not good! :(");
            }
        }

        [HttpPut("{id}")] //https://localhost:7118/api/Movies/2
        public IActionResult UpdateMovie([FromRoute] int id, [FromBody] MovieUpdateDto movieUpdateDto)
        {
            try
            {
                if (id <= 0)
                {
                    return BadRequest("The id must not be negative!");
                }

                var movieDb = StaticDb.Movies.FirstOrDefault(x => x.Id == id);

                if (movieDb == null)
                {
                    return NotFound($"Movie with id: {id} does not exist!");
                }

                if (string.IsNullOrWhiteSpace(movieUpdateDto.Title) || movieUpdateDto.Year <= 0 || !Enum.IsDefined(typeof(Genre), movieUpdateDto.Genre))
                {
                    return BadRequest("Title, Year, and Genre are required fields!");
                }

                if (!string.IsNullOrEmpty(movieUpdateDto.Description) && movieUpdateDto.Description.Length > 250)
                {
                    return BadRequest("Description length should be a maximum of 250 characters!");
                }

                movieDb.UpdateMovieFromDto(movieUpdateDto);

                return Ok("Movie updated successfully!");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Yikes, that's not good! :(");
            }
        }
    }
}