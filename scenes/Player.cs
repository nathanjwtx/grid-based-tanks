using Godot;
using System;
using System.Collections.Generic;

public class Player : Node2D
{
    private bool _dragged = false;
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
                this.Position = mouseMoved.GetPosition();
            }   
        }
    }

    private void SelectedTank()
    {
        
    }
}
