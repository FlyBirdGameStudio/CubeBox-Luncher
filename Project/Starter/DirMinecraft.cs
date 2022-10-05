using System;
using System.IO;

namespace Starter
{
    public class DirMinecraft
    {
        private readonly bool isDirPath = false;
        private readonly string folderPath;

        public DirMinecraft(string path)
        {
            folderPath = path;
            if (folderPath[2] == ':')
                isDirPath = true;
        }

        public string GetFullPath()
        {
            if (isDirPath)
                return folderPath;
            return string.Format("{0}/{1}", AppDomain.CurrentDomain.BaseDirectory, folderPath);
        }

        public string PathBuilder(string subpath)
        {
            if (isDirPath)
                return string.Format("{0}/{1}", folderPath, subpath);
            return string.Format("{0}/{1}/{2}",
                AppDomain.CurrentDomain.BaseDirectory,
                folderPath,
                subpath
                );
        }

        public string PathCreater(string pathBuilder)
        {
            if (!Directory.Exists(pathBuilder))
                Directory.CreateDirectory(pathBuilder);
            return pathBuilder;
        }

        public DirMinecraft CreateSubFolder(string name)
        {
            string pth = PathBuilder(name);
            if (!Directory.Exists(pth))
                Directory.CreateDirectory(pth);
            return this;
        }

        public DirMinecraft CreateSubFolders(string[] folders)
        {
            foreach(var folder in folders)
            {
                string pth = PathBuilder(folder);
                if (!Directory.Exists(pth))
                    Directory.CreateDirectory(pth);
            }
            return this;
        }

        public DirMinecraft DeleteSubFolder(string name)
        {
            string pth = PathBuilder(name);
            if (Directory.Exists(pth))
                Directory.Delete(pth);
            return this;
        }

        public bool IsSubFolderExsist(string name)
        {
            string pth = PathBuilder(name);
            return Directory.Exists(pth);
        }

        public bool IsFolderExsisit()
        {
            if (isDirPath)
                return Directory.Exists(folderPath);
            return Directory.Exists(string.Format(
                "{0}/{1}",
                AppDomain.CurrentDomain.BaseDirectory,
                folderPath
                ));
        }
    }
}
