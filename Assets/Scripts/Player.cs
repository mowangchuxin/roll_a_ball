using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Rigidbody rd;
    public int score;
    public Text scoreText;
    public GameObject winText;

    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        if (score < 10)
        {
            rd.AddForce(new Vector3(h, 0, v) * 2);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "分数：" + score;
        }

        if (score >= 10)
        {
            winText.SetActive(true);
        }
    }
}
