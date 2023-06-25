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
        public void CreateMusic(User artist, string title, String genre, DateTime dateadded, string fileloc)
        {
            Music newMusic = MusicFactory.CreateMusic(artist, title, genre, dateadded, fileloc);
            db.Music.Add(newMusic);
            db.SaveChanges();
        }

        public Music sameFileName(String fileName)
        {
            Music sameMusic = db.Music.Where(x => x.FileLocation == fileName).FirstOrDefault();
            return sameMusic;
        }

        public List<Genre> GetGenres()
        {
            return db.Genre.ToList();
        }
        public List<Music> GetMusics()
        {
            return db.Music.ToList();
        }
    }
}