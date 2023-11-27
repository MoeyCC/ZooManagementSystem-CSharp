using System;

namespace Zoo.BusinessLogic.Models.Animals
{
  public class Zebra : Animal, ICanHaveMuckSweptOut, ICanBeGroomed, ILargeAnimal
  {
    private DateTime lastGroomed;

    private DateTime lastMuckSweptOut;

    public Zebra(DateTime dateOfBirth) : base(dateOfBirth)
    {
    }

    public void Groom()
    {
      lastGroomed = DateTime.Now;
    }

    public void MuckSweepOut()
    {
      lastMuckSweptOut = DateTime.Now;
    }

    public override string ToString()
    {
      return base.ToString() + $"; Last Groomed {lastGroomed}, Last Muck swept out {lastMuckSweptOut}";
    }
  }
}