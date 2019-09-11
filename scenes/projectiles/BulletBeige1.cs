using Godot;
using System;

public class BulletBeige1 : ProjectileMain
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

    private void _on_Lifetime_timeout()
    {
        GD.Print("Timer finished");
    }
}


    
