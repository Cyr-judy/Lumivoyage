using UnityEngine;


public class RapidGazeSimulator : MonoBehaviour
{
    [Header("极速模式设置")]
    [Tooltip("基础移动速度")] public float baseSpeed = 4f;          // 原值1.5 → 4
    [Tooltip("爆发加速倍率")] public float burstMultiplier = 3f;     // 新增爆发模式
    [Tooltip("动态加速冷却")] public float speedCooldown = 1.5f;     // 原值5 → 1.5

    [Header("高级设置")]
    [Tooltip("边缘安全距离")] public float safeMargin = 0.15f;
    [Tooltip("速度随机波动")] public float speedVariance = 0.3f;

    private Vector3 _currentTarget;
    private Camera _mainCam;
    private float _currentSpeed;
    private float _speedTimer;

    void Start()
    {
        _mainCam = Camera.main;
        _currentSpeed = baseSpeed;
        GenerateNewTarget();
        StartCoroutine(SpeedBurstRoutine());
    }

    void Update()
    {
        // 带惯性效果的高速移动
        transform.position = Vector3.Lerp(
            transform.position,
            _currentTarget,
            _currentSpeed * Time.deltaTime
        );

        // 每帧有5%概率触发加速
        if (Random.value < 0.05f) TriggerSpeedBurst();

        // 自动更新目标
        if (Vector3.Distance(transform.position, _currentTarget) < 0.5f)
        {
            GenerateNewTarget();
        }

        AvoidEdges();
    }

    void GenerateNewTarget()
    {
        Vector3 screenPos = new Vector3(
            Random.Range(safeMargin, 1 - safeMargin),
            Random.Range(safeMargin, 1 - safeMargin),
            _mainCam.nearClipPlane
        );

        // 70%概率细节观察（小范围），30%大范围移动
        _currentTarget = _mainCam.ViewportToWorldPoint(
            Random.value < 0.7f ?
            screenPos + Random.insideUnitSphere * 0.2f :
            screenPos
        );
    }

    void TriggerSpeedBurst()
    {
        _currentSpeed = baseSpeed * burstMultiplier;
        _speedTimer = speedCooldown;
    }

    System.Collections.IEnumerator SpeedBurstRoutine()
    {
        while (true)
        {
            if (_speedTimer > 0)
            {
                _speedTimer -= Time.deltaTime;
                _currentSpeed = Mathf.Lerp(
                    baseSpeed,
                    _currentSpeed,
                    _speedTimer / speedCooldown
                );
            }
            yield return null;
        }
    }

    void AvoidEdges()
    {
        Vector3 viewportPos = _mainCam.WorldToViewportPoint(transform.position);
        if (viewportPos.x < safeMargin || viewportPos.x > 1 - safeMargin ||
            viewportPos.y < safeMargin || viewportPos.y > 1 - safeMargin)
        {
            GenerateNewTarget();
            _currentSpeed *= 1.5f; // 靠近边缘时自动加速脱离
        }
    }
    public class TrailEnhancer : MonoBehaviour
    {
        public GameObject trailPrefab;
        public float spawnInterval = 0.1f;

        private float _timer;

        void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= spawnInterval)
            {
                Instantiate(trailPrefab, transform.position, Quaternion.identity);
                _timer = 0;
            }
        }
    }

}