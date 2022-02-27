using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConstantsNamespace{
public static class FieldDescription
{
    public static Vector3 HOME_GOAL_CENTER = new Vector3(0,0,-83);
    public static Vector3 AWAY_GOAL_CENTER = -HOME_GOAL_CENTER;
    public static Vector3 CENTER = new Vector3(0,0,0);
    public static float GOAL_WIDTH = 49.0f;
    public static float FIELD_WIDTH = 106.0f;
    public static float FIELD_LENGTH = 166.0f;

    // Points of interest for the AI
    public static Vector3 HOME_DEFENSE_CENTER = new Vector3(0,0,-45);
    public static Vector3 HOME_DEFENSE_LEFT = new Vector3(-30,0,-65);
    public static Vector3 HOME_DEFENSE_RIGHT = new Vector3(30,0,-65);

    public static Vector3 HOME_MID_CENTER = new Vector3(0,0,-10);
    public static Vector3 HOME_MID_LEFT = new Vector3(-30,0,-10);
    public static Vector3 HOME_MID_RIGHT = new Vector3(30,0,-10);

    
    public static Vector3 HOME_ATTACK_CENTER = new Vector3(0,0,38);
    public static Vector3 HOME_ATTACK_LEFT = new Vector3(-30,0,38);
    public static Vector3 HOME_ATTACK_RIGHT = new Vector3(30,0,38);


    
    public static Vector3 AWAY_DEFENSE_CENTER = -HOME_DEFENSE_CENTER;
    public static Vector3 AWAY_DEFENSE_LEFT = -HOME_DEFENSE_LEFT;
    public static Vector3 AWAY_DEFENSE_RIGHT = -HOME_DEFENSE_RIGHT;

    public static Vector3 AWAY_MID_CENTER = -HOME_MID_CENTER;
    public static Vector3 AWAY_MID_LEFT = -HOME_MID_LEFT;
    public static Vector3 AWAY_MID_RIGHT = -HOME_MID_RIGHT;

    
    public static Vector3 AWAY_ATTACK_CENTER = -HOME_ATTACK_CENTER;
    public static Vector3 AWAY_ATTACK_LEFT = -HOME_ATTACK_LEFT;
    public static Vector3 AWAY_ATTACK_RIGHT = -HOME_ATTACK_RIGHT;
}
}
