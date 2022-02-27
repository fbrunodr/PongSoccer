using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using ConstantsNamespace;
using PerceptionNamespace;
using Moves;

namespace AInamespace{
public class AI4x4 : AI
{
    public AI4x4(List<GameObject> players, List<GameObject> oponents, GameObject ball) :
    base(players, oponents, ball){}

    protected override float chooseTimeToNextMove()
    {
        Perception see = new Perception(players, oponents, ball);
        if(see.isCloseToOtherGoalArea(ball) && see.ballGoingToOwnGoal())
            return Random.Range(GameConstants.MAX_TIME*0.25f, GameConstants.MAX_TIME*0.3f);
        else if(see.isCloseToOwnGoalArea(ball))
            return Random.Range(GameConstants.MAX_TIME*0.15f, GameConstants.MAX_TIME*0.3f);
        else if(see.isOnDefense(ball))
            return Random.Range(GameConstants.MAX_TIME*0.15f, GameConstants.MAX_TIME*0.5f);
        else if(see.isOnMidLength(ball))
            return Random.Range(GameConstants.MAX_TIME*0.2f, GameConstants.MAX_TIME*0.8f);
        else
            return Random.Range(GameConstants.MAX_TIME*0.3f, GameConstants.MAX_TIME*1.0f);
    }

    protected override float getMaxSpeed(float timeOfMove)
    {
        return GameConstants.MAX_SPEED * timeOfMove / GameConstants.MAX_TIME;
    }

    protected override Move chooseMove(float maxSpeed)
    {
        Perception see = new Perception(players, oponents, ball);
        GameObject keeper = see.getKeeper();
        List<GameObject> outfields = see.getNonKeepers();

        Vector3 ballPos = ball.transform.position;
        Vector3 ballVel = ball.GetComponent<Rigidbody>().velocity;

        // Critical state
        if(see.ballGoingToOwnGoal() && see.isCloseToOwnGoalArea(ball))
            return new Move(keeper, ballPos, maxSpeed, ballVel);

        // Keeper away from goal
        if(see.isFarFromPoint(keeper, FieldDescription.AWAY_GOAL_CENTER))
            return new Move(keeper, FieldDescription.AWAY_GOAL_CENTER, Mathf.Min(20, maxSpeed));

        // Defense
        if(see.ballGoingToOwnGoal() && outfields.Any(outfield => see.isBeforePoint(outfield, ballPos)))
        {
            GameObject chosenPlayer = getAny(outfields.FindAll(outfield => see.isBeforePoint(outfield, ballPos)));
            return new Move(chosenPlayer, ballPos, maxSpeed, ballVel);
        }

        // Attack
        if(see.isOnAttack(ball) && outfields.Any(outfield => see.alignedWithBallAndOtherGoal(outfield)))
        {
            GameObject chosenPlayer = getAny(outfields.FindAll(outfield => see.alignedWithBallAndOtherGoal(outfield)));
            return new Move(chosenPlayer, ballPos, maxSpeed, ballVel);
        }

        // Positioning
        GameObject attacker = outfields[0];
        foreach(GameObject outfield in outfields)
            if(outfield.transform.position.z < attacker.transform.position.z)
                attacker = outfield;

        GameObject leftWinger = outfields[0];
        foreach(GameObject outfield in outfields)
            if(outfield.transform.position.x > leftWinger.transform.position.x)
                leftWinger = outfield;

        GameObject rightWinger = outfields[0];
        foreach(GameObject outfield in outfields)
            if(outfield.transform.position.x < rightWinger.transform.position.x)
                rightWinger = outfield;

        GameObject centerBack = outfields[0];
        foreach(GameObject outfield in outfields)
            if(outfield.transform.position.z > centerBack.transform.position.x)
                centerBack = outfield;


        List<Move> possibleMoves = new List<Move>();
        if(see.isOnAttack(ball))
        {
            if(!see.isOnAttack(attacker))
                possibleMoves.Add(new Move(attacker, ballPos, maxSpeed, ballVel));
            if(see.isFarFromPoint(rightWinger, FieldDescription.AWAY_MID_RIGHT))
                possibleMoves.Add(new Move(rightWinger, FieldDescription.AWAY_MID_RIGHT, Mathf.Min(15, maxSpeed)));
            if(see.isFarFromPoint(leftWinger, FieldDescription.AWAY_MID_LEFT))
                possibleMoves.Add(new Move(leftWinger, FieldDescription.AWAY_MID_LEFT, Mathf.Min(15, maxSpeed)));
        }
        else
        {
            if(!see.isOnDefense(rightWinger))
                possibleMoves.Add(new Move(rightWinger, FieldDescription.AWAY_ATTACK_RIGHT, Mathf.Min(30, maxSpeed)));
            if(!see.isOnDefense(leftWinger))
                possibleMoves.Add(new Move(leftWinger, FieldDescription.AWAY_DEFENSE_LEFT, Mathf.Min(30, maxSpeed)));
            if(!see.isOnDefense(centerBack) && !see.alignedWithBallAndOwnGoal(centerBack))
                possibleMoves.Add(new Move(centerBack, FieldDescription.AWAY_DEFENSE_CENTER, Mathf.Min(20, maxSpeed)));
        }

        foreach(GameObject outfield in outfields.FindAll(outfield => see.isBeforePoint(outfield, ballPos)))
            possibleMoves.Add(new Move(outfield, ballPos, maxSpeed, ballVel));

        if(possibleMoves.Count == 0)
            possibleMoves.Add(new Move(keeper, FieldDescription.AWAY_GOAL_CENTER, Mathf.Min(10, maxSpeed)));

        return getAny(possibleMoves);
    }

    private GameObject getAny(List<GameObject> objects)
    {
        return objects[Random.Range(0, objects.Count)];
    }

    private Move getAny(List<Move> moves)
    {
        return moves[Random.Range(0, moves.Count)];
    }

}
}
