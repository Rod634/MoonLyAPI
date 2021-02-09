using MongoDB.Driver;
using MoonLyrics.Data.Collections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MoonLyrics.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly Data.MongoDB _mongoDB;
        IMongoCollection<Artist> _artistCollection;
        public ArtistRepository(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _artistCollection = _mongoDB.DB.GetCollection<Artist>(typeof(Artist).Name.ToLower());
        }

        public void Delete(string id)
        {
            try
            {
                _artistCollection.DeleteOne(Builders<Artist>.Filter.Where(x => x.Id == id));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<Artist> Get()
        {
            try
            {
                var artist = _artistCollection.Find(Builders<Artist>.Filter.Empty).ToList();
                return artist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public List<Artist> GetById(string id)
        {
            try
            {
                var artist = _artistCollection.Find(Builders<Artist>.Filter.Where(x => x.Id == id)).ToList();
                return artist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Post(Artist artist)
        {
            try
            {
                _artistCollection.InsertOne(artist);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Artist artist)
        {
            try
            {
                _artistCollection.ReplaceOne(Builders<Artist>.Filter.Where(x => x.Id == artist.Id), artist);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
