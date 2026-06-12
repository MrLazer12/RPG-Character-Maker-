using rpg_character.Models;
using rpg_character.Models.DTO;

namespace rpg_character.Services.CharacterService;

public interface ICharacterService
{
    Task<CharacterDto> CreateCharacterAsync(CreateCharacterDto dto);
    Task<List<CharacterDto>> GetCharactersAsync();
}