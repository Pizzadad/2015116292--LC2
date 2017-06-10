using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
//using System.Web.Mvc;
using _2015116292_ENT.Entities;
using _2015116292_PER;
using System.Web.Http;
using _2015116292_ENT.EntitiesDTO;
using _2015116292_ENT.IRepositories;
using AutoMapper;

namespace _2015116292_WebApi.Controllers
{
    public class EstadodeevaluacionsController : ApiController
    {
        private readonly IUnityOfWork _UnityOfWork;

        public EstadodeevaluacionsController()
        {

        }

        public EstadodeevaluacionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {

            var Estadodeevaluacion1 = _UnityOfWork.Estadodeevaluacion1.GetAll();

            if (Estadodeevaluacion1 == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var EstadodeevaluacionDTO = new List<EstadodeevaluacionDTO>();

            foreach (var Estadodeevaluacion in Estadodeevaluacion1)
                EstadodeevaluacionDTO.Add(Mapper.Map<Estadodeevaluacion, EstadodeevaluacionDTO>(Estadodeevaluacion));

            return Ok(EstadodeevaluacionDTO);
        }


        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var Estadodeevaluacion = _UnityOfWork.Estadodeevaluacion1.Get(id);

            if (Estadodeevaluacion == null)
                return NotFound();

            return Ok(Mapper.Map<Estadodeevaluacion, EstadodeevaluacionDTO>(Estadodeevaluacion));
        }


        [HttpPut]
        public IHttpActionResult Update(int id, EstadodeevaluacionDTO EstadodeevaluacionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var EstadodeevaluacionInPersistence = _UnityOfWork.Estadodeevaluacion1.Get(id);
            if (EstadodeevaluacionInPersistence == null)
                return NotFound();

            Mapper.Map<EstadodeevaluacionDTO, Estadodeevaluacion>(EstadodeevaluacionDTO, EstadodeevaluacionInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(EstadodeevaluacionDTO);
        }

        [HttpPost]
        public IHttpActionResult Create(EstadodeevaluacionDTO EstadodeevaluacionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Estadodeevaluacion = Mapper.Map<EstadodeevaluacionDTO, Estadodeevaluacion>(EstadodeevaluacionDTO);

            _UnityOfWork.Estadodeevaluacion1.Add(Estadodeevaluacion);
            _UnityOfWork.SaveChanges();

            EstadodeevaluacionDTO.Estadodeevaluacion_id = Estadodeevaluacion.Estadodeevaluacion_id;

            return Created(new Uri(Request.RequestUri + "/" + Estadodeevaluacion.Estadodeevaluacion_id), EstadodeevaluacionDTO);
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var EstadodeevaluacionInDataBase = _UnityOfWork.Estadodeevaluacion1.Get(id);
            if (EstadodeevaluacionInDataBase == null)
                return NotFound();

            _UnityOfWork.Estadodeevaluacion1.Delete(EstadodeevaluacionInDataBase);
            _UnityOfWork.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _UnityOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
