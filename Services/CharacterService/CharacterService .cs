using rpg_character.Models;
using rpg_character.Models.DTO;
using rpg_character.Repository.CharacterRepository;

namespace rpg_character.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _repository;

    public CharacterService(ICharacterRepository repository)
    {
        _repository = repository;
    }

    public async Task<CharacterDto> CreateCharacterAsync(CreateCharacterDto dto)
    {
        var character = new Character
        {
            Name = dto.Name,
            Gender = dto.Gender
        };

        Character created = await _repository.CreateCharacter(character);

        return new CharacterDto
        {
            Id = created.Id,
            Name = created.Name,
            Gender = created.Gender.ToString(),
            Skills = new List<SkillDto>()
        };
    }

    public async Task<List<CharacterDto>> GetCharactersAsync()
    {
        var characters = await _repository.GetCharacters();

        return characters.Select(c => new CharacterDto
        {
            Id = c.Id,
            Name = c.Name,
            Gender = c.Gender.ToString(),
            Skills = c.Skills.Select(s => new SkillDto
            {
                Id = s.Id,
                Name = s.Name,
                Level = s.Level
            }).ToList()
        }).ToList();
    }
}