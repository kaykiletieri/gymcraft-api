namespace GymCraftAPI.Application.Helpers;

public interface IPropertyUpdater
{
    void UpdatePropertyIfNotEmpty<T>(Action<T> updateAction, T? newValue);
}
