using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetFinderApi.ImageManager
{
    public class ByteArrayImageConversion
    {
        public readonly string ContentType;
        public readonly byte[] ContentByteArray;
        public readonly string Extension;
        public readonly bool IsSuccesfull;

        public ByteArrayImageConversion(string base64String)
        {
            string[] base64StringArrayCommaSplit = base64String.Split(",");
            if(base64StringArrayCommaSplit.Length < 2)
            {
                IsSuccesfull = false;
                return;
            }

            string b64Metadata = base64StringArrayCommaSplit[0];
            string b64Content = base64StringArrayCommaSplit[1];
            try
            {
                ContentType = b64Metadata.Split(";")[0].Split(":")[1];
                Extension = MimeTypeMap.List.MimeTypeMap.GetExtension(ContentType).FirstOrDefault();
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                ContentByteArray = Convert.FromBase64String(b64Content);
                IsSuccesfull = true;
            }
            catch (Exception)
            {
                IsSuccesfull = false;
                return;
            }

        }
    }
}
