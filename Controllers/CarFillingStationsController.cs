using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ApiPiterRetailGroup.Entity;

namespace ApiPiterRetailGroup.Controllers
{
    public class CarFillingStationsController : ApiController
    {
        private PiterRetailGroupEntities2 db = new PiterRetailGroupEntities2();

        // GET: api/CarFillingStations
        public IQueryable<CarFillingStation> GetCarFillingStation()
        {
            return db.CarFillingStation;
        }

        // GET: api/CarFillingStations/5
        [ResponseType(typeof(CarFillingStation))]
        public IHttpActionResult GetCarFillingStation(int id)
        {
            //var carFillingStation = db.CarFillingStation.Where(x => x.Id == id).Select(x => new { Addres = x.Address });
            var carFillingStation = db.CarFillingStation.Find(id);
            if (carFillingStation == null)
            {
                return NotFound();
            }

            return Ok(carFillingStation);
        }

        // GET: api/CarFillingStations/5
        [ResponseType(typeof(CarFillingStation))]
        public IHttpActionResult GetCarFillingStationFuel(string fuel)
        {
            if (fuel == "92")
            {
                var station = db.CarFillingStation.Where(x => x.FuelT92 != null).Select(x => new {Address = x.Address, Id = x.Id, Price = x.Price92}).ToList();
                return Ok(station);
            }
            else if (fuel == "95") {
                var station = db.CarFillingStation.Where(x => x.Fuel95 != null).Select(x => new { Address = x.Address, Id = x.Id, Price = x.Price95 }).ToList();

                return Ok(station);
            }
            else if (fuel == "98") {
                var station = db.CarFillingStation.Where(x => x.Fuel98 != null).Select(x => new { Address = x.Address, Id = x.Id, Price = x.Price98 }).ToList();
                return Ok(station);
            }
            else if (fuel == "DT") {
                var station = db.CarFillingStation.Where(x => x.FuelDis != null).Select(x => new { Address = x.Address, Id = x.Id, Price = x.PriceDis }).ToList();
                return Ok(station);
            }

            return Ok("Net");
        }

        // PUT: api/CarFillingStations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCarFillingStation(int id, CarFillingStation carFillingStation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != carFillingStation.Id)
            {
                return BadRequest();
            }

            db.Entry(carFillingStation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarFillingStationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/CarFillingStations
        [ResponseType(typeof(CarFillingStation))]
        public IHttpActionResult PostCarFillingStation(CarFillingStation carFillingStation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CarFillingStation.Add(carFillingStation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = carFillingStation.Id }, carFillingStation);
        }

        // DELETE: api/CarFillingStations/5
        [ResponseType(typeof(CarFillingStation))]
        public IHttpActionResult DeleteCarFillingStation(int id)
        {
            CarFillingStation carFillingStation = db.CarFillingStation.Find(id);
            if (carFillingStation == null)
            {
                return NotFound();
            }

            db.CarFillingStation.Remove(carFillingStation);
            db.SaveChanges();

            return Ok(carFillingStation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarFillingStationExists(int id)
        {
            return db.CarFillingStation.Count(e => e.Id == id) > 0;
        }
    }
}