// https://stackoverflow.com/questions/1922040/resize-an-image-c-sharp
// https://stackoverflow.com/questions/3213999/how-to-create-an-icon-file-that-contains-multiple-sizes-images-in-c-sharp

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

/// <summary>
/// Method utilities for creating icons, checking path, resize, etc.
/// </summary>
public class Utility
{
    /// <summary>
    /// Resize the image to the specified width and height.
    /// </summary>
    /// <param name="image">The image to resize.</param>
    /// <param name="width">The width to resize to.</param>
    /// <param name="height">The height to resize to.</param>
    /// <returns>The resized image.</returns>
    public static Bitmap ResizeImage(Image image, Size size, bool fit)
    {
        int width = size.Width;
        int height = size.Height;
        Rectangle destRect = new Rectangle(0, 0, width, height);
        Bitmap destImage = new Bitmap(width, height, PixelFormat.Format32bppArgb);

        if (fit)
        {
            if (image.Width > image.Height)
            {
                destRect.Height = (int)(image.Height / (float)image.Width * height);
                destRect.Y = (height - destRect.Height) / 2;
            }
            else
            {
                destRect.Width = (int)(image.Width / (float)image.Height * width);
                destRect.X = (width - destRect.Width) / 2;
            }
        }

        destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

        using (Graphics graphics = Graphics.FromImage(destImage))
        {
            graphics.CompositingMode = CompositingMode.SourceCopy;
            graphics.CompositingQuality = CompositingQuality.HighQuality;
            graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

            using (ImageAttributes wrapMode = new ImageAttributes())
            {
                wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
            }
        }

        return destImage;
    }



    // ---------------------------------------------------------------------------------------
    // ---------------------------------------------------------------------------------------

    /// <summary>
    /// Represents the max allowed width of an icon.
    /// </summary>
    private const int MaxIconWidth = 256;

    /// <summary>
    /// Represents the max allowed height of an icon.
    /// </summary>
    private const int MaxIconHeight = 256;

    private const ushort HeaderReserved = 0;
    private const ushort HeaderIconType = 1;
    private const byte HeaderLength = 6;

    private const byte EntryReserved = 0;
    private const byte EntryLength = 16;

    private const byte PngColorsInPalette = 0;
    private const ushort PngColorPlanes = 1;

    /// <summary>
    /// Saves the specified <see cref="Bitmap"/> objects as a single 
    /// icon into the output stream.
    /// </summary>
    /// <param name="images">The bitmaps to save as an icon.</param>
    /// <param name="stream">The output stream.</param>
    /// <remarks>
    /// The expected input for the <paramref name="images"/> parameter are 
    /// portable network graphic files that have a <see cref="Image.PixelFormat"/> 
    /// of <see cref="PixelFormat.Format32bppArgb"/> and where the
    /// width is less than or equal to <see cref="MaxIconWidth"/> and the 
    /// height is less than or equal to <see cref="MaxIconHeight"/>.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Occurs if any of the input images do 
    /// not follow the required image format. See remarks for details.
    /// </exception>
    /// <exception cref="ArgumentNullException">
    /// Occurs if any of the arguments are null.
    /// </exception>
    public static void SavePngsAsIcon(IEnumerable<Bitmap> images, Stream stream)
    {
        if (images == null)
            throw new ArgumentNullException("images");
        if (stream == null)
            throw new ArgumentNullException("stream");

        Bitmap[] orderedImages = images.Where(i => i != null)
                                       .OrderBy(i => i.Width)
                                       .ThenBy(i => i.Height)
                                       .ToArray();

        using (BinaryWriter writer = new BinaryWriter(stream))
        {

            // write the header
            writer.Write(HeaderReserved);
            writer.Write(HeaderIconType);
            writer.Write((ushort)orderedImages.Length);

            // save the image buffers and offsets
            Dictionary<uint, byte[]> buffers = new Dictionary<uint, byte[]>();

            // tracks the length of the buffers as the iterations occur
            // and adds that to the offset of the entries
            uint lengthSum = 0;
            uint baseOffset = (uint)(HeaderLength +
                                     EntryLength * orderedImages.Length);

            for (int i = 0; i < orderedImages.Length; i++)
            {
                Bitmap image = orderedImages[i];

                // creates a byte array from an image
                byte[] buffer = CreateImageBuffer(image);

                // calculates what the offset of this image will be
                // in the stream
                uint offset = (baseOffset + lengthSum);

                // writes the image entry
                writer.Write(GetIconWidth(image));
                writer.Write(GetIconHeight(image));
                writer.Write(PngColorsInPalette);
                writer.Write(EntryReserved);
                writer.Write(PngColorPlanes);
                writer.Write((ushort)Image.GetPixelFormatSize(image.PixelFormat));
                writer.Write((uint)buffer.Length);
                writer.Write(offset);

                lengthSum += (uint)buffer.Length;

                // adds the buffer to be written at the offset
                buffers.Add(offset, buffer);
            }

            // writes the buffers for each image
            foreach (KeyValuePair<uint, byte[]> kvp in buffers)
            {

                // seeks to the specified offset required for the image buffer
                writer.BaseStream.Seek(kvp.Key, SeekOrigin.Begin);

                // writes the buffer
                writer.Write(kvp.Value);
            }
        }

    }

    private static byte GetIconHeight(Bitmap image)
    {
        if (image.Height == MaxIconHeight)
            return 0;

        return (byte)image.Height;
    }

    private static byte GetIconWidth(Bitmap image)
    {
        if (image.Width == MaxIconWidth)
            return 0;

        return (byte)image.Width;
    }

    private static byte[] CreateImageBuffer(Bitmap image)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            image.Save(stream, ImageFormat.Png);

            return stream.ToArray();
        }
    }

    // ---------------------------------------------------------------------------------------
    // ---------------------------------------------------------------------------------------

    private static readonly string numberPattern = " ({0})";

    public static string NextAvailableFilename(string path)
    {
        // Short-cut if already available
        if (!File.Exists(path))
            return path;

        // If path has extension then insert the number pattern just before the extension and return next filename
        if (Path.HasExtension(path))
            return GetNextFilename(path.Insert(path.LastIndexOf(Path.GetExtension(path)), numberPattern));

        // Otherwise just append the pattern to the path and return next filename
        return GetNextFilename(path + numberPattern);
    }

    private static string GetNextFilename(string pattern)
    {
        string tmp = string.Format(pattern, 1);
        if (tmp == pattern)
            throw new ArgumentException("The pattern must include an index place-holder", "pattern");

        if (!File.Exists(tmp))
            return tmp; // short-circuit if no matches

        int min = 1, max = 2; // min is inclusive, max is exclusive/untested

        while (File.Exists(string.Format(pattern, max)))
        {
            min = max;
            max *= 2;
        }

        while (max != min + 1)
        {
            int pivot = (max + min) / 2;
            if (File.Exists(string.Format(pattern, pivot)))
                min = pivot;
            else
                max = pivot;
        }

        return string.Format(pattern, max);
    }
    // -------------------------------------------------------------------------------------------

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool Wow64DisableWow64FsRedirection(ref IntPtr intptr);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool Wow64RevertWow64FsRedirection(ref IntPtr intptr);

    public static void InvalidateExplorerCache()
    {
        try
        {
            IntPtr intptr = new IntPtr();
            // Calling 32 bit to external 64 bit is dangerous....
            if (Wow64DisableWow64FsRedirection(ref intptr))
            {
                Process.Start("ie4uinit", "-show");
                Wow64RevertWow64FsRedirection(ref intptr);
            }
            else
                Process.Start("ie4uinit", "-show");
        }
        catch (Exception)
        {

        }
    }

}

