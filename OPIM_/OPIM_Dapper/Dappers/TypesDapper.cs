using ECommon.Dapper;
using OPIM_Common.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_Dapper.Dappers
{
    public class TypesDapper : DbConnectionSetting
    {
        public Results Create(TypesModel model)
        {

            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var result = connection.Insert(new
                    {
                        Id = model.Id,
                        Name = model.Name,
                        InOrOut = model.InOrOut,
                        CreateOn = model.CreateOn,
                        CreateBy = model.CreateBy,
                        Remark=model.Remark
                    }, OPIM_Common.TableName.Types);
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
                    }, OPIM_Common.TableName.Types);
                    return new Results();
                }
                catch (Exception ex)
                {
                    return new Results(ex.Message);
                }


            }
        }

        public IEnumerable<TypesModel> QueryList()
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var result = connection.QueryList<TypesModel>(new { }, OPIM_Common.TableName.Types).ToList();
                return result;
            }
        }
        public IEnumerable<TypesModel> GetTypeByName(string name)
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                var result = connection.QueryList<TypesModel>(new {Name=name }, OPIM_Common.TableName.Types).ToList();
                return result;
            }
        }

        public Results Update(TypesModel model)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var result = connection.Update(new
                    {
                        Name = model.Id,
                        InOrOut = model.InOrOut,
                        Remark=model.Remark,
                    }, new
                    {
                        Id = model.Id
                    }, OPIM_Common.TableName.Types);
                    return new Results();
                }
                catch (Exception ex)
                {
                    return new Results(ex.Message);
                }
            }
        }
    }
}
