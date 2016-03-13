using System.Collections.Generic;
using System.Linq;
using CouplingManagement.Model;

namespace CouplingManagement.Test
{
  public class TestTrain: IBuildTrain
  {
    /// <summary>
    /// IbuildTrain Implementation of Build Method used for Building Train
    /// </summary>
    public void Build()
    {
      var testRailRoads = GetTestRailRoads();
      var selectedCar = Getcar();
      StartBuilding(testRailRoads, selectedCar);
    }
    /// <summary>
    /// This Funciton Build Train of type car from list of railRoads
    /// </summary>
    /// <param name="railRoads"></param>
    /// <param name="car"></param>
    private void StartBuilding(List<RailRoad> railRoads, Car car)
    {
      for (var i = 0; i < railRoads.Count; i++)
      {
        var index= 1;
        var listCars= railRoads[i].Cars.Select(cars => new KeyValuePair<string, int>(cars.Name, index++)).ToList();

        var selectedRail = railRoads[i].Cars.Take(3).FirstOrDefault(item=>item.Name==car.Name);
        var element = listCars.Take(3).FirstOrDefault(item => item.Key == car.Name);

        if (selectedRail != null && element.Key!=null)
        {
          for (int j = 1; j < element.Value; j++)
          {
            var removed = railRoads[i].Cars.Pop();
            var from = i + 1;
            var to = i + 2;
            YardManagement.WriteToConsole("Move car" + removed.Name + " From" + from + " to" + to);
            var top = railRoads[j + 1].Cars.Peek();
            if (top.Position > 1)
            {
              removed.Position = top.Position - 1;
              if (i+1<railRoads.Count)
              {
                railRoads[i + 1].Cars.Push(removed);
              }
              
            }
             
          }
        }
      }
    }
    /// <summary>
    /// This funciton Get the car Object
    /// </summary>
    /// <returns></returns>
    private Car Getcar()
    {
      return new Car {Name = "G"};
    }
    /// <summary>
    /// This Funciton Build RailRoads
    /// </summary>
    /// <returns></returns>
    private List<RailRoad> GetTestRailRoads()
    {
      var testTrain = new List<string>
      {
        "00DGCDGEFA",
        "0ACCACCGDE",
        "CDGADGADEE",
        "DGDGADGCAA",
        "0AADGADCGD",
        "ACGDCGDEGD"
      };
      
      var railRoads= new List<RailRoad>();
      foreach (var train in testTrain)
      {
        int index = 10;
        var railRoad = new RailRoad();
        var cars = new Stack<Car>();
        foreach (char letter in train.Reverse())
        {
          if (letter != '0')
          {
            var car = new Car
            {
              Name = letter.ToString(),
            };
            car.Position = index--;
            cars.Push(car);            
          }
        }
        railRoad.Cars = cars;
        railRoads.Add(railRoad);
      }
      return railRoads;
    }
  }
}
