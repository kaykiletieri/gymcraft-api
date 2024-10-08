using GymCraftAPI.Domain.Interfaces;
using GymCraftAPI.Infrastructure.Mappers;
using GymCraftAPI.Infrastructure.Mappers.Interfaces;
using GymCraftAPI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GymCraftAPI.Infrastructure.Extensions;

public static class DataExtensions
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(connectionString);
        });

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

        services.AddScoped<IExerciseRepository, ExerciseRepository>();
        services.AddScoped<IExerciseCategoryRepository, ExerciseCategoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IWorkoutDayRepository, WorkoutDayRepository>();
        services.AddScoped<IWorkoutRepository, WorkoutRepository>();
        services.AddScoped<IWorkoutExerciseRepository, WorkoutExerciseRepository>();

        return services;
    }

    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddScoped<IUserMapper, UserMapper>();
        services.AddScoped<IExerciseCategoryMapper, ExerciseCategoryMapper>();
        services.AddScoped<IExerciseMapper, ExerciseMapper>();

        return services;
    }
}
