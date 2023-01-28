/// <summary>
/// ストラテジーパターンのインターフェース
/// ストラテジーパターンを実装したいクラスに継承してください。
/// ストラテジーの切り替えは、使用するクラス側で実装してください。
/// </summary>
public interface IStrategy
{
	/// <summary>
	/// 実行
	/// </summary>
	void Exe();
}
