using DtoLayer.BookingDto;
using FluentValidation;

namespace BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("You must enter your name");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("You must enter your phone number");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("You must enter your email address");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("You must enter person count");

            RuleFor(x => x.Name).MinimumLength(5).WithMessage("You must enter minimum 5 characters").MaximumLength(50).WithMessage("You cannot enter more than 50 characters");
            RuleFor(x => x.Phone).MinimumLength(11).WithMessage("Please enter your phone number correct").MaximumLength(11).WithMessage("Please enter your phone number correct");
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Please enter your email address correct");
        }
    }
}
