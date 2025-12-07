using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

namespace Code
{
    public class StepladderInteraction : MonoBehaviour
    {
        // Проверяет, находится ли игрок рядом с лестницей  
        void OnTriggerStay(Collider other)
        {
            // Проверяем, есть ли у объекта тег "Player"
            if (other.tag == "Player" && Input.GetKey(KeyCode.E))
            {
                // Находим игрока и поднимаем его по оси Y  
                FirstPersonController player = other.GetComponent<FirstPersonController>();
                if (player != null)
                {
                    float ladderHeight = transform.localScale.y;
                    Vector3 targetPosition = player.transform.position + Vector3.up * ladderHeight * 3f + Vector3.forward * transform.localScale.x * 2f;


                    // Плавное поднятие игрока  
                    player.transform.position = Vector3.Lerp(
                        player.transform.position,
                        targetPosition,
                        0.1f
                    );
                }
            }
        }

        // Опционально: проверка при нажатии E даже без коллизии  
        void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Input.GetKey(KeyCode.E) && Physics.Raycast(ray, out hit))
            {
                if (hit.collider == GetComponent<Collider>() && hit.collider.tag == "Player")
                {
                    // Находим игрока и поднимаем его по оси Y  
                    FirstPersonController player = hit.collider.GetComponent<FirstPersonController>();
                    if (player != null)
                    {
                        float ladderHeight = transform.localScale.y;
                        Vector3 targetPosition = player.transform.position + Vector3.up * ladderHeight*2f;

                        // Плавное поднятие игрока  
                        player.transform.position = Vector3.Lerp(
                            player.transform.position,
                            targetPosition,
                            0.1f
                        );
                    }
                }
            }
        }
    }

    // Пример скрипта для игрока (PlayerController.cs)
    //public class PlayerController : MonoBehaviour
    //{
    //    // Этот скрипт должен быть прикреплен к объекту с тегом "Player"
    //    public void CheckStepladderInteraction()
    //    {
    //        // Это опциональный метод, который можно использовать для дополнительной логики  
    //    }
    //}
}


