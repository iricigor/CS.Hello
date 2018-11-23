using System;

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