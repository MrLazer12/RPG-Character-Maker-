using rpg_character.Models;
using rpg_character.Models.DTO;

namespace rpg_character.Services.SkillsService;

public interface ISkillsService
{
    Task<Skills> AddSkillToCharacter(int characterId, CreateSkillRequestDto dto);
    Task<bool> DeleteSkillFromCharacter(int characterId, int skillId);
}