namespace GymCraftAPI.Application.Helpers.Interfaces;

public interface IPropertyUpdater
{
    void UpdatePropertyIfNotEmpty<T>(Action<T> updateAction, T? newValue);
}
