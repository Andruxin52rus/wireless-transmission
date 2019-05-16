using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        /// 

        public static GUI main_GUI; // create GUI instance field so we can access it from DrawingHandler class

        public static SerialPort serial_port;

        [STAThread]
        static void Main()
        {
            foreach (string port in SerialPort.GetPortNames())
            {
                serial_port = new SerialPort(port, 115200);
                if (detectArduino())
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    main_GUI = new GUI();
                    Application.Run(main_GUI);
                }
            }            
        }

        private static bool detectArduino()
        {
            try
            {
                serial_port.ReadTimeout = 1000; // if no answer in a second, we think there`s no Arduino transmitter
                serial_port.WriteBufferSize = 64;
                serial_port.ReadBufferSize = 64;
                serial_port.Open();
                serial_port.Write("Who is ready?\0");
                System.Threading.Thread.Sleep(1000);
                if (serial_port.ReadLine().Contains("I am ready")) return true;
                else return false;
            }
            catch
            {
                Console.WriteLine("Can`t open this Serial Port");
                serial_port.Close();
                return false;                
            }
            
        }
    }
}
