using UnityEngine;

namespace BTLGeek.Character
{
    public class Character : MonoBehaviour
    {
        /// <summary>
        /// キャラクタ用定数クラス
        /// </summary>
        public class Construct
        {
            /// <summary> 最大体力 </summary>
            public const int HP_MAX = 99999;

            /// <summary> 最小体力 </summary>
            public const short HP_MIN = 0;

            /// <summary> 最大アクションポイント </summary>
            public const short AP_MAX = 999;

            /// <summary> 最小アクションポイント </summary>
            public const short AP_MIN = 0;

            /// <summary> 最大レベル </summary>
            public const short LV_MAX = 100;

            /// <summary> 最小レベル </summary>
            public const short LV_MIN = 1;

            /// <summary> 最大経験値 </summary>
            public const int EXP_MAX = 99999999;

            /// <summary> 最小経験値 </summary>
            public const short EXP_MIN = 0;
        }


        /*---- メンバ変数 ----*/
        [field:Header("ステータス(共通)")]

        [field:SerializeField]
        [field:Tooltip("体力(min:0 max:99999)")]
        [field:Range(Construct.HP_MIN, Construct.HP_MAX)]
        private int   hp_  = 1000;

        [field:SerializeField]
        [field:Tooltip("アクションポイント(min:0 max:999)")]
        [field:Range(Construct.AP_MIN, Construct.AP_MAX)]
        private short ap_  = 100;

        [field:SerializeField]
        [field:Tooltip("レベル(min:1 max:100)")]
        [field:Range(Construct.LV_MIN, Construct.LV_MAX)]
        private short lv_  = 1;

        [field:SerializeField]
        [field:Tooltip("経験値(min:0 max:99999999)")]
        [field: Range(Construct.EXP_MIN, Construct.EXP_MAX)]
        private int exp_ = 0;


        /*---- プロパティ ----*/
        /// <summary>
        /// 体力(min:0 max:99999)
        /// </summary>
        public int   HP  { get { return hp_; }  protected set { hp_  = (short)Mathf.Max(Construct.HP_MIN,  Mathf.Min(Construct.HP_MAX, value)); } }
        public short AP  { get { return ap_; }  protected set { ap_  = (short)Mathf.Max(Construct.AP_MIN,  Mathf.Min(Construct.AP_MAX, value)); } }
        public short LV  { get { return lv_; }  protected set { lv_  = (short)Mathf.Max(Construct.LV_MIN,  Mathf.Min(Construct.LV_MAX, value)); } }
        public int   EXP { get { return exp_; } protected set { exp_ = (short)Mathf.Max(Construct.EXP_MIN, Mathf.Min(Construct.EXP_MAX, value)); } }

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
