using Microsoft.EntityFrameworkCore;
using rpg_character.Data;
using rpg_character.Models;

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

    public async Task<List<Character>> GetCharacters()
    {
        return await _context.Characters.ToListAsync();
    }
}