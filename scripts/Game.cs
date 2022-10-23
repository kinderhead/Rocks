using Godot;
using System;

public class Game : Node2D
{
    [Export]
    public PackedScene Rock;

    public static bool Dating = false;
    public static Color RockColor;

    public override void _Ready()
    {
        if (!Dating) NewRock();
    }

    public override void _Process(float delta)
    {
        
    }

    public void NewRock()
    {
        Dating = true;
        var rock = Rock.Instance<Rock>();
        AddChild(rock);
    }

    public async void Pressed() {
        var camera = GetNode<Camera2D>("Camera2D");

        GetNode<Tween>("Tween").InterpolateProperty(camera, "zoom", camera.Zoom, new Vector2(.001f, .001f), 2, Tween.TransitionType.Quint, Tween.EaseType.InOut);
        GetNode<Tween>("Tween").Start();

        await ToSignal(GetTree().CreateTimer(2), "timeout");

        GetTree().ChangeScene("res://radioactive.tscn");
    }
}
