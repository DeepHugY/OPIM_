using OPIM_Common;
using OPIM_Common.DataModels;
using OPIM_Dapper.Dappers;
using OPIM_EntityFramework.QueryService;
using OPIM_EntityFramework.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_BLL.Respository
{
    public class RecordRespository
    {
        private readonly RecordDapper _recordDapper;
        private readonly RecordQueryService _recordQueryService;
        private readonly TypesDapper _typesDapper;
        public RecordRespository()
        {
            this._recordDapper = new RecordDapper();
            this._recordQueryService = new RecordQueryService();
            this._typesDapper = new TypesDapper();
        }

        public Results CreateRecord(RecordsModel model)
        {
            if (model.TypeId == Guid.Empty || model.TypeId == null)
            {
                return new Results("请选择类型");
            }
            if (model.Source == null)
            {
                return new Results("请选择记录来源");
            }
            return _recordDapper.Create(model);
        }


        public Results CreateFromCsv(Guid memberShipId ,string path )
        {
            //判断是不是有类型Type
            Guid typeOutId = Guid.Empty;
            var typeOut = _typesDapper.GetTypeByName("支付宝支出").ToList();
            if (typeOut.Count < 1)
            {
                TypesModel typeOutModel = new TypesModel();
                typeOutModel.Id = Guid.NewGuid();
                typeOutModel.InOrOut = 1;
                typeOutModel.CreateBy = memberShipId;
                typeOutModel.CreateOn = DateTime.Now;
                typeOutModel.Name = "支付宝支出";
                var createTypeOutResult = _typesDapper.Create(typeOutModel);
                if (createTypeOutResult.Success)
                    typeOutId = typeOutModel.Id;
                else
                    return new Results("创建类型失败");
            }
            else
            {
                typeOutId = typeOut[0].Id;
            }
            Guid typeInId = Guid.Empty;
            var typeIn = _typesDapper.GetTypeByName("支付宝收入").ToList();
            if (typeIn.Count < 1)
            {
                TypesModel typeInModel = new TypesModel();
                typeInModel.Id = Guid.NewGuid();
                typeInModel.InOrOut = 0;
                typeInModel.CreateBy = memberShipId;
                typeInModel.CreateOn = DateTime.Now;
                typeInModel.Name = "支付宝收入";
                var createTypeInResult = _typesDapper.Create(typeInModel);
                if (createTypeInResult.Success)
                    typeInId = typeInModel.Id;
                else
                    return new Results("创建类型失败");
            }
            else
            {
                typeInId = typeIn[0].Id;
            }

            //添加数据
            var dt = FileHelper.OpenCSV(path);
            var length = dt.Rows.Count;
            var type1 = dt.Rows[2][10].ToString();
            List<RecordsModel> list = new List<RecordsModel>();
            for (int i = 0; i < length; i++)
            {
                if (!StringHelper.IsNullOrEmptyOrWhiteSpace(dt.Rows[i][10].ToString()))
                {
                    RecordsModel model = new RecordsModel();
                    model.Id = Guid.NewGuid();
                    model.Money = decimal.Parse(dt.Rows[i][9].ToString());
                    model.Remark = dt.Rows[i][8].ToString();
                    model.CreateBy = memberShipId;
                    model.CreateOn = StringHelper.DateTimeConver(dt.Rows[i][2].ToString().Split(' ')[0]);
                    model.Source = "支付宝";
                    var type = dt.Rows[i][10].ToString().TrimEnd();
                    if ( type== "收入")
                        model.TypeId = typeInId;
                    if (type == "支出")
                        model.TypeId = typeOutId;
                    list.Add(model);
                }

            }
            foreach (var item in list)
            {
                _recordDapper.Create(item);
            }
            return new Results();
        }

        public Results UpdateRecord(RecordsModel model)
        {
            if (model.Id == null || model.Id == Guid.Empty)
            {
                return new Results("Id不能为空");
            }
            if (model.Money < 0)
            {
                return new Results("输入的金额不合法");
            }
            return _recordDapper.Update(model);
        }

        public Results RemoveRecord(Guid id)
        {
            if (id == null || id == Guid.Empty)
            {
                return new Results("Id不能为空");
            }
            return _recordDapper.Delete(id);
        }
        public List<RecordView> QueryRecordsList(string search, string date, int inOrOut, Guid memberShipId, out int total, string orderBy, string orderType, int pageIndex, int pageSize)
        {
            List<RecordView> list = new List<RecordView>();
            if (inOrOut == 3)
                list = _recordQueryService.FindWithDate(search, date, memberShipId, out total, orderBy, orderType, pageIndex, pageSize).ToList();
            else
                list = _recordQueryService.FindWithDateAndInOrOut(search, date, inOrOut, memberShipId, out total, orderBy, orderType, pageIndex, pageSize).ToList();
            return list;
        }
        public List<RecordView> QueryRecordsListWithDate(string search, string date, Guid memberShipId, out int total, string orderBy, string orderType, int pageIndex, int pageSize)
        {
            var list = _recordQueryService.FindWithDate(search, date, memberShipId, out total, orderBy, orderType, pageIndex, pageSize).ToList();
            return list;
        }

    }
}
