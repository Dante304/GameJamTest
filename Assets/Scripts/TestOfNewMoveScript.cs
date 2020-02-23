using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TestOfNewMoveScript : MonoBehaviour
{
    public List<AIDestinationSetter> listOfAiDestinationSetter;
    private List<Vector3> currentAgentPositions;

    void Start()
    {

    }

    void Update()
    {
        foreach (var item in listOfAiDestinationSetter)
        {
            currentAgentPositions.Add(item.transform.position);
        }

        var test = listOfAiDestinationSetter[0].target.position;
        // var test2 = PathUtilities.GetPointsAroundPoint(test, AstarPath.active.graphs[0], currentAgentPositions, 5, 5);

        var graph = AstarPath.active.graphs[0];
        PathUtilities.GetPointsAroundPoint(test, (IRaycastableGraph)graph, currentAgentPositions, 3.0f, 3.0f);

        for (int i = 0; i < currentAgentPositions.Count; i++)
        {
            listOfAiDestinationSetter[i].target.position = currentAgentPositions[0];
        }
    }
}
