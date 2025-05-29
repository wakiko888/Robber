using System;
using System.Net.Http.Headers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Robber.new_class;

namespace Robber;

public class Game1 : Game
{

    private bool _isAlreadyPressed = false;
    private int increm = 200;
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _stars;
    private Texture2D _sheep;
    private Texture2D _ob;
    private Texture2D _oob;
    private Texture2D _persomoi;

    private Vector2 _sheepPosition;

    private int Wall_width = 100;

    private int Wall_Height = 20;

    private int Wall_X = 175;

    private int Wall_Y = 150;

    MainCharacter Mc = new();

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
        int width = GraphicsDevice.Viewport.Width;
        int height = GraphicsDevice.Viewport.Height;
        if (Mc.Ypos > height)
        {
            Mc.Ypos = 0;
        }
        if (Mc.Xpos > width)
        {
            Mc.Xpos = 0;
        }

        if (Mc.Xpos < -1)
        {
            Mc.Xpos = width;
        }
        KeyboardState keyboardState = Keyboard.GetState();

        if
        (
            Mc.Xpos < Wall_X + Wall_width &&
            Mc.Ypos < Wall_Y + Wall_Height &&
            Mc.Ypos > Wall_Y &&
            Mc.Xpos > Wall_X
        )
        {
            Console.WriteLine("dsfsedfwsf");
        }
        else
        {

        }

        if (keyboardState.IsKeyDown(Keys.A))
        {
            Mc.hor_speed = -10;
        }

        if (keyboardState.IsKeyDown(Keys.D))
        {
            Mc.hor_speed = 10;
        }

        //if (keyboardState.IsKeyDown(Keys.W))
        //{
        //    Mc.ver_speed = -10;
        //}

        //if (keyboardState.IsKeyDown(Keys.S))
        //{
        //    Mc.ver_speed = 10;
        //}

        if (keyboardState.IsKeyUp(Keys.A) && keyboardState.IsKeyUp(Keys.D))
        {
            Mc.hor_speed = 0;
        }

        //if (keyboardState.IsKeyUp(Keys.W) && keyboardState.IsKeyUp(Keys.S))
        //{
        //    Mc.ver_speed = 0;
        //}

        MouseState mouseState = Mouse.GetState();
        _sheepPosition = new Vector2(mouseState.X, mouseState.Y);
        //Console.WriteLine($"Souris : X = {mouseState.X}, Y = {mouseState.Y}");
        Mc.ver_speed = (float)(Mc.ver_speed + Mc.gravity);
        Mc.Ypos = Mc.Ypos + Mc.ver_speed;
        Mc.Xpos = Mc.Xpos + Mc.hor_speed;
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
        _spriteBatch.Draw(_persomoi, new Rectangle((int)Mc.Xpos, (int)(Mc.Ypos), Mc.Width_character, Mc.Height_character), Color.White);

        _spriteBatch.Draw(_persomoi, new Rectangle(Wall_X, Wall_Y, Wall_width, Wall_Height), Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
