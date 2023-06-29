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
        public List<Playlist> GetPlaylistMusics()
        {
            return pr.GetPlaylistMusics();
        }
    }
}