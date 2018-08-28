using ECommon.Dapper;
using OPIM_Common.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_Dapper.Dappers
{
    public class BudgetDapper : DbConnectionSetting
    {
        public Results Create(BudgetModel model)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    connection.Insert(new
                    {
                        Id = model.Id,
                        TypeId = model.TypeId,
                        Money = model.Money,
                        Year = model.Year,
                        Month = model.Month,
                        CreateBy=model.CreateBy
                    }, OPIM_Common.TableName.Budget);
                    return new Results();
                }
                catch (Exception ex)
                {

                    return new Results(ex.Message);
                }

            }
        }
        public Results Update(Guid id,decimal money)
        {
            using (var connecthion = GetConnection())
            {
                try
                {
                    connecthion.Open();
                    connecthion.Update(new
                    {
                        Money = money
                    },
                    new { Id = id },
                    OPIM_Common.TableName.Budget);
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
                    connection.Delete(new
                    {
                        Id = id
                    }, OPIM_Common.TableName.Budget);
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
