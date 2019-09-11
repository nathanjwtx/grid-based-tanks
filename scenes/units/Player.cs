using Godot;
using System;
using System.Collections.Generic;

public class Player : KinematicBody2D
{
    private bool _dragged = false;
    private Vector2 _current;
    private List<Vector2> _moves = new List<Vector2>();

    public override void _Ready()
    {
        // set initial position of unit
        _current = new Vector2((float)(Math.Floor(this.GetPosition().x / 64)) * 64 + 32,
            (float)(Math.Floor(this.GetPosition().y / 64) * 64 + 32));
        _moves.Add(_current);
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
        // GD.Print(GetParent().GetNode<TileMap>("TileMap").WorldToMap(mousePos));
        Vector2 tile = new Vector2((float)(Math.Floor(mousePos.x / 64)) * 64 + 32,
            (float)(Math.Floor(mousePos.y / 64) * 64 + 32));
        float priorX;
        float priorY;
        // GD.Print(tile);
        if (_moves.Count == 0)
        {
            _moves.Add(tile);
        }
        if (tile != _current)
        {
            _current = tile;
            priorX = _moves[_moves.Count - 1].x;
            priorY = _moves[_moves.Count - 1].y;
            this.Position = tile;
            if (_moves.IndexOf(_current) > -1)
            {
                _moves.RemoveAt(_moves.Count - 1);
            }
            else
            {
                _moves.Add(_current);
            }
            if (_moves.Count > 1)
            {
                var norm = (_current - _moves[_moves.Count - 1]).Normalized();
                GD.Print(norm);
                if (_current.x < priorX)
                {
                    this.SetRotationDegrees((float) 90);
                }
                else if (_current.x > priorX)
                {
                    this.SetRotationDegrees((float)-90);
                }
                else if (_current.y > priorY)
                {
                    this.SetRotationDegrees((float) 0);
                }
                else if (_current.y < priorY)
                {
                    this.SetRotationDegrees((float) 180);
                }
            }
        }

    }
}
