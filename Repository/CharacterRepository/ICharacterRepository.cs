using rpg_character.Models;
using rpg_character.Models.DTO;

namespace rpg_character.Repository.CharacterRepository;

public interface ICharacterRepository
{
    Task<Character> CreateCharacter(Character character);
    Task<List<CharacterDto>> GetCharacters();
}
