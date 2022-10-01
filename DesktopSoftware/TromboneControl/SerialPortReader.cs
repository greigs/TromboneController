using System.IO.Ports;
using System.Linq;
using System.Threading;

namespace TromboneControl
{
    public class SerialPortReader
    {
        private static SerialPort _serialPort = null;

        public void ConfigureAndOpenPort(string preferredPortName = "")
        {
            try
            {
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    UserState.ComPortOpened = false;
                    _serialPort.Close();
                    _serialPort.Dispose();
                }

                // Check if the preferred port exists
                if (!string.IsNullOrWhiteSpace(preferredPortName) 
                    && SerialPort.GetPortNames().Any(x => x.Equals(preferredPortName)))
                {
                    _serialPort = new SerialPort(preferredPortName);
                }
                else
                {
                    // Default to the last found port if no matching ones are found
                    // This is most likely to be the controller (last connected)
                    _serialPort = new SerialPort(SerialPort.GetPortNames().Last());
                }

                _serialPort.BaudRate = 115200;
                _serialPort.ReadTimeout = 1000;
                _serialPort.Open();
                UserState.ComPortOpened = true;
                UserState.ComPortName = _serialPort.PortName;
            }
            catch
            {
                UserState.ComPortOpened = false;
            }
        }
        public string ReadLine() => _serialPort.ReadLine();

        public void CloseAndDispose()
        {
            Thread.Sleep(1000);
            _serialPort.Close();
            _serialPort.Dispose();
            UserState.ComPortOpened = false;
        }
    }
}
