using Vehicles.Domain.Model;

namespace Vehicles.Domain.Interfaces
{
    public interface IVehicle
    {
        Weight Weight { get; }
        Engine Engine { get; }
        Speed TopSpeed { get; }
        Acceleration Acceleration { get; }
        Noise Noise { get; }
        void Accelerate(AccelerationLevel level);
        void Stop();
        Speed CurrentSpeed { get; }
    }
}
