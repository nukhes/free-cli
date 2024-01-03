using System.Globalization;
using System.Management;

class Program
{
    static void Main()
    {
        string tot, free;
        decimal totN, freeN;

        ObjectQuery wql = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
        ManagementObjectSearcher searcher = new ManagementObjectSearcher(wql);
        ManagementObjectCollection results = searcher.Get();

        foreach (ManagementObject result in results)
        {
            tot = result["TotalVisibleMemorySize"].ToString();
            free = result["FreePhysicalMemory"].ToString();

            totN = Convert.ToDecimal(tot, CultureInfo.InvariantCulture);
            freeN = Convert.ToDecimal(free, CultureInfo.InvariantCulture);

            Console.WriteLine("\n{0, 20} {1, 10} {2, 10}", "total", "used", "free");
            Console.WriteLine("Mem: {0, 13:N0}GB {1, 8:N0}GB {2, 8:N0}GB", totN / 1024, (totN - freeN) / 1024, freeN / 1024);

            Console.ReadLine();
        }

    }
}