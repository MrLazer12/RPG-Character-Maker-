using rpg_character.Enum;

namespace rpg_character.Models.DTO
{
    public class CreateCharacterDto
    {
        public required string Name { get; set; }
        public Gender Gender { get; set; }
    }
}