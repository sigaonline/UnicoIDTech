using MODELO.Desafio.Model.Request;
using FluentValidation;

namespace MODELO.Desafio.Model.Validators
{
    public class FairRequestValidator : AbstractValidator<FairRequest>
    {
        public FairRequestValidator()
        {
            RuleFor(x => x.District)
                .NotEmpty().WithMessage("Distrito não pode ser nulo!")
                .MaximumLength(100).WithMessage("Distrito ultrapassa o tamanho permitido!");
            RuleFor(x => x.Region)
                .NotEmpty().WithMessage("Região não pode ser nulo!")
                .MaximumLength(100).WithMessage("Região ultrapassa o tamanho permitido!");
            RuleFor(x => x.NameFair)
                .NotEmpty().WithMessage("Nome da feira não pode ser nulo!")
                .MaximumLength(100).WithMessage("Nome da feira ultrapassa o tamanho permitido!");
            RuleFor(x => x.Neighborhood)
                .NotEmpty().WithMessage("Nome do bairro não pode ser nulo!")
                .MaximumLength(100).WithMessage("Nome do bairro ultrapassa o tamanho permitido!");
        }
    }
}
