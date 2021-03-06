﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace karakutu
{
    class Button
    {
        public Texture2D texture;
        public Rectangle rectangle;
        Vector2 position;
        Color colour = new Color(255, 255, 255, 255);
        public Vector2 size;


        public Button(Texture2D newTexture, GraphicsDevice graphics)
        {
            texture = newTexture;

            size = new Vector2(texture.Width, texture.Height);
        }

        bool down;
        public bool isClicked;
        public void Update(MouseState mouse)
        {
            rectangle = new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            Rectangle mouseRectangle = new Rectangle(mouse.X, mouse.Y, 1, 1);
            if (mouseRectangle.Intersects(rectangle))
            {
                if (colour.A == 255) down = false;
                if (colour.A == 0) down = true;
                if (down) colour.A += 3; else colour.A -= 3;
                if (mouse.LeftButton == ButtonState.Pressed) isClicked = true;
            }
            else if (colour.A < 255)
            {
                colour.A += 3;
                isClicked = false;
            }
        }
        public void setPosition(Vector2 newPosition)
        {
            position = newPosition;
        }
        public void setSize(Vector2 newSize)
        {
            size = newSize;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, colour);
        }
    }
}
