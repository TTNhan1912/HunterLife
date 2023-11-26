using UnityEngine;

namespace Inventory.Model
{

    [CreateAssetMenu]
    public class ItemSO : ScriptableObject
    {
        public int MyPro { get; set; }

        [field: SerializeField]
        public bool IsStackable { get; set; }

        public int ID => GetInstanceID();

        [field: SerializeField]
        public int MaxStackSize { get; set; } = 1;

        [field: SerializeField]
        public string Name { get; set; }

        [field: SerializeField]
        [field: TextArea]
        public string Description { get; set; }

        [field: SerializeField]

        public Sprite IteamImage { get; set; }

        // Hàm tạo mới nhận đường dẫn hình ảnh
        public string imagePath;

        public ItemSO(string imagePath)
        {
            this.imagePath = imagePath;
        }

    }
}

