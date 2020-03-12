using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NavGame.Core
{

    public class CombatGameObject : DamageableGameObject
    {
        float cooldown = 0f;

    
        protected virtual void Update()
        { 
            DecreaseAttackCoolDown();
        }

        public void AttackOnCooldown(DamageableGameObject target)
        {
            if(cooldown <= 0f)
            {
                cooldown = 1f / stats.attackSpeed;
                target.TakeDamage(stats.damage);
            }
        }

        void DecreaseAttackCoolDown()
        {
            if(cooldown == 0f)
            {
                return;
            }
            cooldown = cooldown -= Time.deltaTime;
            if(cooldown < 0f)
            {
                cooldown = 0f;
            }
        }
    }
}


