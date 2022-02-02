using System.Diagnostics;
Go();
static void Go() {
    Console.WriteLine("What hour do you want chrome to shut down? In 24 hour time");
    var validInput = false;
    int hour = 0;
    while (!validInput)
    {
        if (int.TryParse(Console.ReadLine(), out int _hour) && _hour >= 0 && _hour <= 23)
        {

            hour = _hour;
            validInput = true;
        }
        else Console.WriteLine("Invalid input. Try again");
    }

    Console.WriteLine("What minute do you want chrome to shut down?");
    validInput = false;
    int min = 0;
    while (!validInput)
    {
        if (int.TryParse(Console.ReadLine(), out int _min) && _min >= 0 && _min <= 59)
        {

            min = _min;
            validInput = true;
        }
        else Console.WriteLine("Invalid input. Try again");
    }

    Run(hour, min);



}

static void Run(int hour, int min) {

    while (true)
    {

        Console.WriteLine(DateTime.Now);
        Process[] chromeInstances = Process.GetProcessesByName("chrome");

        foreach (Process p in chromeInstances)
            if (DateTime.Now.Hour >= hour && DateTime.Now.Minute >= min)
            {

                p.Kill();
                break;

            }

        System.Threading.Thread.Sleep(1000);
    }


}