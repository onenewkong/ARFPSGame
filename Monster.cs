using System.Collections;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public GameObject monster;
    public GameObject target;

    public float speed = 4f;

    Vector3 dir;

    bool wallTouch = false;

    void Start()
    {
        int randValue = UnityEngine.Random.Range(0, 10);

        if (randValue < 3)
        {
            dir = target.transform.position - monster.transform.position;
            dir.Normalize();
        }

        else
        {
            dir = Vector3.forward;
        }
    }

    void Update()
    {
        monster.transform.rotation = Quaternion.Euler(0, 180, 0);
        monster.transform.position += (-dir) * speed * Time.deltaTime;

        if (wallTouch)
        {
            monster.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Wall"))
        {
            if (!wallTouch)
            {
                dir = Vector3.back;
                wallTouch = true;
            }
            else
            {
                dir = Vector3.forward;
                wallTouch = false;
            } 
        }

        else if (collision.collider.CompareTag("Bullet"))
        {
            this.gameObject.SetActive(false);
            ScoreManager.Instance.AddScore(5);

        }
    }
}
