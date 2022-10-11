using Godot;
using System;
using System.Collections.Generic;

public class Rock : Polygon2D
{
    [Export]
    public Color[] Colors = {};

    public override void _Ready()
    {
        Color = Colors[new Random().Next(Colors.Length)];
    }

    public override void _Process(float delta)
    {
        
    }
}
