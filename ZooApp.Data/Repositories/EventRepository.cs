using Microsoft.Data.SqlClient;
using ZooApp.Data.Db;
using ZooApp.Data.interfaces;
using ZooApp.Domain.Models;

namespace ZooApp.Data.Repositories
{
    /// <summary>
    /// Repository for managing event data operations in the database.
    /// </summary>
    public class EventRepository : IEventRepository
    {
        private readonly DbConnectionHelper _connection;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventRepository"/> class.
        /// </summary>
        /// <param name="connection">The database connection helper.</param>
        public EventRepository(DbConnectionHelper connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Creates a new event in the database and returns the created event with generated ID and timestamp.
        /// </summary>
        /// <param name="entity">The event entity to be created.</param>
        /// <returns>The created event with populated Id and CreatedAt properties.</returns>
        public Event Create(Event entity)
        {
            string queryStr = "INSERT INTO Event (title, description, start_time, end_time, location, max_participants) " +
                              "OUTPUT INSERTED.event_id, INSERTED.created_at " +
                              "VALUES (@title, @description, @start_time, @end_time, @location, @max_participants)";

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

        /// <summary>
        /// Retrieves a single event from the database by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the event to retrieve.</param>
        /// <returns>The event with the specified ID, or null if not found.</returns>
        /// <exception cref="ArgumentException">Thrown when id is less than or equal to 0.</exception>
        public Event GetById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Event ID must be greater than 0.", nameof(id));
            }

            string queryStr = @"SELECT 
                            event_id, title, description, start_time, end_time, location, max_participants,
                            (SELECT COUNT(*) FROM EventParticipants WHERE EventParticipants.event_id = Event.event_id) AS current_participants,
                            created_at
                        FROM Event
                        WHERE event_id = @id";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@id", id);

            connection.Open();

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return MapReaderToEvent(reader);
            }

            return null;
        }

        /// <summary>
        /// Retrieves all events from the database.
        /// </summary>
        /// <returns>An enumerable collection of all events in the database.</returns>
        public IEnumerable<Event> GetAll()
        {
            string queryStr = @"SELECT 
                            event_id, title, description, start_time, end_time, location, max_participants,
                            (SELECT COUNT(*) FROM EventParticipants WHERE EventParticipants.event_id = Event.event_id) AS current_participants,
                            created_at
                        FROM Event
                        ORDER BY start_time ASC";

            var events = new List<Event>();

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);

            connection.Open();

                using var reader = cmd.ExecuteReader();
            
            // Read all events and add them to the list
            while (reader.Read())
            {
                events.Add(MapReaderToEvent(reader));
            }

            return events;
        }

        /// <summary>
        /// Updates an existing event in the database.
        /// </summary>
        /// <param name="entity">The event entity with updated information.</param>
        /// <returns>The updated event.</returns>
        public Event Update(Event entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes an event from the database by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the event to delete.</param>
        /// <returns>The deleted event.</returns>
        public Event Delete(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Helper method to map a SqlDataReader row to an Event object.
        /// </summary>
        /// <param name="reader">The SqlDataReader positioned at a row to read.</param>
        /// <returns>An Event object populated with data from the current reader row.</returns>
        private Event MapReaderToEvent(SqlDataReader reader)
        {
            return new Event
            {
                Id = reader.GetInt32(reader.GetOrdinal("event_id")),
                Title = reader.GetString(reader.GetOrdinal("title")),
                Description = reader.GetString(reader.GetOrdinal("description")),
                StartDateTime = reader.GetDateTime(reader.GetOrdinal("start_time")),
                EndDateTime = reader.GetDateTime(reader.GetOrdinal("end_time")),
                Location = reader.GetString(reader.GetOrdinal("location")),
                CurrentParticipants = reader.GetInt32(reader.GetOrdinal("current_participants")),
                MaxParticipants = reader.GetInt32(reader.GetOrdinal("max_participants")),
                CreatedAt = reader.GetDateTime(reader.GetOrdinal("created_at"))
            };
        }

        /// <summary>
        /// Adds a participant to an event.
        /// </summary>
        /// <param name="eventId">The ID of the event.</param>
        /// <param name="userId">The ID of the user to be added as a participant.</param>
        public void AddParticipant(int eventId, int userId)
        {
            string queryStr = "INSERT INTO EventParticipants (event_id, user_id) VALUES (@eventId, @userId)";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@eventId", eventId);
            cmd.Parameters.AddWithValue("@userId", userId);

            connection.Open();
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Removes a participant from an event.
        /// </summary>
        /// <param name="eventId">The ID of the event.</param>
        /// <param name="userId">The ID of the user to be removed from participants.</param>
        public void RemoveParticipant(int eventId, int userId)
        {
            string queryStr = "DELETE FROM EventParticipants WHERE event_id = @eventId AND user_id = @userId";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@eventId", eventId);
            cmd.Parameters.AddWithValue("@userId", userId);

            connection.Open();
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Checks if a user is a participant in an event.
        /// </summary>
        /// <param name="eventId">The ID of the event.</param>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>True if the user is a participant in the event; otherwise, false.</returns>
        public bool IsParticipant(int eventId, int userId)
        {
            string queryStr = "SELECT COUNT(*) FROM EventParticipants WHERE event_id = @eventId AND user_id = @userId";

            using var connection = _connection.CreateConnection();
            SqlCommand cmd = new SqlCommand(queryStr, connection);
            cmd.Parameters.AddWithValue("@eventId", eventId);
            cmd.Parameters.AddWithValue("@userId", userId);

            connection.Open();
            return (int)cmd.ExecuteScalar() > 0;
        }
    }
}