using Godot;
using System;
using System.Collections.Generic;

public class map : Node2D
{
    private bool _mousePressed;
    private Vector2 _current;
    private TileMap _terrain;
    private Dictionary<string, int> _terrainValues = new Dictionary<string, int>();
    private int _movement;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _mousePressed = false;
        _movement = 0;
        _terrain = GetNode<TileMap>("terrain");
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
            GetTiles();
        }
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton)
        {
            if (@event.IsPressed())
            {
                _mousePressed = true;
                GD.Print(true);
                GetTiles();
            }
            else
            {
                _mousePressed = false;
                GD.Print(false);
            }
        }
    }

    private void GetTiles()
    {
        Vector2 mp = GetViewport().GetMousePosition();
        Vector2 tile = new Vector2((float)(Math.Floor(mp.x / 64)), (float)Math.Floor(mp.y / 64));
        if (tile != _current)
        {
            _current = tile;
            // GD.Print(_current);
            int id = _terrain.GetCellv(_current);
            string tileType = _terrain.TileSet.TileGetName(id);
            int tileValue = _terrainValues[tileType.Left(tileType.Find("_"))];
            GD.Print(tileValue);
        }
    }

}
