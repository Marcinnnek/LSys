using FluentValidation;
using LSys_Domain;

namespace LSys.View_Models.Validators
{
    public class RegisterUserVMValidator : AbstractValidator<RegisterUserVM>
    {
        private readonly LSysDbContext _dbContext;

        public RegisterUserVMValidator(LSysDbContext dbContext)
        {
            _dbContext = dbContext;

            RuleFor(x => x.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = _dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken!");
                    }
                });
            RuleFor(x => x.ConfirmPassword).Equal(z=>z.Password).WithMessage("Password and Confirm Password must be equal!");
        }
    }
}
