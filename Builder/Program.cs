using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            IVehicleBuilder lightTank = new LightTankBuilder();

            VehicleEngineer vehicleEngineer = new VehicleEngineer(lightTank);

            vehicleEngineer.MakeVehicle();

            Vehicle firstVehicle = vehicleEngineer.GetVehicle();

            Console.WriteLine(firstVehicle.GetEngine() + " /!/ " + firstVehicle.GetWeapon() + " /!/ " + firstVehicle.GetWheels() + " /!/ ");
        }

    }

    public interface IVehiclePlan
    {
        void AddEngine(string engine);
        void AddWeapon(string weapon);
        void AddWheels(string wheels);
    }

    public class Vehicle : IVehiclePlan
    {

        private string wheels;
        private string engine;
        private string weapon;

        public void AddWheels(string wheels)
        {
            this.wheels = wheels;
        }

        public void AddEngine(string engine)
        {
            this.engine = engine;
        }

        public void AddWeapon(string weapon)
        {
            this.weapon = weapon;
        }

        public string GetEngine() { return engine; }
        public string GetWheels() { return wheels; }
        public string GetWeapon() { return weapon; }
    }

    public interface IVehicleBuilder
    {
        void BuildWheels();
        void BuildEngine();
        void BuildWeapon();
        Vehicle GetVehicle();
    }

    public class LightTankBuilder : IVehicleBuilder
    {
        private Vehicle vehicle = new Vehicle();

        public void BuildEngine()
        {
            vehicle.AddEngine("2.0L");
        }

        public void BuildWeapon()
        {
            vehicle.AddWeapon("Cannon");
        }

        public void BuildWheels()
        {
            vehicle.AddWheels("4");
        }

        public Vehicle GetVehicle()
        {
            return vehicle;
        }
    }

    public class VehicleEngineer
    {
        private IVehicleBuilder vehicleBuilder;

        public VehicleEngineer(IVehicleBuilder vehicle)
        {
            vehicleBuilder = vehicle;
        }

        public Vehicle GetVehicle()
        {
            return vehicleBuilder.GetVehicle();
        }

        public void MakeVehicle()
        {
            vehicleBuilder.BuildEngine();
            vehicleBuilder.BuildWeapon();
            vehicleBuilder.BuildWheels();
        }
    }
}
