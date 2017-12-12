using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;


public class arduino : MonoBehaviour {
    public bool up = false;
    SerialPort stream1;
    SerialPort stream2;
    bool running;
    System.Threading.Thread thread1;
    System.Threading.Thread thread2;
    public static int ax1 = 0;
    public static int ay1 = 0;
    public static int az1 = 0;
    public static int gx1 = 0;
    public static int gy1 = 0;
    public static int gz1 = 0;
    public static int ax2 = 0;
    public static int ay2 = 0;
    public static int az2 = 0;
    public static int gx2 = 0;
    public static int gy2 = 0;
    public static int gz2 = 0;

    public int port1 = 7;
    public int port2 = 6;


    void ThreadLoop1()
    {
        int state = 0;
        byte[] buffer = new byte[14];
        int index = 0;
        while (running)
        {
            try
            {
                int value = stream1.ReadByte();
                byte b = (byte)value;
                //if()
                switch (state)
                {
                    case 0: // first magic
                        if (b == 0x34)
                        {
                            state = 1;
                        }
                        if (b == 0x78)
                        {
                            state = 3;
                        }
                        break;
                    case 1: // second magic
                        if (b == 0x12)
                        {
                            state = 2;
                        }
                        break;
                    case 2: // data
                        buffer[index] = b;
                        ++index;
                        if (index >= 12)
                        {
                            state = 0;
                            index = 0;
                            //Serial.println(data.ax);
                            ax1 = System.BitConverter.ToInt16(buffer, 0);
                            ay1 = System.BitConverter.ToInt16(buffer, 2);
                            az1 = System.BitConverter.ToInt16(buffer, 4);
                            gx1 = System.BitConverter.ToInt16(buffer, 6);
                            gy1 = System.BitConverter.ToInt16(buffer, 8);
                            gz1 = System.BitConverter.ToInt16(buffer, 10);
                        }
                        break;
                    case 3: // second magic
                        if (b == 0x56)
                        {
                            state = 4;
                        }
                        break;
                    case 4: // data
                        if (b == 0x56 || b == 0x78)
                        {
                            index = 0;
                            state = 0;
                            break;
                        }
                        buffer[index] = b;
                        ++index;
                        if (index >= 2)
                        {
                            state = 0;
                            index = 0;
                            gx1 = System.BitConverter.ToInt16(buffer, 0);
                            Debug.Log("1 - "+gx1);
                        }
                        break;
                }
            }
            catch
            {
            }
        }
    }

    void ThreadLoop2()
    {
        int state = 0;
        byte[] buffer = new byte[14];
        int index = 0;
        while (running)
        {
            try
            {
                int value = stream2.ReadByte();
                byte b = (byte)value;
                //if()
                switch (state)
                {
                    case 0: // first magic
                        if (b == 0x34)
                        {
                            state = 1;
                        }
                        if (b == 0x78)
                        {
                            state = 3;
                        }
                        break;
                    case 1: // second magic
                        if (b == 0x12)
                        {
                            state = 2;
                        }
                        break;
                    case 2: // data
                        buffer[index] = b;
                        ++index;
                        if (index >= 12)
                        {
                            state = 0;
                            index = 0;
                            //Serial.println(data.ax);
                            ax2 = System.BitConverter.ToInt16(buffer, 0);
                            ay2 = System.BitConverter.ToInt16(buffer, 2);
                            az2 = System.BitConverter.ToInt16(buffer, 4);
                            gx2 = System.BitConverter.ToInt16(buffer, 6);
                            gy2 = System.BitConverter.ToInt16(buffer, 8);
                            gz2 = System.BitConverter.ToInt16(buffer, 10);
                        }
                        break;
                    case 3: // second magic
                        if (b == 0x56)
                        {
                            state = 4;
                        }
                        break;
                    case 4: // data
                        if (b == 0x56 || b == 0x78)
                        {
                            index = 0;
                            state = 0;
                            break;
                        }
                        buffer[index] = b;
                        ++index;
                        if (index >= 2)
                        {
                            state = 0;
                            index = 0;
                            gx2 = System.BitConverter.ToInt16(buffer, 0);
                            Debug.Log("2 - " + gx2);
                        }
                        break;
                }
            }
            catch
            {
            }
        }
    }

    // Use this for initialization
    void Start () {
        byte[] value;
        value = new byte[1];
        value[0] = 2;
        string[] p = SerialPort.GetPortNames();
        for (int i = 0; i < p.Length; ++i)
        {
            Debug.Log(p[i]);
        }

        System.IO.StreamReader sr = new System.IO.StreamReader(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)+"\\wiggle.ports");
        int.TryParse(sr.ReadLine(), out port1);
        int.TryParse(sr.ReadLine(), out port2);
        Debug.Log("Port is" + port1);
        Debug.Log("Port is" + port2);
        try
        {
            stream1 = new SerialPort("COM" + port1, 9600);
            stream1.ReadTimeout = 10;
            stream1.Open();
            stream1.Write(value, 0, 1);
            running = true;
            thread1 = new System.Threading.Thread(ThreadLoop1);
            thread1.Start();
        }
        catch { }

        try
        {
            stream2 = new SerialPort("COM" + port2, 9600);
            stream2.ReadTimeout = 10;
            stream2.Open();
            stream2.Write(value, 0, 1);
            running = true;
            thread2 = new System.Threading.Thread(ThreadLoop2);
            thread2.Start();
        }
        catch { }
    }


    // Update is called once per frame
    void Update () {
        //transform.position = new Vector3(0, gx1 / 10000.0f, 0);
    }

    void OnApplicationQuit()
    {
        running = false;
    }
}
