using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using AoL_PSD.Model;
using AoL_PSD.Handler;

namespace AoL_PSD.Controller
{
    public class MusicController
    {
        MusicHandler mh = new MusicHandler();

        public List<bool> AddMusic(User artist, string title, String genre, String fileName, String fileExt)
        {
            List<bool> validation = new List<bool>();
            bool valid = true;

            for (int i = 0; i < 4; i++)
            {
                validation.Add(true); 
            }

            if (!titleValid(title))
            {
                validation[0] = false;
                valid = false;
            }

            if (!genreValid(genre)) 
            {
                validation[1] = false;
                valid = false;
            }

            if (!extensionValid(fileExt))
            {
                validation[2] = false;
                valid = false;
            }

            if (mh.sameFileName(fileName) != null)
            {
                validation[3] = false;
                valid = false;
            }

            if (valid)
            {
                mh.CreateMusic(artist, title, genre, DateTime.Now, fileName+fileExt);
            }

            return validation;

        }

        private bool titleValid(string title)
        {
            if (title.Length >= 1)
            {
                return true;
                // Ada title
            }
            return false;
            // Gaada title
        }

        private bool genreValid(string genre)
        {
            if(!genre.Equals(String.Empty))
            {
                return true;
            }

            return false;
        }        

        private bool extensionValid(String fileExt)
        {
            List<String> extension = new List<String> {".mp3", ".m4a", ".wav" };
            bool contains = extension.Contains(fileExt, StringComparer.OrdinalIgnoreCase);
            if (contains)
            {
                return true;
            }

            return false;
        }
    }
}