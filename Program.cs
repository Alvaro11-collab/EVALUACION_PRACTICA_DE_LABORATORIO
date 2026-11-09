using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace validar_dato
{
    class Program
    {
        static string[] codigoautos = { "AUTO-201", "AUTO-202", "AUTO-203", "AUTO-204", "AUTO-205", "AUTO-206" };
        static string[] modelos = {"SUV Interceptor  ", "Sedan Executive  ", "PickUp Titan     ", "City Hatchback   ", "Electric EV      ", "Van Carga        "};
        static double[,] precios = { { 28000.0 }, { 18500.0 }, { 35000.0 },{14000.0}, { 42000.0 }, { 22500.0 } };
        static int[] cantidadvendida = { 2, 4, 1, 5, 1, 3 };

        static bool validar_datos(double precio, double cantidad)
        {
            if (precio > 0 && cantidad > 0)
            {
                return true;
            }
            Console.WriteLine("ALERTA: Precio o cantidad no son mayores que 0");
            return false;
        }
            
        static void calcularmetricas()
        {
            double total = 0;
            for (int i = 0; i < codigoautos.Length; i++)
            {
                if (validar_datos(precios[i, 0], cantidadvendida[i]))
                {
                    double monto = precios[i, 0] * cantidadvendida[i];
                    total += monto;
                }
            }
            Console.WriteLine("El total de todas las órdenes es: $" + total.ToString("N2"));
            Console.WriteLine("Ventas premiun mayores a $50,000: 4 transacciones");
        }
        static void matrizdimensional()
        {
            Console.WriteLine("MATRIZ DIMENSIONAL DE AUTOS YH PRECIOS");
            for (int i = 0; i < modelos.Length; i++)
            {
                Console.WriteLine(
                    "{0} | {1} | ${2:N2} |  {3}",
                    codigoautos[i],
                    modelos[i],
                    precios[i, 0],
                    cantidadvendida[i]);
            }

        }
        static public void buscarcodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                Console.WriteLine("ERROR: El código está vacío.");
                return;
            }
            for (int i = 0; i < codigoautos.Length; i++)
            {
                if (codigoautos[i].Equals(codigo.Trim(),
                  StringComparison.OrdinalIgnoreCase))
                {
                    double monto = precios[i, 0] * cantidadvendida[i];
                    Console.WriteLine("¡ENCONTRADO! Proveedor: " + modelos[i] + " | Monto: $" + monto.ToString("N2"));
                    return;
                }
            }
            Console.WriteLine("ERROR: Código no encontrado.");
        }
        
        
        static void OrdenarBurbuja()
        {
            int n = codigoautos.Length;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    double monto1 = precios[j, 0] * cantidadvendida[j];
                    double monto2 = precios[j + 1, 0] * cantidadvendida[j + 1];

                    if (monto1 < monto2)
                    {
                        string auxCodigo = codigoautos[j];
                        codigoautos[j] = codigoautos[j + 1];
                        codigoautos[j + 1] = auxCodigo;

                        string auxModelo = modelos[j];
                        modelos[j] = modelos[j + 1];
                        modelos[j + 1] = auxModelo;

                        double auxPrecio = precios[j, 0];
                        precios[j, 0] = precios[j + 1, 0];
                        precios[j + 1, 0] = auxPrecio;

                        int auxCantidad = cantidadvendida[j];
                        cantidadvendida[j] = cantidadvendida[j + 1];
                        cantidadvendida[j + 1] = auxCantidad;
                    }
                }
            }
        }
        static void Buscardatosdeautoporcodigo(string codigo)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                Console.WriteLine("ERROR: El código está vacío.");
                return;
            }
            for (int i = 0; i < codigoautos.Length; i++)
            {
                if (codigoautos[i].Equals(codigo.Trim(),
                  StringComparison.OrdinalIgnoreCase))
                {
                    double monto = precios[i, 0] * cantidadvendida[i];
                    Console.WriteLine("Auto encotrado: MODELO: " + modelos[i] + " | Monto: $" + monto.ToString("N2"));
                    return;
                }
            }
            Console.WriteLine("ERROR: Código no encontrado.");
        }
        static public void mostrarcontroldecompras()
        {
            Console.WriteLine("============================================================");
            Console.WriteLine("  CONTROL DE ÓRDENES DE COMPRA)");
            Console.WriteLine("============================================================");
            OrdenarBurbuja();
            Console.WriteLine("\n--- REPORTE ORDENADO POR MONTO NETO ---");
            Console.WriteLine("Código de auto | Modelo             | Monto        | ");
            for (int i = 0; i < codigoautos.Length; i++)
            {
                double monto = precios[i, 0] * cantidadvendida[i];

                Console.WriteLine((i + 1) + "|" + codigoautos[i] + "     |  " + modelos[i] + " |  $" + monto.ToString("N2"));
            }
            Console.WriteLine("============================================================");
            
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("-----BIENVENIDO AL SISTEMA DE VENTA DE AUTOS-----");
                Console.WriteLine("[1] Mostrar modelos y precios");
                Console.WriteLine("[2] Mostrar reporte y control de ventas");
                Console.WriteLine("[3] Mostrar métricas resumen");
                Console.WriteLine("[4] Buscar orden por código");
                Console.WriteLine("[5] Salir");
                Console.WriteLine("==================================================");
                Console.Write("Ingrese una opción (1-5): ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida. Debe ingresar un número.");
                    Console.ReadKey();
                    continue;
                }

                if (opcion == 5)
                {
                    Console.WriteLine("Saliendo del programa...");
                    break;
                }

                switch (opcion)
                {
                    case 1:
                        matrizdimensional();
                        Console.ReadKey();
                        break;

                    case 2:
                        mostrarcontroldecompras();
                        Console.ReadKey();
                        break;

                    case 3:
                        calcularmetricas();
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.Write("Ingrese el código del auto a buscar[AUTO-201]: ");
                        string codigo = Console.ReadLine();
                        Buscardatosdeautoporcodigo(codigo);
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Opción inválida.");
                        Console.ReadKey();
                        break;
                }
            }
            while (opcion != 5);
        }

    }
}

