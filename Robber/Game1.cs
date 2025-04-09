using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Robber;

public class Game1 : Game
{
    private bool _isAlreadyPressed = false;
    private int increm = 200;

    private float speed_perso = 0;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _stars;
    private Texture2D _sheep;
    private Texture2D _ob;
    private Texture2D _oob;
    private Texture2D _persomoi;

    private Vector2 _sheepPosition;

    public Game1()
    {
        Window.AllowUserResizing = true;
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        //Console.WriteLine("init game");
        base.Initialize();
    }

    protected override void LoadContent()
    {
        //Console.WriteLine("chargement contenu");
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _stars = Content.Load<Texture2D>("stars");
        _sheep = Content.Load<Texture2D>("sheep");
        _ob = Content.Load<Texture2D>("ob");
        _oob = Content.Load<Texture2D>("oob");
        _persomoi = Content.Load<Texture2D>("persomoi");

        _sheepPosition = new Vector2(200, 200); // valeur par défaut

        //Console.WriteLine("etoiles charges");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        increm--;

        MouseState mouseState = Mouse.GetState();
        _sheepPosition = new Vector2(mouseState.X, mouseState.Y);
        //Console.WriteLine($"Souris : X = {mouseState.X}, Y = {mouseState.Y}");

        speed_perso = (float)(speed_perso + 0.1);

        if (mouseState.LeftButton == ButtonState.Pressed)
        {
            if (!_isAlreadyPressed)
            {
                Console.WriteLine("Clic gauche détecté !");
                _isAlreadyPressed = true;
            }
        }
        else
        {
            // Le bouton est relâché → prêt à détecter un nouveau clic
            _isAlreadyPressed = false;
        }


        // TODO: Add your update logic here
        //Console.WriteLine("boucle");
        base.Update(gameTime);

    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        // TODO: Add your drawing code here

        _spriteBatch.Begin();
        //Console.WriteLine(increm);
        int width = GraphicsDevice.Viewport.Width;
        int height = GraphicsDevice.Viewport.Height;

        //_spriteBatch.Draw(_stars, new Rectangle(0, 0, width, height), Color.White);
        _spriteBatch.Draw(_ob, new Rectangle(0, 0, width, height), Color.White);
        _spriteBatch.Draw(_sheep, new Rectangle((int)_sheepPosition.X - 15, (int)_sheepPosition.Y - 15, 30, 30), Color.White);
        //_spriteBatch.Draw(_oob, new Rectangle(0, 0, width, height), Color.White);
        _spriteBatch.Draw(_persomoi, new Rectangle(0, 0, 32, 48), Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
