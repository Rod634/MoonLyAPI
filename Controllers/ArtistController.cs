using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MoonLyrics.Data.Collections;
using MoonLyrics.Dto;

namespace MoonLyrics.Controllers
{
    [Route("MoonLy/Artist")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        
        IMongoCollection<Artist> _artistCollection;

        public ArtistController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _artistCollection = _mongoDB.DB.GetCollection<Artist>(typeof(Artist).Name.ToLower());
        }

        [HttpPost]
        public ActionResult AddArtist([FromBody] ArtistDto obj)
        {
            try
            {
                var artist = new Artist(obj.Name, obj.MusicalGender, obj.Title, obj.Latitude, obj.Longitude);

                _artistCollection.InsertOne(artist);

                return StatusCode(201, "Artist Added Sucessfuly!!");
            }
            catch(Exception ex)
            {
                return StatusCode(201, "Artist Was not added, sorry");
            }
            
        }

        [HttpGet]
        public ActionResult GetAllArtist()
        {
            try
            {
                var artist = _artistCollection.Find(Builders<Artist>.Filter.Empty).ToList();
                return Ok(artist);
            }
            catch (Exception ex)
            {
                return StatusCode(404, "Artist not Found");
            }
        }

        [HttpGet]
        public ActionResult GetArtistById([FromBody] String id)
        {
            try
            {
                var artist = _artistCollection.Find(Builders<Artist>.Filter.Where(x => x.Id == id));
                return Ok(artist);
            }
            catch (Exception ex)
            {
                return StatusCode(404, "Artist not Found");
            }
        }

        [HttpPut]
        public ActionResult UpdateArtist([FromBody] ArtistDto obj)
        {
            try
            {
                var artist = new Artist(obj.Name, obj.MusicalGender, obj.Title, obj.Latitude, obj.Longitude);

                _artistCollection.ReplaceOne(Builders<Artist>.Filter.Where(x => x.Id == obj.Id), artist);

                return StatusCode(201, "Artist Updated sucessfully!!");
            }
            catch (Exception ex)
            {
                return StatusCode(201, "Artist not Updated");
            }
        }

        [HttpDelete]
        public ActionResult DeleteArtist([FromBody] string id)
        {
            try
            {
                _artistCollection.DeleteOne(Builders<Artist>.Filter.Where(x => x.Id == id));
                return StatusCode(201, "Artist Deletd sucessfully");
            }
            catch(Exception ex)
            {
                return StatusCode(400, "Artist was not deleted");
            }
        }
    }
}
