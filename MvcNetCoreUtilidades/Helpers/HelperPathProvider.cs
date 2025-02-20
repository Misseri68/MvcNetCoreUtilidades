using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace MvcNetCoreUtilidades.Helpers
{

    public enum Folders { Images, Facturas, Uploads, Temporal}
    public class HelperPathProvider
    {

        private IWebHostEnvironment env;
        private IServer server;

        public HelperPathProvider(IWebHostEnvironment env, IServer server) {
            this.env = env;
            this.server = server;
        }


        public string MapPath(string fileName, Folders folder)
        {
            string carpeta = "";
            if (folder == Folders.Images)
            {
                carpeta = "images";
            }
            else if (folder == Folders.Facturas)
            {
                carpeta = "facturas";
            }
            else if (folder == Folders.Uploads)
            {
                carpeta = "uploads";
            }else if(folder == Folders.Temporal)
            {
                carpeta = "temporal";
            }



            string rootPath = this.env.WebRootPath;
            string path = Path.Combine(rootPath, carpeta, fileName);
            return path;

        }

        public string MapUrlPath(string fileName, Folders folder)
        {
            string carpeta = "";
            if (folder == Folders.Images)
            {
                carpeta = "images";
            }
            else if (folder == Folders.Facturas)
            {
                carpeta = "facturas";
            }
            else if (folder == Folders.Uploads)
            {
                carpeta = "uploads";
            }
            else if (folder == Folders.Temporal)
            {
                carpeta = "temporal";
            }

            var addresses = this.server.Features.Get<IServerAddressesFeature>().Addresses;
            string serverUrl = addresses.FirstOrDefault();
            string urlPath = serverUrl + "/" + carpeta + "/" + fileName;
            return urlPath;
        }


    }
}
