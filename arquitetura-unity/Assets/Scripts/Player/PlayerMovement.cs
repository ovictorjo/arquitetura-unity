using UnityEngine;


namespace Assets.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;

        private InputActions m_InputActions;
        private Vector2 m_Direction;
        private Rigidbody2D m_Rb;
        
        
        void Awake()
        {
            m_InputActions = new InputActions();
            m_Rb = GetComponent<Rigidbody2D>();
            
            m_InputActions.Player.Movement.performed += ctx => m_Direction = ctx.ReadValue<Vector2>();
            m_InputActions.Player.Movement.canceled += _ => m_Direction = Vector2.zero;

        }

        private void OnEnable() => m_InputActions.Enable();
        
        private void OnDisable() => m_InputActions.Disable();
        
        void FixedUpdate()
        {
            m_Rb.velocity = m_Direction * speed;
        }
    }
}
