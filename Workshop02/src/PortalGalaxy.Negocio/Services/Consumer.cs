using System.Diagnostics;
using System.Runtime.InteropServices;
using PortalGalaxy.Negocio.Interfaces;

namespace PortalGalaxy.Negocio.Services
{
    public class Consumer
    {
        private readonly IService _service;

        public Consumer(IService service)
        {
            _service = service;
        }

        public int Consume()
        {
            return _service.GetValue();
        }

        public void TrabajarConDatos()
        {
            var lista = _service.GetData();

            if (lista.Any())
            {
                Debug.WriteLine("Se encontraron elementos en la lista");
            }
        }
        
        public void TrabajarConDatos(short opcion)
        {
            switch (opcion)
            {
                case 0:
                    Debug.WriteLine("Opcion 0");
                    break;
                case 1:
                    Debug.WriteLine("Caso N° 1");
                    break;
                case >= 2 and <= 10:
                    _ = _service.GetData();
                    break;
                default:
                    throw new ApplicationException("Error de opcion incorrecta");
            }
        }
    }
}
