using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AoL_PSD.Model;
using AoL_PSD.Factory;

namespace AoL_PSD.Repository
{
    public class MusicRepository
    {
        Database1Entities db = new Database1Entities();
        public void addMusic(User artist, string title, Genre genre, DateTime dateadded, string fileloc)
        {
            Music newMusic = MusicFactory.CreateMusic(artist, title, genre, dateadded, fileloc);
            db.Music.Add(newMusic);
            db.SaveChanges();
        }
    }
}