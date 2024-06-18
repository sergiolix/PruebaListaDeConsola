using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace PruebaListaDeConsola.Models
{
    public class GestorDeContactos
    {
        public List<Contacto> contactos ;
        public int nextId;


        public GestorDeContactos()
        {
            contactos = new List<Contacto>();
            nextId = 0;
        }


        public void AgregarContactos(string nombre, string telefono, string email)
        {
        
            if (!EsNombreValido(nombre))
            {
                Console.WriteLine("El nombre solo debe contener letras.");
                return;
            }


            if (!EsTelefonoValido(telefono))
            {
                Console.WriteLine("El teléfono solo debe contener números.");
                return;
            }

            if (!EsEmailValido(email))
            {
                Console.WriteLine("El formato del email no es válido.");
                return;
            }

            Contacto contacto = new Contacto {Id = nextId++, Nombre = nombre, Telefono = telefono, Email = email};

            contactos.Add(contacto);
            Console.WriteLine("contanto agregado");
            Console.WriteLine(contacto.ToString());
        }

        public void EliminarContacto(int id) 
        { 
          Contacto contacto = contactos.Find(c => c.Id == id);

            if (contacto != null)
            {
                contactos.Remove(contacto);
                Console.WriteLine("Contacto eliminado");
            }
            else
            {
                Console.WriteLine("Contacto no Encontrado");
            }
        }

        public void ListarContactos()
        {
            Console.WriteLine("Lista De Contactos:");
            foreach (Contacto contacto in contactos)
            {
                Console.WriteLine(contacto.ToString());
            }
        }

        public void BuscarByNombreOTelefono(string nombre, string telefono)
        {
            List<Contacto> resultados = new List<Contacto>();

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                resultados = contactos.FindAll(c => c.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase));
            }
            else if (!string.IsNullOrWhiteSpace(telefono))
            {
                resultados = contactos.FindAll(c => c.Telefono.Contains(telefono));
            }

            if (resultados.Count > 0)
            {
                Console.WriteLine("Resultados de la búsqueda:");
                foreach (Contacto contacto in resultados)
                {
                    Console.WriteLine(contacto.ToString());
                }
            }
            else
            {
                Console.WriteLine("No se encontraron contactos con los criterios de búsqueda proporcionados.");
            }
        }
    

        public void GuardarListaDeContactos(string ListaDeContactos)
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(contactos);
                File.WriteAllText(ListaDeContactos, jsonString);
                Console.WriteLine("Contactos guardados exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar contactos: {ex.Message}");
            }
        }

        public void CargarListaDeContactos(string ListaDeContactos)
        {
            try
            {
                if (File.Exists(ListaDeContactos))
                {
                    string jsonString = File.ReadAllText(ListaDeContactos);
                    contactos = JsonSerializer.Deserialize<List<Contacto>>(jsonString);
                    nextId = contactos.Count > 0 ? contactos[^1].Id + 1 : 1; // Actualiza el nextId 
                    Console.WriteLine("Contactos cargados exitosamente.");
                }
                else
                {
                    Console.WriteLine("No se encontró el archivo de contactos.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cargar contactos: {ex.Message}");
            }
        }

        public bool EsNombreValido(string nombre)
        {
            foreach (char c in nombre)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }

        private bool EsTelefonoValido(string telefono)
        {
            foreach (char c in telefono)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        private bool EsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

    

}


    


