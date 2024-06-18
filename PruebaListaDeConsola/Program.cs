using PruebaListaDeConsola.Models;

internal class Program
{
    static GestorDeContactos gestorDeContactos = new GestorDeContactos();
    static string ListaDeContactos = "contactos.json";
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu de Contactos:");
            Console.WriteLine("1. Agregar nuevo contacto");
            Console.WriteLine("2. Buscar contacto");
            Console.WriteLine("3. Eliminar contacto");
            Console.WriteLine("4. Listar contactos");
            Console.WriteLine("5. Guardar contactos");
            Console.WriteLine("6. Cargar contactos");
            Console.WriteLine("7. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    AgregarContacto();
                    break;
                case "2":
                    BuscarPor();
                    break;
                case "3":
                    eliminarcontacto();
                    break;
                case "4":
                    listarcontacto();
                    break;
                case "5":
                    GuardarDatos();
                    break;
                case "6":
                    CargarDatos();
                    break;
                case "7":
                    Console.WriteLine("Hasta Luego!!!");
                    return;

                default:
                    Console.WriteLine("Opción no válida. Intente de nuevo.");
                    break;
            }
        }
    }



    static void AgregarContacto()
    {
        Console.Clear();
     
        Console.Write("Ingrese el nombre: ");
        string nombre = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("El nombre es obligatorio.");
            return;
        }

        Console.Write("Ingrese el teléfono: ");
        string telefono = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(telefono))
        {
            Console.WriteLine("El teléfono es obligatorio.");
            return;
        }
        Console.Write("Ingrese el email: ");
        string email = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(email))
        {
            Console.WriteLine("El email es obligatorio.");
            return;
        }
        gestorDeContactos.AgregarContactos(nombre, telefono, email);
    }
    static void eliminarcontacto()
    {
        Console.Clear();    
        Console.WriteLine("Ingrese El Id Del Contacto Que Desea Eliminar");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            Console.WriteLine("Id no Valido");
            return;
        }
        else
        {
            gestorDeContactos.EliminarContacto(id);
        }
    }
    static void listarcontacto() 
    {
        Console.Clear();
        gestorDeContactos.ListarContactos();
    }
    static void BuscarPor ()
    {
        Console.Clear();
        Console.WriteLine("Escriba: \n1.Nombre \n2.Telefono");
        int Auxiliar = int.Parse(Console.ReadLine());
        if (Auxiliar == 1)
        {
            Console.WriteLine("Ingrese El Nombre a Buscar");
            string nombre = Console.ReadLine();
            gestorDeContactos.BuscarByNombreOTelefono(nombre, null);
        }
        else if (Auxiliar == 2)
        {
            Console.WriteLine("Ingrese El telefono  a Buscar");
            string telefono = Console.ReadLine();
            gestorDeContactos.BuscarByNombreOTelefono(null, telefono);
        }
        else {
            Console.WriteLine("Opcion no valida");
        }
    }
    static void GuardarDatos()
    {
        gestorDeContactos.GuardarListaDeContactos(ListaDeContactos);
    }
    static void CargarDatos()
    {
        gestorDeContactos.CargarListaDeContactos(ListaDeContactos);
    }
}