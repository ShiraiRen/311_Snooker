using UnityEngine;

public class Hole : MonoBehaviour
{
       private void OnTriggerEnter(Collider other)
        {
            Ball b = other.GetComponent<Ball>();

            if (b != null)
            {
                if (b.Point == 0)
                {
                    GameMeneger.Instance.ShowString($"White Ball drop!!!\nYou lose!!!");
                    Time.timeScale = 0f;
                }
                else
                {
                    GameMeneger.Instance.ShowScoreText(b.Point);
                }
                Destroy(b.gameObject);
            }
        }
    
}