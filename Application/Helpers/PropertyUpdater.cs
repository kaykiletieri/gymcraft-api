using GymCraftAPI.Application.Helpers.Interfaces;

namespace GymCraftAPI.Application.Helpers;

public class PropertyUpdater : IPropertyUpdater
{
    public void UpdatePropertyIfNotEmpty<T>(Action<T> updateAction, T? newValue)
    {
        if (!string.IsNullOrEmpty(newValue?.ToString()))
        {
            updateAction(newValue);
        }
    }
}
