using _2014139821_ENT.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2014139821_PER;

namespace _2014139821_PER.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly _2014139821_DbContext _Context;
        private static UnityOfWork _Instance;
        private static readonly object _Lock = new object();

        public IAdministradorEquipoRepository AdministradorEquipos { get; private set; }

        public IAdministradorLineaRepository AdministradorLineas { get; private set; }

        public ICentroAtencionRepository CentroAtencions { get; private set; }

        public IClienteRepository Clientes { get; private set; }

        public IContratoRepository Contratos { get; private set; }

        public IDepartamentoRepository Departamentos { get; private set; }

        public IDireccionRepository Direccions { get; private set; }

        public IDistritoRepository Distritos { get; private set; }

        public IEquipoCelularRepository EquipoCelulars { get; private set; }

        public IEstadoEvaluacionRepository EstadoEvaluacions { get; private set; }

        public IEvaluacionRepository Evaluacions { get; private set; }

        public ILineaTelefonicaRepository LineaTelefonicas { get; private set; }

        public IPlanRepository Plans { get; private set; }

        public IProvinciaRepository Provincias { get; private set; }

        public ITipoEvaluacionRepository TipoEvaluacions { get; private set; }

        public ITipoLineaRepository TipoLineas { get; private set; }

        public ITipoPagoRepository TipoPagos { get; private set; }

        public ITipoPlanRepository TipoPlans { get; private set; }

        public ITipoTrabajadorRepository TipoTrabajadors { get; private set; }

        public ITrabajadorRepository Trabajadors { get; private set; }

        public IUbigeoRepository Ubigeos { get; private set; }

        public IVentaRepository Ventas { get; private set; }

        public UnityOfWork()
        {

        }

        public UnityOfWork(_2014139821_DbContext context)
        {

            //Contexto para la BD
            _Context = context;

            AdministradorEquipos = new AdministradorEquipoRepository(_Context);
            AdministradorLineas = new AdministradorLineaRepository(_Context);
            CentroAtencions = new CentroAtencionRepository(_Context);
            Clientes = new ClienteRepository(_Context);
            Contratos = new ContratoRepository(_Context);
            Departamentos = new DepartamentoRepository(_Context);
            Direccions = new DireccionRepository(_Context);
            Distritos = new DistritoRepository(_Context);
            EquipoCelulars = new EquipoCelularRepository(_Context);
            EstadoEvaluacions= new EstadoEvaluacionRepository(_Context);
            Evaluacions = new EvaluacionRepository(_Context);
            LineaTelefonicas = new LineaTelefonicaRepository(_Context);
            Plans = new PlanRepository(_Context);
            Provincias = new ProvinciaRepository(_Context);
            TipoEvaluacions = new TipoEvaluacionRepository(_Context);
            TipoLineas = new TipoLineaRepository(_Context);
            TipoPagos = new TipoPagoRepository(_Context);
            TipoPlans = new TipoPlanRepository(_Context);
            TipoTrabajadors = new TipoTrabajadorRepository(_Context);
            Trabajadors = new TrabajadorRepository(_Context);
            Ubigeos = new UbigeoRepository(_Context);
            Ventas = new VentaRepository(_Context);
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

                return _Instance;
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

        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
