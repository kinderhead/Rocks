using Godot;
using System;

public class radioactive : Node2D
{
    [Export]
    public PackedScene Atom;

    private int atom1;
    private int atom2;
    private double constant;

    public async override void _Ready()
    {
        if (Game.RockType == RockTypes.RADIOACTIVE) {
            Setup();
        }
        else {
            GetNode<Button>("Gui/Button").Disabled = true;
        }

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

        if (pair[0] == AtomType.U) {
            constant = atom.UraniumDecayConstant;
        } else {
            constant = atom.PotassiumDecayConstant;
        }

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

    public void Finish() {
        int amount1 = (int) GetNode<SpinBox>("Gui/Radioactive").Value;
        int amount2 = (int) GetNode<SpinBox>("Gui/Stable").Value;

        double age = CalculateAge(amount1, amount2, constant);
        GD.Print("Guess | atom1: " + amount1 + ", atom2: " + amount2 + ", age: " + age + ", constant: " + constant);

        if (amount1 != atom1 || amount2 != atom2) {
            GetNode<Label>("Gui/Result").Text = "Incorrect, try again";
            return;
        }
        
        GetNode<Label>("Gui/Result").Text = "Correct, this rock is about " + String.Format("{0:n0}", age) + " years old.";
        Game.Dating = false;
    }

    public void NextRock() {
        GetTree().ChangeScene("main.tscn");
    }

    public static double CalculateAge(double atom1, double atom2, double constant) {
        GD.Print(atom2+atom1);
        GD.Print(Math.Log(atom2/atom1));
        GD.Print(constant * Math.Log(atom2/atom1));
        GD.Print(Math.Log(.5));
        return ((constant * Math.Log(atom1/(atom2+atom1))) / Math.Log(.5));
    }
}
