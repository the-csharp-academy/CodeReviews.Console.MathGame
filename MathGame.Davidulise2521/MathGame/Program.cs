internal class Program
{
    private static void Main(string[] args)
    {
        bool continuar = true;

        Console.WriteLine("Bienvenido a MathGame es un juego de matemáticas donde puedes practicar tus habilidades de cálculo. ¡Diviértete y mejora tus habilidades matemáticas!");
        Console.WriteLine("Por favor, ingresa tu nombre: ");

        string nombre = (Console.ReadLine() ?? "").Trim();

        DateTime fechaActual = DateTime.Now;

        Console.WriteLine($"Hola {nombre}, hoy es {fechaActual:dd/MM/yyyy} y son las {fechaActual:HH:mm:ss}.");
        Console.WriteLine("¿Estás listo para comenzar el juego? (sí/no)");

        string respuesta = (Console.ReadLine() ?? "").Trim().ToLower();

        if (respuesta is "sí" or "si")
        {
            Console.WriteLine("¡Genial! Comencemos con el juego.");
            Console.WriteLine("Las operaciones que se realizarán son: suma, resta, multiplicación y división.");
            Console.WriteLine("Se te harán 5 preguntas, y al final se te mostrará tu puntaje.");
            Console.WriteLine("¡Buena suerte!");
        }
        else
        {
            Console.WriteLine("¡No hay problema! Puedes volver a intentarlo más tarde.");
            continuar = false;
            return;
        }

        // 1. Declaración de la lista para el historial en memoria
        List<string> historial = new List<string>();

        do
        {
            Console.WriteLine("\nPor favor, selecciona la operación que deseas practicar: (S)uma, (R)esta, (M)ultiplicación, (D)ivisión, (E) para salir del juego, (H) para ver el historial.");
            string opcion = (Console.ReadLine() ?? "").Trim().ToUpper();

            switch (opcion)
            {
                case "S":
                case "R":
                case "M":
                case "D":
                    // Llamamos al método reutilizable para las 5 preguntas
                    JugarOperacion(opcion, historial);
                    break;
                case "E":
                    Console.WriteLine("Has seleccionado salir del juego.");
                    continuar = false;
                    break;
                case "H":
                    Console.WriteLine("\n--- HISTORIAL DE PARTIDAS ---");
                    if (historial.Count == 0)
                    {
                        Console.WriteLine("Aún no hay partidas registradas en esta sesión.");
                    }
                    else
                    {
                        foreach (string partida in historial)
                        {
                            Console.WriteLine($"- {partida}");
                        }
                    }
                    Console.WriteLine("-----------------------------");
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }

        } while (continuar);


        // 2. Método modular para el motor de preguntas (Principio DRY)
        static void JugarOperacion(string tipo, List<string> historialPartidas)
        {
            Random random = new Random();
            int puntaje = 0;
            string nombreOperacion = tipo switch
            {
                "S" => "Suma",
                "R" => "Resta",
                "M" => "Multiplicación",
                "D" => "División",
                _ => "Operación"
            };

            Console.WriteLine($"\n--- Iniciando modo: {nombreOperacion} ---");

            for (int i = 1; i <= 5; i++)
            {
                int num1 = 0;
                int num2 = 0;
                int resultadoCorrecto = 0;

                switch (tipo)
                {
                    case "S":
                        num1 = random.Next(1, 51);
                        num2 = random.Next(1, 51);
                        resultadoCorrecto = num1 + num2;
                        Console.Write($"Pregunta {i}/5: ¿Cuánto es {num1} + {num2}? R: ");
                        break;
                    case "R":
                        num1 = random.Next(1, 51);
                        num2 = random.Next(1, num1 + 1); // Evita números negativos
                        resultadoCorrecto = num1 - num2;
                        Console.Write($"Pregunta {i}/5: ¿Cuánto es {num1} - {num2}? R: ");
                        break;
                    case "M":
                        num1 = random.Next(1, 11);
                        num2 = random.Next(1, 11);
                        resultadoCorrecto = num1 * num2;
                        Console.Write($"Pregunta {i}/5: ¿Cuánto es {num1} x {num2}? R: ");
                        break;
                    case "D":
                        do
                        {
                            num1 = random.Next(0, 101);
                            num2 = random.Next(1, 101);
                        } while (num1 % num2 != 0); // Asegura división entera exacta
                        resultadoCorrecto = num1 / num2;
                        Console.Write($"Pregunta {i}/5: ¿Cuánto es {num1} / {num2}? R: ");
                        break;
                }

                string entrada = (Console.ReadLine() ?? "").Trim();

                if (int.TryParse(entrada, out int respuestaUsuario))
                {
                    if (respuestaUsuario == resultadoCorrecto)
                    {
                        Console.WriteLine("¡Correcto! +1 punto.");
                        puntaje++;
                    }
                    else
                    {
                        Console.WriteLine($"Incorrecto. La respuesta era {resultadoCorrecto}.");
                    }
                }
                else
                {
                    Console.WriteLine($"Entrada no numérica. Cuenta como incorrecta. La respuesta era {resultadoCorrecto}.");
                }
            }

            Console.WriteLine($"\n¡Juego terminado! Obtuviste {puntaje} de 5 puntos en {nombreOperacion}.");

            // Guardar el registro automáticamente en el historial
            string registro = $"{DateTime.Now:dd/MM/yyyy HH:mm} | Modo: {nombreOperacion} | Puntaje: {puntaje}/5";
            historialPartidas.Add(registro);
        }
    }
}