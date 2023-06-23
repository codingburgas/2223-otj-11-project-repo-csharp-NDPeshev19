using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BMS.Data.Helpers;

public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(
            dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
            dateTime => DateOnly.FromDateTime(dateTime))
    {
        
    }
}
