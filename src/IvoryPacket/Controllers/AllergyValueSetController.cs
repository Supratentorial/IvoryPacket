using System.Collections.Generic;
using Microsoft.AspNet.Mvc;

namespace IvoryPacket.Controllers
{
    public class AllergyValueSetController : Controller
    {
        [Route("api/allergies/valuesets/severity")]
        [HttpGet]
        public IEnumerable<string> GetSeverityOptions()
        {
            return new string[] { "Mild", "Moderate", "Severe" };
        }

        [Route("api/allergies/valuesets/reactiontypes")]
        [HttpGet]
        public IEnumerable<string> GetReactionTypes()
        {
            return new string[] { "Allergic", "Drug Interaction", "Drug Side-effect" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


    }
}
