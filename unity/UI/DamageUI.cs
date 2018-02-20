
using Libraries.btcp.ECS.src.Combat.Events.Interfaces;
using UnityEngine;
using UnityEngine.UI;

namespace Mine.unity.UI
{
    public class DamageUI : MonoBehaviour, IListenerEntityDamaged
    {
        private void Awake()
        {
            Contexts.sharedInstance.game.CreateEntity().AddListener_EntityDamaged(this);
        }


        private void CreateDamageTF(Vector2 position, float amount)
        {
            var tf = GameObject.Instantiate(Resources.Load<Text>("Prefabs/UI/canvas_tf"));
            tf.text = amount.ToString();
            tf.transform.SetParent(transform.parent, false);
            tf.transform.position = position;
        
            var e = Contexts.sharedInstance.game.CreateEntity();
            e.AddPosition(position);
            e.AddGameObject(tf.gameObject);
            e.AddExplosiveForce(new Vector2(Random.Range(-2f, 2f), Random.Range(5f, 8f)));
            e.isAffectedByGravity = true;
            e.isCanvasElement = true;
            
            
            //TODO : Create EffectHelpers
            e.AddScaleBounce(.5f);
            e.AddScaleBounceDuration(.25f);
            e.AddScaleBounceTime(0f);
            e.AddScaleBouncStartSize(1);

            e.AddFadeStart(0f);
            e.AddFadeTarget(1f);
            e.AddFadeTime(0f);
            e.AddFadeDuration(.5f);
        }

        public void OnEntityDamaged(int entityID, int attackerID, float damage)
        {
            var entity = Contexts.sharedInstance.game.GetEntityWithId(entityID);
            CreateDamageTF(entity.position.value, damage);
        }
    }
}