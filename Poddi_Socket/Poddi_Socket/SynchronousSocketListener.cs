using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

namespace Poddi_Socket
{
    public class SynchronousSocketListener
    {

        // Incoming data from the client.  
        public static string data = null;
        private Random r;
        private string dataRic;
        private bool connesso;

        public SynchronousSocketListener()
        {
            r = new Random();
            connesso = false;
        }
        public bool connessione()
        {
            return connesso;
        }
        public string dataRicevuti()
        {
            return dataRic;
        }
        public void StartListening()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the   
            // host running the application.  
            IPAddress ipAddress = System.Net.IPAddress.Parse("127.0.0.1");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 5000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and   
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                while (true)
                {
                    dataRic = "";
                    connesso = false;
                    // Program is suspended while waiting for an incoming connection.  
                    Socket handler = listener.Accept();
                    data = null;

                    // An incoming connection needs to be processed.  
                    while (true)
                    {
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }
                        dataRic = "!";
                    }
                    connesso = true;

                    // Show the data on the console.  
                    dataRic="Text received : {0}"+ data;
                    string n = r.Next(10).ToString();
                    // Echo the data back to the client.  
                    byte[] msg = Encoding.ASCII.GetBytes(n);

                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                    
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
    }
}

