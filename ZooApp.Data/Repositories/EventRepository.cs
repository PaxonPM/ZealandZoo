using Microsoft.Data.SqlClient;
using ZooApp.Data.Db;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;

namespace ZooApp.Data.Repositories
{
    public class EventRepository : IEventRepository
    {

        private readonly DbConnectionHelper _connection;

        public EventRepository(DbConnectionHelper connection)
        {
            _connection = connection;
        }
        /// <summary>
        /// Creates a new event in the database and returns a string representation of the created event.     
        /// </summary>
        /// <param name="entity">The event entity to be created.</param>
        /// <returns>A string representation of the created event.</returns>
        public string Create(Event entity)
        {
            string queryStr = $"INSERT INTO Event (Title, Description, StartDateTime, EndDateTime, Location, MaxParticipants) " +
                $"VALUES (@Title, @description, @start_time, @end_time, @location, @max_participants)";
            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@Title", entity.Title);
            cmd.Parameters.AddWithValue("@Description", entity.Description);
            cmd.Parameters.AddWithValue("@StartDateTime", entity.StartDateTime);
            cmd.Parameters.AddWithValue("@EndDateTime", entity.EndDateTime);
            cmd.Parameters.AddWithValue("@Location", entity.Location);
            cmd.Parameters.AddWithValue("@MaxParticipants", entity.MaxParticipants);
            connection.Open();
            cmd.ExecuteNonQuery();

            return entity.ToString();
        }
        public Event GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            throw new NotImplementedException();
        }

        public string Update(Event entity)
        {
            throw new NotImplementedException();
        }
        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}

        

        