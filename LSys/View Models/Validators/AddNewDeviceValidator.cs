using FluentValidation;
using LSys_Domain;

namespace LSys.View_Models.Validators
{
    public class AddNewDeviceValidator : AbstractValidator<AddDeviceVM>
    {
        private readonly LSysDbContext _dbContext;

        public AddNewDeviceValidator(LSysDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Name).MinimumLength(3).NotEmpty();

        }
    }
}
