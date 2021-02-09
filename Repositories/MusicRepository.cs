using MongoDB.Driver;
using MoonLyrics.Data.Collections;
using System;
using System.Collections.Generic;

namespace MoonLyrics.Repositories
{
    public class MusicRepository : IMusicRepository
    {
        private readonly Data.MongoDB _mongoDB;
        IMongoCollection<Music> _musicCollection;
        public MusicRepository(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _musicCollection = _mongoDB.DB.GetCollection<Music>(typeof(Music).Name.ToLower());
        }

        public void Delete(string id)
        {
            try
            {
                _musicCollection.DeleteOne(Builders<Music>.Filter.Where(x => x.Id == id));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Music> Get()
        {
            try
            {
                var music = _musicCollection.Find(Builders<Music>.Filter.Empty).ToList();
                return music;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Music> GetById(string id)
        {
            try
            {
                var music = _musicCollection.Find(Builders<Music>.Filter.Where(x => x.Id == id)).ToList();
                return music;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Post(Music music)
        {
            try
            {
                _musicCollection.InsertOne(music);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(Music music)
        {
            try
            {
                _musicCollection.ReplaceOne(Builders<Music>.Filter.Where(x => x.Id == music.Id), music);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
