using CampSoft.Classes;
using CampSoft.componentes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampSoft.DAO
{
    public class HorariosDisponiveisDAO
    {
        private readonly ConexaoSQL conexaoSQL;

        public HorariosDisponiveisDAO(ConexaoSQL conexaoSQL)
        {
            this.conexaoSQL = conexaoSQL;
        }

        public List<HorariosDisponiveis> BuscarHorariosDisponiveis()
        {
            // Implementar lógica para buscar os horários disponíveis do banco de dados
            // ...

            List<HorariosDisponiveis> horarios = new List<HorariosDisponiveis>();

            using (SqlConnection connection = conexaoSQL.ObterConexao())
            {
                connection.Open();

                string sql = @"SELECT hd.IdHorario, 
                                DataHoraInicio,
                                DataHoraFinal 
                                FROM TbHorarioDisponivel hd
                                WHERE HD.IdHorario NOT IN (SELECT IdHorario FROM TbAgendamento)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HorariosDisponiveis horario = new HorariosDisponiveis();
                            horario.IdHorario = reader.GetInt32(0);
                            horario.HoraInicio = reader.GetDateTime(1);
                            horario.HoraFinal = reader.GetDateTime(2);

                            horarios.Add(horario);
                        }
                    }
                }
            }

            return horarios; // Retornar a lista de horários disponíveis
        }

        public List<HorariosDisponiveis> BuscarHorariosDisponiveisPorData(DateTime Data)
        {
            // Implementar lógica para buscar os horários disponíveis do banco de dados
            // ...

            List<HorariosDisponiveis> horarios = new List<HorariosDisponiveis>();

            using (SqlConnection connection = conexaoSQL.ObterConexao())
            {
                connection.Open();

                string sql = @"SELECT hd.IdHorario, 
                                DataHoraInicio,
                                DataHoraFinal 
                                FROM TbHorarioDisponivel hd
                                WHERE HD.IdHorario NOT IN (SELECT IdHorario FROM TbAgendamento)
                                AND DataHoraInicio = CAST(@Data AS DATE)";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Data", Data.ToString("dd/MM/YYYY"));

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            HorariosDisponiveis horario = new HorariosDisponiveis();
                            horario.IdHorario = reader.GetInt32(0);
                            horario.HoraInicio = reader.GetDateTime(1);
                            horario.HoraFinal = reader.GetDateTime(2);

                            horarios.Add(horario);
                        }
                    }
                }
            }

            return horarios; // Retornar a lista de horários disponíveis
        }

        public HorariosDisponiveis BuscarHorario(int idHorario, int idUsuario)
        {
            // Implementar lógica para buscar os horários disponíveis do banco de dados
            // ...

            HorariosDisponiveis horario = new HorariosDisponiveis();

            using (SqlConnection connection = conexaoSQL.ObterConexao())
            {
                connection.Open();

                string sql = @"SELECT hd.IdHorario, 
                                DataHoraInicio,
                                DataHoraFinal
                                FROM TbHorarioDisponivel hd
                                INNER JOIN TbAgendamento a ON a.IdHorario = hd.IdHorario
                                WHERE hd.IdHorario = @IdHorario
                                AND a.IdUsuario = @IdUsuario";

                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@IdHorario", idHorario);
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                horario.IdHorario = reader.GetInt32(0);
                                horario.HoraInicio = reader.GetDateTime(1);
                                horario.HoraFinal = reader.GetDateTime(2);
                            }
                        }
                        else {
                            throw new Exception("Nao foi possivel encontrar o horario");
                        }
                    }
                }
            }

            return horario; // Retornar a lista de horários disponíveis
        }

        public void AgendarHorarioDisponivel(HorariosDisponiveis horarioDisponivel)
        {
            using (SqlConnection connection = conexaoSQL.ObterConexao())
            {
                try
                {
                    connection.Open();

                    string sql = "INSERT INTO TbAgendamento (IdHorario, IdUsuario) VALUES (@IdHorario, 1)";


                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@IdHorario", horarioDisponivel.IdHorario);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) {
                    throw new Exception("Não foi possivel agendar um horario. Motivo: " + ex.Message);
                }
               
            }
        }

        public void ExcluirHorarioAgendamento(int idHorario)
        {
            // Implementar lógica para excluir o horário disponível do banco de dados
            // ...
            using (SqlConnection connection = conexaoSQL.ObterConexao())
            {
                try
                {
                    connection.Open();

                    string sql = "DELETE FROM TbAgendamento WHERE IdHorario = @IdHorario";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@IdHorario", idHorario);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex) {
                    throw new Exception("Não foi possivel apagar horario. Motivo: " + ex.Message);
                }
                
            }
        }
    }
}
