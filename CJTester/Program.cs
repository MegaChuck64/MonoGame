using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CJTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entering Game...");
            using var game1 = new TestGame();
            game1.Run();
            //Task.Run(() =>
            //{
            //    game1.Run();
            //});
            //Thread.Sleep(4000);
            //Task.Run(() =>
            //{
            //    game1.Run();
            //});
            

            //Task.Run(() =>
            //{
            //    using var game2 = new TestGame();
            //    //game2.Run();
            //    while (!game2.IsExiting)
            //    {
            //        game2.RunOneFrame();
            //    }
            //    game2.Exit();
            //});
            //game.Exit();
            //Console.Read();
            Console.WriteLine("Exiting Game...");

        }
    }

    public class TestGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch = null!;
        private Texture2D _texture = null!;
        private SpriteFont _font = null!;
        public bool IsExiting { get; private set; } = false;
        public TestGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _texture = Texture2D.FromFile(GraphicsDevice, Path.Combine("Content", "Sprites", "test.png"));
            _font = Content.Load<SpriteFont>(Path.Combine("Fonts", "font_18"));
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            var fps = 1f/(float)gameTime.ElapsedGameTime.TotalSeconds;
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            _spriteBatch.Draw(_texture, new Vector2(100, 100), Color.White);
            _spriteBatch.DrawString(_font, $"FPS: {fps}", new Vector2(2, 2), Color.Red);
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
