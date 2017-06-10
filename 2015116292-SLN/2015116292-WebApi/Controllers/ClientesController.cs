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
using _2015116292_ENT.IRepositories;
using AutoMapper;

namespace _2015116292_WebApi.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IUnityOfWork _UnityOfWork;

        public ClientesController()
        {

        }

        public ClientesController(IUnityOfWork unityOfWork)
        {
            _UnityOfWork = unityOfWork;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {

            var Cliente1 = _UnityOfWork.Cliente1.GetAll();

            if (Cliente1 == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var ClienteDTO = new List<ClienteDTO>();

            foreach (var Cliente in Cliente1)
                ClienteDTO.Add(Mapper.Map<Cliente, ClienteDTO>(Cliente));

            return Ok(ClienteDTO);
        }


        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var Cliente = _UnityOfWork.Cliente1.Get(id);

            if (Cliente == null)
                return NotFound();

            return Ok(Mapper.Map<Cliente, ClienteDTO>(Cliente));
        }


        [HttpPut]
        public IHttpActionResult Update(int id, ClienteDTO ClienteDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ClienteInPersistence = _UnityOfWork.Cliente1.Get(id);
            if (ClienteInPersistence == null)
                return NotFound();

            Mapper.Map<ClienteDTO, Cliente>(ClienteDTO, ClienteInPersistence);

            _UnityOfWork.SaveChanges();

            return Ok(ClienteDTO);
        }

        [HttpPost]
        public IHttpActionResult Create(ClienteDTO ClienteDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var Cliente = Mapper.Map<ClienteDTO, Cliente>(ClienteDTO);

            _UnityOfWork.Cliente1.Add(Cliente);
            _UnityOfWork.SaveChanges();

            ClienteDTO.Cliente_id = Cliente.Cliente_id;

            return Created(new Uri(Request.RequestUri + "/" + Cliente.Cliente_id), ClienteDTO);
        }


        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var ClienteInDataBase = _UnityOfWork.Cliente1.Get(id);
            if (ClienteInDataBase == null)
                return NotFound();

            _UnityOfWork.Cliente1.Delete(ClienteInDataBase);
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
