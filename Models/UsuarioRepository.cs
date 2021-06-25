using System.Collections.Generic;
using System.Linq;
using ProjMaster.Data;

namespace ProjMaster.Models
{
    public class UsuarioService
    {
        public List<Usuario> Listar()
        {
            using(ProjMasterContext bc = new ProjMasterContext())
            {
                return bc.usuarios.ToList();
            }
        }
        public Usuario Listar(int id)
        {
            using(ProjMasterContext bc = new ProjMasterContext())
            {
                return bc.usuarios.Find(id);
            }
        }
        public void incluirUsuario(Usuario novoUser)
        {
            using(ProjMasterContext bc = new ProjMasterContext())
            {
                bc.Add(novoUser);
                bc.SaveChanges();
            }
        }
        public void editarUsuario(Usuario userEditado)
        {
            using(ProjMasterContext bc = new ProjMasterContext())
            {
                Usuario u = bc.usuarios.Find(userEditado.Id);

                u.login = userEditado.login;
                u.Nome = userEditado.Nome;
                u.senha = userEditado.senha;
                u.tipo = userEditado.tipo;

                bc.SaveChanges();
            }
        }
        public void excluirUsuario(int id)
        {
            using(ProjMasterContext bc = new ProjMasterContext())
            {
                bc.usuarios.Remove(bc.usuarios.Find(id));
                bc.SaveChanges();
            }
        }
    }
}