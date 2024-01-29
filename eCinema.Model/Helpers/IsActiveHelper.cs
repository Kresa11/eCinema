namespace eCinema.Model.Helpers;

public static class IsActiveHelper<TDb> where TDb : class
{
    public static void SetIsActive(TDb? entity, bool status)
    {
        var property = entity?.GetType().GetProperty("IsActive");

        property?.SetValue(entity, status);
    }
}