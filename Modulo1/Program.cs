using System.Collections;

namespace Modulo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // demoClaseAbstracta();
            // demoClasesGenericas();
            // demoMetodosGenericos();
            demoMetodosExtension();
        }

        private static void demoMetodosExtension()
        {
            string mensaje = "hola, ¿cómo estas?";

            Console.WriteLine(mensaje.Mayusculas());
            Console.WriteLine(mensaje.Minusculas());
            Console.WriteLine(mensaje.Reverse());

        }

        private static void demoMetodosGenericos()
        {
            MiClaseGenererica<int> objetoInt = new MiClaseGenererica<int>(200);
            objetoInt.MostrarTipoValor();

            MiClaseGenererica<string> objetoString = new MiClaseGenererica<string>("Soy una cadena de texto");
            objetoString.MostrarTipoValor();
        }

        public class MiClaseGenererica<T>
        {
            T valor;

            public MiClaseGenererica(T valor)
            {
                this.valor = valor;
            }

            public void MostrarTipoValor()
            {
                Console.WriteLine(this.valor.GetType());
                Console.WriteLine(this.valor);
            }
        }

        private static void demoClasesGenericas()
        {

            // Sin lista generica no se especifica el tipo de dato, permitiendo que cometa error y me de cuenta solamente cuando se compila

            var lista = new ArrayList();
            lista.Add(100);
            lista.Add("Aviso");
            lista.Add(new Paciente());

            foreach (int dato in lista)
            {
                Console.WriteLine(dato);
            }


            // Lista generica se especifica el tipo de dato

            var listaInt = new List<int>();
            listaInt.Add(100);

            var listaString = new List<string>();
            listaString.Add("Aviso");

            var listaPacientes = new List<Paciente>();
            listaPacientes.Add(new Paciente());
        }

        private static void demoClaseAbstracta()
        {
            Paciente paciente = new Paciente();
            paciente.Id = 1; paciente.Nombre = "Juan"; paciente.Apellido = "Perez";
            paciente.MostrarDatos();
            paciente.Listar();

            Medico medico = new Medico();
            medico.Id = 2; medico.Nombre = "Carlos"; medico.Apellido = "Lopez";
            medico.MostrarDatos();
            medico.Listar();
        }
    }
}

#region demoClaseAbstracta
public abstract class Persona
{
    int id;
    string nombre;
    string apellido;


    public int Id { get => id; set => id = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Apellido { get => apellido; set => apellido = value; }
    public DateTime FechaNacimiento { get; set; }

    public void MostrarDatos()
    {
        Console.WriteLine($"Apellido {Apellido}, Nombre {Nombre}");
    }

    public virtual void Listar()
    {

    }

}

public class Paciente : Persona
{
    public override void Listar()
    {
        // base.Listar(); ejecuta el codigo antes de sobreescribirlo
        Console.WriteLine("Listar pacientes");
    }
}

public class Medico : Persona
{
    public override void Listar()
    {
        // base.Listar(); ejecuta el codigo antes de sobreescribirlo
        Console.WriteLine("Listar medicos");
    }
}
#endregion

// Los metodos de extension son metodos creados por uno mismo y para un tipo de dato especifico
public static class StringExtension
{
    public static string Mayusculas(this string value)
    {
        return value.ToUpper();
    }

    public static string Minusculas(this string value)
    {
        return value.ToLower();
    }

    public static string Reverse(this string value)
    {
        char[] array = value.ToCharArray();
        Array.Reverse(array);
        return new string(array);
    }
}