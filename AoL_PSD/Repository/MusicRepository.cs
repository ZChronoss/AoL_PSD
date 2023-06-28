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

        public Music sameFileName(String fileName, String fileExt)
        {
            Music sameMusic = db.Music.Where(x => x.FileLocation == fileName+fileExt).FirstOrDefault();
            return sameMusic;
        }

        public Music getRandomSong()
        {
            List<int> musicIds = new List<int>();
            List<Music> musics = GetMusics();

            foreach(Music music in musics)
            {
                musicIds.Add(music.Id);
            }

            int songCount = db.Music.Count();
            if(songCount == 1)
            {
                Music music = db.Music.First();
                return music;
            }
            int idx = new Random().Next(musicIds.Count);
            int musicId = musicIds[idx];
            return db.Music.Find(musicId);
        }

        public int getMusicCount()
        {
            return db.Music.Count();
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