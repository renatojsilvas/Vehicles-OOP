using Vehicles.Domain.Model;

namespace Vehicles.Domain.Interfaces
{
    public interface ITractor
    {
        void MoveShovelUp();
        void MoveShovelDown();
        ShovelPosition ShovelPosition { get; }
    }
}
