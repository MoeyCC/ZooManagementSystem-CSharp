namespace Zoo.BusinessLogic.Models.Animals
{
  public interface IScheduler
  {
    void AssignGroomingJobs(IEnumerable<IKeeper> keepers, IEnumerable<IAnimal> animals);

    void AssignFeedingJobs(IEnumerable<IKeeper> keepers, IEnumerable<IAnimal> animals);
  }
}