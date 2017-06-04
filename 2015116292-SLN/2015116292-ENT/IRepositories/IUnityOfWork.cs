using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_ENT.IRepositories
{
    public interface IUnityOfWork : IDisposable
    {
        IAdmiLineaRepository AdmiLinea1 { get; }
        IAdministradorEquipoRepository AdministradorEquipo1 { get; }
        ICentrodeatencionRepository Centrodeatencion1 { get; }
        IClienteRepository Cliente1 { get; }
        IDepartamentoRepository Departamento1 { get; }
        IDireccionRepository Direccion1 { get; }
        IDistritoRepository Distrito1 { get; }
        IEquipocelularRepository Equipocelular1 { get; }
        IEstadodeevaluacionRepository Estadodeevaluacion1 { get; }
        IEvaluacionRepository Evaluacion1 { get; }
        IlineatelefonicaRepository lineatelefonica1 { get; }
        IPlanRepository Plan1 { get; }
        IProvinciaRepository Provincia1 { get; }
        ITipodeevaluacionRepository Tipodeevaluacion1 { get; }
        ItipolineaRepository tipolinea1 { get; }
        ITipoPlanRepository TipoPlan1 { get; }
        ITrabajadorRepository Trabajador1 { get; }
        IUbigeoRepository Ubigeo1 { get; }

        int SaveChanges();
    }
        
}
