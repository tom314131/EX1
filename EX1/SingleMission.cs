using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    class SingleMission : IMission
    {
        //Property of Name
        public string Name { get; set; }

        //Property of Type
        public string Type { get; set; }

        //Property of Func (funtion that get double and return double)
        public FunctionsContainer.Func m_func { get; set; }

        //Constructor
        public SingleMission(FunctionsContainer.Func func, string name)
        {
            Name = name;
            Type = "Single";
            m_func = func;
        }

        //event of EventHandlers
        public event EventHandler<double> OnCalculate;

        //calculate the value and invoke OnCalculate
        public double Calculate(double value)
        {
            double val = m_func(value);
            OnCalculate?.Invoke(this, val);
            return val;
        }
    }
}
