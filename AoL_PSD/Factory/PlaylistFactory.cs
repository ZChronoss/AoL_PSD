using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AoL_PSD.Model;

namespace AoL_PSD.Factory
{
    public class PlaylistFactory
    {
        public static Playlist CreatePlaylistMusic(User user, Music music, DateTime date)
        {
            Playlist newPlaylist = new Playlist()
            {
                UserId = user.Id,
                MusicId = music.Id,
                DateAddedToPlaylist = date
            };

            return newPlaylist;
        }
    }
}