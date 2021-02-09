using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MoonLyrics.Data.Collections;
using MoonLyrics.Dto;
using MoonLyrics.Repositories;

namespace MoonLyrics.Controllers
{
    [Route("MoonLy/Artist")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistController(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        [HttpPost]
        public ActionResult AddArtist([FromBody] ArtistDto obj)
        {
            try
            {
                var artist = new Artist(obj.Name, obj.MusicalGender, obj.Title, obj.Latitude, obj.Longitude);

                _artistRepository.Post(artist);

                return StatusCode(201, "Artist Added Sucessfuly!!");
            }
            catch(Exception ex)
            {
                return StatusCode(406, "Artist Was not added, sorry");
            }
            
        }

        [HttpGet]
        public ActionResult GetAllArtist()
        {
            try
            {
                var artist = _artistRepository.Get();
                return Ok(artist);
            }
            catch (Exception ex)
            {
                return StatusCode(404, "Artist not Found");
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetArtistById(String id)
        {
            try
            {
                var artist = _artistRepository.GetById(id);
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
                var artist = new Artist(obj.Name, obj.MusicalGender, obj.Title, obj.Latitude, obj.Longitude, obj.Id);

                _artistRepository.Update(artist);

                return StatusCode(200, "Artist Updated sucessfully!!");
            }
            catch (Exception ex)
            {
                return StatusCode(400, "Artist not Updated");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteArtist(string id)
        {
            try
            {
                _artistRepository.Delete(id);
                return StatusCode(200, "Artist Deletd sucessfully");
            }
            catch(Exception ex)
            {
                return StatusCode(400, "Artist was not deleted");
            }
        }
    }
}
