using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected string LayerName { get; private set; }
    protected int LayerID { get; private set; }
    protected BehaviourTree BehaviourTree { get; set; }
    protected Blackboard Blackboard { get; set; }
    protected NavMeshAgent NavMeshAgent { get; set; }

    private void Awake()
    {
        LayerID = LayerMask.GetMask(LayerName);
        Blackboard = new Blackboard();
        NavMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        Blackboard.AddData("ThisEnemy", gameObject);
        Blackboard.AddData("MoveTarget", Vector3.zero);
        Blackboard.AddData("ThisAgent", NavMeshAgent);
    }

    private void Update()
    {
        BehaviourTree.Update();
    }
}