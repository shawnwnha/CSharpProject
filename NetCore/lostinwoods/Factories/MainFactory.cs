using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using lostinwoods.Models;
using Microsoft.Extensions.Options;

namespace lostinwoods.Factory
{
    public class MainFactory : IFactory<Trail>
    {
        private MySqlOptions _options;
        public MainFactory(IOptions <MySqlOptions> config)
        {
            _options = config.Value;
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(_options.ConnectionString);
            }
        }
        public void Add(Trail item)
        {
            using (IDbConnection dbConnection = Connection) {
                string query =  "INSERT INTO trail (name, description,length,elevation,longitude,latitude) VALUES (@Name, @Description, @Length, @Elevation, @Longitude, @Latitude)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        public IEnumerable<Trail> FindAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trail ORDER BY name");
            }
        }
        public Trail FindByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<Trail>("SELECT * FROM trail WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        } 
    }
}