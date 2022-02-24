using UnityEngine;
using Aim;

namespace Moves
{
public class Move
{

    private GameObject player;
    private Vector3 target;
    private float playerSpeed;
    private Vector3 targetVel;

    public Move(GameObject player, Vector3 target, float playerSpeed, Vector3 targetVel)
    {
        this.player = player;
        this.target = target;
        this.playerSpeed = playerSpeed;
        this.targetVel = targetVel;
    }

    public Move(GameObject player, Vector3 target, float playerSpeed)
    {
        this.player = player;
        this.target = target;
        this.playerSpeed = playerSpeed;
        targetVel = Vector3.zero;
    }

    public void execute()
    {
        Vector3 playerPosition = player.transform.position;
        AimCalculator aimCalculator = new AimCalculator(playerPosition, target, targetVel);
        Vector3 moveDirection = aimCalculator.getOptimalDirection(playerSpeed);
        player.GetComponent<Rigidbody>().velocity = playerSpeed * moveDirection;
    }
}
}