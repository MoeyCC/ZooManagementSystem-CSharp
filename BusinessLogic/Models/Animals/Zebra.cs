using System;

namespace Zoo.BusinessLogic.Models.Animals
{
  public class Zebra : AnimalThatCanBeGroomed, ILargeAnimal
  {
    public Zebra(DateTime dateOfBirth) : base(dateOfBirth)
    {
    }
  }
}