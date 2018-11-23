using System;
using static Logger;

namespace CS.Hello
{
    class Program {
        static void Main(string[] args) {

            // prepare loggers
            var log1 = new Logger();
            log1.AddScreen();
            log1.AddFile("C:\\temp\\CSharp1.log");
            log1.SetAutoRotate(500);

            var log2 = new Logger("C:\\temp\\CSharp2.log",200);

            var log3 = new Logger();
            log3.AddScreen();


            // main code
            // Console.WriteLine("Hello World!");
            log1.WriteLine("Hello world from logger!");
            log2.WriteLine("This goes to file only");
            
            log3.WriteLine("This goes to screen only");
            log3.WriteLine("This has extended timestamp","G");

            // finish
            log1.Rotate(200);
        }
    }

}
