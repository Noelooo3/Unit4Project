using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    private Robot _robot;
    private Vector3 _destination;

    public MoveCommand(Robot robot, Vector3 destination)
    {
        _robot = robot;
        _destination = destination;
    }
    
    public override void Execute()
    {
        _robot.SetDestination(_destination);
    }
}
