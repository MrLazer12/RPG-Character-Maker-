using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg_character.Models
{
    public class Skills
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int Level { get; set; } = 0;

        // Foreign key
        public int CharacterId { get; set; }
        // Navigation property
        public Character Character { get; set; } = null!;
    }
}