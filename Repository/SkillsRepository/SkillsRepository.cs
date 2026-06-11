using Microsoft.EntityFrameworkCore;
using rpg_character.Data;
using rpg_character.Models;

namespace rpg_character.Repository.SkillsRepository;

public class SkillsRepository : ISkillsRepository
{
    private readonly AppDbContext _context;

    public SkillsRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Skills> AddSkillToCharacter(int characterId, Skills skill)
    {
        var characterExists = await _context.Characters
            .AnyAsync(c => c.Id == characterId);

        if (!characterExists)
            throw new Exception("Character not found");

        skill.CharacterId = characterId;

        _context.Skills.Add(skill);
        await _context.SaveChangesAsync();

        return skill;
    }
}