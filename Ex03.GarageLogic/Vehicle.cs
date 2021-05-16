using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
	public abstract class Vehicle
	{
		public enum eVehicleStatus
		{
			InRepair = 1,
			Repaired,
		    Paid,
		}

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
		protected eVehicleStatus m_VehicleStatus = eVehicleStatus.InRepair; //automaticly puts first val?
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
		public eVehicleStatus VehicleStatus
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
	}
}