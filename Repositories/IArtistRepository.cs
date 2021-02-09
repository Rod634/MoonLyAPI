using MoonLyrics.Data.Collections;
using System.Collections.Generic;

namespace MoonLyrics.Repositories
{
    public interface IArtistRepository
    {
        void Post(Artist artist);
        List<Artist> Get();
        List<Artist> GetById(string id);
        void Update(Artist artist);
        void Delete(string id);
    }
}
