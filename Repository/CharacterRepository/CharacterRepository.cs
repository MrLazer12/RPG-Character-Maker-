using Microsoft.EntityFrameworkCore;
using rpg_character.Data;
using rpg_character.Models;
using rpg_character.Models.DTO;

namespace rpg_character.Repository.CharacterRepository;

public class CharacterRepository : ICharacterRepository
{
    private readonly AppDbContext _context;

    public CharacterRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Character> CreateCharacter(Character character)
    {
        await _context.Characters.AddAsync(character);
        await _context.SaveChangesAsync();

        return character;
    }

    public async Task<List<CharacterDto>> GetCharacters()
    {
        return await _context.Characters
            .Include(c => c.Skills)
            .Select(c => new CharacterDto
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
            })
            .ToListAsync();
    }
}