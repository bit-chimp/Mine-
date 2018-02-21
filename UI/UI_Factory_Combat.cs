using Libraries.btcp.src.UI.Health;
using UnityEngine;
using UnityEngine.UI;

namespace Mine.UI
{
    public static class UI_Factory_Combat
    {
        public static GameEntity CreateDamageTF(Vector2 position, float amount)
        {
            var tf = GameObject.Instantiate(Resources.Load<Text>("Prefabs/UI/canvas_tf"));
            tf.text = amount.ToString();
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
            return e;
        }


        public static GameEntity CreateHealthBar(int entityID)
        {
            var entity = Contexts.sharedInstance.game.GetEntityWithId(entityID);

            var healthBar = GameObject.Instantiate(Resources.Load<HealthBar>("Prefabs/UI/small_health_bar"));

            var healthBarEntity = Contexts.sharedInstance.game.CreateEntity();
            healthBarEntity.AddListener_EntityDestroyed(healthBar);
            healthBarEntity.AddListener_EntityDamaged(healthBar);
            healthBarEntity.AddGameObject(healthBar.gameObject);
            healthBarEntity.isCanvasElement = true;
            healthBarEntity.AddPositionOffset(new Vector2(0, 25f));
            healthBarEntity.AddHealthBar(healthBar);
            healthBarEntity.AddCopyPosition(entityID);
            
            healthBar.SetEntity(healthBarEntity, entity);

            
            return healthBarEntity;
        }
    }
}