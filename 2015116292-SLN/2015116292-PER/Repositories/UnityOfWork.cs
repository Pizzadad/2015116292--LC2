using _2015116292_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2015116292_PER.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly _2015116292_DbContext _Context;
        private static UnityOfWork _Instance;
        private static readonly object _Lock = new object();


           //

           public IAdmiLineaRepository AdmiLinea1 { get; private set; }

        public IAdministradorEquipoRepository AdministradorEquipo1 { get; private set; }

        public ICentrodeatencionRepository Centrodeatencion1 { get; private set; }

        public IClienteRepository Cliente1 { get; private set; }

        public IDepartamentoRepository Departamento1 { get; private set; }

        public IDireccionRepository Direccion1 { get; private set; }

        public IDistritoRepository Distrito1 { get; private set; }

        public IEquipocelularRepository Equipocelular1 { get; private set; }

        public IEstadodeevaluacionRepository Estadodeevaluacion1 { get; private set; }

        public IEvaluacionRepository Evaluacion1 { get; private set; }

        public IlineatelefonicaRepository lineatelefonica1 { get; private set; }

        public IPlanRepository Plan1 { get; private set; }

        public IProvinciaRepository Provincia1 { get; private set; }

        public ITipodeevaluacionRepository Tipodeevaluacion1 { get; private set; }

        public ItipolineaRepository tipolinea1 { get; private set; }

        public ITipoPlanRepository TipoPlan1 { get; private set; }

        public ITrabajadorRepository Trabajador1 { get; private set; }

        public IUbigeoRepository Ubigeo1 { get; private set; }

        private UnityOfWork()
        {
            _Context = new _2015116292_DbContext();

            Departamento1 = new DepartamentoRepository(_Context);
            AdmiLinea1 = new AdmiLineaRepository(_Context);
            AdministradorEquipo1 = new AdministradorEquipoRepository(_Context);
            Centrodeatencion1 = new CentrodeatencionRepository(_Context);
            Cliente1 = new ClienteRepository(_Context);
            Direccion1 = new DireccionRepository(_Context);
            Distrito1 = new DistritoRepository(_Context);
            Equipocelular1 = new EquipocelularRepository(_Context);
            Estadodeevaluacion1 = new EstadodeevaluacionRepository(_Context);
            Evaluacion1 = new EvaluacionRepository(_Context);
            lineatelefonica1 = new lineatelefonicaRepository(_Context);
            Plan1 = new PlanRepository(_Context);
            Provincia1 = new ProvinciaRepository(_Context);
            Tipodeevaluacion1 = new TipodeevaluacionRepository(_Context);
            tipolinea1 = new tipolineaRepository(_Context);
            TipoPlan1 = new TipoPlanRepository(_Context);
            Trabajador1 = new TrabajadorRepository(_Context);
            Ubigeo1 = new UbigeoRepository(_Context);
        }

        public static UnityOfWork Instance
        {
            get
            {
                lock (_Lock)
                {
                    if (_Instance == null)
                        _Instance = new UnityOfWork();
 }


                return Instance;
            }
        }
       
       public void Dispose()
        {
            _Context.Dispose();
        }

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

     }
}
