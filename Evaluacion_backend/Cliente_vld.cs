using Evaluacion_backend.Models;

using FluentValidation;


namespace Evaluacion_backend
{
    public class Cliente_vld : AbstractValidator<Cliente>
    {
        public Cliente_vld()
        {
            RuleFor(x => x.Nombre).NotNull().WithMessage("Nombre Requerido");
            RuleFor(x => x.Apellido).NotNull().WithMessage("Apellido Requerido");
            RuleFor(x => x.Direccion).NotNull().WithMessage("Dirección Requerida");

            RuleFor(x => x.Direccion).NotEmpty().WithMessage("Dirección Requerida");
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("Nombre Requerido");
            RuleFor(x => x.Apellido).NotEmpty().WithMessage("Apellido Requerido");


        }
    }
}
