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
using _2015116292_ENT.IRepositories;
using System.Web.Http;
using _2015116292_ENT.EntitiesDTO;
using AutoMapper;

namespace _2015116292_WebApi.Controllers
{
    public class TrabajadorsController : ApiController
    {
        //  private _2015116292_DbContext db = new _2015116292_DbContext();
        private readonly IUnityOfWork _UnityOfWork;

        public TrabajadorsController()
        {

        }

        public TrabajadorsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }
   
        [HttpGet]
        public IHttpActionResult Get()
        {
            
            var Trabajador1 = _UnityOfWork.Trabajador1.GetAll();

            if (Trabajador1 == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var TrabajadorDTO = new List<TrabajadorDTO>();

            foreach (var trabajador in Trabajador1)
                TrabajadorDTO.Add(Mapper.Map<Trabajador, TrabajadorDTO>(trabajador));

            return Ok(TrabajadorDTO);
        }

      
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var trabajador = _UnityOfWork.Trabajador1.Get(id);

            if (trabajador == null)
                return NotFound();

            return Ok(Mapper.Map<Trabajador, TrabajadorDTO>(trabajador));
        }

       
        [HttpPut]
        public IHttpActionResult Update(int id, TrabajadorDTO trabajadorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var trabajadorInPersistence = _UnityOfWork.Trabajador1.Get(id);
            if (trabajadorInPersistence == null)
                return NotFound();

            Mapper.Map<TrabajadorDTO, Trabajador>(trabajadorDTO, trabajadorInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(trabajadorDTO);
        }

        [HttpPost]
        public IHttpActionResult Create(TrabajadorDTO trabajadorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var trabajador = Mapper.Map<TrabajadorDTO, Trabajador>(trabajadorDTO);

            _UnityOfWork.Trabajador1.Add(trabajador);
            _UnityOfWork.SaveChanges();

            trabajadorDTO.Trabajador_id= trabajador.Trabajador_id;

            return Created(new Uri(Request.RequestUri + "/" + trabajador.Trabajador_id), trabajadorDTO);
        }

   
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var trabajadorInDataBase = _UnityOfWork.Trabajador1.Get(id);
            if (trabajadorInDataBase == null)
                return NotFound();

            _UnityOfWork.Trabajador1.Delete(trabajadorInDataBase);
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
