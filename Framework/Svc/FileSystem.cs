using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Runtime.InteropServices;


namespace DesignedNet.Framework.Svc
{
	// ========================================
	public class FileCache
	{
		public int Type;
		public long Size;
		public string Ext;
		public string Name;
		public string Path;
		public string Details;
		public DateTime Created;
		public DateTime Modified;
	}

	// ========================================
	public class PathCache
	{
		public int Type;
		public string Name;
		public string Path;
		public string Parent;
		public string Details;
		public DateTime Created;
		public DateTime Modified;
		public FileCache[] Files;
		public PathCache[] Subdirs;
		public FileAttributes Attributes;
		public bool IsHidden { get { return ((Attributes & FileAttributes.Hidden) == FileAttributes.Hidden); } }
		public bool IsSystem { get { return ((Attributes & FileAttributes.System) == FileAttributes.System); } }
		public bool IsEncrypted { get { return ((Attributes & FileAttributes.Encrypted) == FileAttributes.Encrypted); } }
		public bool IsCompressed { get { return ((Attributes & FileAttributes.Compressed) == FileAttributes.Compressed); } }
		public FileCache[] GetFiles()
		{
			if (Files == null) Files = null; 
			return Files;
		}
		public PathCache[] GetSubdirs()
		{
			if (Subdirs == null) Subdirs = FileSystem.CachePaths(Path); 
			return Subdirs;
		}
	}

	// ========================================
	/// <summary>
	/// Summary description for FileSystem.
	/// </summary>
	public class FileSystem
	{
		// ========================================
		public FileSystem() {}


		// ========================================
		#region External Methods

		// ----------------------------------------
		[DllImport("kernel32")]
		private static extern uint GetDriveType(string lpRootPathName);

		// ----------------------------------------
		[DllImport("kernel32.dll")]
		public static extern long GetVolumeInformation(string strPathName,
			StringBuilder strVolumeNameBuffer,
			long lngVolumeNameSize,
			long lngVolumeSerialNumber,
			long lngMaximumComponentLength,
			long lngFileSystemFlags,
			StringBuilder strFileSystemNameBuffer,
			long lngFileSystemNameSize);
		#endregion


		// ========================================
		#region Static Operations

		// ----------------------------------------
		// 0: Unknown, 1: NoRootDrive, 2: Removable, 3: LocalDisk, 4: Network, 5: Optical, 6: RAMDrive
		public static int DriveType(string path) { return Convert.ToInt32(GetDriveType(Path.GetPathRoot(path))); }

		// ----------------------------------------
		public static string DriveName(string path)
		{
			long sn = new long();
			long sysflags = new long();
			long maxcomplen = new long();
			StringBuilder volname = new StringBuilder(256);
			StringBuilder sysname = new StringBuilder(256);
			long retval= new long();
			retval = GetVolumeInformation(Path.GetPathRoot(path), volname, 256, sn, maxcomplen, sysflags, sysname, 256);            
			if (retval == 0)
				return "";
			else
				return volname.ToString();
		}

		// ----------------------------------------
		/*
		public static string DirectoryName(string path)
		{
			// trim trailing slash
			if (path.EndsWith(Path.DirectorySeparatorChar.ToString())) path = path.TrimEnd(Path.DirectorySeparatorChar);

			// find last slash
			int index = path.LastIndexOf(Path.DirectorySeparatorChar);
			if (index > 0)
				return path.Substring(index+1);
			else
				return path;
		}
		*/

		// ----------------------------------------
		public static int FileType(string file)
		{
			string extension = Path.GetExtension(file);
			switch (extension.ToLower())
			{
				case ".txt":
				case ".nfo":
					return 2; // Text
				case ".gif":
				case ".jpg":
				case ".tif":
					return 3; // Photo
				case ".avi":
				case ".mpg":
				case ".wmv":
					return 4; // Video
				case ".mp3":
				case ".wav":
				case ".wma":
					return 5; // Audio
				default:
					return 1; // Unknown
			}
		}
		
		// ----------------------------------------
		public static FileCache CacheFile(string file) { return CacheFile(new FileInfo(file)); }
		public static FileCache CacheFile(FileInfo file)
		{
			FileCache cache = new FileCache();
			cache.Modified = file.LastWriteTime;
			cache.Created = file.CreationTime;
			cache.Details = "Details...";
			cache.Type = FileType(file.Name);
			cache.Path = file.FullName;
			cache.Size = file.Length;
			cache.Name = file.Name;
			cache.Ext = file.Extension;
			return cache;
		}

		// ----------------------------------------
		public static PathCache[] CachePaths(string path)
		{
			// get directory
			DirectoryInfo dir = new DirectoryInfo(path);
			if (dir.Exists)
			{
				// create cache array
				int index = 0;
				DirectoryInfo[] subdirs = dir.GetDirectories();
				PathCache[] paths = new PathCache[subdirs.Length];
				foreach(DirectoryInfo subdir in subdirs)
				{
					paths[index] = CachePath(subdir);
					index++;
				}
				return paths;
			}
			else
				return null;
		}

		// ----------------------------------------
		public static PathCache CacheRoot(string path)
		{
			PathCache cache = new PathCache();
			cache.Path = path;
			cache.Name = path.ToUpper();
			cache.Type = FileSystem.DriveType(path);
			if ((cache.Type == 3) || (cache.Type == 5)) // Local Fixed + Optical Discs
			{
				// create drive name
				string label = FileSystem.DriveName(Path.GetPathRoot(path));
				if (label.Length > 0) cache.Name = path.ToUpper() + " (" + label + ")";
				try // load details
				{
					DirectoryInfo dir = new DirectoryInfo(path);
					cache.Details = "Details...";
					cache.Created = dir.CreationTime;
					cache.Modified = dir.LastWriteTime;
					cache.Attributes = dir.Attributes;
				}
				catch {}
			}
			return cache;
		}

		// ----------------------------------------
		public static PathCache CachePath(object cache) { return (PathCache)cache; }
		public static PathCache CachePath(string path) { return CachePath(new DirectoryInfo(path)); }
		public static PathCache CachePath(DirectoryInfo path)
		{
			PathCache cache = new PathCache();
			cache.Type = 7; // default type to folder
			cache.Name = path.Name;
			cache.Path = path.FullName;
			cache.Details = "Details...";
			cache.Created = path.CreationTime;
			cache.Modified = path.LastWriteTime;
			cache.Attributes = path.Attributes;
			if (cache.IsCompressed) cache.Type = 9;
			if (cache.IsEncrypted) cache.Type = 11;
			return cache;
		}

		#endregion

	}
}