using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Template
{
    class Ray
    {
        public Point O = new Point(); //dit moet een (x,y) punt worden
        public Vector2 D = new Vector2(); //dit moet een vector worden
        public float t;

    //er staan een hele hoop functies hieronder,
    //ik weet niet zeker of het handig is ze hier neer te zetten of gewoon in MyApplication
    //de functie "intersects" moet sowieso wel in deze class.

    public Point pixelPositions(int positionX, int positionY)
    {
            //pos is van de vorm (bijvoorbeeld): 200 + 50 * screen.width
            //we willen (denk ik) iets van de vorm (x,y) terug, dus we willen die 200 en 50 bepalen.
            //merk op: x is altijd kleiner dan screen.width, dus x is de rest bij deling.
            return new Point(positionX, positionY);
    }

    public Vector2 normalizeDirectionToLight(Point point1)
    {
            //Dit moet een vector returnen, we moeten of zelf een vector struct aanmaken (en dan optellen en vermenigvuldigen en alles definieren)
            //of eentje van google zoeken

            int x = point1.X;
            int y = point1.Y;
            Vector2 vector = new Vector2(x, y);
            vector.Normalize();
            return vector;
    }

    public float distanceToLight(Vector2 vector1)
    {
            // bereken de afstand van het lichtpunt naar O (denk ik)
            // ik return nu 10 om foutmeldingen te voorkomen, dit moet nog veranderd
            float length = vector1.Length;
            return length;
    }

    public bool intersects(Primitives primitive)
    {
        

        //hier berekenen of de ray de gegeven primitive snijdt
        //ik return nu true om foutmeldingen te voorkomen, dit moet nog veranderd
        return true;
    }

    public float lightAttenuation(float distance)
    {
        //ik return nu 0.5, maar dat moet nog aangepast
        //we willen hier de afzwakking van het licht aan de hand van de afstand van de pixel naar het licht
        return 0.5f;
    }
}
}
