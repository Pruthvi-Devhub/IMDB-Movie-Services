using IMDBService.Models;
using IMDBService.Repository.IRepository;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBService.Repository
{
    public class Moviesdata : IMovies
    {
        private readonly AppDbContext _db;

        public Moviesdata(AppDbContext db)
        {
            _db = db;
        }
        
        public bool Authenticateuser(int userid, string emailid)
        {
            var obj = _db.Users.Find(userid);
            if(obj != null && obj.useremail.Equals(emailid))
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public void Addmovie(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

        public void Addreview(int movieid, JsonPatchDocument movie)
        {
            var obj = _db.Movies.Find(movieid);
            if(obj != null)
            {
                movie.ApplyTo(obj);
                _db.SaveChanges();
            }


        }

        public List<Movie> GetallMoviessortbyreleasedate()
        {
            return _db.Movies.OrderBy(x => x.releasedate).ToList();
        }

        public List<Movie> GetallMoviessortbyupvotes()
        {
            return _db.Movies.OrderBy(x => x.upvotes).ToList();
        }

        public List<Movie> Getfavgenemovies(int userid)
        {
           var obj =  _db.Users.Find(userid);
            return _db.Movies.Where(x => x.genre == obj.Favouritegenre).ToList();
        }
    }
}
