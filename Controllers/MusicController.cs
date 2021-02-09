using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoonLyrics.Data.Collections;
using MoonLyrics.Dto;
using MoonLyrics.Repositories;

namespace MoonLyrics.Controllers
{
    [Route("MoonLy/Music")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicRepository _musicRepository;

        public MusicController(IMusicRepository musicRepository)
        {
            _musicRepository = musicRepository;
        }

        [HttpPost]
        public ActionResult AddMusic([FromBody] MusicDto obj)
        {
            try
            {
                var music = new Music(obj.Name, obj.Gender, obj.Composer, obj.ArtistId, obj.Feats, obj.BeatMaker, obj.Producer, obj.Band,  obj.Lyric);

                _musicRepository.Post(music);

                return StatusCode(201, "Music Added Sucessfuly!!");
            }
            catch (Exception ex)
            {
                return StatusCode(406, "Music Was not added, sorry");
            }

        }

        [HttpGet]
        public ActionResult GetAllMusics()
        {
            try
            {
                var music = _musicRepository.Get();
                return Ok(music);
            }
            catch (Exception ex)
            {
                return StatusCode(404, "Music not Found");
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetMusicById(String id)
        {
            try
            {
                var music = _musicRepository.GetById(id);
                return Ok(music);
            }
            catch (Exception ex)
            {
                return StatusCode(404, "Music not Found");
            }
        }

        [HttpGet("{Artist}/{id}")]
        public ActionResult GetMusicByArtistId(String id)
        {
            try
            {
                var music = _musicRepository.GetArtistMusics(id);
                return Ok(music);
            }
            catch (Exception ex)
            {
                return StatusCode(404, "Music not Found");
            }
        }

        [HttpPut]
        public ActionResult UpdateMusic([FromBody] MusicDto obj)
        {
            try
            {
                var music = new Music(obj.Name, obj.Gender, obj.Composer, obj.ArtistId, obj.Feats, obj.BeatMaker, obj.Producer, obj.Band, obj.Lyric, obj.Id);

                _musicRepository.Update(music);

                return StatusCode(200, "Music Updated sucessfully!!");
            }
            catch (Exception ex)
            {
                return StatusCode(400, "Music not Updated");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteMusic(string id)
        {
            try
            {
                _musicRepository.Delete(id);
                return StatusCode(200, "Music Deletd sucessfully");
            }
            catch (Exception ex)
            {
                return StatusCode(400, "Music was not deleted");
            }
        }
    }
}

