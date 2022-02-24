using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ConstantsNamespace{
public static class FieldDescription
{
    public static Vector3 HomeGoalCenter = new Vector3(0,0,-83);
    public static Vector3 AwayGoalCenter = new Vector3(0,0,83);
    public static Vector3 Center = new Vector3(0,0,0);
    public static float GoalWidth = 49.0f;
    public static float fieldWidth = 106.0f;
    public static float fieldLength = 77.0f;

    // Points of interest for the AI
    public static Vector3 homeDefenseCenter = new Vector3(0,0,-45);
    public static Vector3 homeDefenseLeft = new Vector3(-30,0,-65);
    public static Vector3 homeDefenseRight = new Vector3(30,0,-65);

    public static Vector3 homeMidCenter = new Vector3(0,0,-10);
    public static Vector3 homeMidLeft = new Vector3(-30,0,-10);
    public static Vector3 homeMidRight = new Vector3(30,0,-10);

    
    public static Vector3 homeAttackCenter = new Vector3(0,0,38);
    public static Vector3 homeAttackLeft = new Vector3(-30,0,38);
    public static Vector3 homeAttackRight = new Vector3(30,0,38);


    
    public static Vector3 awayDefenseCenter = -homeDefenseCenter;
    public static Vector3 awayDefenseLeft = -homeDefenseLeft;
    public static Vector3 awayDefenseRight = -homeDefenseRight;

    public static Vector3 awayMidCenter = -homeMidCenter;
    public static Vector3 awayMidLeft = -homeMidLeft;
    public static Vector3 awayMidRight = -homeMidRight;

    
    public static Vector3 awayAttackCenter = -homeAttackCenter;
    public static Vector3 awayAttackLeft = -homeAttackLeft;
    public static Vector3 awayAttackRight = -homeAttackRight;
}
}
