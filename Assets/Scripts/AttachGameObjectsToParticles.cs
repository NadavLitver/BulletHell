using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class AttachGameObjectsToParticles : MonoBehaviour
{
    public GameObject m_Prefab;

    private ParticleSystem m_ParticleSystem;
    private List<GameObject> m_Instances = new List<GameObject>();
    private ParticleSystem.Particle[] m_Particles;
    private int count;
    private bool worldSpace;

    void Start()
    {
        m_ParticleSystem = GetComponent<ParticleSystem>();
        m_Particles = new ParticleSystem.Particle[m_ParticleSystem.main.maxParticles];
        worldSpace = (m_ParticleSystem.main.simulationSpace == ParticleSystemSimulationSpace.World);
    }
    void LateUpdate()
    {

        UpdateLists();
        while (m_Instances.Count < count)
        {
            CreateAndAddToLists(); // needs refactoring
        }
    }
    private void CreateAndAddToLists()
    {
        GameObject tempGo = Instantiate(m_Prefab, m_ParticleSystem.transform);
        m_Instances.Add(tempGo);
    }
    public void RemoveFromList(GameObject toRemove)
    {
        m_Instances.Remove(toRemove);
       
       // Destroy(toRemove);
    }
    private void UpdateLists()
    {
        count = m_ParticleSystem.GetParticles(m_Particles);

        for (int i = 0; i < m_Instances.Count; i++)
        {
            if(m_Instances[i] != null)
            {
                if (i < count)
                {
                    if (worldSpace)
                        m_Instances[i].transform.position = m_Particles[i].position;
                    else
                        m_Instances[i].transform.localPosition = m_Particles[i].position;
                    m_Instances[i].SetActive(true);
                }
                else
                {
                    
                    m_Instances[i].SetActive(false);
                }
            }
            else
            {
             //   RemoveFromList(m_Instances[i]);
            }
          
        }
    }
}
