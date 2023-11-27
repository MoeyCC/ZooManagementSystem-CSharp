using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.BusinessLogic.Models.Animals
{
  public class Lion : Animal, ICanHaveMuckSweptOut, ILargeAnimal
  {
    private DateTime lastMuckSweptOut;
    public Lion(DateTime dateOfBirth) : base(dateOfBirth)
    {
    }
  
    public void MuckSweepOut()
    {
      lastMuckSweptOut = DateTime.Now;
    }
    
    public override string ToString()
    {
      return base.ToString() + $"; Last Muck swept out {lastMuckSweptOut}";
    }
  }
}
