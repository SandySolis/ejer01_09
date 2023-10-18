using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;

class Program
{
    // Declaración de diccionarios para llevar el registro
    static Dictionary<string, int> ventas = new Dictionary<string, int>
    {
        { "Limpieza", 0 },
        { "Abarrotes", 0 },
        { "Golosinas", 0 },
        { "Electrónicos", 0 }
    };

    static Dictionary<string, int> devoluciones = new Dictionary<string, int>
    {
        { "Limpieza", 0 },
        { "Abarrotes", 0 },
        { "Golosinas", 0 },
        { "Electrónicos", 0 }
    };

    static Dictionary<string, int> inventario = new Dictionary<string, int>
    {
        { "Limpieza", 0 },
        { "Abarrotes", 0 },
        { "Golosinas", 0 },
        { "Electrónicos", 0 }
    };

    static Dictionary<string, decimal> caja = new Dictionary<string, decimal>
    {
        { "Limpieza", 0 },
        { "Abarrotes", 0 },
        { "Golosinas", 0 },
        { "Electrónicos", 0 }
    };

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Tienda de Don Lucas");
            Console.WriteLine("================================================");
            Console.WriteLine("1: Registrar venta");
            Console.WriteLine("2: Registrar devolución");
            Console.WriteLine("3: Cerrar Caja");
            Console.WriteLine("================================================");
            Console.Write("Ingrese una opción: ");
            string opcion = Console.ReadLine();
            Console.Clear();
            if (opcion == "1")
            {
                Console.WriteLine("================================================");
                Console.WriteLine("Registrar Venta de:");
                Console.WriteLine("================================================");
                Console.WriteLine("1: Limpieza");
                Console.WriteLine("2: Abarrotes");
                Console.WriteLine("3: Golosinas");
                Console.WriteLine("4: Electrónicos");
                Console.WriteLine("5: <- Regresar");
                Console.WriteLine("================================================");
                Console.Write("Ingrese una opción: ");
                string opcionVenta = Console.ReadLine();
                Console.Clear();
                if (opcionVenta == "1")
                {
                    RegistrarVenta("Limpieza");
                }
                else if (opcionVenta == "2")
                {
                    RegistrarVenta("Abarrotes");
                }
                else if (opcionVenta == "3")
                {
                    RegistrarVenta("Golosinas");
                }
                else if (opcionVenta == "4")
                {
                    RegistrarVenta("Electrónicos");
                }
                else if (opcionVenta == "5")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Opción no válida");
                }
                Console.Clear();
            }
            else if (opcion == "2")
            {
                Console.WriteLine("================================================");
                Console.WriteLine("Registrar Devolución de:");
                Console.WriteLine("================================================");
                Console.WriteLine("1: Limpieza");
                Console.WriteLine("2: Abarrotes");
                Console.WriteLine("3: Golosinas");
                Console.WriteLine("4: Electrónicos");
                Console.WriteLine("5: <- Regresar");
                Console.WriteLine("================================================");
                Console.Write("Ingrese una opción: ");
                string opcionDevolucion = Console.ReadLine();
                if (opcionDevolucion == "1")
                {
                    RegistrarDevolucion("Limpieza");
                }
                else if (opcionDevolucion == "2")
                {
                    RegistrarDevolucion("Abarrotes");
                }
                else if (opcionDevolucion == "3")
                {
                    RegistrarDevolucion("Golosinas");
                }
                else if (opcionDevolucion == "4")
                {
                    RegistrarDevolucion("Electrónicos");
                }
                else if (opcionDevolucion == "5")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Opción no válida");
                }
                Console.Clear();
            }
            else if (opcion == "3")
            {
                MostrarEstadisticasFinalesOrdenadas();
                break;
            }
            else
            {
                Console.WriteLine("Opción no válida");
            }
        }
    }

    static void RegistrarVenta(string categoria)
    {
        Console.Clear();
        Console.WriteLine("================================================");
        Console.WriteLine("Registrar venta de Limpieza");
        Console.WriteLine("================================================");
        Console.Write("Ingrese cantidad (unidades): ");
        int cantidad = int.Parse(Console.ReadLine());
        Console.Write("Ingrese precio por unidad: ");
        decimal precio = decimal.Parse(Console.ReadLine());
        decimal total = cantidad * precio;
        ventas[categoria] += cantidad;
        caja[categoria] += total;
        inventario[categoria] -= cantidad;
        Console.WriteLine("================================================");
        Console.WriteLine($"Se han ingresado {cantidad} unidades");
        Console.WriteLine($"Se han ingresado S/ {total:F2} en caja");
        Console.WriteLine("================================================");
        Console.WriteLine("1: Registrar más productor de limpieza:");
        Console.WriteLine("2: <- Regresar");
        string opc1 = Console.ReadLine();
        Console.Clear();
        if (opc1 == "1")
        {
            Console.WriteLine("================================================");
            Console.WriteLine("Regsitrar Devolcicón de Abarrotes");
            Console.WriteLine("================================================");
            Console.Write("Ingrese cantidad (unidades): ");
            int cantidad1 = int.Parse(Console.ReadLine());
            Console.Write("Ingrese precio por unidad: ");
            decimal precio1 = decimal.Parse(Console.ReadLine());
            decimal total1 = cantidad1 * precio1;
            ventas[categoria] += cantidad1;
            caja[categoria] += total1;
            inventario[categoria] -= cantidad;
            Console.WriteLine("================================================");
            Console.WriteLine($"Se han ingresado {cantidad1} unidades");
            Console.WriteLine($"Se han ingresado S/ {total1:F2} en caja");
        }
        else if (opc1=="2")
        {
            RegistrarVenta(categoria);
        }
        Console.Clear();
    }

    static void RegistrarDevolucion(string categoria)
    {

        Console.Write("Ingrese cantidad (unidades): ");
        int cantidad = int.Parse(Console.ReadLine());
        Console.Write("Ingrese precio por unidad: ");
        decimal precio = decimal.Parse(Console.ReadLine());
        decimal total = cantidad * precio;
        devoluciones[categoria] += cantidad;
        caja[categoria] -= total;
        inventario[categoria] += cantidad;
        Console.WriteLine($"Se han regresado {cantidad} unidades");
        Console.WriteLine($"Se han devuelto S/ {total:F2} de caja");
        Console.WriteLine("================================================");
        Console.WriteLine("1: Devolver más productos de abarrotes :");
        Console.WriteLine("2: <- Regresar");
        string opc1 = Console.ReadLine();
        if (opc1 == "1")
        {
            Console.WriteLine("================================================");
            Console.Write("Ingrese cantidad (unidades): ");
            int cantidad1 = int.Parse(Console.ReadLine());
            Console.Write("Ingrese precio por unidad: ");
            decimal precio1 = decimal.Parse(Console.ReadLine());
            decimal total1 = cantidad1 * precio1;
            ventas[categoria] += cantidad1;
            caja[categoria] += total1;
            inventario[categoria] -= cantidad;
            Console.WriteLine("================================================");
            Console.WriteLine($"Se han regresado {cantidad1} unidades");
            Console.WriteLine($"Se han devuelto S/ {total1:F2} en caja");
            Console.WriteLine("================================================");

        }
        else if (opc1 == "2")
        {
            RegistrarDevolucion(categoria);
        }
        Console.Clear();
    }

    static void MostrarEstadisticasFinalesOrdenadas()
    {
        Console.WriteLine("Cerrando Caja");
        Console.WriteLine("Totales");
        var categoriasOrdenadas = ventas.Keys.OrderBy(c => c);
        foreach (var categoria in categoriasOrdenadas)
        {
            Console.WriteLine($"| {ventas[categoria]} vendidos {categoria} | {devoluciones[categoria]} devueltos | {inventario[categoria]} en total | S/ {caja[categoria]:F2} en caja |");
        }
        decimal totalGeneral = caja.Values.Sum();
        Console.WriteLine($"Queda en caja S/ {totalGeneral:F2}");
        Console.ReadKey();
    }
}
