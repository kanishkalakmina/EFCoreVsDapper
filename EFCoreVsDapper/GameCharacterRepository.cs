using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreVsDapper
{
    public class GameCharacterRepository
    {
        private readonly GameContext _context;
        public GameCharacterRepository()
        {
            _context = new GameContext();
        }

        // EF Core =======================================================================================================================================================
        public void EF_Create()
        {
            var character = new GameCharacter
            {
                CharacterName = "Superman",
                PowerLevel = 100,
                Wepon = "Laser"
            };
            _context.GameCharacters.Add(character);
            _context.SaveChanges();
        }

        public void EF_Read()
        {
            var character = _context.GameCharacters.FirstOrDefault(c => c.CharacterName == "Superman");
            Console.WriteLine($"Character: {character.CharacterName}, PowerLevel: {character.PowerLevel}, Wepon: {character.Wepon}");
        }

        public void EF_Update()
        {
            var character = _context.GameCharacters.FirstOrDefault(c => c.CharacterName == "Superman");
            if (character != null)
            {
                character.PowerLevel = 150;
                _context.SaveChanges();
            }
        }

        public void EF_Delete()
        {
            var character = _context.GameCharacters.FirstOrDefault(c => c.CharacterName == "Superman");
            if (character != null)
            {
                _context.GameCharacters.Remove(character);
                _context.SaveChanges();
            }
        }

        // Dapper =======================================================================================================================================================
        public void Dapper_Create()
        {
            using (var connection = new SqlConnection("Server=BISTECNB179;Database=GameDb;Trusted_Connection=true;TrustServerCertificate=true;"))
            {
                string insertQuery = "INSERT INTO GameCharacters (CharacterName, PowerLevel, Wepon) VALUES (@CharacterName, @PowerLevel, @Wepon)";
                connection.Execute(insertQuery, new { CharacterName = "BatMan", PowerLevel = 200, Wepon = "Bat" });
            }
        }

        public void Dapper_Read()
        {
            using (var connection = new SqlConnection("Server=BISTECNB179;Database=GameDb;Trusted_Connection=true;TrustServerCertificate=true;"))
            {
                string selectQuery = "SELECT * FROM GameCharacters WHERE CharacterName = @CharacterName";
                var character = connection.QueryFirstOrDefault<GameCharacter>(selectQuery, new { CharacterName = "BatMan" });
                Console.WriteLine($"Character: {character.CharacterName}, PowerLevel: {character.PowerLevel}, Wepon: {character.Wepon}");
            }
        }

        public void Dapper_Update()
        {
            using (var connection = new SqlConnection("Server=BISTECNB179;Database=GameDb;Trusted_Connection=true;TrustServerCertificate=true;"))
            {
                string updateQuery = "UPDATE GameCharacters SET PowerLevel = @PowerLevel WHERE CharacterName = @CharacterName";
                connection.Execute(updateQuery, new { PowerLevel = 250, CharacterName = "BatMan" });
            }
        }

        public void Dapper_Delete()
        {
            using (var connection = new SqlConnection("Server=BISTECNB179;Database=GameDb;Trusted_Connection=true;TrustServerCertificate=true;"))
            {
                string deleteQuery = "DELETE FROM GameCharacters WHERE CharacterName = @CharacterName";
                connection.Execute(deleteQuery, new { CharacterName = "Superman" });
            }
        }
    }
}