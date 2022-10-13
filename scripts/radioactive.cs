using Godot;
using System;

public class radioactive : Node2D
{
    public async override void _Ready()
    {
        GetNode<Tween>("Tween").InterpolateProperty(GetNode<Camera2D>("Camera2D"), "zoom", GetNode<Camera2D>("Camera2D").Zoom, new Vector2(1, 1), 2, Tween.TransitionType.Quint, Tween.EaseType.Out);
        GetNode<Tween>("Tween").Start();

        await ToSignal(GetTree().CreateTimer(2), "timeout");

        GD.Print("Yay");
    }

    public override void _Process(float delta)
    {
        
    }
}
