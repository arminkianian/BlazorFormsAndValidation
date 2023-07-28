using BlazorFormsAndValidation.Shared;

namespace BlazorFormsAndValidation.Client.Services.TrailsService
{
    public class TrailsService : ITrailsService
    {
        public async Task AddTrail(AddTrailCommand command)
        {
            Console.WriteLine(command);
        }
    }
}
