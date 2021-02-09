using MoonLyrics.Data.Collections;
using System.Collections.Generic;

namespace MoonLyrics.Repositories
{
    public interface IMusicRepository
    {
        void Post(Music music);
        List<Music> Get();
        List<Music> GetById(string id);
        List<Music> GetArtistMusics(string id);
        void Update(Music artist);
        void Delete(string id);
    }
}
