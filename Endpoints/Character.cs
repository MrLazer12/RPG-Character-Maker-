using Microsoft.AspNetCore.Http.HttpResults;
using rpg_character.Models;
using rpg_character.Models.DTO;
using rpg_character.Services.CharacterService;

namespace rpg_character.Endpoints;

public static class CharacterEndpoints
{
    public static void RegisterCharacterMappingEndpoints(this WebApplication app)
    {
        RouteGroupBuilder characterMappingGroup = app
            .MapGroup("/api/character")
            .WithTags("Character");

        characterMappingGroup
            .MapPost("/create", CreateCharacter)
            .WithOpenApi(o => new(o)
            {
                Summary = "Create a new character"
            })
            .WithDescription("0 - male, 1 - female");

        characterMappingGroup
            .MapGet("/get-characters", GetCharacters)
            .WithOpenApi(o => new(o)
            {
                Summary = "Create a new character"
            });
    }

    private static async Task<Results<Ok<CharacterDto>, BadRequest<string>>> CreateCharacter(
        CreateCharacterDto dto,
        ICharacterService characterService
    )
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            return TypedResults.BadRequest("Name is required");
        }

        var result = await characterService.CreateCharacterAsync(dto);

        return TypedResults.Ok(result);
    }

    private static async Task<Results<Ok<List<CharacterDto>>, BadRequest<string>>> GetCharacters(
        ICharacterService characterService
    )
    {
        var result = await characterService.GetCharactersAsync();

        return TypedResults.Ok(result);
    }
}