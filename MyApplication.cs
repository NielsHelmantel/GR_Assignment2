namespace Template
{

	class MyApplication
	{
		// member variables
		public Surface screen;
        public Sprite sprite;
        public Ray ray;
        public [] light;
		
        // initialize
		public void Init()
		{

            for(int m = 0; m )

            for(int x = 0; x < screen.pixels.Length; x++)
            {
                screen.pixels[x] = MixColor(0,0,0);

                for(int y = 0; y < light.Length; y++)
                {

                }
            }

            

		}
		// tick: renders one frame
		public void Tick()
		{
			// screen.Clear( 0 );
			screen.Print( "hello world", 2, 2, 0xffffff );
			screen.Line( 2, 20, 160, 20, 0xff0000 );

            screen.Bar(50, 50, 100, 100, 155);

        }

        int MixColor(int red, int green, int blue)
        {
            return (red << 16) + (green << 8) + blue;
        }

    }
}