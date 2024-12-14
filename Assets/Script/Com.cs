//======================================================================================================================
//
// 共通定義クラス[Common.cs]
//
//---- 詳細 ------------------------------------------------------------------------------------------------------------
// プログラム全体で使用する、共通の関数・定数・変数を定義する。
// 
//----------------------------------------------------------------------------------------------------------------------
// 更新日     更新者        バージョン 更新内容
// ---------- ------------- ---------- ---------------------------------------------------------------------------------
// yyyy/MM/dd anonymous     xx.xx.xx   -
// 2024/12/15 大行佑也      00.00.01   新規作成
//======================================================================================================================
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BTLGeek
{
    /// <summary>
    /// 共通定数クラス
    /// </summary>
    public static class Com
    {
        //----列挙型 ---------------------------------------------------------------------------------------------------
        /// <summary>
        /// メッセージボックスに表示する、ボタンの種類
        /// </summary>
        /// Unityにメッセージボックスの機能がないからC#のDllを入れたけど、
        /// 名前空間が衝突してめんどくさいので、同じ定義を実装してる。。。
        public enum EMsgBoxButton
        {
            OK,                         // メッセージ ボックスに [OK] ボタンを含めます。
            OKCancel,                   // メッセージ ボックスに [OK] ボタンと [キャンセル] ボタンを含めます。
            AbortRetryIgnore,           // メッセージ ボックスに [中止]、[再試行]、および [無視] の各ボタンを含めます。
            YesNoCancel,                // メッセージ ボックスに [はい]、[いいえ]、および [キャンセル] の各ボタンを含めます。
            YesNo,                      // メッセージ ボックスに [はい] ボタンと [いいえ] ボタンを含めます。
            RetryCancel                 // メッセージ ボックスに [再試行] ボタンと [キャンセル] ボタンを含めます。
        }

        /// <summary>
        /// メッセージボックスに表示する、アイコンの種類
        /// </summary>
        /// Unityにメッセージボックスの機能がないからC#のDllを入れたけど、
        /// 名前空間が衝突してめんどくさいので、同じ定義を実装してる。。。
        public enum EMsgBoxIcon
        {
            None = 0,                   // メッセージ ボックスには、シンボルが含まれていません。
            Error = 16,                 // メッセージ ボックスには、背景が赤い円で囲んだ白い X から成るシンボルが含まれます。
            Warning = 48,               // メッセージ ボックスには、背景が黄色い三角で囲んだ感嘆符から成るシンボルが含まれます。
            Information = 64            // メッセージ ボックスには、円で囲んだ小文字の i から成るシンボルが含まれます。
        }

        /// <summary>
        /// メッセージボックスに表示する既定のボタンを指定します。
        /// </summary>
        /// Unityにメッセージボックスの機能がないからC#のDllを入れたけど、
        /// 名前空間が衝突してめんどくさいので、同じ定義を実装してる。。。
        public enum EMsgBoxDefaultButton
        {
            Button1 = 0,                // メッセージ ボックスの 1 番目のボタンが既定のボタンです。
            Button2 = 0x100,            // メッセージ ボックスの 2 番目のボタンが既定のボタンです。
            Button3 = 0x200             // メッセージ ボックスの 3 番目のボタンが既定のボタンです。
        }

        /// <summary>
        /// ダイアログ ボックスの戻り値を示す識別子を指定します。
        /// </summary>
        /// Unityにメッセージボックスの機能がないからC#のDllを入れたけど、
        /// 名前空間が衝突してめんどくさいので、同じ定義を実装してる。。。
        public enum EMsgBoxRslt
        {
            
            None,                       //     ダイアログ ボックスから Nothing が返されます。 つまり、モーダル ダイアログ ボックスの実行が継続します。
            OK,                         //     ダイアログ ボックスの戻り値は OK です (通常は "OK" というラベルが指定されたボタンから送られます)。
            Cancel,                     //     ダイアログ ボックスの戻り値は Cancel です (通常は "キャンセル" というラベルが指定されたボタンから送られます)。
            Abort,                      //     ダイアログ ボックスの戻り値は Abort です (通常は "中止" というラベルが指定されたボタンから送られます)。
            Retry,                      //     ダイアログ ボックスの戻り値は Retry です (通常は "再試行" というラベルが指定されたボタンから送られます)。
            Ignore,                     //     ダイアログ ボックスの戻り値は Ignore です (通常は "無視" というラベルが指定されたボタンから送られます)。
            Yes,                        //     ダイアログ ボックスの戻り値は Yes です (通常は "はい" というラベルが指定されたボタンから送られます)。
            No                          //     ダイアログ ボックスの戻り値は No です (通常は "いいえ" というラベルが指定されたボタンから送られます)。
        }


        //---- 定数 ----------------------------------------------------------------------------------------------------
        // 戻り値
        public const int                GC_OK                   = 0;                                    // 正常
        public const int                GC_NG                   = -1;                                   // 異常
                                    
        // ON, OFF                  
        public const int                GC_OFF                  = 0;                                    // ON ：有効
        public const int                GC_ON                   = 1;                                    // OFF：無効

        //---- 変数 ----------------------------------------------------------------------------------------------------
        public static string            g_strExeName            = string.Empty;                         // 実行ファイル名
        public static string            g_strExeDir             = string.Empty;                         // プログラムの実行ディレクトリフルパス

        //---- 関数 ----------------------------------------------------------------------------------------------------
        /// <summary>
        /// メッセージボックス表示
        /// </summary>
        /// <param name="rstrMsg">表示メッセージ</param>
        /// <param name="vBtn">ボタンの種類</param>
        /// <param name="vIcon">アイコンの種類</param>
        /// <param name="vDefault">ボタンの初期選択</param>
        /// <returns></returns>
        public static EMsgBoxRslt GFn_MessageBox(string rstrMsg, EMsgBoxButton vBtn, EMsgBoxIcon vIcon, EMsgBoxDefaultButton vDefault)
        {
            return (EMsgBoxRslt)MessageBox.Show(rstrMsg, g_strExeName, (MessageBoxButtons)vBtn, (MessageBoxIcon)vIcon, (MessageBoxDefaultButton)vDefault);
        }

        /// <summary>
        /// メッセージボックス表示
        /// </summary>
        /// <param name="rstrMsg">表示メッセージ</param>
        /// <param name="vBtn">ボタンの種類</param>
        /// <param name="vIcon">アイコンの種類</param>
        public static EMsgBoxRslt GFn_MessageBox(string rstrMsg, EMsgBoxButton vBtn, EMsgBoxIcon vIcon)
        {
            return (EMsgBoxRslt)MessageBox.Show(rstrMsg, g_strExeName, (MessageBoxButtons)vBtn, (MessageBoxIcon)vIcon);
        }

        /// <summary>
        /// メッセージボックス表示
        /// </summary>
        /// <remarks>アイコンは無し。</remarks>
        /// <param name="rstrMsg">表示メッセージ</param>
        /// <param name="vBtn">ボタンの種類</param>
        public static EMsgBoxRslt GFn_MessageBox(string rstrMsg, EMsgBoxButton vBtn)
        {
            return (EMsgBoxRslt)MessageBox.Show(rstrMsg, g_strExeName, (MessageBoxButtons)vBtn);
        }

        /// <summary>
        /// メッセージボックス表示
        /// </summary>
        /// <remarks>ボタンはOKのみ。アイコンは無し。</remarks>
        /// <param name="rstrMsg">表示メッセージ</param>
        public static EMsgBoxRslt GFn_MessageBox(string rstrMsg)
        {
            return (EMsgBoxRslt)MessageBox.Show(rstrMsg, g_strExeName);
        }
    }
}
