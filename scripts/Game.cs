using Godot;
using System;
using System.Collections.Generic;

public enum Fossil {
    Trilobite,
    Zamia
}

public class Game : Node2D
{
    [Export]
    public PackedScene Rock;

    public static bool Dating = false;
    public static Color RockColor;
    public static RockTypes RockType;

    [Export]
    public Texture Trilobite;

    [Export]
    public Texture Zamia;

    public static Fossil FossilType;
    public static Texture FossilTexture;

    public override void _Ready()
    {
        NewRock();
    }

    public override void _Process(float delta)
    {
        if (Input.IsActionPressed("reload")) {
            Dating = false;
            NewRock();
        }
    }

    public void NewRock()
    {
        var rock = Rock.Instance<Rock>();
        AddChild(rock);

        if (Dating) {
            rock.Color = RockColor;
            rock.Type = RockType;
        }
        else {
            if (rock.Type == RockTypes.FOSSIL) {
                GD.Print("Creating fossil");

                var pairs = new List<Tuple<Fossil, Texture>>{new Tuple<Fossil, Texture>(Fossil.Trilobite, Trilobite), new Tuple<Fossil, Texture>(Fossil.Zamia, Zamia)};

                var choice = pairs[new Random().Next(pairs.Count)];
                FossilType = choice.Item1;
                FossilTexture = choice.Item2;
            }
            else {
                FossilTexture = null;
            }
        }

        GetNode<Sprite>("Fossil").Texture = FossilTexture;

        Dating = true;
    }

    public async void Pressed() {
        var camera = GetNode<Camera2D>("Camera2D");

        GetNode<Tween>("Tween").InterpolateProperty(camera, "zoom", camera.Zoom, new Vector2(.001f, .001f), 2, Tween.TransitionType.Quint, Tween.EaseType.InOut);
        GetNode<Tween>("Tween").Start();

        await ToSignal(GetTree().CreateTimer(2), "timeout");

        GetTree().ChangeScene("res://radioactive.tscn");
    }

    public void FossilLookup() {
        GetTree().ChangeScene("res://fossil_lookup.tscn");
    }

    public void MainMenu() {
        GetTree().ChangeScene("res://title.tscn");
    }
}
