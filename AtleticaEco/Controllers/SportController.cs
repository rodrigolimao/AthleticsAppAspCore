using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AtleticaEco.Models;

namespace AtleticaEco.Controllers
{
    [Route("api/[controller]")]
        [ApiController]
        public class SportController : ControllerBase
        {
            private AtleticaModel db;

            // constructor - connect to db as soon as this controller is instantiated
            public SportController(AtleticaModel db)

            {
                this.db = db;
            }

            // GET: api/Sports
            [HttpGet]
            public IEnumerable<Sport> Get()
            {
                return db.Sports.OrderBy(a => a.sport_name).ToList();
            }

            // GET: api/Sports/5

            [HttpGet("{id}")]

            public ActionResult Get(int id)

            {
                Sport Sport = db.Sports.SingleOrDefault(a => a.sport_id == id);

                if (Sport == null)
                {
                    return NotFound();
                }

                else
                {
                    return Ok(Sport);

                }

            }

            // POST: api/Sports

            [HttpPost]
            public ActionResult Post([FromBody] Sport sport)

            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    db.Sports.Add(sport);
                    db.SaveChanges();

                    return CreatedAtAction("Post", sport);
                }

            }

            // PUT: api/Sports/5
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] Sport sport)
            {

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    db.Entry(sport).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    return AcceptedAtAction("Put", sport);
                }
            }

            // DELETE: api/Sports/5

            [HttpDelete("{id}")]

            public ActionResult Delete(int id)

            {
                Sport Sport = db.Sports.SingleOrDefault(a => a.sport_id == id);

                if (Sport == null)

                {
                    return NotFound();
                }

                else
                {
                    db.Sports.Remove(Sport);
                    db.SaveChanges();
                    return Ok();
                }

            }

        }

    }

