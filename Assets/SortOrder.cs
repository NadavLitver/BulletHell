using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SortOrder : MonoBehaviour
{
    [SerializeField] private bool doUpdate;
    private SpriteRenderer m_sr;
   
    void Start()
    {
        m_sr = GetComponent<SpriteRenderer>() ?? GetComponentInChildren<SpriteRenderer>();
        m_sr.sortingOrder = getSort();
        StartCoroutine(doUpdateSortCoru());
    }
    private IEnumerator doUpdateSortCoru()
    {
        while (doUpdate)
        {
            m_sr.sortingOrder = getSort();
            yield return new WaitForEndOfFrame();
        }
    }
    private int getSort() {
        return Mathf.RoundToInt(-transform.position.y * 10);
    } 
}
