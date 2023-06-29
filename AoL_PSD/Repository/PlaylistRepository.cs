using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AoL_PSD.Model;
using AoL_PSD.Factory;

namespace AoL_PSD.Repository
{
    public class PlaylistRepository
    {
        Database1Entities db = new Database1Entities();

        public void addMusicToPlaylist(User user, Music music, DateTime date)
        {
            Playlist newPlaylistMusic = PlaylistFactory.CreatePlaylistMusic(user, music, date);
            db.Playlist.Add(newPlaylistMusic);
            db.SaveChanges();
        }

        public List<Playlist> GetPlaylistMusics()
        {
            return db.Playlist.ToList();
        }
    }
}