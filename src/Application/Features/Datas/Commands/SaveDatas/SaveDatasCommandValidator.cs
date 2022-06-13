
using FluentValidation;

namespace Application.Features.Datas.Commands.SaveDatas;

public class SaveDatasCommandValidator : AbstractValidator<SaveDatasCommand>
{
    public SaveDatasCommandValidator()
    {
        RuleFor(x => x.Data)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Time)
            .Cascade(CascadeMode.Stop)
            .NotNull()
            .NotEmpty();
    }
}