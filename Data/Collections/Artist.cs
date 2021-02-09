using MongoDB.Driver.GeoJsonObjectModel;

namespace MoonLyrics.Data.Collections
{
    public class Artist
    {
        public Artist(string name, string[] musicalGender, string title, double longitude, double latitude, string id = null)
        {         
            Name = name;
            MusicalGender = musicalGender;
            Title = title;
            Localization = new GeoJson2DGeographicCoordinates(longitude, latitude);
            Id = id;
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string[] MusicalGender { get; set; }
        public string Title { get; set; }
        public GeoJson2DGeographicCoordinates Localization { get; set; }

    }
}
