using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; // 탄알 속도
    private Rigidbody bulletRigidbody; // 이동에 사용할 리지드바디 컴포넌트

    // Start is called before the first frame update
    void Start()
    {
        // 게임 오브젝트에서 Rigidbody 컴포넌트를 찾아 bulletRigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        // 리지드바디의 속도 = 앞쪽 방향 * 탄알속도
        bulletRigidbody.velocity = transform.forward * speed;

        Destroy(gameObject, 3f); // 오브젝트 파괴 (해당오브젝트, 시간)
    }

    // 트리거 충돌시 실행되는 메소드
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 대상이 player태그일 경우
        if(other.tag == "Player")
        {
            // 게임 오브젝트에서 PlayerController컴포넌트를 가져옴
            PlayerController playerController = other.GetComponent<PlayerController>();
            
            // PlayerController 컴포넌트를 가져오는데 성공했다면
            if(playerController != null)
            {
                // Die 메소드 실행
                playerController.Die();
            }
        }
    }
}
