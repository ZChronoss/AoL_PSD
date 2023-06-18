using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AoL_PSD.Model;

namespace AoL_PSD.Factory
{
    public class MusicFactory
    {
        public static Music CreateMusic(User artist, Genre genre, DateTime dateAdded, string fileLoc)
        {
            Music newMusic = new Music()
            {
                ArtistId = artist.Id,
                GenreId = genre.Id,
                DateAdded = dateAdded,
                FileLocation = fileLoc
            };

            return newMusic;
        }
    }
}