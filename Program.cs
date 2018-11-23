using System;

namespace CS.Hello
{
    class Program {
        static void Main(string[] args) {

            // prepare loggers
            var log1 = new Logger();
            var log2 = new Logger();
            var log3 = new Logger();

            log1.AddScreen();
            log1.AddFile(@"C:\temp\CS.log");
            log2.AddFile(@"C:\temp\CS.log");
            log3.AddScreen();

            // main code
            // Console.WriteLine("Hello World!");
            log1.WriteLine("Hello world from logger!");
            log2.WriteLine("This goes to file only");
            log3.WriteLine("This goes to screen only");

        }
    }


    class Logger {


        //
        // properties
        //

        private string FileName;
        private bool Screen = false;


        //
        // configuration methods
        //

        public void AddFile(string FileName) {
            this.FileName = FileName;
        }

        public void AddScreen() {
            this.Screen = true;
        }


        //
        // main write method
        //

        public void WriteLine(string Message) {
            
            string ExtendedMessage = DateTime.Now.ToString("T") + " " + Message;

            if (this.Screen) {
                Console.WriteLine(ExtendedMessage);
            }

            if (this.FileName != null) {
                var logWriter = new System.IO.StreamWriter(this.FileName, append: true);
                logWriter.WriteLine(ExtendedMessage);
                logWriter.Dispose();
            }
        }
    }
}
