using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, Vehicle> m_VehiclesList = new Dictionary<string, Vehicle>();

        public Dictionary<string, Vehicle> VehiclesList
        {
            get
            {
                return m_VehiclesList;
            }
        }


        // Returns a list of question about the vehicle, if vehicle not found throws exception
        public List<string> GetQustionsList(string LicseneNumber)
        {
            IsGarageEmpty();
            Vehicle vehicle = m_VehiclesList[LicseneNumber];

            if (vehicle == null)
            {
                {
                    throw new Exception("We don't have this vehicle in our garage, sorry.");
                }
            }
            else
            {
                return m_VehiclesList[LicseneNumber].SetQuestions();
            }

        }



        public void IsGarageEmpty()
        {
            if(m_VehiclesList.Count == 0)
            {
                throw new Exception("There are no vehicles in the garage at the moment.");
            }
        }


        // Set all vehicle data ,TODO throw exception if vehicle not found 
        public void SetVehicleData(string LicseneNumber, List<string> i_DataList)
        {
            //IsGarageEmpty(); //for exception?
            Vehicle vehicle = m_VehiclesList[LicseneNumber];

            vehicle.SetVehicle(i_DataList);
        }

        public void AddNewVehicle(string i_LicenseNumber, Enums.eVehicleType i_VehicleKind)
        {

            Vehicle NewVehicle;

            if (m_VehiclesList.ContainsKey(i_LicenseNumber))
            {
                m_VehiclesList[i_LicenseNumber].VehicleStatus = Enums.eVehicleStatus.InRepair;

                throw new Exception("Vehicle all ready exist, status changed to in repair");
            }
            else
            {
                NewVehicle = VehicleCreator.CreateNewVehicle(i_LicenseNumber, i_VehicleKind);
                m_VehiclesList.Add(i_LicenseNumber, NewVehicle);
            }

        }

        
        // Return list of vehicle by there status
        public List<string> GetVehiclesListByType(Enums.eVehicleStatus i_VehicleStatus)
        {
            IsGarageEmpty();
            List<string> o_ListOfLicenseNumber = new List<string>();

            foreach (KeyValuePair<string, Vehicle> item in m_VehiclesList)
            {
                if (item.Value.VehicleStatus == i_VehicleStatus)
                {
                    o_ListOfLicenseNumber.Add(item.Key);
                }

            }

            if (o_ListOfLicenseNumber.Count == 0)
            {
                throw new Exception("There are no vehicle with this status in the garage");
            }

            return o_ListOfLicenseNumber;
        }

        // Change vehicle status by license, throws exception if the vehicle not found
        public void ChangeVehicleStatus(string i_LicenseNumber, Enums.eVehicleStatus i_VehicleSatus)
        {
            if ((m_VehiclesList.ContainsKey(i_LicenseNumber)) == true)
            {
                (m_VehiclesList[i_LicenseNumber].VehicleStatus) = i_VehicleSatus;
            }
            else
            {
                throw new Exception("We don't have this vehicle in our garage, sorry.");
            }
        }


    }
}
