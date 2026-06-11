using rpg_character.Repository.CharacterRepository;
using rpg_character.Repository.SkillsRepository;

namespace rpg_character.Extensions;

public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<ICharacterRepository, CharacterRepository>();
        services.AddTransient<ISkillsRepository, SkillsRepository>();

        return services;
    }
}