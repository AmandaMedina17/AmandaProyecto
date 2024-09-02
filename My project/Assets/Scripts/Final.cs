using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class Final : claseMadre
{
    List<claseMadre> cartas;
    List<claseMadre> efectos;
    List<BaseCard> Cards;
    bool EjecutadaAnteriormente = false;
    string directory = "Assets\\Scripts\\Codigo\\";
    public static int UltimoEfecto = 0;

    public Final( List<claseMadre> cartas, List<claseMadre> efectos)
    {
        Cards = new List<BaseCard>();
        this.cartas = cartas;
        this.efectos = efectos;
    }

    public override bool Semantica()
    {
        if(!RevisarErrores(efectos)) return false;
        if(!RevisarErrores(cartas)) return false;
        return true;
    }

    static bool RevisarErrores(List<claseMadre> list)
    {
        bool noHayErrores = true; 

        for(int i =0; i<list.Count; i++)
        {
            try
            {
                if(!list[i].Semantica()) noHayErrores = false;
            }
            catch
            {
               noHayErrores = false;
            }
        }

        return noHayErrores;
    }

    public override void Ejecutar()
    {
        if(!EjecutadaAnteriormente)
        {
            int AnteriorCarta = Card.cartas.Count;
            foreach (var item in cartas) item.Ejecutar();
            Cards = Card.cartas.GetRange(AnteriorCarta, Card.cartas.Count - AnteriorCarta);
            EjecutadaAnteriormente = true;
            
            if(!CrearArchivo(Effect.efectosCreados, UltimoEfecto, "Effects", ".gwf")) System.Console.WriteLine("No se pudo declarar el efecto");
            if(!CrearArchivo(Card.cartasCreadas, AnteriorCarta, "Cards", ".gwc")) System.Console.WriteLine("No se pudo declarar el efecto");

            UltimoEfecto = Effect.efectosGuardados.Count;

        }

    }

    public bool CrearArchivo(Dictionary<string, string> declaracion, int start, string carpeta, string extension)
    {
        int Current = start;

        foreach (var item in declaracion)
        {
            if(start>0) start--;
            else if(File.Exists(directory + carpeta + item.Key + extension)) return false;

        }
        foreach (var item in declaracion)
        {
            if(Current > 0) Current--;
            else{
                StreamWriter code = new StreamWriter(directory + carpeta + item.Key + extension);
                code.WriteLine(item.Value);
                code.Close();
            }
        }

        return true;
    }

    public List<BaseCard> CreatedCards()
    {
        if(!EjecutadaAnteriormente) Ejecutar();
        return Cards;
    }
}