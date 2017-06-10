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
using _2015116292_ENT.IRepositories;
using _2015116292_ENT.EntitiesDTO;
using AutoMapper;

namespace _2015116292_WebApi.Controllers
{
    public class TipodeevaluacionsController : ApiController
    {
        private readonly IUnityOfWork _UnityOfWork;

        public TipodeevaluacionsController()
        {

        }

        public TipodeevaluacionsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {

            var Tipodeevaluacion1 = _UnityOfWork.Tipodeevaluacion1.GetAll();

            if (Tipodeevaluacion1 == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var TipodeevaluacionDTO = new List<TipodeevaluacionDTO>();

            foreach (var Tipodeevaluacion in Tipodeevaluacion1)
                TipodeevaluacionDTO.Add(Mapper.Map<Tipodeevaluacion, TipodeevaluacionDTO>(Tipodeevaluacion));

            return Ok(TipodeevaluacionDTO);
        }


        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var Tipodeevaluacion = _UnityOfWork.Tipodeevaluacion1.Get(id);

            if (Tipodeevaluacion == null)
                return NotFound();

            return Ok(Mapper.Map<Tipodeevaluacion, TipodeevaluacionDTO>(Tipodeevaluacion));
        }


        [HttpPut]
        public IHttpActionResult Update(int id, TipodeevaluacionDTO TipodeevaluacionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var TipodeevaluacionInPersistence = _UnityOfWork.Tipodeevaluacion1.Get(id);
            if (TipodeevaluacionInPersistence == null)
                return NotFound();

            Mapper.Map<TipodeevaluacionDTO, Tipodeevaluacion>(TipodeevaluacionDTO, TipodeevaluacionInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(TipodeevaluacionDTO);
        }

        [HttpPost]
        public IHttpActionResult Create(TipodeevaluacionDTO TipodeevaluacionDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Tipodeevaluacion = Mapper.Map<TipodeevaluacionDTO, Tipodeevaluacion>(TipodeevaluacionDTO);

            _UnityOfWork.Tipodeevaluacion1.Add(Tipodeevaluacion);
            _UnityOfWork.SaveChanges();

            TipodeevaluacionDTO.Tipodeevaluacion_id = Tipodeevaluacion.Tipodeevaluacion_id;

            return Created(new Uri(Request.RequestUri + "/" + Tipodeevaluacion.Tipodeevaluacion_id), TipodeevaluacionDTO);
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var TipodeevaluacionInDataBase = _UnityOfWork.Tipodeevaluacion1.Get(id);
            if (TipodeevaluacionInDataBase == null)
                return NotFound();

            _UnityOfWork.Tipodeevaluacion1.Delete(TipodeevaluacionInDataBase);
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
