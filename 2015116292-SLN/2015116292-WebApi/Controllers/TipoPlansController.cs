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
    public class TipoPlansController : ApiController
    {
        private readonly IUnityOfWork _UnityOfWork;

        public TipoPlansController()
        {

        }

        public TipoPlansController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {

            var TipoPlan1 = _UnityOfWork.TipoPlan1.GetAll();

            if (TipoPlan1 == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var TipoPlanDTO = new List<TipoPlanDTO>();

            foreach (var tipoPlan in TipoPlan1)
                TipoPlanDTO.Add(Mapper.Map<TipoPlan, TipoPlanDTO>(tipoPlan));

            return Ok(TipoPlanDTO);
        }


        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var tipoPlan = _UnityOfWork.TipoPlan1.Get(id);

            if (tipoPlan == null)
                return NotFound();

            return Ok(Mapper.Map<TipoPlan, TipoPlanDTO>(tipoPlan));
        }


        [HttpPut]
        public IHttpActionResult Update(int id, TipoPlanDTO tipoPlanDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var TipoPlanInPersistence = _UnityOfWork.TipoPlan1.Get(id);
            if (TipoPlanInPersistence == null)
                return NotFound();

            Mapper.Map<TipoPlanDTO, TipoPlan>(tipoPlanDTO, TipoPlanInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(tipoPlanDTO);
        }

        [HttpPost]
        public IHttpActionResult Create(TipoPlanDTO tipoPlanDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tipoPlan = Mapper.Map<TipoPlanDTO, TipoPlan>(tipoPlanDTO);

            _UnityOfWork.TipoPlan1.Add(tipoPlan);
            _UnityOfWork.SaveChanges();

            tipoPlanDTO.TipoPlan_id = tipoPlan.TipoPlan_id;

            return Created(new Uri(Request.RequestUri + "/" + tipoPlan.TipoPlan_id), tipoPlanDTO);
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var TipoPlanInDataBase = _UnityOfWork.TipoPlan1.Get(id);
            if (TipoPlanInDataBase == null)
                return NotFound();

            _UnityOfWork.TipoPlan1.Delete(TipoPlanInDataBase);
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
