using senai.Filmes.WebApi.Domains;
using senai.Filmes.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.Filmes.WebApi.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string stringConexao = "Data Source=DEV8\\SQLEXPRESS; initial catalog=Filmes_manha; user Id=sa; pwd=sa@132";

        public List<FilmeDomain> Listar()
        {
            List<FilmeDomain> filmes = new List<FilmeDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelecionarTodos = "SELECT IdFilme, Titulo from Filmes";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelecionarTodos, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),

                            Titulo = rdr["Titulo"].ToString()
                        };

                        filmes.Add(filme);
                    }
                }
            }
            return filmes;

        }

        public FilmeDomain atualizarFilme(int id, FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateFilme = "UPDATE Filmes SET Titulo = @Titulo WHERE IdFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateFilme, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("Titulo", filme.Titulo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
                return null;
            }
        }

        public void cadastrarFilmes(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastrar = "INSERT INTO Filmes(Titulo) VALUES (@Titulo)";

                SqlCommand cmd = new SqlCommand(queryCadastrar, con);

                cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

                con.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public void deletarFilme(int idFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Filmes WHERE IdFilme = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", idFilme);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }


        public FilmeDomain listarFilmeId(int idFilme)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryListarFilmeId = "SELECT IdFilme, Titulo FROM Filmes WHERE IdFilme = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryListarFilmeId, con))
                {
                    cmd.Parameters.AddWithValue("@ID", idFilme);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),

                            Titulo = rdr["Titulo"].ToString()
                        };

                        return filme;
                    }

                    return null;
                }
            }
        }
    }
}
