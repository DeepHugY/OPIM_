using ECommon.Dapper;
using OPIM_Common.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_Dapper.Dappers
{
    public class RecordDapper : DbConnectionSetting
    {
        public Results Create(RecordsModel model)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var result = connection.Insert(new
                    {
                        Id = model.Id,
                        TypeId = model.TypeId,
                        Source = model.Source,
                        Money = model.Money,
                        Remark = model.Remark,
                        CreateOn = model.CreateOn,
                        CreateBy = model.CreateBy
                    }, OPIM_Common.TableName.Records);
                    return new Results();
                }
                catch (Exception ex)
                {
                    return new Results(ex.Message);
                }
            }
        }

        public Results Delete(Guid id)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var result = connection.Delete(new
                    {
                        Id = id
                    }, OPIM_Common.TableName.Records);
                    return new Results();
                }
                catch (Exception ex)
                {

                    return new Results(ex.Message);
                }
            }
        }
        public Results Update(RecordsModel model)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var result = connection.Update(new
                    {
                        //TypeId = model.TypeId,
                        //Source = model.Source,
                        Money = model.Money,
                        Remark = model.Remark
                    }, new
                    {
                        Id = model.Id
                    }, OPIM_Common.TableName.Records);
                    return new Results();
                }
                catch (Exception ex)
                {
                    return new Results(ex.Message);
                }
            }
        }
        public IEnumerable<RecordsModel> QueryList()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var result = connection.QueryList<RecordsModel>(new { }, OPIM_Common.TableName.Records);
                return result;
            }
        }
    }
}
