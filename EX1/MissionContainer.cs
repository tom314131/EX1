using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1
{
    public class FunctionsContainer
    {
        //delegate of all the function that get double and return double
        public delegate double Func(double var);

        //Dictionary between string and function that get double and returns double
        private Dictionary<string, Func> funcList = new Dictionary<string, Func>();

        //Property of Func
        public Func this[string key]
        {
            get
            {
                if (funcList.ContainsKey(key))
                {
                    return funcList[key];
                }
                else
                {
                    funcList.Add(key, IdentityFunction);
                    return funcList[key];
                }
            }
            set
            {
                if (funcList.ContainsKey(key))
                {
                    funcList[key] = value;
                }
                else
                {
                    funcList.Add(key, value);
                }
            }
        }

        //returns list of names of all the missions
        public List<string> getAllMissions()
        {
            List<string> missionsNames = new List<string>();
            foreach (KeyValuePair<string, Func> funcName in funcList)
            {
                missionsNames.Add(funcName.Key);
            }
            return missionsNames;
        }

        //Function for all the funtion that are not in the list
        private double IdentityFunction(double var)
        {
            return var;
        }
    }
}
