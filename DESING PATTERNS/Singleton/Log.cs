// Si selle ga a necesitar pasar un parámetro por constructor:
public sealed class Log
{
    private static readonly Log _instance = null;
    private string _path;
    // Para proteger y evitar la creación de dos instancias en caso de que se entén usando Threads (Hilos)
    private static object _protect = new object();

    public static Log GetInstance(string path)
    {
        // Se aplica la protección (Sólo deja entrar un hilo a la vez)
        lock (_protect)
        {
            if (_instance == null)
            {
                _instance = new Log();
            }
        }

        return _instance;
    }

    private Log(string path) {
        _path = path;
    }

    public void Save(string message)
    {
        File.AppendAllText(_path, message + Enviroment.NewLine);
    }
}

// NOTAR QUE ES FUNCIONAL Y PARA AGREGAR UNA NUEVA LÍNEA AL LOG SE HACE DE LA SIGUIENTE MANERA
Log.GetInstance("log.txt").Save("Primera línea del log");