using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        transform.LookAt(player.transform.position);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //적군이 플레이어와 접촉하였는가?
        if (collision.collider.CompareTag("Player"))
        {
            // 점수 1점 혹득!
            GameManager.Instance.AddScore();

            // 적군 사망처리
            Destroy(collision.gameObject);
        }
    }
}
