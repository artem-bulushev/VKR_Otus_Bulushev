using UnityEngine;

namespace Code
{
    public class StickAttack : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                gameObject.GetComponent<Animator>().SetTrigger("StickAttack_1");
            }
        }
    }
}