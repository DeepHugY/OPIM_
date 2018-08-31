using ECommon.Dapper;
using OPIM_Common.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPIM_Dapper.Dappers
{
   public class AnnouncementDapper : DbConnectionSetting
    {
        public Results Create(AnnouncementsView model)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var result = connection.Insert(new
                    {
                        Id = model.Id,
                       Title=model.Title,
                       Contents=model.Contents,
                       CreateBy=model.CreateBy,
                        CreateOn = model.CreateOn,
                       
                    }, OPIM_Common.TableName.Announcement);
                    return new Results();
                }
                catch (Exception ex)
                {
                    return new Results(ex.Message);
                }
            }
        }
        public Results Update(AnnouncementsView model)
        {
            using (var connection = GetConnection())
            {
                try
                {
                    connection.Open();
                    var result = connection.Update(new
                    {
                        Title = model.Title,
                        Contents = model.Contents
                    }, new
                    {
                        Id = model.Id
                    }, OPIM_Common.TableName.Announcement);
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
                    var result = connection.DeleteAsync(new
                    {
                        Id = id
                    }, OPIM_Common.TableName.Announcement);
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
