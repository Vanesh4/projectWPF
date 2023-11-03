using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp2.Models
{
    internal class Puestos
    {
        private string idCargo { get; set; }
        private string area { get; set; }
        private string celCoorporativo { get; set; }
        private string correoCoorporativo { get; set; }
        private string correoGmail { get; set; }
        private string diagramaPosicion { get; set; }
        private string observacion { get; set; }

        public Puestos()
        {

        }
        public Puestos(string idCargo, string area, string celCoorporativo, string correoCoorporativo, string correoGmail, string diagramaPosicion, string observacion)
        {
            this.idCargo = idCargo; 
            this.area = area;
            this.celCoorporativo = celCoorporativo;
            this.correoCoorporativo = correoCoorporativo;
            this.correoGmail = correoGmail;
            this.diagramaPosicion = diagramaPosicion;
            this.observacion = observacion;
        }


        public DataSet getPuestos()
        {
            conexionbd con = new conexionbd();
            string consulta = "select * from tbl_puestos";
            return con.crearConexion(consulta);
        }

        public DataSet fitrarCargo(string puesto)
        {
            conexionbd con = new conexionbd();
            string consulta = $"SELECT * FROM tbl_puestos WHERE idCargo = '{puesto}'";
            //string consulta = "SELECT * FROM tbl_puestos WHERE idCargo = 'Cargo1'";
            return con.crearConexion(consulta);
        }

        public String postPuestos()
        {            
            
            conexionbd con = new conexionbd();
            string peticion = "INSERT INTO tbl_puestos (idCargo, area, celCoorporativo, correoCoorporativo, correoGmail, diagramaPosicion, observacion)" +
                $"VALUES ('{idCargo}', '{area}', '{celCoorporativo}', '{correoCoorporativo}', '{correoGmail}', '{diagramaPosicion}', '{observacion}');";
            int res = con.conexionAltTabla(peticion);

            if (res >= 1)
            {
                return "Inserción exitosa";
            }
            else
            {
                return "Error al insertar datos ";
            }
        }
    }
}
