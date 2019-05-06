using System;
using System.Collections.Generic;
using System.Drawing;
using static DotFeather.MiscUtility;

namespace DotFeather
{
    /// <summary>
    /// <see cref="ITile"/> オブジェクトを格子状にレンダリングする <see cref="IDrawable"/> オブジェクトです。
    /// </summary>
    public class Tilemap : IDrawable
    {
        /// <summary>
        /// </summary>
        public int ZOrder { get; set; }
        /// <summary>
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// </summary>
        public Vector Location { get; set; }
        /// <summary>
        /// </summary>
        public float Angle { get; set; }
        /// <summary>
        /// </summary>
        public Vector Scale { get; set; }
        /// <summary>
        /// </summary>
        public Color? DefaultColor { get; set; }

        /// <summary>
        /// タイルあたりのピクセス単位のサイズを取得または設定します。
        /// </summary>
        /// <value></value>
        public Vector TileSize { get; set; }

        /// <summary>
        /// <see cref="Tilemap"/> クラスの新しいインスタンスを初期化します。
        /// </summary>
        /// <param name="tileSize">タイル1枚あたりのサイズ。</param>
        public Tilemap(Vector tileSize)
        {
            TileSize = tileSize;
            tiles = new Dictionary<(int, int), (ITile, Color?)>();
        }

        /// <summary>
        ///  指定した位置にあるタイルを取得または設定します。
        /// </summary>
        public ITile this[int x, int y]
        {
            get => GetTileAt(x, y);
            set => SetTile(x, y, value);
        }

        /// <summary>
        ///  指定した位置にあるタイルを取得または設定します。
        /// </summary>
        public ITile this[Vector point]
        {
            get => GetTileAt(point);
            set => SetTile(point, value);
        }

        /// <summary>
        /// </summary>
        public void Draw(GameBase game, Vector location)
        {
            foreach (var kv in tiles)
            {
                var (x, y) = kv.Key;
                var loc = new Vector(x, y) * TileSize * Scale;
                kv.Value.tile.Draw(game, this, Location + location + loc, kv.Value.color);
            }
        }

        /// <summary>
        /// 指定した位置にあるタイルを取得します。
        /// </summary>
        public ITile GetTileAt(Vector point) => GetTileAt((int)point.X, (int)point.Y);
        /// <summary>
        /// 指定した位置にあるタイルを取得します。
        /// </summary>
        public ITile GetTileAt(int x, int y) => tiles.ContainsKey((x, y)) ? tiles[(x, y)].tile : default;

        /// <summary>
        /// 指定した位置にあるタイルの色を取得します。
        /// </summary>
        public Color? GetTileColorAt(Vector point) => GetTileColorAt((int)point.X, (int)point.Y);
        /// <summary>
        /// 指定した位置にあるタイルの色を取得します。
        /// </summary>
        public Color? GetTileColorAt(int x, int y) => tiles.ContainsKey((x, y)) ? tiles[(x, y)].color : default;

        /// <summary>
        /// 指定した位置にタイルを設置します。
        /// </summary>
        public void SetTile(Vector point, ITile tile, Color? color = default) => SetTile((int)point.X, (int)point.Y, tile, color);

        /// <summary>
        /// 指定した位置にタイルを設置します。
        /// </summary>
        public void SetTile(int x, int y, ITile tile, Color? color = default)
        {
            if (tile == default)
                tiles.Remove((x, y));
            else
                tiles[(x, y)] = (tile, color ?? DefaultColor);
        }

        /// <summary>
        /// タイルを全て削除します。
        /// </summary>
        public void Clear()
        {
            tiles.Clear();
        }

        /// <summary>
        /// タイルを線形描画します。
        /// </summary>
        public void Line(int x1, int y1, int x2, int y2, ITile tile)
        {
            var steep = Math.Abs(y2 - y1) > Math.Abs(x2 - x1);
            // 左上から右下に描くよう正規化する
            if (steep)
            {
                Swap(ref x1, ref y1);
                Swap(ref x2, ref y2);
            }
            if (x1 > x2)
            {
                Swap(ref x1, ref x2);
                Swap(ref y1, ref y2);
            }

            var deltaX = x2 - x1;
            var deltaY = Math.Abs(y2 - y1);
            var error = deltaX / 2;
            int ystep;
            var y = y1;
            if (y1 < y2)
                ystep = 1;
            else
                ystep = -1;

            for (var x = x1; x <= x2; x++)
            {
                if (steep)
                    this[y, x] = tile;
                else
                    this[x, y] = tile;

                error -= deltaY;
                if (error < 0)
                {
                    y += ystep;
                    error += deltaX;
                }
            }
        }

        /// <summary>
        /// 指定した矩形にタイルを並べます。
        /// </summary>
        public void Fill(int x1, int y1, int width, int height, ITile tile)
        {
            for (var y = y1; y < y1 + height; y++)
                for (var x = x1; x < x1 + width; x++)
                    this[x, y] = tile;
        }

        /// <summary>
        /// タイルを線形描画します。
        /// </summary>
        public void Line(Vector start, Vector end, ITile tile)
            => Line((int)start.X, (int)start.Y, (int)end.X, (int)end.Y, tile);

        /// <summary>
        /// 指定した矩形にタイルを並べます。
        /// </summary>
        public void Fill(Vector position, Vector size, ITile tile)
            => Line((int)position.X, (int)position.Y, (int)size.X, (int)size.Y, tile);

        /// <summary>
        /// この <see cref="Tilemap"/> を破棄します。
        /// </summary>
        public void Destroy()
        {
            foreach (var kv in tiles)
            {
                kv.Value.tile.Destroy();
            }
            tiles.Clear();
        }

        private Dictionary<(int x, int y), (ITile tile, Color? color)> tiles;
    }
}
