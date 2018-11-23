using System;
using System.IO;

class Logger {

    //
    // properties
    //

    private string FileName;
    private bool Screen = false;
    private int AutoRotateSize = 0;


    //
    // Constructors
    //

    public Logger () {}

    public Logger (string FileName, int AutoRotateSize = 0) {
        this.FileName = FileName;
        this.AutoRotateSize = AutoRotateSize;
    }


    //
    // configuration methods
    //

    public void AddFile(string FileName) {
        this.FileName = FileName;
        // TODO: test if file exists, if not create it with some default text?
    }

    public void AddScreen() {
        this.Screen = true;
    }

    public void SetAutoRotate(int MaxSize = 1000000) {
        this.AutoRotateSize = MaxSize;
    }


    //
    // main write method
    //

    public void WriteLine(string Message, string TimeStampFormat = "T") {
        
        if (this.AutoRotateSize > 0)
            this.Rotate(AutoRotateSize);

        string ExtendedMessage = DateTime.Now.ToString(TimeStampFormat) + " " + Message;

        if (this.Screen) {
            Console.WriteLine(ExtendedMessage);
        }

        if (this.FileName != null) {
            var logWriter = new StreamWriter(this.FileName, append: true);
            logWriter.WriteLine(ExtendedMessage);
            logWriter.Dispose();
        }
    }

    //
    // log rotation
    //

    public void Rotate(int MaxSize = 1000000) {
        if (this.FileName == null)
            return;

        if (!File.Exists(this.FileName))
            return;

        var fileInfo = new FileInfo(this.FileName);
        if (fileInfo.Length < MaxSize)
            return;

        var rotatedPath = this.FileName + "." + DateTime.Now.ToString("yyyy-MM-dd-hhmmss");;
        File.Move(this.FileName, rotatedPath);
        File.Create(this.FileName);

        // TODO: implement zipping, retention
    }
}