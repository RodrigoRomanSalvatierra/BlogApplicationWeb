using BlogApplication.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApplication.AccesoDatos.Data.Repository
{
    public interface IUsuarioRepository: IRepository<ApplicationUser>
    {
        // estos metodos nos serviran para Bloquear o descbloquear a usuarios desde la lista del administrador
        // se los bloquea por dias o semanas dependiendo el valor que le asignemos
        void BloquearUsuario(string idUsuario);
        void DesbloquearUsuario(string idUsuario);
    }
}
