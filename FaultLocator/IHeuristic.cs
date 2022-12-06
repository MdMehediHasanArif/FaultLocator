using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaultLocator
{
    public interface IHeuristic
    {
        double CalculateHeuristic1(Input input);
        double CalculateHeuristic2(Input input);
        double CalculateHeuristic3(Input input);
    }
}
