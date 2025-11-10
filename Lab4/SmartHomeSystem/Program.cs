using System;
using System.Collections.Generic;

namespace SmartHomeSystem
{
    public class Program
    {
        public static void Main()
        {
            SmartHomeController controller = new SmartHomeController();

            Light light = new Light { Name = "Лампа у вітальні" };
            AirConditioner air = new AirConditioner { Name = "Кондиціонер у спальні" };
            CoffeeMachine coffee = new CoffeeMachine { Name = "Кавомашина на кухні" };
            MotionSensor sensor = new MotionSensor { Name = "Датчик руху у коридорі" };

            controller.AddDevice(light);
            controller.AddDevice(air);
            controller.AddDevice(coffee);
            controller.AddDevice(sensor);

            controller.AddEnergyDevice(light);
            controller.AddEnergyDevice(air);
            controller.AddEnergyDevice(coffee);

            controller.TurnAllOn();

            light.PrintStatus();
            air.PrintStatus();
            coffee.PrintStatus();
            sensor.PrintStatus();

            controller.ShowEnergyReport(5);
            controller.TurnAllOff();
        }
    }
}