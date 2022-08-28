using System.Threading.Tasks;
using System.Timers;
using Microsoft.AspNet.SignalR;

namespace SignalRAutofac
{
    public class TestHub : Hub
    {
        public ITest Test { get; set; }
        private static Timer timer1;
        public void Hello()
        {
            string message = "the is message froom IP/UPD/TCP we recive and send to client side";
           // Test.DoStuff(message);

            timer1 = new Timer(); //new Timer(1000);
            timer1.Elapsed += (sender, e) => Test.DoStuff(message);
            timer1.Interval = 1000;//miliseconds
            timer1.Start();
        }

        public override Task OnConnected()
        {
            Clients.Caller.hello("Welcome!");
            Hello();
            return base.OnConnected();
        }
    }
}