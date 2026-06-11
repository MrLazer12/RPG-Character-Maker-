namespace rpg_character.Models.DTO;

public class CharacterDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;

    public List<SkillDto> Skills { get; set; } = new();
}