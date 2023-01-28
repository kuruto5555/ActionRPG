using UnityEngine;

namespace BTLGeek.Character.Player
{
    public class Player : Character
    {
        /*---- メンバ変数 ----*/
        /// <summary>
        /// ステート
        /// </summary>
        Common.State<Player> state_ = null;

        /// <summary>
        /// アニメーター
        /// </summary>
        Animator animator_ = null;


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

        }
    }
}
