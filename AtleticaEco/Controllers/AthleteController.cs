using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtleticaEco.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AtleticaEco.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AthleteController : ControllerBase
    {
        private AtleticaModel db;

        // constructor - connect to db as soon as this controller is instantiated
        public AthleteController(AtleticaModel db)

        {
            this.db = db;
        }

        // GET: api/athletes
        [HttpGet]
        public IEnumerable<Athlete> Get()
        {
            return db.Athletes.OrderBy(a => a.athlete_name).ToList();
        }

        // GET: api/athletes/5

        [HttpGet("{id}")]

        public ActionResult Get(int id)

        {
            Athlete athlete = db.Athletes.SingleOrDefault(a => a.athlete_id == id);

            if (athlete == null)
            {
                return NotFound();
            }

            else
            {
                return Ok(athlete);

            }

        }

        // POST: api/athletes

        [HttpPost]
        public ActionResult Post([FromBody] Athlete athlete)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                db.Athletes.Add(athlete);
                db.SaveChanges();

                return CreatedAtAction("Post", athlete);
            }

        }

        // PUT: api/athletes/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Athlete athlete)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                db.Entry(athlete).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();       
                return AcceptedAtAction("Put", athlete);
            }
        }

        // DELETE: api/athletes/5

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)

        {
            Athlete athlete = db.Athletes.SingleOrDefault(a => a.athlete_id == id);

            if (athlete == null)

            {
                return NotFound();
            }

            else
            {
               db.Athletes.Remove(athlete);
                db.SaveChanges();
                return Ok();
            }

        }

    }

}
