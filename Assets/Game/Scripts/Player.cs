using UnityEngine;
using UnityEngine.InputSystem;

// 自機オブジェクト
public class Player : MonoBehaviour
{
    // 移動する速さ
    [SerializeField]
    private float _MoveSpeed;

    // 移動ベクトル
    private Vector3 _MoveVector = Vector3.zero;

    // 初期化時処理
    void Start()
    {
        // InputActionを取得
        GameInput input = new();

        // スティック入力時のイベントを登録
        input.Play.Move.started += OnMove;
        input.Play.Move.performed += OnMove;
        input.Play.Move.canceled += OnMove;

        // ノーツ入力ボタンが押された時のイベントを登録
        input.Play.Hit.performed += OnHit;

        // ポーズボタンが押された時のイベントを登録
        input.Play.Pause.performed += OnPause;

        // InputActionを有効にする
        input.Enable();
    }

    // 更新時処理
    void Update()
    {
        transform.position += _MoveVector;
    }

    // スティック入力時のイベント
    private void OnMove(InputAction.CallbackContext context)
    {
        _MoveVector = _MoveSpeed * context.ReadValue<float>() * Time.deltaTime * Vector3.right;
    }

    // ノーツ入力ボタンが押された時のイベント
    private void OnHit(InputAction.CallbackContext context)
    {
    }

    // ポーズボタンが押された時のイベント
    private void OnPause(InputAction.CallbackContext context)
    {

    }
}
