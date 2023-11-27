using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoo.BusinessLogic.Models;
using Zoo.BusinessLogic.Models.Animals;

namespace Zoo.BusinessLogic.Services
{
  public class MuckSweepOutScheduler
  {
    private static MuckSweepOutScheduler instance;

    public static MuckSweepOutScheduler Instance
    {
      get
      {
        if (instance == null)
        {
          instance = new MuckSweepOutScheduler();
        }

        return instance;
      }
    }

    private MuckSweepOutScheduler()
    {
    }

    public void AssignGroomingJobs(IEnumerable<IKeeper> keepers, IEnumerable<IAnimal> animals)
    {
      foreach (var keeper in keepers)
      {
        keeper.GetResponsibleAnimals<ICanHaveMuckSweptOut>().AsParallel().ForAll(keeper.MuckSweepOutAnimal);
      }
    }
  }
}