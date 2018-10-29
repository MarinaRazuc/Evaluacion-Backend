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

            RuleFor(x => x.Nombre).Length(1,15).WithMessage("Nombre debe contener entre 1 y 15 caracteres");
            RuleFor(x => x.Apellido).Length(1, 30).WithMessage("Apellido debe contener entre 1 y 30 caracteres");
            RuleFor(x => x.Direccion).Length(1, 30).WithMessage("Dirección debe contener entre 1 y 30 caracteres");


        }
    }
}
