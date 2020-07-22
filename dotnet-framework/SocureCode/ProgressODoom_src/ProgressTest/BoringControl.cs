using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using ProgressODoom;

namespace ProgressTest {
	public class BoringControl : Control {
		private Color color = Color.FromArgb(240, 240, 240);
		private IGlossPainter gloss = null;

		public Color Color {
			get { return color; }
			set {
				color = value;
				this.Invalidate();
			}
		}

		public IGlossPainter GlossPainter {
			get { return gloss; }
			set {
				gloss = value;
				gloss.PropertiesChanged += new EventHandler(gloss_PropertiesChanged);
				this.Invalidate();
			}
		}

		void gloss_PropertiesChanged(object sender, EventArgs e) {
			this.Invalidate();
		}

		protected override void OnPaint(PaintEventArgs e) {
			base.OnPaint(e);
			Rectangle bounds = new Rectangle(1, 0, this.Width - 3, this.Height - 2);
			using (Brush b = new SolidBrush(color)) {
				e.Graphics.FillRectangle(b, bounds);

				if (gloss != null) {
					gloss.PaintGloss(bounds, e.Graphics);
				}

				e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1f), bounds);
			}
		}
	}
}