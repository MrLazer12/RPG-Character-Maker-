using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rpg_character.Enum;

namespace rpg_character.Models;

public class Character
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Gender Gender { get; set; }

    public ICollection<Skills> Skills { get; set; } = new List<Skills>();
}