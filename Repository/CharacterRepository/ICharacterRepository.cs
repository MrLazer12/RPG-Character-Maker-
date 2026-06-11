using rpg_character.Models;

namespace rpg_character.Repository.CharacterRepository;

public interface ICharacterRepository
{
    Task<Character> CreateCharacter(Character character);
    Task<List<Character>> GetCharacters();
}
