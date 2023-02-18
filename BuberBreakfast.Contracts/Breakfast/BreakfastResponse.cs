namespace BuberBreakfast.Contracts.Breakfast;

public record BreakfastResponse(
    Guid id,
    string Name,
    string Description,
    DateTime StartDateTime,
    DateTime EndDateTime,
    DateTime LastModified,
    List<string> Savory,
    List<string> Sweet);