using Godot;
using System;

public class radioactive : Node2D
{
    [Export]
    public PackedScene Atom;

    private int atom1;
    private int atom2;

    public async override void _Ready()
    {
        Setup();

        GetNode<Tween>("Tween").InterpolateProperty(GetNode<Camera2D>("Camera2D"), "zoom", GetNode<Camera2D>("Camera2D").Zoom, new Vector2(1, 1), 2, Tween.TransitionType.Quint, Tween.EaseType.Out);
        GetNode<Tween>("Tween").Start();

        await ToSignal(GetTree().CreateTimer(2), "timeout");
    }

    public override void _Process(float delta)
    {

    }

    public void Setup()
    {
        var rand = new Random();

        AtomType[] pair = atom.TypePairs[rand.Next(atom.TypePairs.Length)];

        float ratio = (float) rand.Next(25, 50) / 100f;

        int amount = rand.Next(20, 30);

        atom1 = (int)(amount - (amount*ratio));
        atom2 = (int)(amount*ratio);

        GD.Print("Ratio: " + ratio + ", atom1: " + atom1 + ", atom2: " + atom2);

        for (int i = 0; i < atom1; i++)
        {
            CreateAtom(pair[0]);
        }

        for (int i = 0; i < atom2; i++)
        {
            CreateAtom(pair[1]);
        }
    }

    public void CreateAtom(AtomType type) {
        var rand = new Random();

        atom atom = Atom.Instance<atom>();
        atom.SetAtomType(type);
        atom.Position = new Vector2(rand.Next(30, 750) - 500, rand.Next(30, 550) - 250);
        AddChild(atom);
    }
}
