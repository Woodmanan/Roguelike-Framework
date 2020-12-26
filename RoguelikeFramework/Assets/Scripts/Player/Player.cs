﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : Monster
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeTurn()
    {
        if (InputTracking.HasNextAction())
        {
            switch (InputTracking.PopNextAction())
            {
                //Handle Movement code
                case PlayerAction.MOVE_UP:
                    AttemptMovement(Direction.NORTH);
                    break;
                case PlayerAction.MOVE_DOWN:
                    AttemptMovement(Direction.SOUTH);
                    break;
                case PlayerAction.MOVE_LEFT:
                    AttemptMovement(Direction.WEST);
                    break;
                case PlayerAction.MOVE_RIGHT:
                    AttemptMovement(Direction.EAST);
                    break;
                case PlayerAction.MOVE_UP_LEFT:
                    AttemptMovement(Direction.NORTH_WEST);
                    break;
                case PlayerAction.MOVE_UP_RIGHT:
                    AttemptMovement(Direction.NORTH_EAST);
                    break;
                case PlayerAction.MOVE_DOWN_LEFT:
                    AttemptMovement(Direction.SOUTH_WEST);
                    break;
                case PlayerAction.MOVE_DOWN_RIGHT:
                    AttemptMovement(Direction.SOUTH_EAST);
                    break;
                
                //Handle potential error case (Thanks, Nethack design philosophy!)
                case PlayerAction.NONE:
                    Debug.LogError("Player read an input of NONE", this);
                    break;
                default:
                    Debug.LogError("Player read an input that matches no PlayerAction");
                    break;
            }
        }
    }

    /*
     * Attempt to move in a given direction. Does checks for if a wall is passable
     * and if a monster is standing there. If so, performs the necessary actions
     * or logs the messages.
     */ 
    private void AttemptMovement(Direction dir)
    {
        Vector2Int newLocation = GetUnitStep(dir);
        CustomTile tile = Map.singleton.GetTile(newLocation.x, newLocation.y);
        
        //Does tile have a monster? (Allows edge case for monster in wall)
        Monster target = tile.currentlyStanding;
        if (target)
        {
            //TODO: Actually attack monsters
            return;
        }
        
        //Is tile passable
        if (tile.BlocksMovement())
        {
            Logger.Log($"You bumped into a {tile.name}");
            return;
        }
        
        MoveUnit(dir);
        LOS.GeneratePlayerLOS(location, visionRadius);
    }
    
    


}