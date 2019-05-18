namespace Template
{

    class MyApplication
    {
        // member variables
        public Surface screen;
        public Ray ray = new Ray();
        public Light[] lights = new Light[3];
        bool occluced;
        public Primitives[] primitives = new Primitives[1];
        public float pixelColor; //de pixelkleur in float ipv integer voor de berekeningen

        // initialize
        public void Init()
        {
            //om te proberen definieer ik hier twee lichtpunten
            lights[0] = new Light
            {
                pX = 300,
                pY = 100, //x + y * width is de locatie van het licht (x,y) in de pixelarray
                color = MixColor(1, 1, 1)
            };
            lights[1] = new Light
            {
                pX = 200,
                pY = 50,
                color = MixColor(1, 1, 0)
            };
            lights[2] = new Light
            {
                pX = 100,
                pY = 26,
                color = MixColor(1, 1, 0)
            };

            // hieronder een lege primitive om de code werkend te maken.
            primitives[0] = new Primitives
            {
                centerX = 5,
                centerY = 30,
                radius = 100,
                PrimitivesType = PrimitivesType.Circle
            };

            //hieronder de basiscode uit de opdracht, vertaald naar c# code
            for (int x = 0; x < screen.pixels.Length; x++)
            {
                pixelColor = MixColor(0, 0, 0);

                for (int y = 0; y < lights.Length; y++)
                {
                    ray.O = ray.pixelPositions(x, screen.width);
                    ray.t = ray.distanceToLight(lights[y].pX, lights[y].pY);
                    ray.D = ray.normalizeDirectionToLight(lights[y].pX, lights[y].pY);
                    occluced = false;
                    for (int p = 0; p < primitives.Length; p++)
                    {
                        if (ray.intersects(primitives[p]))
                        {
                            occluced = true;
                        }
                    }
                    if (!occluced)
                    {
                        pixelColor += lights[y].color * ray.lightAttenuation(ray.t);
                    }
                }



                //gaat dit hieronder qua afronding goed?
                screen.pixels[x] = (int)pixelColor;
            }



        }
        // tick: renders one frame
        public void Tick()
        {
            // screen.Clear( 0 );
            //screen.Print("hello world", 2, 2, 0xffffff);
            //screen.Line(2, 20, 160, 20, 0xff0000);

            //screen.Bar(50, 50, 100, 100, 155);

        }

        int MixColor(int red, int green, int blue)
        {
            return (red << 16) + (green << 8) + blue;
        }


    }
}