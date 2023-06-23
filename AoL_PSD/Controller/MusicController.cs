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

        public List<bool> AddMusic(string title, Genre genre, string fileLoc)
        {
            List<bool> validation = new List<bool>();
            bool valid = true;

            // title harus ada, file harus ada
            for (int i = 0; i < 2; i++)
            {
                validation.Add(true); 
            }

            if (!titleValid(title))
            {
                validation[0] = false;
                valid = false;
            }

            if (valid) // title ada, file ada
            {

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

    }
}