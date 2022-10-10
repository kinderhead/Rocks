using Godot;
using System;
using System.Collections.Generic;

public class Rock : Polygon2D
{
    public override void _Ready()
    {
        var points = new List<Vector2>();

        points.Add(new Vector2(GD.RandRange(-250, -500), 0));
    }

    public override void _Process(float delta)
    {
        
    }
}
