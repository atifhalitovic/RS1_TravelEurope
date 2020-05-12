using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TravelEurope.Util.FileManager;

namespace TravelEurope.Util
{
    public class ImgUploadHelper
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IFileManager _fileManager;
        public ImgUploadHelper(IHostingEnvironment he,IFileManager manager)
        {
            _hostingEnvironment = he;
            _fileManager = manager;
        }


        public async Task<string> GetImgLocationAsync(IFormFile imgInp)
        {
            if (imgInp == null)
                return "images//default-profile-photo.png";

            return await _fileManager.Save(imgInp, "images\\ProfileImages");
        }

    }
}
