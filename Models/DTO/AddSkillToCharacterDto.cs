using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rpg_character.Models.DTO;

public class AddSkillToCharacterDto
{
    public required string Name { get; set; }
    public int Level { get; set; } = 0;
}