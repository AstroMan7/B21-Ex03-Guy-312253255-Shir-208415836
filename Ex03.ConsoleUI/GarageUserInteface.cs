using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ex03.GarageLogic;


namespace Ex03.ConsoleUI
{
	public class GarageUserInteface
	{
		private readonly Menu r_StartMenu = new Menu();
		private readonly Menu r_VehicleMenu = new Menu();
		private readonly Ex03.GarageLogic.GarageManager r_GarageMng = new GarageLogic.GarageManager();
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
			while (true)
			{
				r_StartMenu.ShowMenu();
				userChoice = GetInputChoiceFromTheUser();
				switch (userChoice)
				{
					case (int)eUserChoice.AddNewVehcile:
						{
							AddNewVehicleToGarage();
							break;
						}
					case (int)eUserChoice.ShowVehcilesList:
						{
							//ShowAllVehiclesList();
							break;
						}
					case (int)eUserChoice.ChangeVehicleStatus:
						{
							//ChangeVehicleStatus();
							break;
						}
					case (int)eUserChoice.AddAirPresuer:
						{
							//AddAirPressure();
							break;
						}
					case (int)eUserChoice.AddFuel:
						{
							break;
						}
					case (int)eUserChoice.ChargeBattery:
						{
							break;
						}
					case (int)eUserChoice.ShowVehicleData:
						{
							break;
						}
					case (int)eUserChoice.Exit:
						{
							Console.WriteLine("Thank you for visiting ^^^Guy's &* Shir's Garage^^^ , see you soon!");
							Console.ReadKey();
							Environment.Exit(1);
							break;
						}
					default:
						{
							Console.WriteLine("Please select a valid option.");
							break;
						}
				}
			}
		}

		public int GetInputChoiceFromTheUser()
		{
			int userChoice;
			bool check;

			check = int.TryParse(Console.ReadLine(), out userChoice);

			return userChoice;
		}

		private void AddNewVehicleToGarage()
		{
			Console.Clear();
			string licesneNumber = EnterLicenseNumber();
			
			GarageLogic.Enums.eVehicleType vehicleChoice;

			try
			{

				Console.Clear();
				r_VehicleMenu.ShowMenu();
				vehicleChoice = (GarageLogic.Enums.eVehicleType)GetInputChoiceFromTheUser();
				r_GarageMng.AddNewVehicle(licesneNumber, vehicleChoice);
				Console.Clear();
				List<string> questions = r_GarageMng.GetQustionsList(licesneNumber);
				List<string> userOutputAnswers = new List<string>();

				for (int i = 0; i < questions.Count; i++)
				{
					Console.WriteLine(string.Format("{0}", questions[i]));
					userOutputAnswers.Add(Console.ReadLine());
				}

				r_GarageMng.SetVehicleData(licesneNumber, userOutputAnswers);
				Console.WriteLine("Vehicle added...");
			}
			// TODO - CHAECK ALL CATCH
			catch (FormatException ex)
			{
				Console.WriteLine(ex.Message);
				r_GarageMng.VehiclesList.Remove(licesneNumber);
			}
			catch (ArgumentException)
			{
				Console.WriteLine("you've entered a wrong value, please try again:");
				r_GarageMng.VehiclesList.Remove(licesneNumber);
			}
			catch (ValueOutOfRangeException ex)
			{
				Console.WriteLine(ex.Message);
				r_GarageMng.VehiclesList.Remove(licesneNumber);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}

		//Gets list of all vehicles in garage by situation. invoke garage manager and throws execpation if needed

		public void ShowListOfAllTheVehicles()
		{
			Console.Clear();
			try
			{
				string userAnswer;
				int index = 1;
				GarageLogic.Enums.eVehicleStatus status;

				Console.WriteLine(
					@"choose one of the status: InRepair, Repaired or Paid , to show a list of all the vehicle on this status:");
				userAnswer = Console.ReadLine();
				status = (GarageLogic.Enums.eVehicleStatus)Enum.Parse(typeof(GarageLogic.Enums.eVehicleStatus),
					userAnswer);
				List<string> vehiclesByType = r_GarageMng.GetVehiclesListByType(status);
				foreach (string vehicleLicenseNumber in vehiclesByType)
				{
					Console.WriteLine(string.Format("{0}. {1} -  {2}", index.ToString(), vehicleLicenseNumber, status));
					index++;
				}

			}
			catch (ArgumentException)
			{
				Console.WriteLine("you choose the wrong status, please try again");
				ShowListOfAllTheVehicles();
			}
			catch (FormatException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

		}


		private string EnterLicenseNumber()
		{
			string o_licenseNumber; //not sure about naming convention here

			Console.WriteLine("please enter license number");
			o_licenseNumber = Console.ReadLine();

			return o_licenseNumber;
		}

	}

}
