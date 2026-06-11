using rpg_character.Services.CharacterService;

namespace rpg_character.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICharacterService, CharacterService>();
        return services;
    }
}