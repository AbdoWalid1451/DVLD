using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business_Layer
{
    public class clsUtil
    {

        public static string CreateGUID()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }

        public static string ReplaceFileNameWithGuid(string SourceFile)
        {
            return CreateGUID() + new FileInfo(SourceFile).Extension;
        }

        public static bool CopyPhotoToPhotosPlace(ref string SourcePath)
        {
            if (string.IsNullOrEmpty(SourcePath))
                return false;
           
            bool flag = false;

            string destinationFolder = @"D:\programing\Abu-Hadhoud_Course\تاسيس 2\DVLD\assets\PeopleImages";

            string destinationPath = Path.Combine(destinationFolder, ReplaceFileNameWithGuid(SourcePath));

            try
            {
             File.Copy(SourcePath, destinationPath, true);
                SourcePath = destinationPath;
                flag = true;
            }
            catch { 
            }
            return flag;
        }
    }
}
