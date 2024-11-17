using UnityEngine;

namespace TowerSystem
{
    [RequireComponent(typeof(TowerShoot))]
    public class Tower : MonoBehaviour
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public float Damage { get; private set; }
        [field: SerializeField] public float Range { get; private set; }
        [field: SerializeField] public float Cooldown { get; private set; }
        [field: SerializeField] public float Cost { get; private set; }
        [field: SerializeField] public TowerType Type { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }

        [SerializeField] private GameObject rangeObj;

        private Vector3 _target;
        private void Start()
        {
            rangeObj.transform.localScale = new Vector2(Range * 2, Range * 2);
            //rangeObj.SetActive(false);
        }
    }
}