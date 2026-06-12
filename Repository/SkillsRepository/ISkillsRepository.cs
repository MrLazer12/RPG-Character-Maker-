using rpg_character.Models;

namespace rpg_character.Repository.SkillsRepository;

public interface ISkillsRepository
{
    Task<Skills> AddSkillToCharacter(int characterId, Skills skill);
    Task<Skills?> GetByIdAsync(int skillId, int characterId);

    Task DeleteSkillFromCharacter(Skills skill);
}