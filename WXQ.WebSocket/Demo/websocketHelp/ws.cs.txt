using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;
namespace WebApplication2.websocketHelp
{
    public class ws
    {

        private static HttpServer httpsv = new HttpServer(4649);

        public void Init()
        {

            httpsv.AddWebSocketService<Chat>("/Chat");

            httpsv.Start();
            if (httpsv.IsListening)
            {
                Console.WriteLine("Listening on port {0}, and providing WebSocket services:", httpsv.Port);
                foreach (var path in httpsv.WebSocketServices.Paths)
                    Console.WriteLine("- {0}", path);
            }

    

           

        }

        public void send()
        {
            
           var ss=  httpsv.WebSocketServices.Hosts;

            var ids = Chat.idLt;
            foreach ( var s in httpsv.WebSocketServices.Hosts) {


                foreach (var s1 in s.Sessions.Sessions)
                {
                    s.Sessions.SendTo("hello:xxxx" + s1.ID, s1.ID);
                }
               

            } 

          



            foreach (string s in ids)
            {
                try
                {
                    
                   
                  


                }
                catch (Exception ex)
                {

                }



                
            }
         
            
        }


        public void stop()
        {
            httpsv.Stop();

        }
        






    }
}
