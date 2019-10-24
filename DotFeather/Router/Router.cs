using System;
using System.Collections.Generic;

namespace DotFeather
{
    /// <summary>
    /// シーン遷移などを管理するクラスです。
    /// </summary>
    public class Router
    {
        /// <summary>
        /// 親のゲームクラスを取得します。
        /// </summary>
        /// <value></value>
        public GameBase Game { get; }

        /// <summary>
        /// 親のゲームクラスを指定して <see cref="Router"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="gameBase"></param>
        public Router(GameBase gameBase)
        {
            Game = gameBase;
        }

        /// <summary>
        /// ゲームクラスのアップデート時に呼び出してください。
        /// </summary>
        public void Update(DFEventArgs e)
        {
            if (current != null)
            {
                current.OnUpdate(this, Game, e);
                if (current.BackgroundColor != null)
                    Game.BackgroundColor = current.BackgroundColor.Value;
    
                if (current.Title != null)
                    Game.Title = current.Title;
            }
        }

        public void RegisterScene<T>(string name) where T : Scene
        {
            dic[name] = New<T>.Instance;
        }

        /// <summary>
        /// シーンを遷移します。
        /// </summary>
        /// <param name="args">遷移先のシーンに渡す引数の辞書。</param>
        /// <typeparam name="T">遷移する対象のシーン。</typeparam>
        public void ChangeScene<T>(Dictionary<string, object>? args = null) where T : Scene
        {
            ChangeScene(New<T>.Instance(), args);
        }

        public void ChangeScene(string path, Dictionary<string, object>? args = null)
        {
            if (!dic.ContainsKey(path))
                throw new ArgumentException();
            
            ChangeScene(dic[path](), args);
        }

        private void ChangeScene<T>(T scene, Dictionary<string, object>? args) where T : Scene
        {
            if (current != null)
            {
                current.OnDestroy(this);
                Game.Root.Remove(current.Root);
                current = null;
            }
            current = scene;
            current.OnStart(this, Game, args ?? new Dictionary<string, object>());
            Game.Root.Add(current.Root);
        }

        private Scene? current;
        private Dictionary<string, Func<Scene>> dic = new Dictionary<string, Func<Scene>>();
    }
}
