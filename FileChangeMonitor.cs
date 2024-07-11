using System;
using System.IO;

namespace Agri_Energy_Connect_Web_Application
{
    public class FileChangeMonitor
    {
        private FileSystemWatcher _fileWatcher;

        public event EventHandler<FileChangedEventArgs> FileChanged;

        public FileChangeMonitor(string path, string filter = "*.cs")
        {
            _fileWatcher = new FileSystemWatcher
            {
                Path = path,
                Filter = filter,
                NotifyFilter = NotifyFilters.LastWrite
            };

            _fileWatcher.Changed += OnChanged;
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            FileChanged?.Invoke(this, new FileChangedEventArgs { FilePath = e.FullPath });
        }

        public void Start()
        {
            _fileWatcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            _fileWatcher.EnableRaisingEvents = false;
        }
    }

    public class FileChangedEventArgs : EventArgs
    {
        public string FilePath { get; set; }
    }
}
