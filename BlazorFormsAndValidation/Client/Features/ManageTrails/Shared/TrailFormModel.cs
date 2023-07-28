using FluentValidation;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorFormsAndValidation.Client.Features.ManageTrucks.Shared
{
    public class TrailFormModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Location { get; set; } = "";
        public int TimeInMinutes { get; set; }
        public int Length { get; set; }
        public List<RouteInstruction> Route { get; set; } = new List<RouteInstruction>();

        public IBrowserFile? BrowserFile { get; set; }

        public class RouteInstruction
        {
            public int Stage { get; set; }
            public string Description { get; set; } = "";
        }
    }

    public class TrailValidator : AbstractValidator<TrailFormModel>
    {
        public TrailValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please enter a name");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter a description");

            RuleFor(x => x.Location).NotEmpty().WithMessage("Please enter a location");

            RuleFor(x => x.Length).GreaterThan(0).WithMessage("Please enter a length");

            RuleFor(x => x.Route).NotEmpty().WithMessage("Please add a route instruction");

            RuleFor(x => x.TimeInMinutes).GreaterThan(0).WithMessage("Please enter a time");

            RuleForEach(x => x.Route).SetValidator(new RouteInstructionValidator());
        }
    }

    public class RouteInstructionValidator : AbstractValidator<TrailFormModel.RouteInstruction>
    {
        public RouteInstructionValidator()
        {
            RuleFor(x => x.Stage).NotEmpty().WithMessage("Please enter a stage");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter a description");
        }
    }
}
