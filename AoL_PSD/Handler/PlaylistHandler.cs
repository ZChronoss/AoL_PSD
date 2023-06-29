using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AoL_PSD.Model;
using AoL_PSD.Repository;

namespace AoL_PSD.Handler
{
    public class PlaylistHandler
    {
        PlaylistRepository pr = new PlaylistRepository();
        MusicRepository mr = new MusicRepository();

        public void addToPlaylist(User user, int id)
        {
            Music music = mr.GetAMusic(id);
            pr.addMusicToPlaylist(user, music, DateTime.Now);
        }

        public void deletePlaylist(int userId, int musicId)
        {
            pr.deletePlaylist(userId, musicId);
        }

        public List<Playlist> GetPlaylistMusics(int userId)
        {
            return pr.GetPlaylistMusics(userId);
        }

        public bool sameMusic(int musicid, int userid)
        {
            return pr.sameMusic(musicid, userid);
        }
    }
}