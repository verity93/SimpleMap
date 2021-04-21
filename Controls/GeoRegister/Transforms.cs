using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows;
using Point = System.Windows.Point;

namespace ProgramMain.ExampleForms.Controls
{

    /*
     * fiducial points (which are the corners of the photo). 
     * And yet at least 2 or 3 more reference points 
     * 
     * http://www.dlib.org/dlib/november12/fleet/11fleet.html
     * 
    Aligning the raster with control points
Generally you will georeference your raster data using existing spatial data (target data), such as georeferenced rasters or a vector feature class that resides in the desired map coordinate system. The process involves identifying a series of ground control points—known x,y coordinates—that link locations on the raster dataset with locations in the spatially referenced data. Control points are locations that can be accurately identified on the raster dataset and in real-world coordinates. Many different types of features can be used as identifiable locations, such as road or stream intersections, the mouth of a stream, rock outcrops, the end of a jetty of land, the corner of an established field, street corners, or the intersection of two hedgerows.

The control points are used in conjunction with the transformation to shift and warp the raster dataset from its existing location to the spatially correct location. The connection between one control point on the raster dataset (the from point) and the corresponding control point on the aligned target data (the to point) is a control point pair.
    
    */
    public static class VectorExtentions
    {
        
        public static Point Rotate(this Point pt, double angle)
        {
            var a = angle * System.Math.PI / 180.0;
            float cosa = (float)Math.Cos(a);
            float sina = (float)Math.Sin(a);
            Point newPoint = new Point((float)(pt.X * cosa - pt.Y * sina), (float)(pt.X * sina + pt.Y * cosa));
            return newPoint;
        }
        //Rotate around non zero center
        public static Point Rotate(this Point pt, double angle, Point center)
        {
            Vector v = new Vector(pt.X - center.X, pt.Y - center.Y).Rotate(angle);
            return new Point(v.X + center.X, v.Y + center.Y);
        }

        public static Point RotateAndTranform(this Point pt, double angle, double translatedX, double translatedY)
        {
            double a = angle * Math.PI / 180;
            Point newPoint = new Point(0, 0);
            newPoint.X = (pt.X + translatedX) * Math.Cos(a) - (pt.Y + translatedY) * Math.Sin(a);
            newPoint.Y = (pt.X + translatedX) * Math.Sin(a) + (pt.Y + translatedY) * Math.Cos(a);
            return newPoint;
        }


        public static Vector Rotate(this Vector v, double degrees)
        {
            return v.RotateRadians(degrees * Math.PI / 180);
        }

        public static Vector RotateRadians(this Vector v, double radians)
        {
            double ca = Math.Cos(radians);
            double sa = Math.Sin(radians);
            return new Vector(ca * v.X - sa * v.Y, sa * v.X + ca * v.Y);
        }
    }

   
    public class ImageTransforms
    {
        public static double AngleBetween(Point p1, Point p2)
        {
            //Angle between two Vectors 2D - Stack Overflow

            ///calculate angle in radian, if you need it in degrees just do angle * 180 / PI
            double angle = Math.Atan2((double)(p1.Y - p2.Y), (double)(p1.X - p2.X));
            if (angle < 0)
                angle += 2 * Math.PI;

            return angle;

        }
        /// <summary>
        /// Method to rotate an Image object. The result can be one of three cases:
        /// - upsizeOk = true: output image will be larger than the input, and no clipping occurs 
        /// - upsizeOk = false & clipOk = true: output same size as input, clipping occurs
        /// - upsizeOk = false & clipOk = false: output same size as input, image reduced, no clipping
        /// 
        /// A background color must be specified, and this color will fill the edges that are not 
        /// occupied by the rotated image. If color = transparent the output image will be 32-bit, 
        /// otherwise the output image will be 24-bit.
        /// 
        /// Note that this method always returns a new Bitmap object, even if rotation is zero - in 
        /// which case the returned object is a clone of the input object. 
        /// </summary>
        /// <param name="inputImage">input Image object, is not modified</param>
        /// <param name="angleDegrees">angle of rotation, in degrees</param>
        /// <param name="upsizeOk">see comments above</param>
        /// <param name="clipOk">see comments above, not used if upsizeOk = true</param>
        /// <param name="backgroundColor">color to fill exposed parts of the background</param>
        /// <returns>new Bitmap object, may be larger than input image</returns>
        public static Bitmap RotateImage(Image inputImage, float angleDegrees, bool upsizeOk,
                                         bool clipOk, Color backgroundColor)
        {
            // Test for zero rotation and return a clone of the input image
            if (angleDegrees == 0f)
                return (Bitmap)inputImage.Clone();

            // Set up old and new image dimensions, assuming upsizing not wanted and clipping OK
            int oldWidth = inputImage.Width;
            int oldHeight = inputImage.Height;
            int newWidth = oldWidth;
            int newHeight = oldHeight;
            float scaleFactor = 1f;

            // If upsizing wanted or clipping not OK calculate the size of the resulting bitmap
            if (upsizeOk || !clipOk)
            {
                double angleRadians = angleDegrees * Math.PI / 180d;

                double cos = Math.Abs(Math.Cos(angleRadians));
                double sin = Math.Abs(Math.Sin(angleRadians));
                newWidth = (int)Math.Round(oldWidth * cos + oldHeight * sin);
                newHeight = (int)Math.Round(oldWidth * sin + oldHeight * cos);
            }

            // If upsizing not wanted and clipping not OK need a scaling factor
            if (!upsizeOk && !clipOk)
            {
                scaleFactor = Math.Min((float)oldWidth / newWidth, (float)oldHeight / newHeight);
                newWidth = oldWidth;
                newHeight = oldHeight;
            }

            // Create the new bitmap object. If background color is transparent it must be 32-bit, 
            //  otherwise 24-bit is good enough.
            Bitmap newBitmap = new Bitmap(newWidth, newHeight, backgroundColor == Color.Transparent ?
                                             PixelFormat.Format32bppArgb : PixelFormat.Format24bppRgb);
            newBitmap.SetResolution(inputImage.HorizontalResolution, inputImage.VerticalResolution);

            // Create the Graphics object that does the work
            using (Graphics graphicsObject = Graphics.FromImage(newBitmap))
            {
                graphicsObject.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsObject.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graphicsObject.SmoothingMode = SmoothingMode.HighQuality;

                // Fill in the specified background color if necessary
                if (backgroundColor != Color.Transparent)
                    graphicsObject.Clear(backgroundColor);

                // Set up the built-in transformation matrix to do the rotation and maybe scaling
                graphicsObject.TranslateTransform(newWidth / 2f, newHeight / 2f);

                if (scaleFactor != 1f)
                    graphicsObject.ScaleTransform(scaleFactor, scaleFactor);

                graphicsObject.RotateTransform(angleDegrees);
                graphicsObject.TranslateTransform(-oldWidth / 2f, -oldHeight / 2f);

                // Draw the result 
                graphicsObject.DrawImage(inputImage, 0, 0);
            }

            return newBitmap;
        }

    }


    /*
     * 
     * 
     
    georef = read_georeference(map_name, token_path, src.RasterXSize, src.RasterYSize)
    gcps = transform_gcps(georef['control_points'], srs)
    if len(gcps) < 3:
        raise Exception('Not enough GCPs')

    if dst_driver.ShortName == 'VRT':
        georefed_path = dst_path + '.aux'
    else:
        georefed_path = tempfile.mktemp()

    vrt_driver = gdal.GetDriverByName('VRT')
    georefed = vrt_driver.CreateCopy(georefed_path, src)
    georefed.SetProjection(srs)
    georefed.SetGCPs(gcps, srs)

    if dst_driver.ShortName == 'VRT':
        warped_path = dst_path
    else:
        warped_path = tempfile.mktemp()

    warped = gdal.AutoCreateWarpedVRT(georefed, srs, srs)
    if warped is None:
        raise Exception("Can't warp")
    warped.SetDescription(warped_path)

    if georef['cutline']:
        del warped
        add_cutline(warped_path, georef['cutline'])
        warped = gdal.Open(warped_path)
    
    if warped.RasterCount == 3:
        del warped
        add_alpha(warped_path)
        warped = gdal.Open(warped_path)
    
    if dst_driver.ShortName != 'VRT':
        # This is necessary, because otherwise we won't
        # be able to interrupt the process.
        import signal
        signal.signal(signal.SIGINT, signal.SIG_DFL)

        print "Warping ..."
        dst = dst_driver.CreateCopy(dst_path, warped, callback=gdal.TermProgress)

        os.remove(warped_path)
        os.remove(georefed_path)


def sanitize_srs(text):
    obj = osr.SpatialReference()
    if obj.SetFromUserInput(text) != 0:
        raise Exception('Invalid SRS ' + text)
    return obj.ExportToWkt()


def transform_gcps(gcps, srs):
    src = osr.SpatialReference()
    src.ImportFromEPSG(4326)
    dst = osr.SpatialReference()
    dst.ImportFromWkt(srs)
    tr = osr.CoordinateTransformation(src, dst)
    ret = []
    for gcp in gcps:
        x, y, z = tr.TransformPoint(gcp['longitude'], gcp['latitude'], 0.0)
        ret.append(gdal.GCP(x, y, z, gcp['pixel_x'], gcp['pixel_y']))
    return ret


def add_cutline(path, cutline):
    with open(path, 'rb') as f:
        text = f.read()
    wkt = ('MULTIPOLYGON (((' +
           ','.join('%.15f %.15f' % (x, y) for (x, y) in cutline) +
           ')))')
    text = text.replace('</GDALWarpOptions>',
                        '<Cutline>%s</Cutline></GDALWarpOptions>' % (wkt,))
    with open(path, 'wb') as f:
        f.write(text)

def add_alpha(path):
    with open(path, 'rb') as f:
        text = f.read()
    # Add the warping options
    text = text.replace("""<BlockXSize>""","""<VRTRasterBand dataType="Byte" band="%i" subClass="VRTWarpedRasterBand">
    <ColorInterp>Alpha</ColorInterp>
  </VRTRasterBand>
  <BlockXSize>""" % 4)
    text = text.replace("""</GDALWarpOptions>""", """<DstAlphaBand>%i</DstAlphaBand>
  </GDALWarpOptions>""" % 4)
    text = text.replace("""</WorkingDataType>""", """</WorkingDataType>
    <Option name="INIT_DEST">0</Option>""")
    with open(path, 'wb') as f:
        f.write(text)

def read_georeference(map_name, token_path, x_size, y_size):
    params = urllib.urlencode({
        'map': map_name,
        'x_size': x_size,
        'y_size': y_size
    })
    georef_url = 'http://georeferencer3.appspot.com/api/georeference?' + params

    print 'Fetching georeference ...'
    resp = urllib2.urlopen(georef_url)
    status = resp.getcode()
    if status != 200:
        raise Exception("Invalid response %s" % (status,))
    data = json.loads(resp.read())
    resp.close()
    return data




    */

}
