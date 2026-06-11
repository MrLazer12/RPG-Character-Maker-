
using rpg_character.Models;
using rpg_character.Models.DTO;
using rpg_character.Repository.CharacterRepository;

namespace rpg_character.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _repository;
    private readonly ILogger<CharacterService> _logger;

    public CharacterService(
        ICharacterRepository repository,
        ILogger<CharacterService> logger
    )
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<CreateCharacterDto> CreateCharacterAsync(CreateCharacterDto dto)
    {
        try
        {
            Character character = new Character
            {
                Name = dto.Name,
                Gender = dto.Gender
            };

            var created = await _repository.CreateCharacter(character);

            return new CreateCharacterDto
            {
                Name = created.Name,
                Gender = created.Gender
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating character with name {Name}", dto.Name);
            throw;
        }
    }

    public async Task<List<CharacterDto>> GetCharactersAsync()
    {
        try
        {
            return await _repository.GetCharacters();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while getting list of characters");
            throw;
        }
    }
}