using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public abstract class Vehicle
	{
		// Consts
		public const int k_ModelQLocation = 0;
		public const int k_OwnerNameQLocation = 1;
		public const int k_OwnerPhoneQLocation = 2;
		public const int k_EnergyLeftQLocation = 3;
		public const int k_WheelManufacturerQLocation = 4;
		public const int k_WheelAirPressureQLocation = 5;

		// Data members
		protected string m_LicenseNumber;
		protected string m_Model;
		protected string m_OwnerOfVehicle;
		protected string m_OwnerPhoneNumber;
		protected Ex03.GarageLogic.Enums.eVehicleStatus m_VehicleStatus = Ex03.GarageLogic.Enums.eVehicleStatus.InRepair; //automaticly puts first val?
		protected Engine m_MyEngine;
		protected float m_EnergyLeft;

		// C'tor
		protected Vehicle(string i_LicenseNumber, Engine i_Engine)
		{
			m_MyEngine = i_Engine;
			m_LicenseNumber = i_LicenseNumber;
		}
		// Get method for m_MyEngine
		public Engine MyEngine
		{
			get
			{
				return m_MyEngine;
			}
		}

		// Get/Set method for m_VehicleStatus
		public Enums.eVehicleStatus VehicleStatus
		{
			get
			{
				return m_VehicleStatus;
			}

			set
			{
				m_VehicleStatus = value;
			}

		}
		public virtual void SetVehicle(List<string> i_DataList)
		{
			m_Model = i_DataList[k_ModelQLocation];
			m_OwnerOfVehicle = i_DataList[k_OwnerNameQLocation];
			m_OwnerPhoneNumber = i_DataList[k_OwnerPhoneQLocation];
			m_EnergyLeft = float.Parse(i_DataList[k_EnergyLeftQLocation]);
		}
		//  Add new question for basic vehicle, virtual method overrided in each one of the inherited classes
		public virtual List<string> SetQuestions() //why cant turn private?
		{
			List<string> o_Questions = new List<string>();

			o_Questions.Add("Please type the model of the car");
			o_Questions.Add("Owners Name:");
			o_Questions.Add("Owners Phone:");
			o_Questions.Add("How much Fuel / Electricity left:");
			o_Questions.Add("Who is your wheel manufacturer?");
			o_Questions.Add("What is your current wheel pressure?");

			return o_Questions;
		}

	}
}