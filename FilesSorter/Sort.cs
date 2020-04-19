using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FilesSorter
{
    public class Sort
    {
        readonly string _path;
        public Sort(string path)
        {
            _path = path;
            CreateFolderAndMoveFiles();
        }

        private List<string> GetAllFiles()
        {
            return Directory.GetFiles(_path).ToList();
        }

        private List<string> GetExistingExtension()
        {
            var files = GetAllFiles();
            List<string> extensions = new List<string>();
            extensions.AddRange(files.Select(file => Path.GetExtension(file)).Distinct());
            return extensions;
        }

        private void CreateFolderAndMoveFiles()
        {
            var extensions = GetExistingExtension();
            foreach (var extension in extensions)
            {
                var path = string.Empty;
                if (!string.IsNullOrEmpty(extension))
                {
                    var ext = extension.Remove(0, 1);
                    path = _path + "/" + ext.Trim().ToUpper();
                }
                else
                {
                    path = _path + "/" + Constants.FILEWITHOUTEXTENSION;
                }
                Directory.CreateDirectory(path);
                MoveFiles(extension, path);
            }
        }

        private void MoveFiles(string extension, string path)
        {
            var files = GetAllFiles();
            var specificFiles = files.Where(r => r.EndsWith(extension)).Select(r => r);
            foreach (var file in specificFiles)
            {
                var fileName = Path.GetFileName(file);
                var newLocation = path + "/" + fileName;
                File.Move(file, newLocation, false);
            }
        }
    }
}
