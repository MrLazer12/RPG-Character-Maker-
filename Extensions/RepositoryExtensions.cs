using rpg_character.Repository.CharacterRepository;

namespace rpg_character.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICharacterRepository, CharacterRepository>();

        return services;
    }
}