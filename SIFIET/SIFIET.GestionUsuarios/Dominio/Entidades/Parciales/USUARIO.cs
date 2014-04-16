﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SIFIET.GestionUsuarios.Datos.Modelo
{
    public partial class USUARIO
    {

        public ICollection<ROL> Roles
        {
            get
            {
                return (from e in new UsuariosEntities().ROLs

                        select e).ToList();

            }
        }
    }
}