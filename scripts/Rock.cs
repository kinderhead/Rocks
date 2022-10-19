using Godot;
using System;
using System.Collections.Generic;

public enum RockTypes {
    RADIOACTIVE
}

public class Rock : Polygon2D
{
    [Export]
    public Color[] Colors = {};

    [Export]
    public RockTypes Type = RockTypes.RADIOACTIVE;

    public override void _Ready()
    {
        Color = Colors[new Random().Next(Colors.Length - 1)];
        Game.RockColor = Color;
    }

    public override void _Process(float delta)
    {
        
    }
}
