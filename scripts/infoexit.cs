using Godot;
using System;

public class infoexit : Button
{
    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        if (Pressed) {
            GetTree().ChangeScene("res://title.tscn");
        }
    }
}
