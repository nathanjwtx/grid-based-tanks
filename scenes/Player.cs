using Godot;
using System;
using System.Collections.Generic;

public class Player : Node2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    private bool _mousePressed = false;
    private Vector2 _current;
    private TileMap _terrain;
    private Dictionary<string, int> _terrainValues = new Dictionary<string, int>();
    private List<int> _movement = new List<int>();
    private List<Vector2> _moves = new List<Vector2>();

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _mousePressed = false;
        _terrain = GetParent().GetNode<TileMap>("terrain");
        _terrainValues.Add("grass", 20);
        _terrainValues.Add("straight", 10);
        _terrainValues.Add("bend", 10);
        _terrainValues.Add("cross", 10);
        _terrainValues.Add("tee", 10);
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
                MoveTank();
            }
            else
            {
                _mousePressed = false;
            }
        }
    }

    public void MoveTank()
    {
        Vector2 mp = GetViewport().GetMousePosition();
        Vector2 tile = new Vector2((float)(Math.Floor(mp.x / 64)),
            (float)(Math.Floor(mp.y / 64)));
        if (_moves.Count == 0)
        {
            _moves.Add(_current);
        }
        if (tile != _current)
        {
            _current = tile;
            // GD.Print(this.GetGlobalPosition());
            this.Position = new Vector2(32 + _current.x * 64, 32 + _current.y * 64);
            int id = _terrain.GetCellv(_current);
            string tileType = _terrain.TileSet.TileGetName(id);
            int tileValue = _terrainValues[tileType.Left(tileType.Find("_"))];
            
            
            if (_moves.IndexOf(_current) > -1)
            {
                // GD.Print("match");
                _moves.RemoveAt(_moves.Count - 1);
                _movement.RemoveAt(_movement.Count - 1);
            }
            else
            {
                // GD.Print("no match");
                _moves.Add(_current);
                _movement.Add(tileValue);
            }

            if (_moves.Count > 0)
            {
                float priorX = _moves[_moves.Count - 2].x;
                float priorY = _moves[_moves.Count- 2].y;
                // GD.Print($"Count: {_moves.Count}");
                // GD.Print($"Prev: {_moves[_moves.Count - 2]}");
                if (priorX - _current.x == 1)
                {
                    this.SetRotationDegrees((float)-90.0);
                }
                // else if (
            }

            foreach (Vector2 v in _moves)
            {
                GD.Print(v);
            }
        }
    }

    private int CalculateMovement()
    {
        int total = 0;
        foreach (int s in _movement)
        {
            total += s;
        }
        return total;
    }
}
