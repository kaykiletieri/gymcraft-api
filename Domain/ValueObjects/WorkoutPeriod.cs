namespace GymCraftAPI.Domain.ValueObjects;

public class WorkoutPeriod
{
    public DateTime StartDate { get; }
    public DateTime? EndDate { get; }

    public WorkoutPeriod(DateTime startDate, DateTime? endDate = null)
    {
        if (endDate.HasValue && endDate < startDate)
        {
            throw new ArgumentException("End date must be after start date.");
        }

        StartDate = startDate;
        EndDate = endDate ?? startDate.AddMonths(1);
    }

    public IEnumerable<DateTime> GetAllDays()
    {
        DateTime currentDate = StartDate;
        List<DateTime> days = [];

        while (!EndDate.HasValue || currentDate <= EndDate.Value)
        {
            days.Add(currentDate);
            currentDate = currentDate.AddDays(1);
        }

        return days;
    }

    public bool IsActiveOn(DateTime date)
    {
        return StartDate <= date && (EndDate == null || EndDate >= date);
    }
}
