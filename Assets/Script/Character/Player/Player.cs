using UnityEngine;

namespace BTLGeek.Character.Player
{
    public class Player : Character
    {
        /*---- メンバ変数 ----*/
        /// <summary>
        /// プレイヤーモデルの親オブヘクト
        /// </summary>
        [field:SerializeField]
        [field:Tooltip("プレイヤーモデルの親オブジェクトをアタッチして下さい。")]
        private GameObject model_ = null;

        /// <summary> 移動速度 </summary>
        [field:SerializeField]
        [field:Tooltip("移動速度(min:0.1 max:10)")]
        [field:Range(0.1f, 10f)]
        private float moveSpeed_ = 1.0f;

        /// <summary> 回転速度 </summary>
        [field:SerializeField]
        [field:Tooltip("回転速度(min:1 max:1080)")]
        [field:Range(1f, 1080f)]
        private float rotateSpeed_ = 360f;

        /// <summary> ステート </summary>
        private Common.State<Player> state_ = null;

        /// <summary> アニメーター </summary>
        private Animator animator_ = null;

        private float currentAngularVelocity_;

        /*---- メソッド ----*/
        /// <summary>
        /// はじめてUpadate関数が呼ばれる際に一度だけ呼ばれる
        /// </summary>
        void Start()
        {
            // アニメーターのnillチェック
            if(null == animator_) {
                // nullだった場合
                // アニメーターの取得
                animator_ = GetComponent<Animator>();
                // 取得結果チェック
                if (null == animator_) {
                    // 取得できなかった場合
                    // エラーログ出力
                    Debug.LogError(gameObject.name + "にanimatorをアタッチしてください。");
                }
            }
        }

        /// <summary>
        /// 毎フレーム呼ばれる
        /// </summary>
        void Update()
        {
            // 移動
            Move( );
        }

        /// <summary>
        /// 移動
        /// </summary>
        /// <remarks>
        /// WASDキーで移動。<br />
        /// 移動する場合、進行方向を向くようにする。
        /// </remarks>
        private void Move()
        {
            // ローカル変数宣言＆初期化
            bool isMove     = false;                // 移動の入力があったか(true:あり false:なし)
            Vector3 dir     = Vector3.zero;         // 移動方向
            Vector3 pos     = transform.position;   // プレイヤーの座標
            float cosTheta  = 0f;                   // 進行方向が右か左か(正の値:右 負の値:左)
            float angle     = 0f;                   // 進行方向へ回転したい角度
            float maxRotate = 0f;                   // 回転時の最大回転角度

            // 入力判定
            if (Input.GetKey(KeyCode.W)) {
                dir.z += 1;
                isMove = true;
            }
            if (Input.GetKey(KeyCode.S)) {
                dir.z -= 1;
                isMove = true;
            }
            if (Input.GetKey(KeyCode.D)) {
                dir.x += 1;
                isMove = true;
            }
            if (Input.GetKey(KeyCode.A)) {
                dir.x -= 1;
                isMove = true;
            }

            // 同時入力対策
            if(dir.magnitude == 0) {
                isMove = false;
            }

            // 入力があれば更新する
            if (isMove) {
                // カメラのフロント方向を基準に座標更新
                pos += Camera.main.transform.right   * dir.normalized.x * moveSpeed_ * Time.deltaTime;
                pos += Camera.main.transform.forward * dir.normalized.z * moveSpeed_ * Time.deltaTime;
                transform.position = pos;

                // プレイヤーの向きと移動方向を比較してキャラクターの向きを更新
                cosTheta = Vector3.Dot(model_.transform.right, dir);
                angle = Vector3.Angle(model_.transform.forward, dir); // 回転したい角度
                maxRotate = rotateSpeed_ * Mathf.Sign(cosTheta) * Time.deltaTime; 
                if (angle >= Mathf.Epsilon) {
                    // モデルが移動方向を徐々に向く
                    model_.transform.Rotate(0.0f, Mathf.Min(maxRotate, angle), 0.0f);
                }
            }
        }
    }
}
