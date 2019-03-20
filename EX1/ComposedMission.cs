using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class ComposedMission : IMission
    {
        //Property of Name
        public string Name { get; set; }

        //Property of Type
        public string Type { get; set; }

        //private member to see if we already activated value
        private bool activated = false;

        //private member that check wahtis the last value we claculated
        private double lastOutput;

        //list of function that are getting double and returning double
        public List<FunctionsContainer.Func> lFunc = new List<FunctionsContainer.Func>();

        //constructor
        public ComposedMission(string mission)
        {
            Name = mission;
            Type = "Composed";
        }

        //event of EventHandlers
        public event EventHandler<double> OnCalculate;

        //calculate the value by the list of function in lFunc and invoke OnCalculate
        public double Calculate(double value)
        {
            for (int i = 0; i < lFunc.Count; i++)
            {
                if (activated)
                {
                    lastOutput = lFunc[i](lastOutput);

                }
                else
                {
                    lastOutput = lFunc[i](value);
                    activated = true;
                }
            }
            OnCalculate?.Invoke(this, lastOutput);
            activated = false;
            return lastOutput;
        }

        //add function to lFunc
        public ComposedMission Add(FunctionsContainer.Func func)
        {
            lFunc.Add(func);
            return this;
        }

    }
}
