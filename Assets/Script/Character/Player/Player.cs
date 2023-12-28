using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BTLGeek.Character.Player
{
    public class Player : Character
    {
        /*---- プロパティ ----*/
        /// <summary> ダッシュ中フラグ(true:ダッシュ中 false:ダッシュしていない) </summary>
//        [field:NonSerialized]
        [field:SerializeField]
        public bool IsDash { get; private set; } = false;

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

        /// <summary> ダッシュ時の移動速度 </summary>
        [field:SerializeField]
        [field:Tooltip("ダッシュの移動速度倍率(min:1 max:10)")]
        [field:Range(1f, 20f)]
        private float dashSpeed_ = 2.0f;

        /// <summary> 回転速度 </summary>
        [field:SerializeField]
        [field:Tooltip("回転速度(min:1 max:1080)")]
        [field:Range(1f, 1080f)]
        private float rotateSpeed_ = 360f;

        /// <summary> カメラを持たせている、スプリングアーム </summary>
        [field:SerializeField]
        [field:Tooltip("カメラをもたせているSpringArm")]
        private GameObject springArm_ = null;

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
            // 各インスタンスの取得
            animator_ = GetComponentInChildren<Animator>();
            // 取得結果チェック
            if (null == animator_) {
                // 取得できなかった場合
                // エラーログ出力
                Debug.LogError($"{gameObject.name}にanimatorをアタッチしてください。");
            }
        }

        /// <summary>
        /// 毎フレーム呼ばれる
        /// </summary>
        void Update()
        {
            Attack( );  // 攻撃
            Move( );    // 移動
        }

        /// <summary>
        /// 毎フレームUpdate関数の呼ばれる
        /// </summary>
        private void LateUpdate()
        {
            Look( );    // 視点
        }

        /// <summary>
        /// 攻撃
        /// </summary>
        /// <remarks>
        /// 左クリック：通常攻撃
        /// 右クリック：スキル１
        /// Ｑキー　　：スキル２
        /// </remarks>
        private void Attack()
        {
            if (Input.GetKey(KeyCode.Q)) Skill_2( );                // スキル２
            else if (Input.GetKey(KeyCode.Mouse1)) Skill_1( );      // スキル３
            else if (Input.GetKey(KeyCode.Mouse0)) NomalAttack( );  // 通常攻撃
        }

        private void NomalAttack()
        {

        }

        private void Skill_1()
        {

        }

        private void Skill_2()
        {

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
            Vector3 dir     = Vector3.zero;         // 移動方向

            // 入力判定
            dir.z += (Input.GetKey(KeyCode.W)) ? 1f : 0f;
            dir.z -= (Input.GetKey(KeyCode.S)) ? 1f : 0f;
            dir.x += (Input.GetKey(KeyCode.D)) ? 1f : 0f;
            dir.x -= (Input.GetKey(KeyCode.A)) ? 1f : 0f;
            IsDash = (IsDash == true || Input.GetKey(KeyCode.LeftShift)) ? true : false;

            // 移動量が0なら各フラグをフォルスにし、待機Animationを再生
            if(dir.magnitude == 0) {
                IsDash = false;
                animator_.Play("PlayerIdlingAnimation");
                return;
            }

            // 移動モーション再生
            if (IsDash) {
                animator_.Play("PlayerRunAnimation");
            }
            else {
                animator_.Play("PlayerWalkAnimation");
            }

            // カメラのフロント方向を基準に座標更新
            Vector3 moveValue = Camera.main.transform.forward * dir.normalized.z    // カメラの前方向
                              + Camera.main.transform.right   * dir.normalized.x;   // カメラの右方向
            moveValue.y = 0;    // 上下は無視する
            transform.position += moveValue.normalized * (IsDash ? dashSpeed_ : moveSpeed_) * Time.deltaTime;

            // プレイヤーの向きと移動方向を比較してキャラクターの向きを更新
            float angle = Vector3.Angle(model_.transform.forward, moveValue);       // 回転したい角度
            float cosTheta = Vector3.Dot(model_.transform.right, moveValue);        // 進行方向が右か左か(正の値:右 負の値:左)
            float maxRotate = rotateSpeed_ * Mathf.Sign(cosTheta) * Time.deltaTime; // 回転時の最大回転角度
            if (angle >= Mathf.Epsilon) {
                // モデルが移動方向を徐々に向く
                model_.transform.Rotate(0.0f, Mathf.Min(maxRotate, angle), 0.0f);
            }
        }

        /// <summary>
        /// 視点移動
        /// </summary>
        private void Look()
        {
            Transform transform = springArm_.transform;
            float rotateX =  Input.GetAxis("Mouse X"); // マウスの横方向の移動量
            float rotateY = -Input.GetAxis("Mouse Y"); // マウスの縦方向の移動量
            transform.RotateAround(transform.position, Vector3.up,      rotateX * rotateSpeed_ * Time.deltaTime);
            transform.RotateAround(transform.position, transform.right, rotateY * rotateSpeed_ * Time.deltaTime);
        }
    }
}
