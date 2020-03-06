using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.DataBaseFirst.Domains;
using Senai.InLock.WebApi.DataBaseFirst.Interfaces;
using Senai.InLock.WebApi.DataBaseFirst.Repositories;

namespace Senai.InLock.WebApi.DataBaseFirst.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private IJogoRepository _jogoRepository;

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_jogoRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_jogoRepository.BuscarPorId(id));
        }

        [HttpPost]
        public IActionResult Post(Jogos novoJogo)
        {
            _jogoRepository.Cadastrar(novoJogo);

            return StatusCode(201);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _jogoRepository.Deletar(id);

            return StatusCode(200);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Jogos jogoAtualizado)
        {
            _jogoRepository.Atualizar(id, jogoAtualizado);

            return StatusCode(200);
        }
    }
}