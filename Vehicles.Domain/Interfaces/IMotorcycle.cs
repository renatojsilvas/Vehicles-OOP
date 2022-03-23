using Vehicles.Domain.Model;

namespace Vehicles.Domain.Interfaces
{
    public interface IMotorcycle
    {
        void DoAWheelie();

        void UndoAWheelie();

        MotorcyclePosition MotorcyclePosition { get; }

    }
}
