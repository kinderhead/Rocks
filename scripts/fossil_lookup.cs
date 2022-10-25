using Godot;
using System;

public class fossil_lookup : Node2D
{
    public override void _Ready()
    {
        if (Game.RockType == RockTypes.FOSSIL) GetNode<Sprite>("Fossil").Texture = Game.FossilTexture;
    }

    public override void _Process(float delta)
    {
        
    }

    private void Correct() {
        Game.Dating = false;
        GetNode<Button>("Container/Button2").Visible = true;
    }

    public void Leave() {
        GetTree().ChangeScene("res://main.tscn");
    }

    public void TrilobiteButton() {
        if (Game.RockType == RockTypes.FOSSIL && Game.FossilType == Fossil.Trilobite) Correct();
    }

    public void ZamiaButton() {
        if (Game.RockType == RockTypes.FOSSIL && Game.FossilType == Fossil.Zamia) Correct();
    }
}
