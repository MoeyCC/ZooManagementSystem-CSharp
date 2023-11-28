namespace Zoo.BusinessLogic.Models.Animals
{
  public interface IScheduler
  {
    void AssignJobs(IEnumerable<IKeeper> keepers, IEnumerable<IAnimal> animals);
  }
}