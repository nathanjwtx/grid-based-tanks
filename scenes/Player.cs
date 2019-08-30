using Godot;
using System;
using System.Collections.Generic;

public class Player : Node2D
{
    private bool _dragged = false;
    private Vector2 _current;
    public override void _Ready()
    {
        GD.Print(this.GetPosition());
    }

    public override void _Process(float delta)
    {
        // SelectedTank();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent)
        {
            if ((mouseEvent.GetPosition() - this.GetPosition()).Length() < 32)
            {
                if (!_dragged & mouseEvent.ButtonMask == 1)
                {
                    _dragged = true;
                }
                else
                {
                    _dragged = false;
                }
            }   
        }
        if (@event is InputEventMouseMotion mouseMoved)
        {
            if (_dragged)
            {
                MoveTank(mouseMoved.GetPosition());
            }   
        }
    }

    private void MoveTank(Vector2 mousePos)
    {
        Vector2 tile = new Vector2((float)(Math.Floor(mousePos.x / 64)), 
            (float)(Math.Floor(mousePos.y / 64)));
        if (tile != _current)
        {
            _current = tile;
            this.Position = new Vector2(32 + _current.x * 64, 32 + _current.y * 64);
            
        }
    }
}
