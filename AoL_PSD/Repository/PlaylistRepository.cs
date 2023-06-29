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

        public void deletePlaylist(int userId, int musicId)
        {
            Playlist delPlaylist = db.Playlist.Where(x => x.MusicId == musicId && x.UserId == userId).FirstOrDefault();

            db.Playlist.Remove(delPlaylist);
            db.SaveChanges();
        }

        public List<Playlist> GetPlaylistMusics(int userId)
        {
            return db.Playlist.Where(x => x.UserId == userId).ToList();
        }

        public bool sameMusic(int musicid, int userid)
        {
            Playlist valid = db.Playlist.Where(x => x.MusicId == musicid && x.UserId == userid).FirstOrDefault();

            if(valid == null)
            {
                return true;
            }

            return false;
        }
    }
}