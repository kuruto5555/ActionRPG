using UnityEngine;

namespace BTLGeek.Character
{
    public class Character : MonoBehaviour
    {
        /*---- 定数 ----*/
        /// <summary>
        /// 最大体力
        /// </summary>
        public const int   HP_MAX = 99999;

        /// <summary>
        /// 最小体力
        /// </summary>
        public const short HP_MIN = 0;

        /// <summary>
        /// 最大アクションポイント
        /// </summary>
        public const short AP_MAX = 999;

        /// <summary>
        /// 最小アクションポイント
        /// </summary>
        public const short AP_MIN = 0;

        /// <summary>
        /// 最大レベル
        /// </summary>
        public const short LV_MAX = 100;

        /// <summary>
        /// 最小レベル
        /// </summary>
        public const short LV_MIN = 1;

        /// <summary>
        /// 最大経験値
        /// </summary>
        public const short EXP_MAX = 100;

        /// <summary>
        /// 最小経験値
        /// </summary>
        public const short EXP_MIN = 1;


        /*---- メンバ変数 ----*/
        [field:Header("ステータス(共通)")]

        [field:SerializeField]
        [field:Tooltip("体力(min:0 max:99999)")]
        [field:Range(HP_MIN, HP_MAX)]
        private int   hp_  = 1000;

        [field:SerializeField]
        [field:Tooltip("アクションポイント(min:0 max:999)")]
        [field:Range(AP_MIN, AP_MAX)]
        private short ap_  = 100;

        [field:SerializeField]
        [field:Tooltip("レベル(min:1 max:100)")]
        [field:Range(LV_MIN, LV_MAX)]
        private short lv_  = 1;

        [field:SerializeField]
        [field:Tooltip("経験値(min:0 max:99999999)")]
        [field: Range(0, 9999999)]
        private int exp_ = 0;


        /*---- プロパティ ----*/
        /// <summary>
        /// 体力(min:0 max:99999)
        /// </summary>
        public int HP { get { return hp_; } protected set { hp_  = (short)Mathf.Max(HP_MIN, Mathf.Min(HP_MAX, value)); } }
        public short AP { get { return ap_; } protected set { ap_  = (short)Mathf.Max(AP_MIN, Mathf.Min(AP_MAX, value)); } }
        public short LV { get { return lv_; } protected set { lv_  = (short)Mathf.Max(LV_MIN, Mathf.Min(LV_MAX, value)); } }
        public int EXP { get { return exp_; } protected set { exp_ = (short)Mathf.Max(EXP_MIN, Mathf.Min(EXP_MAX, value)); } }

        /*---- メソッド ----*/
        /// <summary>
        /// オブジェクトが有効になったとき一度だけ呼ばれる
        /// </summary>
        void Start()
        {

        }

        /// <summary>
        /// 毎フレーム呼ばれる
        /// </summary>
        void Update()
        {

        }
    }
}
