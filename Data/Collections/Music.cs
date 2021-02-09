namespace MoonLyrics.Data.Collections
{
    public class Music
    {
        public Music(string name, string gender, string composer, string artistId, string[] feats = null, string beatMaker = null, string producer = null, string band = null, string lyric = null, string id = null)
        {
            Name = name;
            Gender = gender;
            Feats = feats;
            Composer = composer;
            BeatMaker = beatMaker;
            Producer = producer;
            Band = band;
            ArtistId = artistId;
            Lyric = lyric;
            Id = id;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Lyric { get; set; }
        public string[] Feats { get; set; }
        public string Composer { get; set; }
        public string BeatMaker { get; set; }
        public string Producer { get; set; }
        public string Band { get; set; }
        public string ArtistId { get; set; }
        
    }
}
