﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Cache_Editor_API;

namespace Cache_Editor_API.Graphics3D
{
	public class DrawingArea
	{
		public static void initDrawingArea(int i, int j, int[] pixels)
		{
			DrawingArea.pixels = pixels;
			width = j;
			height = i;
			if (pixels != null && i > 0 && j > 0)
			{
				if (bmp == null || bmp.Width != width || bmp.Height != height)
				{
					bmp = new Bitmap(width, height);
					fp = new FastPixel(bmp);
				}
			}
			setDrawingArea(i, 0, j, 0);
		}

		public static void initDrawingArea(int h, int w, Color[] _pixels)
		{
			pixels = new int[_pixels.Length];
			for (int i = 0; i < pixels.Length; i++)
				pixels[i] = _pixels[i].ToArgb();
			width = w;
			height = h;
			if (pixels != null && h > 0 && w > 0)
			{
				if (bmp == null || bmp.Width != width || bmp.Height != height)
				{
					bmp = new Bitmap(width, height);
					fp = new FastPixel(bmp);
				}
			}
			setDrawingArea(h, 0, w, 0);
		}

		public static void defaultDrawingAreaSize()
		{
			topX = 0;
			topY = 0;
			bottomX = width;
			bottomY = height;
			centerX = bottomX - 1;
			centerY = bottomX / 2;
		}

		public static void setDrawingArea(int i, int j, int k, int l)
		{
			if (j < 0)
				j = 0;
			if (l < 0)
				l = 0;
			if (k > width)
				k = width;
			if (i > height)
				i = height;
			topX = j;
			topY = l;
			bottomX = k;
			bottomY = i;
			centerX = bottomX - 1;
			centerY = bottomX / 2;
			anInt1387 = bottomY / 2;
		}

		public static void setAllPixelsToZero()
		{
			int i = width * height;
			for (int j = 0; j < i; j++)
			{
				pixels[j] = 0;
			}

		}

		public static void method335(int i, int j, int k, int l, int i1, int k1)
		{
			if (k1 < topX)
			{
				k -= topX - k1;
				k1 = topX;
			}
			if (j < topY)
			{
				l -= topY - j;
				j = topY;
			}
			if (k1 + k > bottomX)
				k = bottomX - k1;
			if (j + l > bottomY)
				l = bottomY - j;
			int l1 = 256 - i1;
			int i2 = (i >> 16 & 0xff) * i1;
			int j2 = (i >> 8 & 0xff) * i1;
			int k2 = (i & 0xff) * i1;
			int k3 = width - k;
			int l3 = k1 + j * width;
			for (int i4 = 0; i4 < l; i4++)
			{
				for (int j4 = -k; j4 < 0; j4++)
				{
					int l2 = (pixels[l3] >> 16 & 0xff) * l1;
					int i3 = (pixels[l3] >> 8 & 0xff) * l1;
					int j3 = (pixels[l3] & 0xff) * l1;
					int k4 = ((i2 + l2 >> 8) << 16) + ((j2 + i3 >> 8) << 8) + (k2 + j3 >> 8);
					pixels[l3++] = k4;
				}

				l3 += k3;
			}
		}

		public static void method336(int i, int j, int k, int l, int i1)
		{
			if (k < topX)
			{
				i1 -= topX - k;
				k = topX;
			}
			if (j < topY)
			{
				i -= topY - j;
				j = topY;
			}
			if (k + i1 > bottomX)
				i1 = bottomX - k;
			if (j + i > bottomY)
				i = bottomY - j;
			int k1 = width - i1;
			int l1 = k + j * width;
			for (int i2 = -i; i2 < 0; i2++)
			{
				for (int j2 = -i1; j2 < 0; j2++)
					pixels[l1++] = l;

				l1 += k1;
			}

		}

		public static void fillPixels(int i, int j, int k, int l, int i1)
		{
			method339(i1, l, j, i);
			method339((i1 + k) - 1, l, j, i);
			method341(i1, l, k, i);
			method341(i1, l, k, (i + j) - 1);
		}

		public static void method338(int i, int j, int k, int l, int i1, int j1)
		{
			method340(l, i1, i, k, j1);
			method340(l, i1, (i + j) - 1, k, j1);
			if (j >= 3)
			{
				method342(l, j1, k, i + 1, j - 2);
				method342(l, (j1 + i1) - 1, k, i + 1, j - 2);
			}
		}

		public static void method339(int i, int j, int k, int l)
		{
			if (i < topY || i >= bottomY)
				return;
			if (l < topX)
			{
				k -= topX - l;
				l = topX;
			}
			if (l + k > bottomX)
				k = bottomX - l;
			int i1 = l + i * width;
			for (int j1 = 0; j1 < k; j1++)
				pixels[i1 + j1] = j;

		}

		private static void method340(int i, int j, int k, int l, int i1)
		{
			if (k < topY || k >= bottomY)
				return;
			if (i1 < topX)
			{
				j -= topX - i1;
				i1 = topX;
			}
			if (i1 + j > bottomX)
				j = bottomX - i1;
			int j1 = 256 - l;
			int k1 = (i >> 16 & 0xff) * l;
			int l1 = (i >> 8 & 0xff) * l;
			int i2 = (i & 0xff) * l;
			int i3 = i1 + k * width;
			for (int j3 = 0; j3 < j; j3++)
			{
				int j2 = (pixels[i3] >> 16 & 0xff) * j1;
				int k2 = (pixels[i3] >> 8 & 0xff) * j1;
				int l2 = (pixels[i3] & 0xff) * j1;
				int k3 = ((k1 + j2 >> 8) << 16) + ((l1 + k2 >> 8) << 8) + (i2 + l2 >> 8);
				pixels[i3++] = k3;
			}

		}

		public static void method341(int i, int j, int k, int l)
		{
			if (l < topX || l >= bottomX)
				return;
			if (i < topY)
			{
				k -= topY - i;
				i = topY;
			}
			if (i + k > bottomY)
				k = bottomY - i;
			int j1 = l + i * width;
			for (int k1 = 0; k1 < k; k1++)
				pixels[j1 + k1 * width] = j;

		}

		private static void method342(int i, int j, int k, int l, int i1)
		{
			if (j < topX || j >= bottomX)
				return;
			if (l < topY)
			{
				i1 -= topY - l;
				l = topY;
			}
			if (l + i1 > bottomY)
				i1 = bottomY - l;
			int j1 = 256 - k;
			int k1 = (i >> 16 & 0xff) * k;
			int l1 = (i >> 8 & 0xff) * k;
			int i2 = (i & 0xff) * k;
			int i3 = j + l * width;
			for (int j3 = 0; j3 < i1; j3++)
			{
				int j2 = (pixels[i3] >> 16 & 0xff) * j1;
				int k2 = (pixels[i3] >> 8 & 0xff) * j1;
				int l2 = (pixels[i3] & 0xff) * j1;
				int k3 = ((k1 + j2 >> 8) << 16) + ((l1 + k2 >> 8) << 8) + (i2 + l2 >> 8);
				pixels[i3] = k3;
				i3 += width;
			}

		}

		public static void DrawRSImage(RSImage s, int x, int y)
		{
			x += s.XOffset;
			y += s.YOffset;
			int l = x + y * DrawingArea.width;
			int i1 = 0;
			int j1 = s.Height;
			int k1 = s.Width;
			int l1 = DrawingArea.width - k1;
			int i2 = 0;
			if (y < DrawingArea.topY)
			{
				int j2 = DrawingArea.topY - y;
				j1 -= j2;
				y = DrawingArea.topY;
				i1 += j2 * k1;
				l += j2 * DrawingArea.width;
			}
			if (y + j1 > DrawingArea.bottomY)
				j1 -= (y + j1) - DrawingArea.bottomY;
			if (x < DrawingArea.topX)
			{
				int k2 = DrawingArea.topX - x;
				k1 -= k2;
				x = DrawingArea.topX;
				i1 += k2;
				l += k2;
				i2 += k2;
				l1 += k2;
			}
			if (x + k1 > DrawingArea.bottomX)
			{
				int l2 = (x + k1) - DrawingArea.bottomX;
				k1 -= l2;
				i2 += l2;
				l1 += l2;
			}
			if (!(k1 <= 0 || j1 <= 0))
			{
				DrawPixels(s.Pixels, i1, l, k1, j1, l1, i2);
			}
		}

		public static void DrawPixels(Color[] ai1, int j, int k, int l, int i1, int j1, int k1)
		{
			int i;//was parameter
			int l1 = -(l >> 2);
			l = -(l & 3);
			for (int i2 = -i1; i2 < 0; i2++)
			{
				for (int j2 = l1; j2 < 0; j2++)
				{
					i = ai1[j++].ToArgb();
					if (i != 0)
						pixels[k++] = (int)((uint)i | 0xFF000000);
					else
						k++;
					i = ai1[j++].ToArgb();
					if (i != 0)
						pixels[k++] = (int)((uint)i | 0xFF000000);
					else
						k++;
					i = ai1[j++].ToArgb();
					if (i != 0)
						pixels[k++] = (int)((uint)i | 0xFF000000);
					else
						k++;
					i = ai1[j++].ToArgb();
					if (i != 0)
						pixels[k++] = (int)((uint)i | 0xFF000000);
					else
						k++;
				}

				for (int k2 = l; k2 < 0; k2++)
				{
					i = ai1[j++].ToArgb();
					if (i != 0)
						pixels[k++] = (int)((uint)i | 0xFF000000);
					else
						k++;
				}

				k += j1;
				j += k1;
			}

		}

		public static Bitmap ToBitmap()
		{
			fp.Lock();
			for (int x = 0; x < width; x++)
			{
				for (int y = 0; y < height; y++)
				{
					fp.SetPixel(x, y, Color.FromArgb((int)(pixels[x + y * width] + (pixels[x + y * width] > 0 ? 0xFF000000 : 0))));
				}
			}

			fp.Unlock(true);
			return bmp;
		}

		public static void Update()
		{
			for (int i = 0; i < width * height; i++)
				p_colors[i % width, i / width] = Color.FromArgb(pixels[i]);
		}

		public DrawingArea()
		{
		}

		public static int[] pixels;
		public static Color[,] p_colors;
		public static int width;
		public static int height;
		public static int topY;
		public static int bottomY;
		public static int topX;
		public static int bottomX;
		public static int centerX;
		public static int centerY;
		public static int anInt1387;

		private static Bitmap bmp;
		private static FastPixel fp;
	}
}