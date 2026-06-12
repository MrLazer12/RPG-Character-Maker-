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

        skillsMappingGroup
            .MapDelete("/delete-skill/{characterId}/{skillId}", DeleteSkillFromCharacter)
            .WithOpenApi(o => new(o)
            {
                Summary = "Delete skill from character"
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

    private static async Task<IResult> DeleteSkillFromCharacter(
        int characterId,
        int skillId,
        ISkillsService skillsService
    )
    {
        var result = await skillsService.DeleteSkillFromCharacter(characterId, skillId);

        if (!result)
        {
            return Results.NotFound(
                new
                {
                    message = "Skill not found for this character"
                }
            );
        }

        return Results.Ok(
            new
            {
                message = "Skill deleted successfully"
            }
        );
    }
}