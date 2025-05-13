using UnityEngine;


public class RapidGazeSimulator : MonoBehaviour
{
    [Header("����ģʽ����")]
    [Tooltip("�����ƶ��ٶ�")] public float baseSpeed = 4f;          // ԭֵ1.5 �� 4
    [Tooltip("�������ٱ���")] public float burstMultiplier = 3f;     // ��������ģʽ
    [Tooltip("��̬������ȴ")] public float speedCooldown = 1.5f;     // ԭֵ5 �� 1.5

    [Header("�߼�����")]
    [Tooltip("��Ե��ȫ����")] public float safeMargin = 0.15f;
    [Tooltip("�ٶ��������")] public float speedVariance = 0.3f;

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
        // ������Ч���ĸ����ƶ�
        transform.position = Vector3.Lerp(
            transform.position,
            _currentTarget,
            _currentSpeed * Time.deltaTime
        );

        // ÿ֡��5%���ʴ�������
        if (Random.value < 0.05f) TriggerSpeedBurst();

        // �Զ�����Ŀ��
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

        // 70%����ϸ�ڹ۲죨С��Χ����30%��Χ�ƶ�
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
            _currentSpeed *= 1.5f; // ������Եʱ�Զ���������
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