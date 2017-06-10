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
using _2015116292_ENT.EntitiesDTO;
using AutoMapper;
using _2015116292_ENT.IRepositories;
using System.Web.Http;

namespace _2015116292_WebApi.Controllers
{
    public class EquipocelularsController : ApiController
    {
        private readonly IUnityOfWork _UnityOfWork;

        public EquipocelularsController()
        {

        }

        public EquipocelularsController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {

            var Equipocelular1 = _UnityOfWork.Equipocelular1.GetAll();

            if (Equipocelular1 == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var EquipocelularDTO = new List<EquipocelularDTO>();

            foreach (var Equipocelular in Equipocelular1)
                EquipocelularDTO.Add(Mapper.Map<Equipocelular, EquipocelularDTO>(Equipocelular));

            return Ok(EquipocelularDTO);
        }


        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var Equipocelular = _UnityOfWork.Equipocelular1.Get(id);

            if (Equipocelular == null)
                return NotFound();

            return Ok(Mapper.Map<Equipocelular, EquipocelularDTO>(Equipocelular));
        }


        [HttpPut]
        public IHttpActionResult Update(int id, EquipocelularDTO EquipocelularDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var EquipocelularInPersistence = _UnityOfWork.Equipocelular1.Get(id);
            if (EquipocelularInPersistence == null)
                return NotFound();

            Mapper.Map<EquipocelularDTO, Equipocelular>(EquipocelularDTO, EquipocelularInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(EquipocelularDTO);
        }

        [HttpPost]
        public IHttpActionResult Create(EquipocelularDTO EquipocelularDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Equipocelular = Mapper.Map<EquipocelularDTO, Equipocelular>(EquipocelularDTO);

            _UnityOfWork.Equipocelular1.Add(Equipocelular);
            _UnityOfWork.SaveChanges();

            EquipocelularDTO.Equipocelular_id = Equipocelular.Equipocelular_id;

            return Created(new Uri(Request.RequestUri + "/" + Equipocelular.Equipocelular_id), EquipocelularDTO);
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var EquipocelularInDataBase = _UnityOfWork.Equipocelular1.Get(id);
            if (EquipocelularInDataBase == null)
                return NotFound();

            _UnityOfWork.Equipocelular1.Delete(EquipocelularInDataBase);
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
