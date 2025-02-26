using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandController : MonoBehaviour
{
    [SerializeField] private Robot robot;
    [SerializeField] private Graph graph;
    [SerializeField] private Vertice startVertice;

    private Queue<Command> _commandQueue = new Queue<Command>();
    private Vertice _currentDestination;
    
    private void Start()
    {
        _currentDestination = startVertice;
        
        List<Vertice> allVertices = new List<Vertice>();
        allVertices = graph.vertices;
        foreach (var vertice in allVertices)
        {
            vertice.OnClickListener += SetDestination;
        }
    }

    private void Update()
    {
        if (robot.isMoving)
            return;
        if (_commandQueue.Count == 0)
            return;
        Command nextCommand = _commandQueue.Dequeue();
        nextCommand.Execute();
    }

    private void SetDestination(Vertice destinationVertice)
    {
        Stack<Vertice> path = graph.GetPath(_currentDestination, destinationVertice);
        while (path.Count > 0)
        {
            Vertice nextVerticeToGo = path.Pop();
            MoveCommand moveCommand = new MoveCommand(robot, nextVerticeToGo.transform.position);
            _commandQueue.Enqueue(moveCommand);
        }
        _currentDestination = destinationVertice;
    }
}
