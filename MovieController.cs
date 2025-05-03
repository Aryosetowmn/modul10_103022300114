namespace modul10_103022300114
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    [Route("api/[controller]")]
    [ApiController]
    public class  MovieController : ControllerBase
    {
        private static List<Movie> listMovie = new List<Movie>
        { 
            new Movie
            {
                Title = "The Shawshank Redemption",
                Director = "Frank Darabont",
                Stars = new List<string> { "Tim Robbins", "Morgan Freeman", "Bob Gunton" },
                Description = "A banker convicted of uxoricide forms a friendship over a quarter century with a hardened convict, while maintaining his innocence and trying to remain hopeful through simple compassion."
            },
            new Movie
            {
                Title = "The Godfather",
                Director = "Francis Ford Coppola",
                Stars = new List<string> { "Marlon Brando", "Al Pacino", "James Caan" },
                Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son."
            },
            new Movie
            {
                Title = "The Dark Knight",
                Director = "Christopher Nolan",
                Stars = new List<string> { "Christian Bale", "Heath Ledger", "Aaron Eeckhart" },
                Description = "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness."
            },
        };

        [HttpGet]
        public ActionResult<List<Movie>> GetAll()
        {
            Console.WriteLine("Jumlah Film: " + listMovie.Count);
            return listMovie;
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetById(int id)
        {
            if (id < 0 || id >= listMovie.Count)
            {
                return NotFound(new { message = "Movie tidak ditemukan." });
            }
            return listMovie[id];
        }

        [HttpPost]
        public ActionResult<Movie> Create([FromBody] Movie movie)
        {
            if (movie == null)
            {
                return BadRequest(new { message = "Data movie tidak valid." });
            }
            listMovie.Add(movie);
            return CreatedAtAction(nameof(GetById), new { id = listMovie.Count - 1 }, movie);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= listMovie.Count)
            {
                return NotFound(new { message = "Movie tidak ditemukan." });
            }
            listMovie.RemoveAt(id);
            return NoContent();
        }
    }
}
