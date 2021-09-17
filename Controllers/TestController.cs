using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechSmith.Model;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TechSmith.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        public TestController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet("getHeros")]
        public IActionResult GetHeros()
        {
            List<string> names = new();
            names.Add("Batman");
            names.Add("Superman");
            names.Add("Wonder Women");

            return Ok(names);      
        }
        [HttpPost("getInfo")]
        public IActionResult GetInfo([FromBody] HeroModel hero)
        {
            HeroModel RtHero = new();
            if (hero.Name == "Superman")
            {
                RtHero.Name = "Superman";
                RtHero.Species = "Kryptonian";
                RtHero.ProfilePic = @"https://upload.wikimedia.org/wikipedia/en/3/35/Supermanflying.png";
                RtHero.Intro = "Superman is a superhero" +
                    " who first appeared in American comic " +
                    "books published by DC Comics. The character" +
                    " was created by writer Jerry Siegel and artist " +
                    "Joe Shuster, and debuted in the comic book Action" +
                    " Comics #1 (cover-dated June 1938 and published April" +
                    " 18, 1938).[1] Superman has been adapted to a number of" +
                    " other media which includes radio serials, novels, movies," +
                    " television shows and theatre.";
                RtHero.Gender = "Male";
            }
            else if (hero.Name == "Batman")
            {
                RtHero.Name = "Batman";
                RtHero.Species = "Human";
                RtHero.ProfilePic = @"https://upload.wikimedia.org/wikipedia/en/c/c7/Batman_Infobox.jpg";
                RtHero.Intro = "Batman is a superhero who appears in American comic " +
                    "books published by DC Comics. Batman was created by artist Bob Kane " +
                    "and writer Bill Finger, and debuted in the 27th issue of the comic book " +
                    "Detective Comics on March 30, 1939. In the DC Universe continuity, Batman " +
                    "is the alias of Bruce Wayne, a wealthy American playboy, philanthropist, and " +
                    "industrialist who resides in Gotham City.";
                RtHero.Gender = "Male";
            }
            else if (hero.Name == "Wonder Women")
            {
                RtHero.Name = "Wonder Woman";
                RtHero.Species = "Amazon";
                RtHero.ProfilePic = @"https://upload.wikimedia.org/wikipedia/en/thumb/9/93/Wonder_Woman.jpg/250px-Wonder_Woman.jpg";
                RtHero.Intro = "Wonder Woman is a superhero appearing in American comic books published" +
                    " by DC Comics. The character is a founding member of the Justice League. The character" +
                    " first appeared in All Star Comics #8 published October 21, 1941 with her first feature" +
                    " in Sensation Comics #1 in January 1942. ";
                RtHero.Gender = "Female";
            }

            return Ok(RtHero);
        }
    }
}
