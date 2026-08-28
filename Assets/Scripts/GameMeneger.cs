using UnityEngine;
using UnityEngine.InputSystem;

public class GameMeneger : MonoBehaviour
{

    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    [SerializeField]
    private GameObject[] ballPositions;

    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private GameObject cueBall;

    [SerializeField]
    private float xInput = 0f;


    public static GameMeneger Instance;

    void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetBall(Ballcolor.Red, 1);
        SetBall(Ballcolor.Yellow, 2);
        SetBall(Ballcolor.Green, 3);
        SetBall(Ballcolor.Brown, 4);
        SetBall(Ballcolor.Blue, 5);
        SetBall(Ballcolor.Pink, 6);
        SetBall(Ballcolor.Black, 7);
    }

    // Update is called once per frame
    void Update()
    {
        RoteteBall();

        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            ShootBall();

        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
            xInput = -0.1f;

        else if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
            xInput = 0.1f;

        else 
            xInput = 0f;
    }

    private void SetBall(Ballcolor col, int i)
    {
        GameObject obj = Instantiate(ballPrefab,
                               ballPositions[i].transform.position,
                               Quaternion.identity);

        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }

    private void ShootBall()
    {
        Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.AddRelativeForce(Vector3.forward * 50, ForceMode.Impulse);
    }

    private void RoteteBall()
    {
        if (cueBall !=null)
            cueBall.transform.Rotate(new Vector3(0f, xInput , 0f));
    }


}
