using UnityEngine;
using System.Collections;

public static class ManejadorDeArchivos
{
    public static string LeerArchivo(string ruta)
    {
        string line;
        string respuesta = "";
        // Read the file and display it line by line.  
        System.IO.StreamReader file = new System.IO.StreamReader(ruta);
        while ((line = file.ReadLine()) != null)
        {
            respuesta += line;
        }
        file.Close();
        return respuesta;
    }
}
