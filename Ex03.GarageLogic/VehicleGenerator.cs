namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        // Create new Vehicle object depends in the Vehicle type, return new vehicle
        //Polimorphism?
        public static Vehicle CreateNewVehicle(string i_LicenseNumber, Enums.eVehicleType i_VehicleKind)
        {
            Vehicle o_NewVehicle=null; //remove null later

            switch (i_VehicleKind)
            {
                case Enums.eVehicleType.FuelCar:
                    {
                        // = new Car(i_LicenseNumber, new FuelEngine());
                        break;
                    }
                case Enums.eVehicleType.ElectricCar:
                    {
                        //o_NewVehicle = new Car(i_LicenseNumber, new ElectricEngine());
                        break;
                    }
                case Enums.eVehicleType.FuelMotorcycle:
                    {
                        //o_NewVehicle = new Motorcycle(i_LicenseNumber, new FuelEngine());
                        break;
                    }
                case Enums.eVehicleType.ElectricMotorcycle:
                    {
                        // o_NewVehicle = new Motorcycle(i_LicenseNumber, new ElectricEngine());
                        break;
                    }
                case Enums.eVehicleType.Truck:
                    {
                        // o_NewVehicle = new Truck(i_LicenseNumber, new FuelEngine());
                        break;
                    }
                default:
                    {
                        o_NewVehicle = null;
                        break;
                    }

            }

            return o_NewVehicle;
        }
    }
}


