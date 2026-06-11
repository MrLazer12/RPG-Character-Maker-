using rpg_character.Models;
using rpg_character.Models.DTO;

namespace rpg_character.Repository.SkillsRepository;

public interface ISkillsRepository
{
    Task<Skills> AddSkillToCharacter(int characterId, Skills skill); 
}