using CampSoft.Classes;
using CampSoft.componentes;
using Microsoft.Data.SqlClient;
using static CampSoft.Classes.Jogador;

namespace CampSoft.DAO
{
    public class JogadorDAO
    {
        private ConexaoSQL conexaoSQL;

        public JogadorDAO(ConexaoSQL conexaoSQL)
        {
            this.conexaoSQL = conexaoSQL;
        }

        public void CriarJogador(Jogador jogador)
        {
            using (SqlConnection connection = conexaoSQL.ObterConexao())
            {
                connection.Open();

                string sql = "INSERT INTO TbJogador (Nome, Classe, Equipe) VALUES (@Nome, @Classe, @Equipe)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Nome", jogador.Nome);
                    command.Parameters.AddWithValue("@Classe", jogador.classe);
                    command.Parameters.AddWithValue("@Equipe", jogador.Equipe);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Jogador> LerJogadores()
        {
            List<Jogador> jogadores = new List<Jogador>();

            using (SqlConnection connection = conexaoSQL.ObterConexao())
            {
                connection.Open();

                string sql = "SELECT IdJogador, Nome, Classe, Equipe FROM TbJogador";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Jogador jogador = new Jogador();
                            jogador.IdJogador = reader.GetInt32(0);
                            jogador.Nome = reader.GetString(1);
                            jogador.classe = Enum.Parse<Classe>(reader.GetString(2));
                            jogador.Equipe = reader.GetString(3);

                            jogadores.Add(jogador);
                        }
                    }
                }
            }

            return jogadores;
        }

        public Jogador BuscarJogador(int id)
        {
            Jogador jogador = new Jogador();

            using (SqlConnection connection = conexaoSQL.ObterConexao())
            {
                connection.Open();

                string sql = "SELECT IdJogador, Nome, Classe, Equipe FROM TbJogador WHERE IdJogador = @IdJogador";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@IdJogador", id);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows) {
                            while (reader.Read())
                            {
                                jogador.IdJogador = reader.GetInt32(0);
                                jogador.Nome = reader.GetString(1);
                                jogador.classe = Enum.Parse<Classe>(reader.GetString(2));
                                jogador.Equipe = reader.GetString(3);
                            }
                            

                        }
                        else
                        {
                            throw new Exception("Nao foi possivel encontrar um jogador");
                        }

                    }
                }
            }

            return jogador;
        }

        public void AtualizarJogador(Jogador jogador)
        {
            using (SqlConnection connection = conexaoSQL.ObterConexao())
            {
                connection.Open();

                string sql = "UPDATE TbJogador SET Nome = @Nome, Classe = @Classe, Equipe = @Equipe WHERE IdJogador = @IdJogador";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@IdJogador", jogador.IdJogador);
                    command.Parameters.AddWithValue("@Nome", jogador.Nome);
                    command.Parameters.AddWithValue("@Classe", jogador.classe);
                    command.Parameters.AddWithValue("@Equipe", jogador.Equipe);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ExcluirJogador(int idJogador)
        {
            using (SqlConnection connection = conexaoSQL.ObterConexao())
            {
                connection.Open();

                string sql = "DELETE FROM TbJogador WHERE IdJogador = @IdJogador";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@IdJogador", idJogador);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
