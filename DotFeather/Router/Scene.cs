using System;
using System.Collections.Generic;
using System.Drawing;
using DotFeather;

namespace DotFeather.Router
{
    /// <summary>
    /// シーンの抽象クラスです。
    /// </summary>
    public abstract class Scene
    {
        /// <summary>
        /// シーンのルートコンテナーを取得します。
        /// </summary>
        public Container Root { get; } = new Container();

        /// <summary>
        /// 乱数生成器を取得します。
        /// </summary>
        public Random Random { get; private set; } = new Random();

        /// <summary>
        /// 背景色を取得または設定します。
        /// </summary>
        public Color BackgroundColor { get; set; }

        /// <summary>
        /// 乱数を初期化します。
        /// </summary>
        /// <param name="seed">シード値。指定しない場合は <see cref="Random"/> クラスのデフォルトコンストラクターを用いて初期化します。</param>
        public void Randomize(int? seed = null)
        {
            Random = seed is int s ? new Random(s) : new Random();
        }

        /// <summary>
        /// シーンの始まりに呼ばれます。
        /// </summary>
        public virtual void OnStart(Router router, GameBase game, Dictionary<string, object> args) { }

        /// <summary>
        /// シーンのフレーム更新時に呼ばれます。
        /// </summary>
        public virtual void OnUpdate(Router router, GameBase game, DFEventArgs e) { }

        /// <summary>
        /// シーンの遷移時など、シーンが破棄される際に呼び出されます。
        /// </summary>
        public virtual void OnDestroy(Router router) { }
    }
}