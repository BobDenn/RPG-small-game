using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Clone_Skill : Skill
{
    [Header("Clone info")]
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private float cloneDuration;

    [SerializeField] private bool canAttack;

    // you can create clone when you start to use dash or dash state is finished
    [SerializeField] private bool createCloneOnDashStart;
    [SerializeField] private bool createCloneOnDashOver;
    

    public void CreateClone(Transform _clonePosition, Vector3 offset)
    {

        // I don't know how to use Instantiate
        GameObject newClone = Instantiate(clonePrefab);

        // clone's position
        newClone.GetComponent<Clone_Skill_Controller>().SetupClone(_clonePosition, cloneDuration, canAttack, offset, FindClosestEnemy(newClone.transform));
    }

    public void CreateCloneOnDashStart()
    {
        if (createCloneOnDashStart)
            CreateClone(player.transform, Vector3.zero);
    }
    public void CreateCloneOnDashOver()
    {
        if (createCloneOnDashOver)
            CreateClone(player.transform, Vector3.zero);
    }

}
