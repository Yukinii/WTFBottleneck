using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;
using WTFHardwareInterface.Core.Hardware;

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
    public static class CPU
    {
        private static IEnumerable<float?> GetValues(SensorType type)
        {
            return from sensor in HardwareInterface.CPUSensors where sensor.SensorType == type select sensor.Value;
        }

        public static async Task<int> GetTempAsync()
        {
            return await Task.Run(() => (from value in GetValues(SensorType.Temperature) where value != null select (int)value.Value).FirstOrDefault());
        }

        public static async Task<int> GetLoadAsync()
        {
            return await Task.Run(() => (from value in GetValues(SensorType.Load) where value != null select (int)value.Value).FirstOrDefault());
        }
    }
}