using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;

    [SerializeField] private List<Objective> m_Objectives;

    [SerializeField] private List<ObjectiveTile> m_ObjectiveTiles;

    [SerializeField] private GameObject m_ObjectivePrefab;
    [SerializeField] private Transform m_Content;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        foreach (Objective objective in m_Objectives)
        {
            GameObject objectiveGO = Instantiate(m_ObjectivePrefab, m_Content);
            ObjectiveTile objectiveTile = objectiveGO.GetComponent<ObjectiveTile>();
            objectiveTile.SetObjective(objective);
            m_ObjectiveTiles.Add(objectiveTile);
        }
    }

    public void CompleteObjective(ObjectiveType objectiveType)
    {
        Objective objective = m_Objectives.Find(x => x.objectiveType == objectiveType);
        if (objective != null)
        {
            objective.isCompleted = true;
            m_ObjectiveTiles[m_Objectives.IndexOf(objective)].CompleteObjective(objective);
            
        }
    }
}
