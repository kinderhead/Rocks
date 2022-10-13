using Godot;
using System;

public struct AtomType {
    public string Name;
    public Color Color;

    public AtomType(string name, Color color) {
        Name = name;
        Color = color;
    }
}

public class atom : Sprite
{
    [Export]
    public AtomType[] AtomTypes = {
        new AtomType("K", new Color(.63f, .63f, .63f))
    };

    private AtomType atomType;

    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        
    }

    public void SetAtomType(AtomType type) {
        Modulate = type.Color;
        GetNode<Label>("Label");
    }
}
