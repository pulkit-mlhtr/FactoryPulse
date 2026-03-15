using FluentValidation;
using FactoryPulse.API.Request;

namespace FactoryPulse.API.Validators;

public class UpdateEquipmentStateRequestValidator : AbstractValidator<UpdateEquipmentStateRequest>
{
    public UpdateEquipmentStateRequestValidator()
    {
        RuleFor(x => x.EquipmentId).GreaterThan(0);
        RuleFor(x => x.ChangedBy).NotEmpty();
        RuleFor(x => x.CurrentState).IsInEnum();
        RuleFor(x => x.ProductionLine).GreaterThan(0);
    }
}
