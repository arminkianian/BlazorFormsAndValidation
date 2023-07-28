using BlazorFormsAndValidation.Shared;

namespace BlazorFormsAndValidation.Client.Services.TrailsService
{
    public interface ITrailsService
    {
        Task AddTrail(AddTrailCommand command);
    }
}
