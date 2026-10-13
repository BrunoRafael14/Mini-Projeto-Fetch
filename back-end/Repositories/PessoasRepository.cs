using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using back_end.Models;
using Npgsql;

namespace back_end.Repositories
{
    public class PessoasRepository
    {
        private DbConnectionFactory _dbConnection;
        public PessoasRepository(DbConnectionFactory dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public List<PessoaModel>? BuscarPessoasRepository()
        {
            try
            {
               var PessoasModelResponse = new List<PessoaModel>();

                var conexao = _dbConnection.CreateConnection();
                conexao.Open();
                var querySql = "SELECT * FROM Pessoas;";
                using var comando = new NpgsqlCommand(querySql, conexao);
                using var leitor = comando.ExecuteReader();

                while (leitor.Read())
                {
                    PessoasModelResponse.Add(new PessoaModel
                    {
                        Id = leitor.GetInt32(0),
                        Nome = leitor.GetString(1),
                        Email = leitor.GetString(2)
                    });
                }

                return PessoasModelResponse; 
            }
            catch
            {
                return null;
            }
            
        }

        public bool CadastrarPessoaRepository(PessoaModel pessoaModel)
        {
            try
            {
                var conexao = _dbConnection.CreateConnection();
                conexao.Open();
                var querySql = $"INSERT INTO Pessoas(nome, email) VALUES('{pessoaModel.Nome}','{pessoaModel.Email}')";
                using var comando = new NpgsqlCommand(querySql, conexao);
                comando.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}