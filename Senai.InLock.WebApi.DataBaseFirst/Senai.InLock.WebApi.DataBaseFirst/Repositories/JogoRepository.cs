using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        InLockContext ctx = new InLockContext();

        public void Atualizar(int id, Jogos jogoAtualizado)
        {
            //Atualiza um jogo pelo ID buscado
            ctx.Jogos.Update(jogoAtualizado);

            // Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        public Jogos BuscarPorId(int id)
        {
            //Busca o jogo pelo ID
            return ctx.Jogos.FirstOrDefault(e => e.IdJogo == id);
        }

        public void Cadastrar(Jogos novoJogo)
        {
            // Adiciona um novo jogo
            ctx.Jogos.Add(novoJogo);

            // Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            //Deleta um jogo pelo ID
            ctx.Jogos.Remove(BuscarPorId(id));

            //Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        public List<Jogos> Listar()
        {
            // Retorna uma lista com todas as informações dos jogos
            return ctx.Jogos.ToList();
        }
    }
}
