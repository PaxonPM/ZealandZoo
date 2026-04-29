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
        public Event Create(Event entity)
        {
            string queryStr = $"INSERT INTO Event (title, description, start_time, end_time, location, max_participants) " +
                $"OUTPUT INSERTED.event_id, INSERTED.created_at " +
                $"VALUES (@title, @description, @start_time, @end_time, @location, @max_participants)";
            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@title", entity.Title);
            cmd.Parameters.AddWithValue("@description", entity.Description);
            cmd.Parameters.AddWithValue("@start_time", entity.StartDateTime);
            cmd.Parameters.AddWithValue("@end_time", entity.EndDateTime);
            cmd.Parameters.AddWithValue("@location", entity.Location);
            cmd.Parameters.AddWithValue("@max_participants", entity.MaxParticipants);
            connection.Open();

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                entity.Id = reader.GetInt32(0);
                entity.CreatedAt = reader.GetDateTime(1);
            }

            return entity;
        }
        public Event GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Event> GetAll()
        {
            throw new NotImplementedException();
        }

        public Event Update(Event entity)
        {
            throw new NotImplementedException();
        }
        public Event Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}

        

        