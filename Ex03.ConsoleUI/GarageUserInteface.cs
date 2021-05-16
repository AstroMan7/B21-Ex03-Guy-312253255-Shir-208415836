using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
	public class GarageUserInteface
	{
		private readonly Menu r_StartMenu = new Menu();
		private readonly Menu r_VehicleMenu = new Menu();

		public enum eUserChoice
		{
			AddNewVehcile = 1,
			ShowVehcilesList,
			ChangeVehicleStatus,
			AddAirPresuer,
			AddFuel,
			ChargeBattery,
			ShowVehicleData,
			Exit,
		}

		public void RunProgram()
		{
			int userChoice = 0;

			Console.WriteLine(
@"Hey and welcome to ^^^Hassin & Savion Garage^^^
Please select one of the option below to get things moving:" + Environment.NewLine);
			r_StartMenu.SetStartMenu();
			r_VehicleMenu.SetVehicleMenu();
		}
	}
}
