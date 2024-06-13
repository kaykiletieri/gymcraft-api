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

        return services;
    }
}
