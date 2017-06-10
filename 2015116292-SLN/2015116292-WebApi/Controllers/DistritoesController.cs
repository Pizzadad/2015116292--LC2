using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
//using System.Web.Mvc;
using _2015116292_ENT.Entities;
using _2015116292_ENT.EntitiesDTO;
using _2015116292_PER;
using System.Web.Http;
using AutoMapper;
using _2015116292_ENT.IRepositories;

namespace _2015116292_WebApi.Controllers
{
    public class DistritoesController : ApiController
    {
        private readonly IUnityOfWork _UnityOfWork;

        public DistritoesController()
        {

        }

        public DistritoesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {

            var Distrito1 = _UnityOfWork.Distrito1.GetAll();

            if (Distrito1 == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var DistritoDTO = new List<DistritoDTO>();

            foreach (var Distrito in Distrito1)
                DistritoDTO.Add(Mapper.Map<Distrito, DistritoDTO>(Distrito));

            return Ok(DistritoDTO);
        }


        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var Distrito = _UnityOfWork.Distrito1.Get(id);

            if (Distrito == null)
                return NotFound();

            return Ok(Mapper.Map<Distrito, DistritoDTO>(Distrito));
        }


        [HttpPut]
        public IHttpActionResult Update(int id, DistritoDTO DistritoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var DistritoInPersistence = _UnityOfWork.Distrito1.Get(id);
            if (DistritoInPersistence == null)
                return NotFound();

            Mapper.Map<DistritoDTO, Distrito>(DistritoDTO, DistritoInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(DistritoDTO);
        }

        [HttpPost]
        public IHttpActionResult Create(DistritoDTO DistritoDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Distrito = Mapper.Map<DistritoDTO, Distrito>(DistritoDTO);

            _UnityOfWork.Distrito1.Add(Distrito);
            _UnityOfWork.SaveChanges();

            DistritoDTO.Distrito_id = Distrito.Distrito_id;

            return Created(new Uri(Request.RequestUri + "/" + Distrito.Distrito_id), DistritoDTO);
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var DistritoInDataBase = _UnityOfWork.Distrito1.Get(id);
            if (DistritoInDataBase == null)
                return NotFound();

            _UnityOfWork.Distrito1.Delete(DistritoInDataBase);
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
