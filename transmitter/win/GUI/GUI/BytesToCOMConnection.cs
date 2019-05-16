/*
 * COMConnection is a class with one interface method (sendData) for sending List of bytes to COM port
 * Date of creation: 28.10.2016
*/

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public static class BytesToCOMConnection
    {
        //static SerialPort serial_port = new SerialPort("COM4", 115200);
        static SerialPort true_serial_port = new SerialPort();
        static byte[] CONTROL_COMMANDS = { 0x01, 0x02, 0x03 };
        static string[] kinds_of_data =  { "text", "drawing", "erase_drawing" };
        // 0x01 is text, 0x02 is drawing etc
        

        

        public static void sendData(string text)
        {
            byte[] text_in_bytes = Encoding.UTF8.GetBytes(text.ToUpper().ToCharArray()); // may contain non-ASCII-7 symbols
            List<byte> text_in_byte_list = new List<byte>(0);
            foreach (byte b in text_in_bytes)
            {
                if (b <= 127)
                {
                    text_in_byte_list.Add(b); // if character is in ASCII-7
                }
            }
            if (text_in_byte_list.Count != 0) sendData(text_in_byte_list, "text");
            DrawingHandler.last_command_was_drawing = false;
        }

        public static void sendData(List<byte> data, string kind_of_data)
        {
            // sending data consists of calling incapsulation and calling sendDataToCOM with incapsulated data
            List<byte> encapsulated_data = encapsulate(data, kind_of_data);
            if (encapsulated_data != null) // if there`re bytes
            {
                ushort data_length = Convert.ToUInt16(encapsulated_data.Count);
                byte[] byte_data = encapsulated_data.ToArray();
                sendDataToCOM(byte_data, data_length);

                foreach (byte b in encapsulated_data)
                {
                    Console.Write(b);
                    Console.Write(", ");
                }

            }
        }

        private static List<byte> encapsulate(List<byte> data, string kind_of_data)
        {
            // packet format: CONTROL_COMMAND (1) + DATA_LENGTH (2) + USER_DATA
            data = addDataLength(data); // add length of user`s data in bytes first of all
            data = addControlCommand(data, kind_of_data); // add control command (kind of user`s data)
            return data;            
        }

        private static List<byte> addDataLength(List<byte> data)
        {
            List<byte> length_in_bytes = convertToBytes(Convert.ToUInt16(data.Count));
            // length_in_bytes is a number of bytes in List<byte> data
            // converToBytes works only with UInt16 (ushort) which equivalents to 2 bytes. It depends on packet format            
            data.InsertRange(0, length_in_bytes); // insert 2 bytes in data at index 0           
            return data;
        }

        private static List<byte> addControlCommand(List<byte> data, string kind_of_data)
        {
            int kind_number = 0; //position of kind_of_data in kinds_of_data array
            foreach (string kind in kinds_of_data)
            {
                if (kind_of_data.ToLower() == kind) // so string kind_of_data is correct
                {                    
                    data.Insert(0, CONTROL_COMMANDS[kind_number]); // first byte is to CONTROL_COMMAND
                    return data;
                }
                kind_number++;
            }
            return null; // if string kind_of_data is not correct
        }
                
        public static List<byte> convertToBytes(ushort number)
        {
            List<bool> bits = new List<bool>();
            while (number / 2 != 0)
            {
                bits.Insert(0, Convert.ToBoolean((number % 2)));
                number /= 2;
            }
            bits.Insert(0, Convert.ToBoolean(number));
            // at this point we get binary representation of number
            while (bits.Count != 16)
            {
                bits.Insert(0, Convert.ToBoolean(0)); // fill bits with zeros at the left until 2 bytes (16 bit)
            }
            int index = bits.Count - 1; // points to first (most right) bit in current byte 
            List<byte> bytes = new List<byte>();                        
            while (index != -1) // for 16-bit it will execute 2 times so you get 2 bytes
            {
                byte b = 0;
                for (int i = index; i > index - 8; i--)
                {
                    b += Convert.ToByte(Convert.ToInt32(bits.ElementAt(i)) * Convert.ToInt32(Math.Pow(2, index - i)));
                    // convert from binary to decimal and sum by all 8 bit positions
                }
                bytes.Add(b);
                index -= 8;
            }
            bytes.Reverse(); // it gives correct 16-bit sequence which written as 2 bytes
            // for example, 258 = 0000 0001 0000 0010, so bytes[0] = 1, bytes[1] = 2
            // to decode 258 you just need to do: bytes[1] + 2^8 * bytes[0]
            return bytes;
        }

        private static void sendDataToCOM(byte[] data, ushort length)
        {
            Program.serial_port.Write(data, 0, length);
        }
        
    }
}
