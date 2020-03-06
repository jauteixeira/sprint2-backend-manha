using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado)
        {
            ctx.TiposUsuario.Update(tipoUsuarioAtualizado);
        }

        public TiposUsuario BuscarPorId(int id)
        {
            return ctx.TiposUsuario.FirstOrDefault(e => e.IdTipoUsuario == id);
        }

        public void Cadastrar(TiposUsuario novoTiposUsuario)
        {
            ctx.TiposUsuario.Add(novoTiposUsuario);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            ctx.TiposUsuario.Remove(BuscarPorId(id));

            ctx.SaveChanges();
        }

        public List<TiposUsuario> Listar()
        {
            return ctx.TiposUsuario.ToList();
        }
    }
}
