using IMDBService.Models;
using IMDBService.Repository;
using IMDBService.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBService.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private IMovies _Imoviesrepo;
    


        public MovieController(IMovies imovies)
        {

            _Imoviesrepo = imovies;
        }

        [HttpGet(Name = "Getmoviessortbyupvotes")]
        public IActionResult Getmoviessortbyupvotes()
        {
            List<Movie> movies = _Imoviesrepo.GetallMoviessortbyupvotes();
            return Ok(movies);
        }

        [HttpGet(Name = "Getallmoviessortbyreleasedate")]
        public IActionResult Getallmoviessortbyreleasedate()
        {
            List<Movie> movies = _Imoviesrepo.GetallMoviessortbyreleasedate();
            return Ok(movies);
        }

        [HttpPost(Name = "Addmovie")]
        public IActionResult Addmovie([FromBody] Movie movie, [FromHeader] int userid, [FromHeader] string mailid)
        {
            bool Isregistereduser = _Imoviesrepo.Authenticateuser(userid, mailid);
            if (Isregistereduser)
            {
                if (ModelState.IsValid)
                {
                    _Imoviesrepo.Addmovie(movie);
                    return Ok();
                }
                return BadRequest();
            }

            else
            {
                return Unauthorized();
            }
        }


        [HttpPatch("{movieid:int}",Name = "Addreviewformovie")]
        public IActionResult Addreviewformovie([FromRoute] int movieid,[FromBody] JsonPatchDocument movie, [FromHeader] int userid, [FromHeader] string mailid)
        {
            bool Isregistereduser = _Imoviesrepo.Authenticateuser(userid, mailid);
            if (Isregistereduser)
            {
                _Imoviesrepo.Addreview(movieid, movie);
                return Ok();
            }

            else
            {
                return Unauthorized();
            }
           
        }

        [HttpGet("{userid:int}",Name = "GetallFavouritegenremoviesbyuserid")]
        public IActionResult GetallFavouritegenremoviesbyuserid([FromRoute]int userid, [FromHeader] string mailid)
        {

            bool Isregistereduser = _Imoviesrepo.Authenticateuser(userid, mailid);
            if (Isregistereduser)
            {
                List<Movie> movies = _Imoviesrepo.Getfavgenemovies(userid);
                return Ok(movies);
            }

            else
            {
                return Unauthorized();
            }
            
        }



    }
}