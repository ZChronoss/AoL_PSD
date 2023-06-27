using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AoL_PSD.Model;
using AoL_PSD.Repository;

namespace AoL_PSD.Handler
{
    public class MusicHandler
    {
        MusicRepository mr = new MusicRepository();
        public void CreateMusic(User artist, String title, String genre, DateTime dateAdded, string fileLoc)
        {
            mr.CreateMusic(artist, title, genre, dateAdded, fileLoc);
        }

        public Music sameFileName(String fileName)
        {
            Music sameMusic = mr.sameFileName(fileName);
            return sameMusic;
        }

        public Music getRandomSong()
        {
            return mr.getRandomSong();
        }

        public int getMusicCount()
        {
            return mr.getMusicCount();
        }


        public List<Genre> GetGenres()
        {
            return mr.GetGenres();
        }

        public List<Music> GetMusics()
        {
            return mr.GetMusics();
        }
    }
}