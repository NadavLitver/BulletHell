using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Direction { right, left, back, front }
public class TeleportEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    
    [Header("Light params")]
    [SerializeField] private float In;
    [SerializeField] private float Stay;
    [SerializeField] private float Out;
    [SerializeField] private float Intensity;

    [Header("GO References")]
    public DirectionHandler Right;
    public DirectionHandler Left;
    public DirectionHandler Back;
    public DirectionHandler Front;

    public GameObject RightGO;
    public GameObject LeftGO;
    public GameObject BackGO;
    public GameObject FrontGO;

    private void Start()
    {
        RightGO.gameObject.SetActive(false);
        LeftGO.gameObject.SetActive(false);
        BackGO.gameObject.SetActive(false);
        FrontGO.gameObject.SetActive(false);
    }

    private DirectionHandler GetHandlerfromDirection(Direction dir)
    {
        switch (dir)
        {
            case Direction.right:return Right;
            case Direction.left: return Left;
            case Direction.back: return Back;
            case Direction.front: return Front;
            default: return Front;
        }
    }
    public void Activate(Direction dir)
    {
        StartCoroutine(ActivateCoru(GetHandlerfromDirection(dir)));
    }
    private IEnumerator ActivateCoru(DirectionHandler DH)
    {
        DH.gameObject.SetActive(true);
        RightGO.gameObject.SetActive(true);
        float currDurr = 0;
        while (currDurr < 1)
        {
            currDurr += Time.deltaTime / In;
            DH.m_sr.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, currDurr));
            DH.m_light.intensity = Mathf.Lerp(100, 0, currDurr);
        }
        currDurr = 1;
        DH.m_light.intensity = Mathf.Lerp(50, 0, currDurr);
        DH.m_sr.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, currDurr));

        yield return new WaitForSeconds(Stay);
        while (currDurr <= 0)
        {
            currDurr -= Time.deltaTime / Out;
            DH.m_light.intensity = Mathf.Lerp(50, 0, currDurr);
            DH.m_sr.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, currDurr));
        }
        ps.gameObject.SetActive(true);
        DH.gameObject.SetActive(false);
        RightGO.gameObject.SetActive(false);

        currDurr = 0;
    }

}
