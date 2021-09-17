using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TechSmith.Model
{
    public class HeroModel
    {
        public string Name { get; set; }
        #nullable enable
        public string? Species { get; set; }
        public string? Intro { get; set; }
        public string? ProfilePic { get; set; }
        public string? Gender { get; set; }
        #nullable disable
    }
}
