using Godot;
using System;

public class information : Button
{
    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        if (Pressed) {
            GetTree().ChangeScene("res://info.tscn");
        }
    }
}
