using RoverApp.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using RoverApp.Resources;

namespace RoverApp.Classes
{
    [DesignerCategory("Code")]
    public class Rover : Panel
    {
        #region Constructor

        public Rover(int x, int y, int width, int height, Compass direction)
        {
            try
            {
                // Set location by x and y. Add +5 for padding.
                Location = new Point(x + 5, y + 5);

                // Set size by width and height. Recude by 10 for padding.
                Size = new Size(width - 10, height - 10);

                // Current direction of rover.
                Direction = direction;

                // Icon and layout
                BackgroundImage = AppResources.rover_icon;
                BackgroundImageLayout = ImageLayout.Stretch;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Events

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            RenderRotation();
        }

        #endregion

        #region Methods

        void RenderRotation()
        {
            try
            {
                // Reset image rotation.
                BackgroundImage = AppResources.rover_icon;

                // Calculate image rotation given direction.
                switch (Direction)
                {
                    case Compass.N:
                        {
                            BackgroundImage.RotateFlip(RotateFlipType.RotateNoneFlipNone);
                            break;
                        }
                    case Compass.E:
                        {
                            BackgroundImage.RotateFlip(RotateFlipType.Rotate270FlipX);
                            break;
                        }
                    case Compass.S:
                        {
                            BackgroundImage.RotateFlip(RotateFlipType.Rotate180FlipX);
                            break;
                        }
                    case Compass.W:
                        {
                            BackgroundImage.RotateFlip(RotateFlipType.Rotate90FlipX);
                            break;
                        }
                    default:
                        break;
                }
            }
            catch (Exception Ex)
            {

            }
        }

        #endregion

        #region Properties

        public Compass Direction { get; set; }

        #endregion
    }
}
