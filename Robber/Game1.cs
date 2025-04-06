﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Robber;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _stars;
    private Texture2D _sheep;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        Console.WriteLine("init game");
        base.Initialize();
    }

    protected override void LoadContent()
    {
        Console.WriteLine("chargement contenu");
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _stars = Content.Load<Texture2D>("stars");
        _sheep = Content.Load<Texture2D>("sheep");
        Console.WriteLine("etoiles charges");

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        Console.WriteLine("update logic");
        base.Update(gameTime);

    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _spriteBatch.Begin();

        _spriteBatch.Draw(_stars, new Rectangle(0, 0, 800, 480), Color.White);
        _spriteBatch.Draw(_sheep, new Rectangle(0, 0, 800, 480), Color.White);

        _spriteBatch.End();
        Console.WriteLine("draw...");

        base.Draw(gameTime);
    }
}
