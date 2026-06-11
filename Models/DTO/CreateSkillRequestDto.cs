namespace rpg_character.Models.DTO;

public class CreateSkillRequestDto
{
    public string Name { get; set; } = null!;
    public int Level { get; set; }
}