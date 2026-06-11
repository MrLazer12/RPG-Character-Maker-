using rpg_character.Services.CharacterService;
using rpg_character.Services.SkillsService;

namespace rpg_character.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICharacterService, CharacterService>();
        services.AddScoped<ISkillsService, SkillsService>();

        return services;
    }
}