using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField] protected string LayerName { get; private set; }
    [SerializeField] protected int Speed { get; set; }
    protected int LayerID { get; private set; }
    protected BehaviourTree BehaviourTree { get; set; }
    protected Blackboard Blackboard { get; set; }
    protected CharacterController CharacterController { get; private set; }

    private void Awake()
    {
        LayerID = LayerMask.GetMask(LayerName);
        Blackboard = new Blackboard();
        CharacterController = gameObject.GetComponent<CharacterController>();
    }

    private void Start()
    {
        Blackboard.AddData("ThisEnemy", gameObject);
        Blackboard.AddData("MoveTarget", Vector3.zero);
        Blackboard.AddData("EnemyCharacterController", CharacterController);
        Blackboard.AddData("EnemySpeed", Speed);
    }

    private void Update()
    {
        BehaviourTree.Update();
    }
}