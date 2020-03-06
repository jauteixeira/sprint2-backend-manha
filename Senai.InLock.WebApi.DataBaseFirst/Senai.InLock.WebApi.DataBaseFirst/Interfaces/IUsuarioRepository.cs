using Senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        List<Usuarios> Listar();

        /// <summary>
        /// Busca um usuario através do ID
        /// </summary>
        /// <param name="id">ID do usuario que será buscado</param>
        /// <returns>Um usuario buscado</returns>
        Usuarios BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        void Cadastrar(Usuarios novoUsuario);

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto novoUsuario que será cadastrado</param>
        void Atualizar(int id, Usuarios usuarioAtualizado);

        /// <summary>
        /// Deleta um usuario existente
        /// </summary>
        /// <param name="id">ID do usuario que será deletado</param>
        void Deletar(int id);
    }
}
