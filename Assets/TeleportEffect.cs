using System.Collections;
using UnityEngine;
public enum Direction { right, left, back, front }
public class TeleportEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;

    [Header("Light params")]
    public float In;       
    public float Stay;
    public float Out;
    public float Intensity;

    [Header("GO References")]
    public DirectionHandler Right;
    public DirectionHandler Left;
    public DirectionHandler Back;
    public DirectionHandler Front;

    public GameObject RightGO;
    public GameObject LeftGO;
    public GameObject BackGO;
    public GameObject FrontGO;

    [SerializeField] private Color idleColor;
    [SerializeField] private Color targetColor;


    private DirectionHandler GetHandlerfromDirection(Direction dir)
    {
        switch (dir)
        {
            case Direction.right: return Right;
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
        DH.Activate();
        
        Debug.Log(DH.name);
        float currDurr = 0;
        while (currDurr < 1)
        {
            //in
            currDurr += Time.deltaTime / In;
            DH.m_sr.color = Color.Lerp(idleColor, targetColor, currDurr);
            DH.m_light.intensity = Mathf.Lerp(Intensity, 0, currDurr);
            yield return new WaitForEndOfFrame();
        }
        //stay
        currDurr = 1;
        yield return new WaitForSeconds(0.05f);
        DH.m_light.intensity = Mathf.Lerp(Intensity, 0, currDurr);
        DH.m_sr.color = Color.Lerp(idleColor, targetColor, currDurr);
        ps.gameObject.SetActive(true);
        yield return new WaitForSeconds(Stay);
        while (currDurr > 0)
        {
            //out
            currDurr -= Time.deltaTime / Out;
            DH.m_light.intensity = Mathf.Lerp(Intensity, 0, currDurr);
            DH.m_sr.color = Color.Lerp(idleColor, targetColor, currDurr);
            yield return new WaitForEndOfFrame();
        }
        DH.Deactivate();
        currDurr = 0;
    }
}
