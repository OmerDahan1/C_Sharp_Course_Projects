using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        private readonly float r_MaxEnergy;
        private float m_CurrentEnergy;

        public Engine(string i_MaxEnergy, string i_CurrentEnergy)
        {
            this.r_MaxEnergy = float.Parse(i_MaxEnergy);
            this.m_CurrentEnergy = float.Parse(i_CurrentEnergy);
        }

        public float MaxEnergy
        {
            get
            {
                return this.r_MaxEnergy;
            }
        }

        public float CurrentEnergy
        {
            get
            {
                return this.m_CurrentEnergy;
            }
        }

        internal void AddEnergy(float i_EnergyToAdd, string i_TypeOfEnergy)
        {
            float newEnergy = this.m_CurrentEnergy + i_EnergyToAdd;

            if (newEnergy <= this.r_MaxEnergy)
            {
                this.m_CurrentEnergy = newEnergy;
            }
            else
            {
                throw new ValueOutOfRangeException(0, this.r_MaxEnergy - this.m_CurrentEnergy, i_TypeOfEnergy);
            }
        }

        public abstract override string ToString();
    }
}
