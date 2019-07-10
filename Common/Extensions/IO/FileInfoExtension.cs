using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using System.Linq;

namespace CommonLib.Extensions.IO
{
    public static class FileInfoExtension
    {
        #region CompareTo(比较文件)

        /// <summary>
        /// 比较文件
        /// </summary>
        /// <param name="file1">文件1</param>
        /// <param name="file2">文件2</param>
        /// <returns></returns>
        public static bool CompareTo(this FileInfo file1, FileInfo file2)
        {
            if (file1 == null || !file1.Exists)
            {
                throw new ArgumentNullException(nameof(file1));
            }

            if (file2 == null || !file2.Exists)
            {
                throw new ArgumentNullException(nameof(file2));
            }

            if (file1.Length != file2.Length)
            {
                return false;
            }

            return file1.Read().Equals(file2.Read());
        }

        #endregion

        #region Read(读取文件并转换为字符串)

        /// <summary>
        /// 读取文件并转换为字符串
        /// </summary>
        /// <param name="file">文件</param>
        /// <returns></returns>
        public static string Read(this FileInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (file.Exists == false)
            {
                return string.Empty;
            }

            using (var reader = file.OpenText())
            {
                return reader.ReadToEnd();
            }
        }

        #endregion

        #region ReadBinary(读取文件并转换为二进制数组)

        /// <summary>
        /// 读取文件并转换为二进制数组
        /// </summary>
        /// <param name="file">文件</param>
        /// <returns></returns>
        public static byte[] ReadBinary(this FileInfo file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            if (file.Exists == false)
            {
                return new byte[0];
            }

            using (var reader = file.OpenRead())
            {
                return reader.ReadAllBytes();
            }
        }

        #endregion

        public static String ChangeExtension(this FileInfo @this, String extension)
        {
            return Path.ChangeExtension(@this.FullName, extension);
        }


        public static void AppendAllLines(this FileInfo @this, IEnumerable<String> contents)
        {
            File.AppendAllLines(@this.FullName, contents);
        }

        /// <summary>
        ///     A FileInfo extension method that appends all lines.
        /// </summary>
        /// <param name="this">The @this to act on.</param>
        /// <param name="contents">The contents.</param>
        /// <param name="encoding">The encoding.</param>
        public static void AppendAllLines(this FileInfo @this, IEnumerable<String> contents, Encoding encoding)
        {
            File.AppendAllLines(@this.FullName, contents, encoding);
        }


        public static void AppendAllText(this FileInfo @this, String contents)
        {
            File.AppendAllText(@this.FullName, contents);
        }

        public static void AppendAllText(this FileInfo @this, String contents, Encoding encoding)
        {
            File.AppendAllText(@this.FullName, contents, encoding);
        }
        public static int CountLines(this FileInfo @this)
        {
            return File.ReadAllLines(@this.FullName).Length;
        }

        public static int CountLines(this FileInfo @this, Func<string, bool> predicate)
        {
            return File.ReadAllLines(@this.FullName).Count(predicate);
        }


        public static String GetDirectoryFullName(this FileInfo @this)
        {
            return @this.Directory.FullName;
        }

        public static String GetDirectoryName(this FileInfo @this)
        {
            return @this.Directory.Name;
        }

        public static String GetFileNameWithoutExtension(this FileInfo @this)
        {
            return Path.GetFileNameWithoutExtension(@this.FullName);
        }

        public static String GetPathRoot(this FileInfo @this)
        {
            return Path.GetPathRoot(@this.FullName);
        }
        public static Boolean HasExtension(this FileInfo @this)
        {
            return Path.HasExtension(@this.FullName);
        }

        public static Boolean IsPathRooted(this FileInfo @this)
        {
            return Path.IsPathRooted(@this.FullName);
        }

        public static Byte[] ReadAllBytes(this FileInfo @this)
        {
            return File.ReadAllBytes(@this.FullName);
        }
        public static String[] ReadAllLines(this FileInfo @this, Encoding encoding)
        {
            return File.ReadAllLines(@this.FullName, encoding);
        }


        public static string ReadToEnd(this FileInfo @this)
        {
            using (FileStream stream = File.Open(@this.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(stream, Encoding.Default))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static string ReadToEnd(this FileInfo @this, long position)
        {
            using (FileStream stream = File.Open(@this.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                stream.Position = position;

                using (var reader = new StreamReader(stream, Encoding.Default))
                {
                    return reader.ReadToEnd();
                }
            }
        }


        public static string ReadToEnd(this FileInfo @this, Encoding encoding)
        {
            using (FileStream stream = File.Open(@this.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static string ReadToEnd(this FileInfo @this, Encoding encoding, long position)
        {
            using (FileStream stream = File.Open(@this.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                stream.Position = position;

                using (var reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }


        public static void Rename(this FileInfo @this, string newName)
        {
            string filePath = Path.Combine(@this.Directory.FullName, newName);
            @this.MoveTo(filePath);
        }

        public static void RenameExtension(this FileInfo @this, String extension)
        {
            string filePath = Path.ChangeExtension(@this.FullName, extension);
            @this.MoveTo(filePath);
        }
        public static void RenameFileWithoutExtension(this FileInfo @this, string newName)
        {
            string fileName = string.Concat(newName, @this.Extension);
            string filePath = Path.Combine(@this.Directory.FullName, fileName);
            @this.MoveTo(filePath);
        }

        public static void WriteAllLines(this FileInfo @this, String[] contents)
        {
            File.WriteAllLines(@this.FullName, contents);
        }

        public static void WriteAllLines(this FileInfo @this, String[] contents, Encoding encoding)
        {
            File.WriteAllLines(@this.FullName, contents, encoding);
        }

        public static void WriteAllLines(this FileInfo @this, IEnumerable<String> contents)
        {
            File.WriteAllLines(@this.FullName, contents);
        }
        public static void WriteAllLines(this FileInfo @this, IEnumerable<String> contents, Encoding encoding)
        {
            File.WriteAllLines(@this.FullName, contents, encoding);
        }
        public static void WriteAllText(this FileInfo @this, String contents)
        {
            File.WriteAllText(@this.FullName, contents);
        }
        public static void WriteAllText(this FileInfo @this, String contents, Encoding encoding)
        {
            File.WriteAllText(@this.FullName, contents, encoding);
        }
    }
}
