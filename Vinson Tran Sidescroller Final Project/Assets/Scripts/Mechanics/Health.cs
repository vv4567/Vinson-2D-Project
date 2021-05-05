using System;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;
using UnityEngine.UI;


namespace Platformer.Mechanics {
    /*{
    /*public class HealthHeart : MonoBehaviour
    {
        public int health;
        public int numOfHearts;

        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;
    
    }
*/

    /// <summary>
    /// Represebts the current vital statistics of some game entity.
    /// </summary>
    public class Health : MonoBehaviour
    {
        public int health;
        public int numOfHearts;

        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;

        void Update() {

            if(currentHP> numOfHearts)
            {
                currentHP = numOfHearts;
            }

            for (int i = 0; i < hearts.Length; i++) {

                if (i < currentHP) {

                    hearts[i].sprite = fullHeart; } else {
                    hearts[i].sprite = emptyHeart;

if (i < numOfHearts)

                    

                    hearts[i].enabled = true;

else
                    {
                        hearts[i].enabled = false;
                    }
                }
            }
        }

    /// <summary>
    /// The maximum hit points for the entity.
    /// </summary>
public int maxHP = 3;

        /// <summary>
        /// Indicates if the entity should be considered 'alive'.
        /// </summary>
        public bool IsAlive => currentHP > 0;

        public int currentHP;

        /// <summary>
        /// Increment the HP of the entity.
        /// </summary>
        public void Increment()
        {
            currentHP = Mathf.Clamp(currentHP + 1, 0, maxHP);
        }

        /// <summary>
        /// Decrement the HP of the entity. Will trigger a HealthIsZero event when
        /// current HP reaches 0.
        /// </summary>
        public void Decrement()
        {
            currentHP = Mathf.Clamp(currentHP - 1, 0, maxHP);
            if (currentHP == 0)
            {
                var ev = Schedule<HealthIsZero>();
                ev.health = this;
            }
        }

        /// <summary>
        /// Decrement the HP of the entitiy until HP reaches 0.
        /// </summary>
        public void Die()
        {
            while (currentHP > 0) Decrement();
        }

        void Awake()
        {
            currentHP = maxHP;
        }
    }
}
