using _2015116292_ENT.Entities;
using _2015116292_ENT.EntitiesDTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _2015116292_WebApi.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdmiLinea, AdmiLineaDTO>();
            CreateMap<AdmiLineaDTO, AdmiLinea>();

            CreateMap<Centrodeatencion, CentrodeatencionDTO>();
            CreateMap<CentrodeatencionDTO, Centrodeatencion>();

            CreateMap<Cliente, ClienteDTO>();
            CreateMap<ClienteDTO, Cliente>();

            CreateMap<Departamento, DepartamentoDTO>();
            CreateMap<DepartamentoDTO, Departamento>();

            CreateMap<AdministradorEquipo, AdministradorEquipoDTO>();
            CreateMap<AdministradorEquipoDTO, AdministradorEquipo>();

            CreateMap<Direccion, DireccionDTO>();
            CreateMap<DireccionDTO, Direccion>();


            CreateMap<Provincia, ProvinciaDTO>();
            CreateMap<ProvinciaDTO, Provincia>();
            

            CreateMap<Plan, PlanDTO>();
            CreateMap<PlanDTO, Plan>();

            CreateMap<lineatelefonica, lineatelefonicaDTO>();
            CreateMap<lineatelefonicaDTO, lineatelefonica>();

            CreateMap<Evaluacion, EvaluacionDTO>();
            CreateMap<EvaluacionDTO, Evaluacion>();

            CreateMap<Estadodeevaluacion, EstadodeevaluacionDTO>();
            CreateMap<EstadodeevaluacionDTO, Estadodeevaluacion>();

            CreateMap<Equipocelular, EquipocelularDTO>();
            CreateMap<EquipocelularDTO, Equipocelular>();

            CreateMap<Distrito, DistritoDTO>();
            CreateMap<DistritoDTO, Distrito>();

            CreateMap<Ubigeo, UbigeoDTO>();
            CreateMap<UbigeoDTO, Ubigeo>();

            CreateMap<Trabajador, TrabajadorDTO>();
            CreateMap<TrabajadorDTO, Trabajador>();

            CreateMap<TipoPlan, TipoPlanDTO>();
            CreateMap<TipoPlanDTO, TipoPlan>();


            CreateMap<tipolinea, tipolineaDTO>();
            CreateMap<tipolineaDTO, tipolinea>();


            CreateMap<Tipodeevaluacion, TipodeevaluacionDTO>();
            CreateMap<TipodeevaluacionDTO, Tipodeevaluacion>();


        }
    }
}