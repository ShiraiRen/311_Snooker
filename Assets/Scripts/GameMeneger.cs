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

    [SerializeField]
    private GameObject ballLine;

    [SerializeField]
    private GameObject cam;



    public static GameMeneger Instance;

    void Awake()
    {
        Instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        CameraBehindCueBall();

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

        if (Keyboard.current.backspaceKey.wasPressedThisFrame)
            StopBall();


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

        ballLine.SetActive(false);
        cam.transform.parent = null;
        cam.transform.position = new Vector3(0f, 26f, -38.98f);
        cam.transform.eulerAngles = new Vector3(45f,  0f,  0f);
    }

    private void RoteteBall()
    {
        if (cueBall !=null)
            cueBall.transform.Rotate(new Vector3(0f, xInput , 0f));
    }

    private void StopBall()
    {
       Rigidbody rd = cueBall.GetComponent<Rigidbody>();
        rd.linearVelocity = Vector3.zero;
        rd.angularVelocity = Vector3.zero;
        cueBall.transform.eulerAngles = new Vector3(0f, 0f , 0f);

        ballLine.SetActive(true);
        CameraBehindCueBall();

    }

    private void CameraBehindCueBall()
    {
        cam.transform.parent = cueBall.transform;
        cam.transform.position = cueBall.transform.position + new Vector3(0f, 7f, -15f);
        cam.transform.eulerAngles = new Vector3(30f, 0f, 0f);
    }
}
