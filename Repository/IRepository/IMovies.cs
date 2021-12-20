using IMDBService.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBService.Repository.IRepository
{
    public interface IMovies
    {
        //fornormaluser and registered user
        List<Movie> GetallMoviessortbyreleasedate();
        List<Movie> GetallMoviessortbyupvotes();

        //for registered user
        void Addmovie(Movie movie);

        void Addreview(int movieid, JsonPatchDocument movie);

        List<Movie> Getfavgenemovies(int userid);

        bool Authenticateuser(int userid, string emailid);
    }
}
