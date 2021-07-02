using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Assets.Scripts
{
    public class Weapon : MonoBehaviour
    {
        private InputActions m_InputActions;
        private Queue<GameObject> projectilePool;
        
        [SerializeField] private GameObject shootingPrefab;
        [SerializeField] private int poolSize;
        
        void Awake()
        {
            m_InputActions = new InputActions();
            m_InputActions.Player.Shoot.performed += _ => Shooting();
        }
        
        private void OnEnable() => m_InputActions.Enable();
        
        private void OnDisable() => m_InputActions.Disable();

        // Update is called once per frame
        void Update()
        {
            AjustRotation();
        }

        private void AjustRotation()
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            
            transform.rotation = rotation;

        }


        private void Shooting()
        {
            Instantiate(shootingPrefab, transform.position,transform.rotation);
        }
    }
}
