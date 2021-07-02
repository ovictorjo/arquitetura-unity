using UnityEngine;

namespace Assets.Scripts.Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator m_Animator;
        private Rigidbody2D m_Rb;
        private string m_CurrentAnimation;

        private enum FacingDirection
        {
            FacingRight,
            FacingLeft,
            FacingUp,
            FacingdDown
        }
        
        private FacingDirection m_FacingDirection;
        
        // Start is called before the first frame update
        void Awake()
        {
            m_Animator = GetComponent<Animator>();
            m_Rb = GetComponent<Rigidbody2D>();
            
        }
        

        // Update is called once per frame
        void FixedUpdate()
        {
            UpdateAnimation();
        }

        private void UpdateAnimation()
        {
            if (m_Rb.velocity == Vector2.zero)
            {
                if (m_FacingDirection == FacingDirection.FacingRight)
                {
                    ChangeAnimation("idle_rigth");
                }
                
                else if (m_FacingDirection == FacingDirection.FacingLeft)
                {
                    ChangeAnimation("idle_left");
                }
                
                else if (m_FacingDirection == FacingDirection.FacingdDown)
                {
                    ChangeAnimation("idle_down");
                }
                
                else if (m_FacingDirection == FacingDirection.FacingUp)
                {
                    ChangeAnimation("idle_up");
                }
            }
            
            else if (m_Rb.velocity.x > 0.1f)
            {
                ChangeAnimation("player_rigth");
                m_FacingDirection = FacingDirection.FacingRight;
            }
            
            else if (m_Rb.velocity.x <  -0.1f)
            {
                ChangeAnimation("player_left");
                m_FacingDirection = FacingDirection.FacingLeft;
            }
            
            else if (m_Rb.velocity.y > 0.1f)
            {
                ChangeAnimation("player_up");
                m_FacingDirection = FacingDirection.FacingUp;
            }
            
            else if (m_Rb.velocity.y < -0.1f)
            {
                ChangeAnimation("walking_player");
                m_FacingDirection = FacingDirection.FacingdDown;
            }
            
        }

        private void ChangeAnimation(string animationName)
        {
            if (m_CurrentAnimation == animationName) return;
            
            m_CurrentAnimation = animationName;
            m_Animator.Play(animationName);
        }
    }
}
