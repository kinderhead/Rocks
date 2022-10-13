using Godot;
using System;

public class Background : Polygon2D
{
    public override void _Ready()
    {
        Color = Game.RockColor;
    }
}
