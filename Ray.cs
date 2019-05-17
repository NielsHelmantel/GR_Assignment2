using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics; //nodig voor vector
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

        public Point pixelPositions(int pos, int screenwidth)
        {
            //pos is van de vorm (bijvoorbeeld): 200 + 50 * screen.width
            //we willen iets van de vorm (x,y) terug, dus we willen die 200 en 50 bepalen.
            //merk op: x is altijd kleiner dan screen.width, dus x is de rest bij deling.
            int positionX = pos % screenwidth;
            int positionY = (pos - positionX) / screenwidth;
            return new Point(positionX, positionY);
        }

        //distance from pixel to lightsource
        public float distanceToLight(int posXlight, int posYlight)
        {
            float x = (float)posXlight - O.X;
            float y = (float)posYlight - O.Y;
            float distance = (float)Math.Sqrt(x * x + y * y);
            return distance;
        }

        //direction vector from the given pixel to the given lightsource
        public Vector2 normalizeDirectionToLight(int posXlight, int posYlight)
        {
            float x = (float)posXlight - O.X;
            float y = (float)posYlight - O.Y;
            float vectorlength = t;
            float normalisedX = (1 / vectorlength) * x;
            float normalisedY = (1 / vectorlength) * y;
            Vector2 vector = new Vector2(normalisedX, normalisedY);
            return vector;
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
