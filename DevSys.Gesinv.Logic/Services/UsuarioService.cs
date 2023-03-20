using DevSys.Gesinv.DAL.Contracts;
using DevSys.Gesinv.Logic.Contracts;
using DevSys.Gesinv.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSys.Gesinv.Logic.Services
{
    public class UsuarioService : GenericService<Usuario>, IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _repository;
        public UsuarioService(IGenericRepository<Usuario> repository) : base(repository)
        {
            _repository = repository;
        }
        public Usuario GetUsuario(string correo, string password) 
        {
            Usuario usuario_encontrado = _repository.GetAll().Result.Where(u => u.Correo == correo && u.Password == password).FirstOrDefault();
            return usuario_encontrado;
        }


    }
}
