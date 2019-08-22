using Godot;
using System;

public class Player : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private bool _mousePressed = false;
    private Vector2 _current;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        if (_mousePressed)
        {
            MoveTank();
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton)
        {
            if (@event.IsPressed())
            {
                _mousePressed = true;
            }
        }
    }

    public void MoveTank()
    {
        Vector2 mp = GetViewport().GetMousePosition();
        Vector2 tile = new Vector2((float)(Math.Floor(mp.x / 64)),
            (float)(Math.Floor(mp.y / 64)));
        if (tile != _current)
        {
            _current = tile;
            GD.Print(this.GetGlobalPosition());
            this.Position = new Vector2(32 + _current.x * 64, 32 + _current.y * 64);
        }
    }
}
