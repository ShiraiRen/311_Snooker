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
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            ShootBall();
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
}
