using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SIFIET.GestionUsuarios.Datos.Modelo;

namespace SIFIET.Aplicacion
{
    public static class  FachadaSIFIET
    {

        public static List<USUARIO> ConsultarUsuarios(){
            
            return SIFIET.GestionUsuarios.Aplicacion.FachadaUsuarios.ConsultarUsuarios();
            }

        

        public static void RegistrarUsuario(string idUsuario, string emailInstitucional, string passwordUsuario, int identificacionUsuario, string nombresUsuario, string apellidosUsuario, string estado)
        {
            SIFIET.GestionUsuarios.Aplicacion.FachadaUsuarios.RegistrarUsuario(idUsuario, emailInstitucional, passwordUsuario, identificacionUsuario, nombresUsuario, apellidosUsuario, estado);
        }
    }
}
