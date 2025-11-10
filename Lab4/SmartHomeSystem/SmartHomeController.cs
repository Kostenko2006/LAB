using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystem
{
    public class SmartHomeController
    {
        private readonly List<ISwitchable> devices = new();
        private readonly List<IEnergyConsumer> energyDevices = new();

        public void AddDevice(ISwitchable device) => devices.Add(device);
        public void AddEnergyDevice(IEnergyConsumer device) => energyDevices.Add(device);

        public void TurnAllOn() => devices.ForEach(d => d.TurnOn());
        public void TurnAllOff() => devices.ForEach(d => d.TurnOff());

        public void ShowEnergyReport(int hours)
        {
            Console.WriteLine($"\nЗвіт про споживання енергії за {hours} год:");

            double total = 0;
            foreach (var d in energyDevices)
            {
                double usage = d.GetEnergyUsage(hours);
                Console.WriteLine($"{d.DeviceName}: {usage} кВт·год (потужність: {d.PowerConsumption} Вт)");
                total += usage;
            }

            Console.WriteLine($"Загальне споживання: {total} кВт·год");
            Console.WriteLine($"Вартість (~4 грн/кВт·год): {total * 4} грн\n");
        }
    }
}
