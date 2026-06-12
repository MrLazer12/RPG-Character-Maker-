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

    public async Task<Skills> AddSkillToCharacter(
        int characterId,
        CreateSkillRequestDto dto
    )
    {
        Skills skill = new Skills
        {
            Name = dto.Name,
            Level = dto.Level
        };

        Skills result = await _repository.AddSkillToCharacter(characterId, skill);

        return new Skills
        {
            Id = result.Id,
            Name = result.Name,
            Level = result.Level
        };
    }

    public async Task<bool> DeleteSkillFromCharacter(
        int characterId,
        int skillId
    )
    {
        Skills? skill = await _repository.GetByIdAsync(skillId, characterId);

        if (skill == null)
            return false;

        await _repository.DeleteSkillFromCharacter(skill);

        return true;
    }
}