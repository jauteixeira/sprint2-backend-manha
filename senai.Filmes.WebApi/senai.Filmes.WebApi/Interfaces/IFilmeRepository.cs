using senai.Filmes.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Interfaces
{
    interface IFilmeRepository
    {
        //MÉTODO PARA LISTAR FILMES
        List<FilmeDomain> Listar();

        //MÉTODO PARA CADASTRAR FILMES
        void cadastrarFilmes(FilmeDomain filme);

        //MÉTODO PARA DELETAR UM FILME
        void deletarFilme(int idFilme);

        //MÉTODO PARA LISTAR UM FILME PELO ID
        FilmeDomain listarFilmeId(int idFilme);

        //MÉTODO PARA ATUALIZAR UM FILME EXISTENTE
        FilmeDomain atualizarFilme(int id, FilmeDomain filme);
    }
}
