using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using System.Threading.Tasks;
using Zoo.BusinessLogic.Models;
using Zoo.BusinessLogic.Models.Animals;

namespace Zoo.BusinessLogic.Services
{
  public class Scheduler
  {
    private static Scheduler instance;

    public static Scheduler Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new Scheduler();
        }

        return instance;
      }
    }

    private Scheduler()
    {
    }

    public void AssignJobs(IEnumerable<IKeeper> keepers, IEnumerable<IAnimal> animals)
    {
      Parallel.ForEach(keepers, keeper =>
      {
        foreach (var animal in keeper.GetResponsibleAnimals<Animal>())
        {
          if (animal.IsHungry())
          {
            keeper.FeedAnimal(animal);
          }
        }

        foreach (var groomableAnimal in keeper.GetResponsibleAnimals<ICanBeGroomed>())
        {
            keeper.GroomAnimal(groomableAnimal);
        }
      });
    }
  }
}