using CouplingManagement.Test;

namespace CouplingManagement.Model
{
  public class BuildTrainFactory
  {    
    //ToDo Could use Fixed Commands
    public IBuildTrain GetBuildTrain(string command)
    {
      switch (command)
      {
        case "Build Train":
          return new Trains();
        case "Run Building Test Train":
          return new TestTrain();
      }
      return null;
    }
  }
}
