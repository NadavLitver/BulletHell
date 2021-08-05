using UnityEngine;

public class StatueMover : MonoBehaviour
{
    [SerializeField]
    GameObject[] Statues;
    [SerializeField]
    Vector2[] ZeroStatePositions;
    [SerializeField]
    Vector2[] firstStatePositions;
    [SerializeField]
    Vector2[] SecondStatePositions;
    [SerializeField]
    Vector2[] ThirdStatePositions;
    [SerializeField]
    Vector2[] FourthStatePositions;
    [SerializeField]
    float moveSpeed;
    private bool CanFirstState, CanSecondState, CanThirdState, canFourthState;
    private bool FirstStateScanned, SecondStateScanned, ThirdStateScanned, FourthStateScanned;

    public AstarPath path;


    private void Start()
    {

        ZeroStatePositions = new Vector2[Statues.Length];
        for (int i = 0; i < Statues.Length; i++)
        {
            ZeroStatePositions[i] = Statues[i].transform.position;
        }
        Invoke("EnableFirstState", 12);
        Invoke("EnableSecondState", 24);
        Invoke("EnableThirdState", 36);
        Invoke("EnableFourthState", 48);


    }
    private void FixedUpdate()
    {
        if (CanFirstState)
        {
            FirstStatePositioning();
        }
        if (CanSecondState)
        {
            SecondStatePositioning();
        }
        if (CanThirdState)
        {
            ThirdStatePositioning();
        }
        if (canFourthState)
        {
            FourthStatePositioning();
        }

    }
    void EnableFirstState()
    {
        CanFirstState = true;
        CanSecondState = false;
        CanThirdState = false;
        canFourthState = false;
    }
    void EnableSecondState()
    {
        CanFirstState = false;
        CanSecondState = true;
        CanThirdState = false;
        canFourthState = false;

    }
    void EnableThirdState()
    {
        CanFirstState = false;
        CanSecondState = false;
        CanThirdState = true;
        canFourthState = false;

    }
    void EnableFourthState()
    {
        CanFirstState = false;
        CanSecondState = false;
        CanThirdState = false;
        canFourthState = true;

    }
    void FirstStatePositioning()
    {
        for (int i = 0; i < Statues.Length; i++)
        {
            Statues[i].transform.position = Vector2.MoveTowards(Statues[i].transform.position, firstStatePositions[i], moveSpeed * Time.deltaTime);
            if ((Vector2)Statues[i].transform.position == firstStatePositions[i])
            {
            
                   
                if (i == 2)
                {
                  path.Scan();
                  FirstStateScanned = true;
                    foreach (GameObject statue in Statues)
                    {
                        statue.GetComponentInChildren<SortOrder>().UpdateSortOrder();
                    }  
                }
                   
            }

        }
    }

    void SecondStatePositioning()
    {

        for (int i = 0; i < Statues.Length; i++)
        {
            Statues[i].transform.position = Vector2.MoveTowards(Statues[i].transform.position, SecondStatePositions[i], moveSpeed * Time.deltaTime);
            if ((Vector2)Statues[i].transform.position == SecondStatePositions[i])
            {
                   
                if (i == 2)
                {
                        path.Scan();
                        SecondStateScanned = true;
                    foreach (GameObject statue in Statues)
                    {
                        statue.GetComponentInChildren<SortOrder>().UpdateSortOrder();
                    }
                }
            }
        }

    }
    void ThirdStatePositioning()
    {

        for (int i = 0; i < Statues.Length; i++)
        {
            Statues[i].transform.position = Vector2.MoveTowards(Statues[i].transform.position, ThirdStatePositions[i], moveSpeed * Time.deltaTime);
            if ((Vector2)Statues[i].transform.position == ThirdStatePositions[i])
            {
                if (i == 2)
                {
                    path.Scan();
                    ThirdStateScanned = true;
                    foreach (GameObject statue in Statues)
                    {
                        statue.GetComponentInChildren<SortOrder>().UpdateSortOrder();
                    }

                }
            }
        }
    }
    void FourthStatePositioning()
    {

        for (int i = 0; i < Statues.Length; i++)
        {
            Statues[i].transform.position = Vector2.MoveTowards(Statues[i].transform.position, FourthStatePositions[i], moveSpeed * Time.deltaTime);
            if ((Vector2)Statues[i].transform.position == FourthStatePositions[i])
            {
                if (i == 2)
                {
                    path.Scan();
                    FourthStateScanned = true;
                    foreach (GameObject statue in Statues)
                    {
                        statue.GetComponentInChildren<SortOrder>().UpdateSortOrder();
                    }

                }
            }
        }
    }
}
