using System.Collections.Generic;

namespace CouplingManagement.Model
{
  public class RailRoad
  {
    public Stack<Car> Cars { get; set; }

    public int MaximumCars { get; private set; }

    public RailRoad()
    {
      MaximumCars = 10;
    }

  }
}
