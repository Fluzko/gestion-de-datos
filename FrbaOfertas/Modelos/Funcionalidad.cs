using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaOfertas.Modelos
{
    public class Funcionalidad
    {
        public int id_funcionalidad { get; set; }
        public String funcionalidad { get; set; }
        public String descripcion { get; set; }

        public Funcionalidad(int id, String funcionalidad){
            id_funcionalidad = id;
            this.funcionalidad = funcionalidad;
        }
        public Funcionalidad(int id, String funcionalidad, String descripcion)
        {
            id_funcionalidad = id;
            this.funcionalidad = funcionalidad;
            this.descripcion = descripcion;
        }


        public void changeView() {
            switch(id_funcionalidad){
                case 1:
                    (new AbmRol.AbmRol()).Show();
                    break;
                
                case 2:
                    (new AbmCliente.AbmCliente()).Show();
                    
                    break;

                case 3:
                    (new AbmProveedor.AbmProveedores()).Show();
                    break;

                case 4:
                    //(new CragaCredito.CargaCredito()).Show();
                    break;

                case 5:
                    (new CrearOferta.PublicarOferta()).Show();
                    break;

                case 6:
                    (new ComprarOferta.ComprarOferta()).Show();
                    break;

                case 7:
                    (new ConsumirOferta.ConsumirOferta()).Show();
                    break;

                case 8:
                    (new Facturar.Facturar()).Show();
                    break;

                case 9:
                    //(new ListadoEstadistico.ListadoEstadistico()).Show();
                    break;

                default:
                    break;
            }
        }
    }
}
