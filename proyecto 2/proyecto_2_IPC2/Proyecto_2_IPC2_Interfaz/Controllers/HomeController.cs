using Microsoft.AspNetCore.Mvc;
using Proyecto_2_IPC2_Interfaz.Models;
using System.Diagnostics;
using System;
using System.IO;
using System.Collections.Generic;
using proyecto_2_IPC2.Modelos;
using proyecto_2_IPC2.Estructuras;
using proyecto_2_IPC2.Servicios;

namespace Proyecto_2_IPC2_Interfaz.Controllers
{
    public class HomeController : Controller
    {
        private readonly GestorDatos _gestor;

        public HomeController(GestorDatos gestor)
        {
            _gestor = gestor;
        }

        //menu
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CargarXML(IFormFile archivo)
        {
            if (archivo != null && archivo.Length > 0)
            {
                var tempPath = Path.GetTempFileName();
                using (var stream = System.IO.File.Create(tempPath))
                {
                    archivo.CopyTo(stream);
                }
                try
                {
                    var lector = new LectorXML();
                    lector.CargarConfiguracion(tempPath, _gestor);
                    System.Diagnostics.Debug.WriteLine($"Sistemas cargados: {_gestor.Sistemas.Cantidad()}");
                    System.Diagnostics.Debug.WriteLine($"Mensajes cargados: {_gestor.Mensajes.Cantidad()}");
                    _gestor.ProcesarTodosMensajes();
                    TempData["Mensaje"] = "XML cargado correctamente.";
                }
                catch (Exception ex)
                {
                    TempData["Error"] = $"Error al cargar XML: {ex.Message}";
                }
                finally
                {
                    System.IO.File.Delete(tempPath);
                }
            }
            else
            {
                TempData["Error"] = "No se seleccionó ningún archivo.";
            }
            return RedirectToAction("Index");
        }

        public IActionResult GestionDrones()
        {
            _gestor.Drones.OrdenarAlfabeticamente();
            return View(_gestor.Drones);
        }

        [HttpPost]
        public IActionResult AgregarDron(string nombre)
        {
            if (!string.IsNullOrWhiteSpace(nombre) && _gestor.Drones.Buscar(nombre) == null)
            {
                _gestor.Drones.Agregar(new Dron(nombre));
                TempData["Mensaje"] = $"Dron '{nombre}' agregado.";
            }
            else
            {
                TempData["Error"] = "Nombre inválido o dron ya existe.";
            }
            return RedirectToAction("GestionDrones");
        }

        public IActionResult GestionSistemas()
        {
            return View(_gestor.Sistemas);
        }

        public IActionResult VerSistema(string nombre)
        {
            var sistema = _gestor.Sistemas.Buscar(nombre);
            if (sistema == null)
                return NotFound();

            return View(sistema);
        }

        public IActionResult GraficoSistema(string nombre)
        {
            try
            {
                var sistema = _gestor.Sistemas.Buscar(nombre);
                if (sistema == null)
                    return NotFound();

                string tempDir = Path.Combine(Directory.GetCurrentDirectory(), "tempGraphs");
                if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);

                string dotFile = Path.Combine(tempDir, Guid.NewGuid() + ".dot");
                string pngFile = Path.Combine(tempDir, Path.GetFileNameWithoutExtension(dotFile) + ".png");

                var reporte = new ReporteGraphviz();
                reporte.GenerarDotSistema(sistema, dotFile);

                if (!System.IO.File.Exists(dotFile))
                    return Content("No se pudo crear el archivo .dot");

                string dotPath = @"C:\Program Files\Graphviz\bin\dot.exe";
                if (!System.IO.File.Exists(dotPath))
                    dotPath = "dot";

                var startInfo = new System.Diagnostics.ProcessStartInfo
                {
                    FileName = dotPath,
                    Arguments = $"-Tpng \"{dotFile}\" -o \"{pngFile}\"",
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (var process = new System.Diagnostics.Process { StartInfo = startInfo })
                {
                    process.Start();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                        return Content($"Error de Graphviz: {error}");
                }

                if (!System.IO.File.Exists(pngFile))
                    return Content("No se generó el archivo PNG");

                byte[] bytes = System.IO.File.ReadAllBytes(pngFile);
                System.IO.File.Delete(dotFile);
                System.IO.File.Delete(pngFile);
                return File(bytes, "image/png");
            }
            catch (Exception ex)
            {
                return Content($"Excepción: {ex.Message}");
            }
        }


        public IActionResult GestionMensajes()
        {
            return View(_gestor.Mensajes);
        }


        public IActionResult VerInstrucciones(string nombreMensaje)
        {
            var mensaje = _gestor.Mensajes.Buscar(nombreMensaje);
            if (mensaje == null)
                return NotFound();

            var sistema = _gestor.Sistemas.Buscar(mensaje.NombreSistema);
            ViewBag.Sistema = sistema;
            return View(mensaje);
        }

        public IActionResult GraficoMensaje(string nombreMensaje)
        {
            try
            {
                var mensaje = _gestor.Mensajes.Buscar(nombreMensaje);
                if (mensaje ==null)
                    return NotFound();

                string tempDir =Path.Combine(Directory.GetCurrentDirectory(), "tempGraphs");
                if (!Directory.Exists(tempDir)) Directory.CreateDirectory(tempDir);

                string dotFile=Path.Combine(tempDir, Guid.NewGuid() + ".dot");
                string pngFile=Path.Combine(tempDir, Path.GetFileNameWithoutExtension(dotFile) + ".png");

                var reporte =new ReporteGraphviz();
                reporte.GenerarDotMensaje(mensaje, dotFile);

                if (!System.IO.File.Exists(dotFile))
                    return Content("No se pudo crear el archivo .dot");

                string dotPath =@"C:\Program Files\Graphviz\bin\dot.exe";
                if (!System.IO.File.Exists(dotPath))
                    dotPath = "dot";

                var startInfo =new System.Diagnostics.ProcessStartInfo
                {
                    FileName = dotPath,
                    Arguments = $"-Tpng \"{dotFile}\" -o \"{pngFile}\"",
                    RedirectStandardOutput= true,
                    RedirectStandardError =true,
                    UseShellExecute =false,
                    CreateNoWindow=true
                };

                using (var process = new System.Diagnostics.Process { StartInfo = startInfo })
                {
                    process.Start();
                    string error = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    if (process.ExitCode != 0)
                        return Content($"Error de Graphviz: {error}");
                }

                if (!System.IO.File.Exists(pngFile))
                    return Content("No se generó el archivo PNG");

                byte[] bytes = System.IO.File.ReadAllBytes(pngFile);
                System.IO.File.Delete(dotFile);
                System.IO.File.Delete(pngFile);
                return File(bytes, "image/png");
            }
            catch (Exception ex)
            {
                return Content($"Excepción: {ex.Message}");
            }
        }


        public IActionResult GenerarSalida()
        {
            var escritor = new EscritorXML();
            var tempFile = Path.GetTempFileName();
            escritor.GenerarSalida(_gestor, tempFile);
            var bytes = System.IO.File.ReadAllBytes(tempFile);
            System.IO.File.Delete(tempFile);
            return File(bytes, "application/xml", "salida.xml");
        }


        public IActionResult Ayuda()
        {
            return View();
        }
    }
}