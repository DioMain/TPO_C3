using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamTests.Service
{
    internal class LoggerService
    {
        public const string DataPath = "../../../../LOG.log";

        public static void WriteLine(string text)
        {
            if (!File.Exists(DataPath))
                File.Create(DataPath);

            File.WriteAllText(DataPath, File.ReadAllText(DataPath) + $"[{DateTime.Now}] {text}\n");
        }
    }
}
