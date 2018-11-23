using System;

namespace CS.Hello
{
    class Program {
        static void Main(string[] args) {

            // Console.WriteLine("Hello World!");

            // prepare logger
            var log1 = new Logger();
            var log2 = new Logger();
            var log3 = new Logger();

            log1.AddScreen();
            log1.AddFile(@"C:\temp\CS.log");
            log2.AddFile(@"C:\temp\CS.log");
            log3.AddScreen();

            // main code
            log1.WriteLine("Hello world from logger!");
            log2.WriteLine("This goes to file only");
            log3.WriteLine("This goes to screen only");

        }
    }

    class Logger {

        private string FileName;
        private bool Screen = false;


        public void AddFile(string FileName) {
            this.FileName = FileName;
        }

        public void AddScreen() {
            this.Screen = true;
        }

        public void WriteLine(string Message) {
            
            if (this.Screen) {
                Console.WriteLine(Message);
            }

            if (this.FileName != null) {
                // TODO: Add file locking
                string ExtendedMessage = DateTime.Now.ToString("T") + " " + Message;
                var logWriter = new System.IO.StreamWriter(this.FileName, append: true);
                logWriter.WriteLine(ExtendedMessage);
                logWriter.Dispose();
            }
        }
    }
}
