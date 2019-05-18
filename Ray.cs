using OpenTK;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics; //nodig voor vector
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2 = System.Numerics.Vector2;

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
            if (primitive.PrimitivesType == PrimitivesType.Circle)
            {
                // Richtingsvector van het middelpunt cirkel naar huidige pixel.
                Point pos = new Point(primitive.centerX, primitive.centerY);

                float cX = pos.X - O.X;
                float cY = pos.Y - O.Y;

                Vector2 c = new Vector2(cY, cX);

                // Het component van vector c op de richtingsvector naar het lichtpunt. 
                // variabele t uit de sheets L5;43 hernoemd naar m, omdat t al wordt gebruikt als ray.t
                float m = Vector2.Dot(c, D);
                
                Vector2 q = c - m * D;

                // De lengte van vector Q.
                float p2 = Vector2.Dot(q, q);

                // In dit geval zijn er geen snijpunten:
                double radius2 = Math.Pow(primitive.radius, 2);
                if (p2 > radius2) {
                    return false;          
                }

                // Het punt wanneer de ray de cirkel raakt. 
                m -= (float)Math.Sqrt(radius2 - p2);

                // Als
                if ((m < t) && (m > 0))
                {
                    t = m;
                    return true;
                } 
                
            }

            // Als er geen primitives bestaan dan is er ook geen intersectie.
            return false;

            //hier berekenen of de ray de gegeven primitive snijdt
            //ik return nu true om foutmeldingen te voorkomen, dit moet nog veranderd
           
        }

        public float lightAttenuation(float distance)
        {
            //ik return nu 0.5, maar dat moet nog aangepast
            //we willen hier de afzwakking van het licht aan de hand van de afstand van de pixel naar het licht
            float attenuationFactor = 1 / (distance * distance);
            return attenuationFactor;
        }

    }
}
