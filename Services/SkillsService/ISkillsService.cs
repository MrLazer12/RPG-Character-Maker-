using rpg_character.Models;
using rpg_character.Models.DTO;

namespace rpg_character.Services.SkillsService;

public interface ISkillsService
{
    Task<SkillResponseDto> AddSkillToCharacter(int characterId, CreateSkillRequestDto dto);
}