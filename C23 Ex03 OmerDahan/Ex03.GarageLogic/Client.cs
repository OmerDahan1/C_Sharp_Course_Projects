using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Client
    {

        private readonly string r_OwnerName;
        private readonly string r_OwnerPhoneNumber;
        private readonly Vehicle r_ClientVehicle;
        private readonly string r_LicenseNumber;
        private eStatus m_CurrentStatus;

        public enum eStatus
        {
            InRepair = 1,
            RepairedAndUnpaid = 2,
            RepairedAndPaid = 3,
        }

        public Client(string i_OwnerName, string i_OwnerPhoneNumber, Vehicle i_ClientVehicle)
        {
            this.r_OwnerName = i_OwnerName;
            this.r_OwnerPhoneNumber = i_OwnerPhoneNumber;
            this.r_ClientVehicle = i_ClientVehicle;
            this.m_CurrentStatus = eStatus.InRepair;
            this.r_LicenseNumber = i_ClientVehicle.LicenseNumber;
        }

        public Vehicle Vehicle
        {
            get
            {
                return this.r_ClientVehicle;
            }
        }

        public eStatus CurrentVehicleStatus
        {
            get
            {
                return this.m_CurrentStatus;
            }

            set
            {
                this.m_CurrentStatus = value;
            }
        }

        public override string ToString()
        {
            string ownerInfoAndStatus = string.Format(
@"{0}Owner's name: {1}
Vehical status: {2}
",
this.r_ClientVehicle.GetVehicleProperties(),
this.r_OwnerName,
this.m_CurrentStatus);

            return ownerInfoAndStatus;
        }
    }
}
