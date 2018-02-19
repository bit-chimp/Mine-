using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    }

    public void OnEntityDamaged(int entityID, int attackerID, float damage)
    {
        var entity = Contexts.sharedInstance.game.GetEntityWithId(entityID);
        CreateDamageTF(entity.position.value, damage);
    }
}