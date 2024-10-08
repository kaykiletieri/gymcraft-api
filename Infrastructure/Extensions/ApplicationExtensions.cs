using GymCraftAPI.Application.Helpers;
using GymCraftAPI.Application.Helpers.Interfaces;
using GymCraftAPI.Application.Services;
using GymCraftAPI.Application.Services.Interfaces;

namespace GymCraftAPI.Infrastructure.Extensions;

public static class ApplicationExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IExerciseService, ExerciseService>();
        services.AddScoped<IExerciseCategoryService, ExerciseCategoryService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IWorkoutDayService, WorkoutDayService>();
        services.AddScoped<IWorkoutService, WorkoutService>();
        services.AddScoped<IWorkoutExerciseService, WorkoutExerciseService>();

        return services;
    }

    public static IServiceCollection AddHelpers(this IServiceCollection services)
    {
        services.AddScoped<IPropertyUpdater, PropertyUpdater>();

        return services;
    }
}
