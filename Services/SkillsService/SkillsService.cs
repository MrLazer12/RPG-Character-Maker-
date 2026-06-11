using rpg_character.Models;
using rpg_character.Models.DTO;
using rpg_character.Repository.SkillsRepository;

namespace rpg_character.Services.SkillsService;

public class SkillsService : ISkillsService
{
    private readonly ISkillsRepository _repository;
    private readonly ILogger<SkillsService> _logger;

    public SkillsService(
        ISkillsRepository repository,
        ILogger<SkillsService> logger
    )
    {
        _repository = repository;
        _logger = logger;
    }

    public async Task<SkillResponseDto> AddSkillToCharacter(
        int characterId,
        CreateSkillRequestDto dto
    )
    {
        try
        {
            Skills skill = new Skills
            {
                Name = dto.Name,
                Level = dto.Level
            };

            var result = await _repository.AddSkillToCharacter(characterId, skill);

            return new SkillResponseDto
            {
                Id = result.Id,
                Name = result.Name,
                Level = result.Level
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error creating character with name {Name}", dto.Name);
            throw;
        }
    }
}