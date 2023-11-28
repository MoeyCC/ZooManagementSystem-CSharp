using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoo.BusinessLogic.Models;
using Zoo.BusinessLogic.Models.Animals;

namespace Zoo.BusinessLogic.Services
{
  public class Scheduler : IScheduler
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

    public void AssignGroomingJobs(IEnumerable<IKeeper> keepers, IEnumerable<IAnimal> animals)
    {
      foreach (var keeper in keepers)
      {
        keeper.GetResponsibleAnimals<ICanBeGroomed>().AsParallel().ForAll(keeper.GroomAnimal);
      }
    }

    public void AssignFeedingJobs(IEnumerable<IKeeper> keepers, IEnumerable<IAnimal> animals)
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
      });
    }
  }
}