using rpg_character.Models.DTO;
using rpg_character.Services.SkillsService;

namespace rpg_character.Endpoints;

public static class Skills
{
    public static void RegisterSkillsMappingEndpoints(this WebApplication app)
    {
        RouteGroupBuilder skillsMappingGroup = app
            .MapGroup("api/skills")
            .WithTags("Skills");

        skillsMappingGroup
            .MapPost("/add-skill/{characterId}", AddSkillToCharacter)
            .WithOpenApi(o => new(o)
            {
                Summary = "Add a new skill to character"
            });
    }

    private static async Task<IResult> AddSkillToCharacter(
        int characterId,
        CreateSkillRequestDto request,
        ISkillsService skillsService
    )
    {
        var result = await skillsService.AddSkillToCharacter(characterId, request);

        return TypedResults.Ok(result);
    }
}