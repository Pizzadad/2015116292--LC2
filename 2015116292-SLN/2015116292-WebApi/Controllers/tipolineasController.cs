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
    public class tipolineasController : ApiController
    {
        private readonly IUnityOfWork _UnityOfWork;

        public tipolineasController()
        {

        }

        public tipolineasController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {

            var tipolinea1 = _UnityOfWork.tipolinea1.GetAll();

            if (tipolinea1 == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var tipolineaDTO = new List<tipolineaDTO>();

            foreach (var tipolinea in tipolinea1)
                tipolineaDTO.Add(Mapper.Map<tipolinea, tipolineaDTO>(tipolinea));

            return Ok(tipolineaDTO);
        }


        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var tipolinea = _UnityOfWork.tipolinea1.Get(id);

            if (tipolinea == null)
                return NotFound();

            return Ok(Mapper.Map<tipolinea, tipolineaDTO>(tipolinea));
        }


        [HttpPut]
        public IHttpActionResult Update(int id, tipolineaDTO tipolineaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tipolineaInPersistence = _UnityOfWork.tipolinea1.Get(id);
            if (tipolineaInPersistence == null)
                return NotFound();

            Mapper.Map<tipolineaDTO, tipolinea>(tipolineaDTO, tipolineaInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(tipolineaDTO);
        }

        [HttpPost]
        public IHttpActionResult Create(tipolineaDTO tipolineaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tipolinea = Mapper.Map<tipolineaDTO, tipolinea>(tipolineaDTO);

            _UnityOfWork.tipolinea1.Add(tipolinea);
            _UnityOfWork.SaveChanges();

            tipolineaDTO.tipolinea_id = tipolinea.tipolinea_id;

            return Created(new Uri(Request.RequestUri + "/" + tipolinea.tipolinea_id), tipolineaDTO);
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tipolineaInDataBase = _UnityOfWork.tipolinea1.Get(id);
            if (tipolineaInDataBase == null)
                return NotFound();

            _UnityOfWork.tipolinea1.Delete(tipolineaInDataBase);
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
