using OPIM_Common;
using OPIM_Common.DataModels;
using OPIM_Dapper.Dappers;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace OPIM_BLL.Respository
{
    public class ImageRespository
    {
        private readonly MemberShipDapper _memberShipDapper;
        public ImageRespository()
        {
            this._memberShipDapper = new MemberShipDapper();
        }
        public async Task<Results> UploadMemberShipIcon(Guid id, string base64)
        {
            var memberShip = _memberShipDapper.GetMemberShipById(id);
            string[] imgData = base64.Split(',');
            string extendedName = FileHelper.GetExtendedNameByBase64(imgData[0]);
            string name = FileHelper.GenerateNameByRandom(extendedName);
            string path = ConfigurationManager.AppSettings["IconPath"] + memberShip.Account + @"\";
            var absolutePath = PathHelper.GetAbsolutePath() + path;
            FileHelper fileHelper = new FileHelper();
            int fileResult = await fileHelper.WriteFile(absolutePath, name, imgData[1]);
            if (fileResult < 0)
            {
                return new Results("图片写入失败");
            }
            var relativePath = PathHelper.GetRelativePath(path+name);
            return _memberShipDapper.UpdateIcon(id, relativePath);
        }
    }
}
