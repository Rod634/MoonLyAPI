using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoonLyrics.Dto
{
    public class ArtistDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] MusicalGender { get; set; }
        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
