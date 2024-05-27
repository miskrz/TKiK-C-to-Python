using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Website.Models;
using System.Text;
using Microsoft.JSInterop.Infrastructure;

namespace Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult RunApp()
    {
        string path = "../Output/CGrammar";

        string output = string.Empty;
        string errors = string.Empty;

        try
        {
            

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "dotnet",
                Arguments = "run --project " + path,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = false,
            };

            using (Process process = Process.Start(startInfo))
            {
                output = process.StandardOutput.ReadToEnd();
                errors = process.StandardError.ReadToEnd();
                process.WaitForExit();
            }
        }
        catch (Exception ex)
        {
            errors = ex.Message;
        }

        return Json(new { outputText = output, errorsText = errors });
    }

    [HttpPost]
    public ActionResult SaveInputToFile(string inputData)
    {
        try
        {
            string filePathOutput = "../OutputFiles/outputPython.py";
            string filePathError = "../OutputFiles/error.txt";
            // Ścieżka do miejsca, gdzie będzie zapisywany plik
            string filePath = "../OutputFiles/inputC.c";

            // Zapisz zawartość pola wejściowego do pliku
            System.IO.File.WriteAllText(filePathOutput, "", Encoding.UTF8);
            System.IO.File.WriteAllText(filePath, inputData, Encoding.UTF8);
            System.IO.File.WriteAllText(filePathError, "", Encoding.UTF8);

            // Zwróć odpowiedź sukcesu
            return Json(new { success = true });
        }
        catch (Exception ex)
        {
            // Zwróć odpowiedź z błędem w przypadku problemów z zapisem pliku
            return Json(new { success = false, error = ex.Message });
        }
    }

    public ActionResult GetOutputFile()
    {
        string filePath = "../OutputFiles/outputPython.py";

        try
        {
            // Ścieżka do miejsca, gdzie jest zapisany plik z wynikami

            // Odczytaj zawartość pliku
            string output = System.IO.File.ReadAllText(filePath);

            // Zwróć zawartość pliku
            return Content(output, "text/plain");
        }
        catch (Exception ex)
        {
            // Zwróć odpowiedź z błędem w przypadku problemów z odczytem pliku
            return Content(ex.Message, "text/plain");
        }
    }


    public ActionResult GetErrorFile()
    {
        string filePath = "../OutputFiles/error.txt";

        try
        {
            
            // Ścieżka do miejsca, gdzie jest zapisany plik z wynikami

            // Odczytaj zawartość pliku
            string output = System.IO.File.ReadAllText(filePath);

            // Zwróć zawartość pliku
            return Content(output, "text/plain");
        }
        catch (Exception ex)
        {
            // Zwróć odpowiedź z błędem w przypadku problemów z odczytem pliku
            return Content(ex.Message, "text/plain");
        }
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
