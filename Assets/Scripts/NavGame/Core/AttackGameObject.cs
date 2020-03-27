using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavGame.Managers;

namespace NavGame.Core
{

    public class AttackGameObject : TouchableGameObject
    {
        public OfenseStats ofenseStats;
        float cooldown = 0f;
        public OnAttackHitEvent onAttackHit;

        protected virtual void Update()
        {
            DecreaseAttackCoolDown();
        }

        public void AttackOnCooldown(DamageableGameObject target)
        {
            if (cooldown <= 0f)
            {
                cooldown = 1f / ofenseStats.attackSpeed;
                target.TakeDamage(ofenseStats.damage);
                if (onAttackHit != null)
                {
                    onAttackHit(target.transform.position);
                }
            }
        }

        void DecreaseAttackCoolDown()
        {
            if (cooldown == 0f)
            {
                return;
            }
            cooldown = cooldown -= Time.deltaTime;
            if (cooldown < 0f)
            {
                cooldown = 0f;
            }
        }
    }
}


