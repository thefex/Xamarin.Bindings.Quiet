using Android.App;
using Android.Widget;
using Android.OS;
using Org.Quietmodem.Quiet;
using System.IO;
using System.Text;

namespace DroidTestProject
{
    [Activity(Label = "DroidTestProject", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { button.Text = $"{count++} clicks!"; };

            FrameReceiverConfig receiverConfig = null;
            FrameTransmitterConfig transmitterConfig = null;

            try
            {
                transmitterConfig = new FrameTransmitterConfig(
                        this,
                        "audible-7k-channel-0");
                receiverConfig = new FrameReceiverConfig(
                        this,
                        "audible-7k-channel-0");
            }
            catch (IOException e)
            {
                // could not build configs
            }

            FrameReceiver receiver = null;
            FrameTransmitter transmitter = null;

            try
            {
                receiver = new FrameReceiver(receiverConfig);
                transmitter = new FrameTransmitter(transmitterConfig);
            }
            catch (ModemException e)
            {
                // could not set up receiver/transmitter
            }

            string payload = "Hello, World Hello, WorldHello, WorldHello, WorldHello, WorldHello, WorldHello, WorldHello, WorldHello, WorldHello, World!";
            try
            {
                transmitter.Send(Encoding.UTF8.GetBytes(payload));
            }
            catch (IOException e)
            {
                // our message might be too long or the transmit queue full
            }


            // set receiver to block until a frame is received
            // by default receivers are nonblocking
           // receiver.SetBlocking(10, 0);

        //    byte[] buf = new byte[1024];
       //     long recvLen = 0;
       //     try
        //    {
                
       //         recvLen = receiver.Receive(buf);
        //    }
       //     catch (IOException e)
       //     {
                // read timed out
        //    }

       //     button.Text = Encoding.UTF8.GetString(buf, 0, (int) recvLen);
        }
    }
}

