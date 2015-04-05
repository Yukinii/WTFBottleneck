using System.Collections.Generic;
using System.Threading.Tasks;
using System.Timers;
using OpenHardwareMonitor.Hardware;

/*
    This file is part of WTFBottleneck.

    WTFBottleneck is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    WTFBottleneck is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with WTFBottleneck.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace WTFHardwareInterface.Core.Hardware
{
    public static class HardwareInterface
    {
        private static Computer _computer;
        public static readonly List<ISensor> CPUSensors = new List<ISensor>();
        public static readonly List<ISensor> GPUSensors = new List<ISensor>();
        public static readonly List<ISensor> RAMSensors = new List<ISensor>();
        public static readonly List<ISensor> OtherSensors = new List<ISensor>();
        public static readonly Timer PollingTimer = new Timer(2000);

        public static async Task Initialize()
        {
            if (!PollingTimer.Enabled)
            {
                PollingTimer.Elapsed += PollingTimer_Elapsed;
                PollingTimer.Start();
            }
            await Task.Run(() =>
            {
                _computer = new Computer { RAMEnabled = true, GPUEnabled = true, CPUEnabled = true, HDDEnabled = true, MainboardEnabled = true };
                _computer.Open();
                GetSensors();
            });
        }

        private static void PollingTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            foreach (var hardware in _computer.Hardware)
            {
                hardware.Update();
            }
        }

        public static void GetSensors()
        {
            foreach (var hardware in _computer.Hardware)
            {
                hardware.Update();
                var sensors = hardware.Sensors;
                switch (hardware.HardwareType)
                {
                    case HardwareType.CPU:
                        CPUSensors.AddRange(sensors);
                        break;
                    case HardwareType.GpuAti:
                    case HardwareType.GpuNvidia:
                        GPUSensors.AddRange(sensors);
                        break;
                    case HardwareType.RAM:
                        RAMSensors.AddRange(sensors);
                        break;
                    default:
                        OtherSensors.AddRange(sensors);
                        break;
                }
            }
        }
    }
}