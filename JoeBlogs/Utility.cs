using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;

namespace JoeBlogs
{
    /// <summary>
    /// Utility class.
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Converts the image to a byte array.
        /// </summary>
        /// <param name="imageToConvert">The image to convert.</param>
        /// <param name="formatOfImage">The format of image.</param>
        /// <returns></returns>
        public static byte[] ConvertImageToByteArray(Image imageToConvert, ImageFormat formatOfImage)
        {
            byte[] Ret;
            using (MemoryStream ms = new MemoryStream())
            {
                imageToConvert.Save(ms, formatOfImage);
                Ret = ms.ToArray();
            }
            return Ret;
        }

        /// <summary>
        /// Converts the byte array to image.
        /// </summary>
        /// <param name="byteArray">The byte array.</param>
        /// <returns></returns>
        public static Image ConvertByteArrayToImage(byte[] byteArray)
        {
            if (byteArray != null)
            {
                MemoryStream ms = new MemoryStream(byteArray, 0,
                byteArray.Length);
                ms.Write(byteArray, 0, byteArray.Length);
                return Image.FromStream(ms, true);
            }
            return null;
        }
    }

    public static class EnumUtility
    {
        public static string GetCommentStatusName(CommentStatus status)
        {
            return Enum.GetName(typeof(CommentStatus), status);
        }
        public static CommentStatus GetCommentStatus(string commentStatus)
        {
            try
            {
                return (CommentStatus)Enum.Parse(typeof(CommentStatus), commentStatus);
            }
            catch (ArgumentException)
            {
                throw new ArgumentException(string.Format("Status value of '{0}' doesn't exist in the CommentStatus enum", commentStatus));
            }
        }
    }

    public static class StringUtility
    {
        public static string ToUpperFirstLetter(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;
            // convert to char array of the string
            char[] letters = source.ToCharArray();
            // upper case the first char
            letters[0] = char.ToUpper(letters[0]);
            // return the array made of the new char array
            return new string(letters);
        }
    }

    public static class MapUtility
    {
        public static void SetPrivateFieldValue<T>(string fieldName, object value, T obj)
        {
            var propertyInfo = typeof(T)
                .GetField(fieldName, BindingFlags.Instance | BindingFlags.NonPublic);

            propertyInfo.SetValue(obj, value);
        }
    }
}