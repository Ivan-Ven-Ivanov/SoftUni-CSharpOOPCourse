using Telephony.Core.Interfaces;
using Telephony.IO.Interfaces;
using Telephony.Models;
using Telephony.Models.Interfaces;

namespace Telephony.Core
{
    public class Engine : IEngine
    {
        private IReader reader;
        private IWriter writer;
        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }
        public void Run()
        {
            string[] phoneNumbers = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] urls = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICallable callable;

            foreach (string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.Length == 7)
                {
                    callable = new StationaryPhone();
                }
                else
                {
                    callable = new Smartphone();
                }

                try
                {
                    writer.WriteLine(callable.Call(phoneNumber));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }

            IBrowseable browseable = new Smartphone();

            foreach (string url in urls)
            {
                try
                {
                    writer.WriteLine(browseable.Browse(url));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
            }
        }
    }
}
