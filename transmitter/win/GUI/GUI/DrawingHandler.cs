using System;
using System.Collections.Generic;
using System.Drawing;

public static class DrawingHandler
{
    static public int lcd_x_size, lcd_y_size;
    static private int x_size, y_size, num_of_frames_x, num_of_frames_y;
    public static bool[,] real_lcd_display;
    static private bool[ , ] lcd_display, frame_display, display;
    static private List<byte> packet;
    public static bool last_command_was_drawing = false;

    static DrawingHandler()
	{        
        lcd_x_size = 24;
        lcd_y_size = 8;        
        num_of_frames_x = 3;
        num_of_frames_y = 1;
        real_lcd_display = new bool[lcd_x_size, lcd_y_size];
    }

    public static void eraseDrawing()
    {
        dataInit();
        real_lcd_display = new bool[lcd_x_size, lcd_y_size];
        GUI.BytesToCOMConnection.sendData(packet, "erase_drawing");
    }

    private static void dataInit()
    {
        x_size = GUI.Program.main_GUI.DrawingField.Width; // find DrawningField sizes from running instance in Program class
        y_size = GUI.Program.main_GUI.DrawingField.Height;
        display = new bool[x_size, y_size];
        lcd_display = new bool[lcd_x_size, lcd_y_size];
        frame_display = new bool[num_of_frames_x, num_of_frames_y];
        packet = new List<byte>(0);
        packet.Clear();
    }

    public static void sendDrawing(bool[ , ] display_matrix, bool is_black_brush)
    {
        reduceReceived(display_matrix, is_black_brush); // reduce to lcd resolution
        chooseChangedFrames();
        createPacket();
        GUI.BytesToCOMConnection.sendData(packet, "drawing");
        last_command_was_drawing = true;
    }

    private static void createPacket()
    {
        for (int frame_x = 0; frame_x < num_of_frames_x; frame_x++)
        {
            for (int frame_y = 0; frame_y < num_of_frames_y; frame_y++)
            {
                if (last_command_was_drawing)
                {
                    if (frame_display[frame_x, frame_y])
                    {
                        packet.Add(Convert.ToByte(frame_x + num_of_frames_x * frame_y)); // insert byte to number frame
                        for (int lcd_y = 0; lcd_y < lcd_y_size / num_of_frames_y; lcd_y++)
                        {
                            byte b = 0;
                            for (int lcd_x = 0; lcd_x < lcd_x_size / num_of_frames_x; lcd_x++)
                            {
                                b += Convert.ToByte(Math.Pow(2, lcd_x_size / num_of_frames_x - lcd_x - 1) * Convert.ToByte(real_lcd_display[frame_x * lcd_x_size / num_of_frames_x + lcd_x, frame_y * lcd_y_size / num_of_frames_y + lcd_y]));
                            }
                            packet.Add(b); // add byte to packet
                        }
                    } 
                } else
                {
                    packet.Add(Convert.ToByte(frame_x + num_of_frames_x * frame_y)); // insert byte to number frame
                    for (int lcd_y = 0; lcd_y < lcd_y_size / num_of_frames_y; lcd_y++)
                    {
                        byte b = 0;
                        for (int lcd_x = 0; lcd_x < lcd_x_size / num_of_frames_x; lcd_x++)
                        {
                            b += Convert.ToByte(Math.Pow(2, lcd_x_size / num_of_frames_x - lcd_x - 1) * Convert.ToByte(real_lcd_display[frame_x * lcd_x_size / num_of_frames_x + lcd_x, frame_y * lcd_y_size / num_of_frames_y + lcd_y]));
                        }
                        packet.Add(b); // add byte to packet
                    }
                }
                
            }
        }
    }

    private static void chooseChangedFrames()
    {
        int true_pixels;
        for (int x = 0; x < lcd_x_size; x += lcd_x_size / num_of_frames_x)
        {
            for (int y = 0; y < lcd_y_size; y += lcd_y_size / num_of_frames_y)
            {
                true_pixels = 0;
                for (int i = 0; i < lcd_x_size / num_of_frames_x; i++)
                {
                    for (int j = 0; j < lcd_y_size / num_of_frames_y; j++)
                    {
                        if (lcd_display[x + i, y + j]) true_pixels++;
                    }
                }
                if (true_pixels != 0)
                    frame_display[x / (lcd_x_size / num_of_frames_x), y / (lcd_y_size / num_of_frames_y)] = true;
            }
        }
    }

    private static void reduceReceived(bool[,] display_matrix, bool is_black_brush)
    {
        dataInit(); // to start state - fill arrays with false and claer packet
        int true_pixels;
        for (int x = 0; x < x_size; x += x_size / lcd_x_size)
        {
            for (int y = 0; y < y_size; y += y_size / lcd_y_size)
            {
                true_pixels = 0;
                for (int i = 0; i < x_size / lcd_x_size; i++)
                {
                    for (int j = 0; j < y_size / lcd_y_size; j++)
                    {
                        if (display_matrix[x + i, y + j]) true_pixels++;
                    }
                }
                if (true_pixels > (x_size / lcd_x_size * y_size / lcd_y_size) / 2)
                {
                    lcd_display[x / (x_size / lcd_x_size), y / (y_size / lcd_y_size)] = true;
                    if (is_black_brush) real_lcd_display[x / (x_size / lcd_x_size), y / (y_size / lcd_y_size)] = true;
                    else real_lcd_display[x / (x_size / lcd_x_size), y / (y_size / lcd_y_size)] = false;
                }                    
            }
        }
    }   
}
