using Godot;
using System;

public struct AtomType {
    public string Name;
    public Color Color;

    public AtomType(string name, Color color) {
        Name = name;
        Color = color;
    }

    public static bool operator ==(AtomType a, AtomType b) {
        return a.Name == b.Name;
    }

    public static bool operator !=(AtomType a, AtomType b) {
        return !(a == b);
    }

    public bool Equals(AtomType obj)
    {
        return this == obj;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static AtomType K = new AtomType("K", new Color(.63f, .63f, .63f));
    public static AtomType Ar = new AtomType("Ar", new Color(.71f, .12f, .4f));
    public static AtomType U = new AtomType("U", new Color(.38f, .72f, .4f));
    public static AtomType Pb = new AtomType("Pb", new Color(.35f, .35f, .35f));
}

public class atom : Sprite
{
    public static AtomType[][] TypePairs = {
        new AtomType[]{AtomType.K, AtomType.Ar},
        new AtomType[]{AtomType.U, AtomType.Pb}
    };

    public static double UraniumDecayConstant = 4500000000;
    public static double PotassiumDecayConstant = 1300000000;

    public AtomType AtomType;

    public override void _Ready()
    {
        
    }

    public override void _Process(float delta)
    {
        
    }

    public void SetAtomType(AtomType type) {
        Modulate = type.Color;
        var label = GetNode<Label>("Label");

        label.Text = type.Name;
        label.Modulate = new Color(1 - type.Color.r, 1 - type.Color.g, 1 - type.Color.b);

        AtomType = type;
    }
}
