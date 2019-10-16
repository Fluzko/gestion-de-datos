using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Windows.Forms;

namespace FrbaOfertas
{
    class ConectorDB
    {
        public SqlConnection conection;
        
        public ConectorDB(){
            try {
                conection = new SqlConnection(  @"Data source=localhost\SQLSERVER2012; 
                                                Initial Catalog=GD2C2019;
                                                user=gdCupon2019;
                                                password=gd2019");
                conection.Open();
                Console.WriteLine("Conexion con la base de datos ");
            } catch (Exception e) {
                MessageBox.Show(e.ToString());
                MessageBox.Show("Error en la conexion con la base de datos");
            }
        }
    }
}
