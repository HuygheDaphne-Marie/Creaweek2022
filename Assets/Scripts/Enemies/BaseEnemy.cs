using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected string LayerName { get; private set; }
    protected int LayerID { get; private set; }
    protected BehaviourTree BehaviourTree { get; set; }
    protected Blackboard Blackboard { get; set; }

    private void Awake()
    {
        LayerID = LayerMask.GetMask(LayerName);
        Blackboard = new Blackboard();
    }

    private void Update()
    {
        BehaviourTree.Update();
    }
}