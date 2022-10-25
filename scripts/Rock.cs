using Godot;
using System;
using System.Collections.Generic;

public enum RockTypes {
    RADIOACTIVE,
    FOSSIL
}

public class Rock : Polygon2D
{
    [Export]
    public Color[] Colors = {};

    [Export]
    public RockTypes Type = RockTypes.RADIOACTIVE;

    public override void _Ready()
    {
        if (!Game.Dating) {
            GD.Print("Creating new rock " + new Random().Next(0, 2));
            Color = Colors[new Random().Next(Colors.Length)];
            
            if (new Random().Next(0, 2) == 0) {
                Type = RockTypes.RADIOACTIVE;
            }
            else {
                Type = RockTypes.FOSSIL;
            }

            Game.RockColor = Color;
            Game.RockType = Type;
        }
    }

    public override void _Process(float delta)
    {
        
    }
}
