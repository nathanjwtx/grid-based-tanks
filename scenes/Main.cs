using Godot;
using System;
using System.Collections.Generic;

public class Main : Node
{
    private Dictionary<Player, ValueTuple<Vector2, bool>> _playerInfo = new Dictionary<Player, (Vector2, bool)>();
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
       foreach (var t in GetTree().GetNodesInGroup("playerUnits"))
       {
           if (t is Player p)
           {

                Vector2 mp = p.GetPosition();
                Vector2 tile = new Vector2((float)(Math.Floor(mp.x / 64)), (float)Math.Floor(mp.y / 64));

               _playerInfo.Add(p, (tile, false));
           }
       } 
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        MousePos();       
    }
    public void MousePos()
    {
        
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent)
        {
            // GD.Print(mouseEvent.AsText());
            if (mouseEvent.ButtonMask == 1)
            {
                Vector2 mp = GetViewport().GetMousePosition();
                Vector2 tile = new Vector2((float)(Math.Floor(mp.x / 64)), (float)(Math.Floor(mp.y / 64)));
                // GD.Print(tile);
            }
        }
    }
}
