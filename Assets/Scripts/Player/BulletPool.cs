using UnityEngine;
using UnityEngine.Pool; 

public class BulletPool : MonoBehaviour
{
    // Singleton để súng có thể gọi: BulletPool.Instance
    public static BulletPool Instance { get; private set; }

    [Header("Cài đặt Đạn")]
    [SerializeField] private GameObject bulletPrefab; // Bản thiết kế viên đạn
    [SerializeField] private int defaultCapacity = 50; // Sức chứa ban đầu
    [SerializeField] private int maxSize = 200;        // Sức chứa tối đa trước khi bắt đầu hủy bớt đạn

    public IObjectPool<GameObject> pool;

    private void Awake()
    {
        // Khởi tạo Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Khởi tạo hệ thống Pool của Unity
        pool = new ObjectPool<GameObject>(
            createFunc: CreateBullet, 
            actionOnGet: OnGetBullet, 
            actionOnRelease: OnReleaseBullet, 
            actionOnDestroy: OnDestroyBullet, 
            collectionCheck: false, 
            defaultCapacity: defaultCapacity, 
            maxSize: maxSize
        );
    }

    // 1. Quy tắc tạo đạn mới
    private GameObject CreateBullet()
    {
        return Instantiate(bulletPrefab);
    }

    // 2. Quy tắc lấy đạn ra dùng
    private void OnGetBullet(GameObject bullet)
    {
        bullet.SetActive(true);
    }

    // 3. Quy tắc thu hồi đạn
    private void OnReleaseBullet(GameObject bullet)
    {
        bullet.SetActive(false);
    }

    // 4. Quy tắc hủy đạn khi quá tải
    private void OnDestroyBullet(GameObject bullet)
    {
        DestroyImmediate(bullet);
    }
}